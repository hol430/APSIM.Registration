using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

namespace ImportOldRegistrations
{
    class Program
    {
        static void Main(string[] args)
        {
            RegistrationsDB DB = new RegistrationsDB();
            DB.Open();

            DataTable Data = ExcelUtility.ExcelHelper.GetDataFromSheet("C:\\Users\\hol353\\Work\\ProductRegistrationWeb\\OldRegistrations.xlsx", "Sheet1");
            foreach (DataRow Row in Data.Rows)
            {
                DateTime Date = DateTime.FromOADate(Convert.ToDouble(Row[1]));
                string FullName = Row[2].ToString().Replace(',', ' ');
                string FirstName,LastName;
                if (FullName.Contains(' '))
                {
                    int PosSpace = FullName.IndexOf(' ');
                    FirstName = FullName.Substring(0, PosSpace);
                    LastName = FullName.Substring(PosSpace+1);
                }
                else
                {
                    FirstName = "?";
                    LastName = FullName;
                }
                string Organisation = Row[3].ToString().Replace(',', ' ');
                string Address1 = Row[4].ToString().Replace(',', ' ').Replace("\r", "").Replace("\n", "");
                string Address2 = Row[5].ToString().Replace(',', ' ').Replace("\r", "").Replace("\n", "");
                string Email = Row[7].ToString().Replace(',', ' ');
                string Product = Row[8].ToString().Replace(',', ' ');

                if (!FullName.Contains("http://") && !Organisation.Contains("http://") && 
                    !Address1.Contains("http://") && !Address2.Contains("http://") &&
                    !Email.Contains("http://"))
                    DB.Add(Date, FirstName, LastName, Organisation, Address1, Address2, "?", "?", "?", "?", Email, Product);
            }

            DB.Close();
        }
    }
}
