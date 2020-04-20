using APSIM.Shared.Utilities;
using APSIM.Shared.Web;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace APSIM.Registration.Portal
{
    public partial class Downloads : System.Web.UI.Page
    {
        private List<Product> Products
        {
            get
            {
                return new List<Product>()
                {
                    new Product("APSIM Classic", GetApsimClassicUpgrades),
                    new Product("APSIM Next Generation", GetApsimXUpgrades),
                    new Product("Apsoil", GetApsoilVersions),
                    new Product("HowWet?", GetHowWetVersions),
                    new Product("HowOften?", GetHowOftenVersions),
                    new Product("HowMuch?", GetHowMuchVersions),
                    new Product("HowLeaky?", GetHowLeakyVersions),
                    new Product("Perfect", GetPerfectVersions),
                };
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Populate products drop-down.
                foreach (Product product in Products)
                    productsDropDown.Items.Add(product.Name);

                // Allow for product specified via query string.
                string selection = Request.QueryString["product"];
                if (!string.IsNullOrEmpty(selection) && Products.Any(p => p.Name == selection))
                    productsDropDown.SelectedValue = selection;

                tblDownloads.Visible = false;

                // Manually fire off a product changed event to fill the versions table.
                SelectedProductChanged(this, EventArgs.Empty);
            }
        }

        protected void SelectedProductChanged(object sender, EventArgs e)
        {
            Product product = Products.Find(p => p.Name == productsDropDown.SelectedValue);
            if (product != null)
                PopulateTable(product.GetVersions());
        }

        /// <summary>
        /// Populate the versions table with a list of available product versions.
        /// </summary>
        /// <param name="versions">List of available versions of the product.</param>
        private void PopulateTable(List<ProductVersion> versions)
        {
            // Remove all rows except header row.
            while (tblDownloads.Rows.Count > 1)
                tblDownloads.Rows.RemoveAt(1);

            // Product name, version name, version number, download link.
            foreach (ProductVersion version in versions)
            {
                TableRow row = new TableRow();

                TableCell versionName = new TableCell();
                HyperLink versionLink = new HyperLink();
                versionLink.Text = version.Description;
                versionLink.NavigateUrl = version.InfoLink;
                versionName.Controls.Add(versionLink);
                row.Cells.Add(versionName);

                TableCell versionNumber = new TableCell();
                versionNumber.Text = version.Number;
                row.Cells.Add(versionNumber);

                TableCell releaseDate = new TableCell();
                releaseDate.Text = version.ReleaseDate.ToString("yyyy-MM-dd");
                row.Cells.Add(releaseDate);

                HyperLink windowsLink = new HyperLink();
                windowsLink.Text = "Windows x86_64";
                windowsLink.NavigateUrl = version.DownloadLinkWindows;
                TableCell downloadCell = new TableCell();
                downloadCell.Controls.Add(windowsLink);

                if (!string.IsNullOrEmpty(version.DownloadLinkLinux))
                {
                    downloadCell.Controls.Add(new Label() { Text = ", " });
                    HyperLink linuxLink = new HyperLink();
                    linuxLink.Text = "Linux x86_64";
                    linuxLink.NavigateUrl = version.DownloadLinkLinux;
                    downloadCell.Controls.Add(linuxLink);
                }

                if (!string.IsNullOrEmpty(version.DownloadLinkMac))
                {
                    downloadCell.Controls.Add(new Label() { Text = ", " });
                    HyperLink macLink = new HyperLink();
                    macLink.Text = "macOS x86_64";
                    macLink.NavigateUrl = version.DownloadLinkMac;
                    downloadCell.Controls.Add(macLink);
                }

                row.Cells.Add(downloadCell);

                tblDownloads.Rows.Add(row);
            }

            tblDownloads.Visible = true;
        }

        // fixme - need to add link to release notes and find a better way
        // of grabbing release date/version info for perfect/howwet/etc.
        private List<ProductVersion> GetPerfectVersions()
        {
            return new List<ProductVersion>() { new ProductVersion("PERFECT", "", "", DateTime.Now, GetDownloadPath("PERFECT"), null, null) };
        }

        private List<ProductVersion> GetHowLeakyVersions()
        {
            return new List<ProductVersion>() { new ProductVersion("HowLeaky", "2.18", "", new DateTime(2007, 10, 12), GetDownloadPath("HowLeaky"), null, null) };
        }

        private List<ProductVersion> GetHowMuchVersions()
        {
            return new List<ProductVersion> { new ProductVersion("HowMuch", "", "", DateTime.Now, GetDownloadPath("HowMuch"), null, null)};
        }

        private List<ProductVersion> GetHowOftenVersions()
        {
            return new List<ProductVersion>() { new ProductVersion("HowOften", "2.0.0.0", "", new DateTime(2004, 3, 1), GetDownloadPath("HowOften"), null, null) };
        }

        private List<ProductVersion> GetHowWetVersions()
        {
            return new List<ProductVersion>() { new ProductVersion("HowWet", "2.10", "", new DateTime(1997, 2, 24), GetDownloadPath("HowWet"), null, null) };
        }

        private List<ProductVersion> GetApsoilVersions()
        {
            return new List<ProductVersion>() { new ProductVersion("APSoil", "7.1", "", new DateTime(2013, 5, 31), GetDownloadPath("APSoil"), null, null) };
        }

        private List<ProductVersion> GetApsimClassicUpgrades()
        {
            List<BuildJob> upgrades = WebUtilities.CallRESTService<List<BuildJob>>("http://apsimdev.apsim.info/APSIM.Builds.Service/BuildsClassic.svc/GetJobs?NumRows=1000&PassOnly=true");
            // fixme - start time is not the same as merge time!
            return upgrades.Select(u => new ProductVersion(u.Description, u.VersionString, u.IssueURL, u.StartTime, u.WindowsInstallerURL, u.LinuxBinariesURL, null)).ToList();
        }

        private List<ProductVersion> GetApsimXUpgrades()
        {
            List<Upgrade> upgrades = WebUtilities.CallRESTService<List<Upgrade>>("https://apsimdev.apsim.info/APSIM.Builds.Service/Builds.svc/GetUpgradesSinceIssue");
            return upgrades.Select(u => new ProductVersion(u)).ToList();
        }

        private string GetDownloadPath(string productName)
        {
#if DEBUG
            if (productName == "APSoil")
                return "https://apsimdev.apsim.info/ApsoilWeb/ApsoilSetup.exe";
#endif
            string downloadDirectory = Path.Combine(Request.PhysicalApplicationPath, "Downloads");
            string ourURL = Request.Url.AbsoluteUri.Replace("Downloads.aspx", "");
            if (ourURL.Contains('?'))
                ourURL = ourURL.Remove(ourURL.IndexOf('?'));

            foreach (string SubDirectory in Directory.GetDirectories(downloadDirectory))
            {
                foreach (string FileName in Directory.GetFiles(SubDirectory, "*.exe"))
                {
                    if (FileName.ToLower().Contains(productName.ToLower()))
                    {
                        string URL = FileName.Replace(downloadDirectory, ourURL + "Downloads");
                        return URL.Replace("\\", "/");
                    }
                }
            }

            throw new Exception("Cannot find product name : " + productName);
        }
    }
}