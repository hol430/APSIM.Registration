using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ProductRegistration
{
    public partial class ViewRegistrations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AppendHeader("Content-Disposition", "attachment; filename=Registrations.csv");
            Response.Buffer = false;

            Response.ContentType = "text/plain";

            System.Data.DataView dv = (DataView) SqlDataSource1.Select(new DataSourceSelectArguments());
            DataTable Data = dv.ToTable();
            string St = "";
            for (int i = 1; i < Data.Columns.Count; i++)
            {
                if (i > 1)
                    St += ", ";
                St += Data.Columns[i].ColumnName;
            }
            Response.Write(St + "\r\n");

            foreach (DataRow Row in Data.Rows)
            {
                St = "";
                for (int i = 1; i < Data.Columns.Count; i++)
                {
                    if (i == 1)
                    {
                        DateTime D = Convert.ToDateTime(Row[i]);
                        St = D.ToShortDateString();
                    }
                    else
                    {
                        St += ", " + Row[i].ToString();
                    }
                }
                
                Response.Write(St + "\r\n");
            }
            Response.Flush();                 // send our content to the client browser.
            Response.SuppressContent = true;  // stops .net from writing it's stuff.

        }
    }
}