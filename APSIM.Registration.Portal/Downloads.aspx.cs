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

                Refresh();
            }
        }

        protected void SelectedProductChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        /// <summary>
        /// Refresh the data in the products table.
        /// </summary>
        private void Refresh()
        {
            int n = -1;
            int.TryParse(NumRowsTextBox.Text, out n);

            Product product = Products.Find(p => p.Name == productsDropDown.SelectedValue);
            if (product != null)
                PopulateTable(product.GetVersions(n));
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

                TableCell releaseDate = new TableCell();
                releaseDate.Text = version.ReleaseDate.ToString("yyyy-MM-dd");
                row.Cells.Add(releaseDate);

                TableCell versionNumber = new TableCell();
                versionNumber.Text = version.Number;
                row.Cells.Add(versionNumber);

                TableCell versionName = new TableCell();

                if (string.IsNullOrWhiteSpace(version.InfoLink))
                    versionName.Controls.Add(new Label() { Text = version.Description });
                else
                {
                    HyperLink versionLink = new HyperLink();
                    versionLink.Text = version.Description;
                    versionLink.NavigateUrl = version.InfoLink;
                    versionName.Controls.Add(versionLink);
                }
                row.Cells.Add(versionName);

                HyperLink windowsLink = new HyperLink();
                windowsLink.Text = "Windows";
                windowsLink.NavigateUrl = version.DownloadLinkWindows;
                TableCell downloadCell = new TableCell();
                downloadCell.Controls.Add(windowsLink);

                if (!string.IsNullOrEmpty(version.DownloadLinkLinux))
                {
                    downloadCell.Controls.Add(new Label() { Text = ", " });
                    HyperLink linuxLink = new HyperLink();
                    linuxLink.Text = "Linux";
                    linuxLink.NavigateUrl = version.DownloadLinkLinux;
                    downloadCell.Controls.Add(linuxLink);
                }

                if (!string.IsNullOrEmpty(version.DownloadLinkMac))
                {
                    downloadCell.Controls.Add(new Label() { Text = ", " });
                    HyperLink macLink = new HyperLink();
                    macLink.Text = "macOS";
                    macLink.NavigateUrl = version.DownloadLinkMac;
                    downloadCell.Controls.Add(macLink);
                }

                row.Cells.Add(downloadCell);

                tblDownloads.Rows.Add(row);
            }

            tblDownloads.Visible = true;
        }

        private List<ProductVersion> GetApsoilVersions(int n)
        {
            return new List<ProductVersion>() { new ProductVersion("APSoil", "7.1", "", new DateTime(2013, 5, 31), GetDownloadPath("APSoil"), null, null) };
        }

        private List<ProductVersion> GetApsimClassicUpgrades(int n)
        {
            if (n <= 0)
                n = 1000; // fixme

            List<BuildJob> upgrades = WebUtilities.CallRESTService<List<BuildJob>>($"http://apsimdev.apsim.info/APSIM.Builds.Service/BuildsClassic.svc/GetReleases?numRows={n}");

            // fixme - we need to upload all of the legacy installers to apsim.info but need
            // more disk space to do so. In the meantime I've uploaded the versions where
            // we incremented the version number.
            //int[] versionsToKeep = new[] { 402, 700, 1017, 1388, 2287, 3009, 3377, 3616, 3868, 4047, 4159 };
            upgrades = upgrades.Where(u => u.BuiltOnJenkins).ToList();

            // fixme - start time is not the same as merge time!
            List<ProductVersion> result = upgrades.Select(u => new ProductVersion(u.Description, u.VersionString, u.IssueURL, u.StartTime, u.WindowsInstallerURL, u.LinuxBinariesURL, null)).ToList();
            result.AddRange(GetStaticApsimClassicVersions());
            if (result.Count > n)
                result = result.Take(n).ToList();

            return result;
        }

        private static IEnumerable<ProductVersion> GetStaticApsimClassicVersions()
        {
            string filesUrl = "https://apsimdev.apsim.info/APSIMClassicFiles/";
            yield return new ProductVersion("APSIM 7.10", "Apsim7.10-r4159", "", new DateTime(2018, 4, 1), filesUrl + "Apsim7.10-r4159.ApsimSetup.exe", null, null);
            yield return new ProductVersion("APSIM 7.9", "Apsim7.9-r4047", "", new DateTime(2017, 6, 14), filesUrl + "Apsim7.9-r4047.ApsimSetup.exe", null, null);
            yield return new ProductVersion("APSIM 7.8", "Apsim7.8-r3868", "", new DateTime(2016, 3, 29), filesUrl + "Apsim7.8-r3868.ApsimSetup.exe", null, null);
            yield return new ProductVersion("APSIM 7.7", "Apsim7.7-r3616", "", new DateTime(2014, 12, 16), filesUrl + "Apsim7.7-r3616.ApsimSetup.exe", null, null);
            yield return new ProductVersion("APSIM 7.6", "Apsim7.6-r3377", "", new DateTime(2014, 3, 24), filesUrl + "Apsim7.6-r3377.ApsimSetup.exe", null, null);
            yield return new ProductVersion("APSIM 7.5", "Apsim7.5-r3009", "", new DateTime(2013, 4, 15), filesUrl + "Apsim7.5-r3009.ApsimSetup.exe", null, null);
            yield return new ProductVersion("APSIM 7.4", "Apsim7.4-r2287", "", new DateTime(2012, 2, 13), filesUrl + "Apsim7.4-r2287.ApsimSetup.exe", null, null);
            yield return new ProductVersion("APSIM 7.3", "Apsim7.3-r1388", "", new DateTime(2011, 2, 27), filesUrl + "Apsim7.3-r1388.ApsimSetup.exe", null, null);
            yield return new ProductVersion("APSIM 7.2", "Apsim7.2-r1017", "", new DateTime(2010, 8, 23), filesUrl + "Apsim7.2-r1017.ApsimSetup.exe", null, null);
            yield return new ProductVersion("APSIM 7.1", "Apsim7.1-r700", "", new DateTime(2009, 11, 14), filesUrl + "Apsim7.1-r700.ApsimSetup.exe", null, null);
            yield return new ProductVersion("APSIM 7.0", "Apsim7.0-r402", "", new DateTime(2009, 4, 26), filesUrl + "Apsim7.0-r402.ApsimSetup.exe", null, null);
            yield return new ProductVersion("APSIM 6.1", "Apsim6.1", "", new DateTime(2008, 5, 15), filesUrl + "Apsim6.1Setup.exe", null, null);
            yield return new ProductVersion("APSIM 6.0", "Apsim6.0", "", new DateTime(2008, 3, 27), filesUrl + "Apsim6.0Setup.exe", null, null);
        }

        private List<ProductVersion> GetApsimXUpgrades(int n)
        {
            List<Upgrade> upgrades = WebUtilities.CallRESTService<List<Upgrade>>($"https://apsimdev.apsim.info/APSIM.Builds.Service/Builds.svc/GetLastNUpgrades?n={n}");
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

        protected void OnNumRowsChanged(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}