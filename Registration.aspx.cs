using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ProductRegistration
{

    public partial class Registration : System.Web.UI.Page
    {
        /// <summary>
        /// Page has loaded - setup all controls.
        /// </summary>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Product.Items.Count == 0)
            {
                Product.Items.Add("APSIM");
                Product.Items.Add("Apsoil");
                Product.Items.Add("HowWet?");
                Product.Items.Add("HowOften?");
                Product.Items.Add("HowMuch?");
                Product.Items.Add("HowLeaky?");
                Product.Items.Add("Perfect");

                if (Request.QueryString["Product"] != null)
                {
                    Product.Text = Product.Text = Request.QueryString["Product"];
                }

                List<string> Versions = new List<string>();
                Version.Items.Clear();
                string DownloadDirectory = Path.Combine(Request.PhysicalApplicationPath, "Downloads");
                foreach (string SubDirectory in Directory.GetDirectories(DownloadDirectory))
                {
                    foreach (string FileName in Directory.GetFiles(SubDirectory, "Apsim*.exe"))
                    {
                        string VersionNumber = Path.GetFileNameWithoutExtension(FileName).Replace("Apsim", "");
                        VersionNumber = VersionNumber.Replace("Setup", "");
                        Versions.Add(VersionNumber);
                    }
                }
                Versions.Sort();
                Versions.Reverse();
                foreach (string VersionString in Versions)
                    Version.Items.Add(VersionString);
                
                Product.SelectedIndexChanged += new EventHandler(UpdateForm);
            }
            UpdateForm(null, null);
        }


        /// <summary>
        /// Update the controls that change depending on the state of the product dropdown.
        /// </summary>
        void UpdateForm(object sender, EventArgs e)
        {
            string FileName;
            if (Product.Text == "APSIM")
            {
                VersionLabel.Text = "Version:*";
                Version.Visible = true;
                FileName = "APSIMDisclaimer.html";
            }
            else
            {
                VersionLabel.Text = "";
                Version.Visible = false;
                FileName = "OtherDisclaimer.html";
            }
            Terms.Text = "<iframe height=\"300px\" width=\"700px\" src=\"" + FileName + "\"/>";
            
            //StreamReader In = new StreamReader(FileName);
            //Terms.Text = "<div style=\"height: 300px; width: 700px; overflow: auto; position:relative; border: solid; border-width:thin; border-color: #CCCCCC\">" + In.ReadToEnd() + "</div>";
            //Terms.Text = In.ReadToEnd();
            //Terms.Text = "<div><iframe src=\"APSIMDisclaimer.html\"/></div>";
            //In.Close();
        }

        /// <summary>
        /// User has clicked yes. 
        /// </summary>
        protected void YesButton_Click(object sender, EventArgs e)
        {
            if (ControlsAreValid())
            {
                UpdateDB();
                string RedirectURL;
                if (GetProductName().ToLower().Contains("apsim"))
                {
                    SendEmail();
                    RedirectURL = "Thankyou.aspx";
                }
                else
                {
                    RedirectURL = "Thankyou.aspx?URL=" + GetDownloadURL();
                }
                Response.Redirect(RedirectURL);
            }

        }
        protected void NoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        /// <summary>
        /// Update the registrations database.
        /// </summary>
        private void UpdateDB()
        {
            RegistrationsDB DB = new RegistrationsDB();
            DB.Open();

            DB.Add(FirstName.Text, LastName.Text, Organisation.Text, Address1.Text, Address2.Text,
                   City.Text, State.Text, Postcode.Text, Country.Text, Email.Text, GetProductName());

            DB.Close();
        }


        /// <summary>
        /// Send an email to the user.
        /// </summary>
        private void SendEmail()
        {
            System.Net.Mail.MailMessage Mail = new System.Net.Mail.MailMessage();
            Mail.From = new System.Net.Mail.MailAddress("no-reply@csiro.au");
            Mail.To.Add(Email.Text);
            Mail.Subject = "APSIM Software Non-Commercial Licence";
            Mail.IsBodyHtml = true;

            string MailBodyFile = Path.Combine(Request.PhysicalApplicationPath, "EmailBody.html");

            StreamReader In = new StreamReader(MailBodyFile);
            string Body = In.ReadToEnd();
            Body = Body.Replace("$DownloadURL$", GetDownloadURL());
            Body = Body.Replace("$PASSWORD$", GetProductPassword());
            Mail.Body = Body;
            In.Close();

            string AttachmentFileName = Path.Combine(Request.PhysicalApplicationPath, "APSIM_Licence_V3.0.pdf");
            Mail.Attachments.Add(new System.Net.Mail.Attachment(AttachmentFileName));

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp-relay.csiro.au");
            smtp.Send(Mail);
        }

        /// <summary>
        /// Return the user selected product name.
        /// </summary>
        /// <returns></returns>
        private string GetProductName()
        {
            string ProductName = Product.Text;
            if (Version.Visible)
                ProductName += Version.Text;
            return ProductName;
        }


        /// <summary>
        /// Return the password for the specified product.
        /// </summary>
        private string GetProductPassword()
        {
            string Password = "No password is required for this release of APSIM.";
            if (Version.Visible)
            {
                string VersionNumberString = Version.Text;
                int VersionNumber = Convert.ToInt32(Convert.ToDouble(VersionNumberString) * 10);
                if (VersionNumber == 73)
                    Password = "The password for this release of APSIM is: <b>hety-9895-yrw-6040</b>";
                else if (VersionNumber == 72)
                    Password = "The password for this release of APSIM is: <b>fedt-1141-hsd-2051</b>";
                else if (VersionNumber < 72)
                    Password = "The Password for this release of APSIM is <b>" + VersionNumberString.Replace(".", "") + "0004860</b>";
            }
            return Password;
        }

        /// <summary>
        /// Return the download URL for the specified product.
        /// </summary>
        private string GetDownloadURL()
        {
            string DownloadDirectory = Path.Combine(Request.PhysicalApplicationPath, "Downloads");
            string OurURL = Request.Url.AbsoluteUri.Replace("Registration.aspx", "");
            string ProductName = GetProductName();
            ProductName = ProductName.Replace("?", "");
            foreach (string SubDirectory in Directory.GetDirectories(DownloadDirectory))
            {
                foreach (string FileName in Directory.GetFiles(SubDirectory, "*.exe"))
                {
                    if (FileName.ToLower().Contains(ProductName.ToLower()))
                    {
                        string URL = FileName.Replace(DownloadDirectory, OurURL + "Downloads");
                        return URL.Replace("\\", "/");
                    }
                }
            }
            throw new Exception("Cannot find product name : " + ProductName);

        }

        /// <summary>
        /// Return true if controls are valid.
        /// </summary>
        private bool ControlsAreValid()
        {
            List<string> MissingFields = new List<string>();
            if (FirstName.Text == "")
                MissingFields.Add("First name");
            if (LastName.Text == "")
                MissingFields.Add("Last name");
            if (Organisation.Text == "")
                MissingFields.Add("Organisation");
            if (Address1.Text == "")
                MissingFields.Add("Address1");
            if (City.Text == "")
                MissingFields.Add("City");
            if (Postcode.Text == "")
                MissingFields.Add("Postcode");
            if (Country.Text == "")
                MissingFields.Add("Country");
            if (Email.Text == "")
                MissingFields.Add("Email");

            if (MissingFields.Count > 0)
            {
                string Message = "";
                for (int i = 0; i < MissingFields.Count; i++)
                {
                    if (i > 0)
                        Message += ", ";

                    Message += MissingFields[i];
                }
                ErrorLabel.Text = "Error. You haven't entered anything for these fields: " + Message;
                ErrorLabel.Visible = ErrorLabel.Text != "";
                return false;
            }
            ErrorLabel.Visible = false;
            return true;
        }


    }
}