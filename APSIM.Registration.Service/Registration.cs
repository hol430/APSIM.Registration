
namespace APSIM.Registration.Service
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using APSIM.Shared.Utilities;

    public class Registration : IRegistration
    {
        private const string commercialLicenceName = "Commercial";

        private const string nonCommercialLicenceName = "Non-Commercial";

        /// <summary>
        /// Add a upgrade registration into the database.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="organisation"></param>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="postcode"></param>
        /// <param name="country"></param>
        /// <param name="email"></param>
        /// <param name="product"></param>
        public void Add(string firstName, string lastName, string organisation, string address1, string address2,
                    string city, string state, string postcode, string country, string email, string product)
        {
            string sql = "INSERT INTO Registrations (Date, FirstName, LastName, Organisation, Country, Email, Product, Version, Platform, Type) " +
                            "VALUES (@Date, @FirstName, @LastName, @Organisation, @Country, @Email, @Product, @Version, @Platform, @Type)";

            // Address2 and state are optional so check for them and give default values.
            if (address2 == null || address2 == "")
                address2 = "-";
            if (state == null || state == "")
                state = "-";

            if (!Constants.Countries.Contains(country))
                return;
                //throw new Exception($"Invalid country name '{country}'");

            using (SqlConnection connection = Open())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Date", DateTime.Now));
                    command.Parameters.Add(new SqlParameter("@FirstName", firstName));
                    command.Parameters.Add(new SqlParameter("@LastName", lastName));
                    command.Parameters.Add(new SqlParameter("@Organisation", organisation));
                    command.Parameters.Add(new SqlParameter("@Country", country));
                    command.Parameters.Add(new SqlParameter("@Email", email));
                    command.Parameters.Add(new SqlParameter("@Product", product));
                    command.Parameters.Add(new SqlParameter("@Version", "1"));
                    command.Parameters.Add(new SqlParameter("@Platform", "Windows"));
                    command.Parameters.Add(new SqlParameter("@Type", "Registration"));
                    command.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// Add a upgrade registration into the database.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="organisation"></param>
        /// <param name="country"></param>
        /// <param name="email"></param>
        /// <param name="product"></param>
        public void AddNew(string firstName, string lastName, string organisation, string country, string email, string product)
        {
            string sql = "INSERT INTO Registrations (Date, FirstName, LastName, Organisation, Country, Email, Product, Version, Platform, Type) " +
                            "VALUES (@Date, @FirstName, @LastName, @Organisation, @Country, @Email, @Product, @Version, @Platform, @Type)";

            if (!Constants.Countries.Contains(country))
                throw new Exception($"Invalid country name '{country}'");

            using (SqlConnection connection = Open())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Date", DateTime.Now));
                    command.Parameters.Add(new SqlParameter("@FirstName", firstName));
                    command.Parameters.Add(new SqlParameter("@LastName", lastName));
                    command.Parameters.Add(new SqlParameter("@Organisation", organisation));
                    command.Parameters.Add(new SqlParameter("@Country", country));
                    command.Parameters.Add(new SqlParameter("@Email", email));
                    command.Parameters.Add(new SqlParameter("@Product", product));
                    command.Parameters.Add(new SqlParameter("@Version", "1"));
                    command.Parameters.Add(new SqlParameter("@Platform", "Windows"));
                    command.Parameters.Add(new SqlParameter("@Type", "Registration"));
                    command.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// Add a upgrade or registration into the database.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="organisation"></param>
        /// <param name="country"></param>
        /// <param name="email"></param>
        /// <param name="product"></param>
        /// <param name="version"></param>
        /// <param name="platform"></param>
        /// <param name="type"></param>
        public void AddRegistration(string firstName, string lastName, string organisation, string country, string email, string product, string version, string platform, string type)
        {
            string sql = "INSERT INTO Registrations (Date, FirstName, LastName, Organisation, Country, Email, Product, Version, Platform, Type, LicenceType) " +
                            "VALUES (@Date, @FirstName, @LastName, @Organisation, @Country, @Email, @Product, @Version, @Platform, @Type, @LicenceType)";

            if (!Constants.Countries.Contains(country))
                throw new Exception($"Invalid country name '{country}'");

            using (SqlConnection connection = Open())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Date", DateTime.Now));
                    command.Parameters.Add(new SqlParameter("@FirstName", firstName));
                    command.Parameters.Add(new SqlParameter("@LastName", lastName));
                    command.Parameters.Add(new SqlParameter("@Organisation", organisation));
                    command.Parameters.Add(new SqlParameter("@Country", country));
                    command.Parameters.Add(new SqlParameter("@Email", email));
                    command.Parameters.Add(new SqlParameter("@Product", product));
                    command.Parameters.Add(new SqlParameter("@Version", version));
                    command.Parameters.Add(new SqlParameter("@Platform", platform));
                    command.Parameters.Add(new SqlParameter("@Type", type));

                    string licenceType = nonCommercialLicenceName;
                    try
                    {
                        licenceType = IsCommercialUser(email) ? commercialLicenceName : nonCommercialLicenceName;
                    }
                    catch
                    {
                    }
                    command.Parameters.Add(new SqlParameter("@LicenceType", licenceType));

                    command.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// Adds a registration for a commercial user.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="organisation"></param>
        /// <param name="country"></param>
        /// <param name="email"></param>
        /// <param name="product"></param>
        /// <param name="version"></param>
        /// <param name="platform"></param>
        /// <param name="type"></param>
        /// <param name="licensorName"></param>
        /// <param name="licensorEmail"></param>
        /// <param name="companyTurnover"></param>
        /// <param name="companyRego"></param>
        /// <param name="companyAddress"></param>
        public void AddCommercialRegistration(string firstName, string lastName, string organisation, string country, string email, string product, string version, string platform, string type, string licensorName, string licensorEmail, string companyTurnover, string companyRego, string companyAddress)
        {
            string sql = "INSERT INTO Registrations (Date, FirstName, LastName, Organisation, Country, Email, Product, Version, Platform, Type, LicenceType, LicensorName, LicensorEmail, CompanyTurnover, CompanyRego, CompanyAddress) " +
                            "VALUES (@Date, @FirstName, @LastName, @Organisation, @Country, @Email, @Product, @Version, @Platform, @Type, @LicenceType, @LicensorName, @LicensorEmail, @CompanyTurnover, @CompanyRego, @CompanyAddress)";

            if (!Constants.Countries.Contains(country))
                throw new Exception($"Invalid country name '{country}'");

            using (SqlConnection connection = Open())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Date", DateTime.Now));
                    command.Parameters.Add(new SqlParameter("@FirstName", firstName));
                    command.Parameters.Add(new SqlParameter("@LastName", lastName));
                    command.Parameters.Add(new SqlParameter("@Organisation", organisation));
                    command.Parameters.Add(new SqlParameter("@Country", country));
                    command.Parameters.Add(new SqlParameter("@Email", email));
                    command.Parameters.Add(new SqlParameter("@Product", product));
                    command.Parameters.Add(new SqlParameter("@Version", version));
                    command.Parameters.Add(new SqlParameter("@Platform", platform));
                    command.Parameters.Add(new SqlParameter("@Type", type));
                    command.Parameters.Add(new SqlParameter("@LicenceType", commercialLicenceName));
                    command.Parameters.Add(new SqlParameter("@LicensorName", licensorName));
                    command.Parameters.Add(new SqlParameter("@LicensorEmail", licensorEmail));
                    command.Parameters.Add(new SqlParameter("@CompanyTurnover", companyTurnover));
                    command.Parameters.Add(new SqlParameter("@CompanyRego", companyRego));
                    command.Parameters.Add(new SqlParameter("@CompanyAddress", companyAddress));

                    command.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// Check if a user with a given email address has previously
        /// accepted the licence terms and conditions.
        /// </summary>
        /// <param name="email">Email address.</param>
        public bool IsRegistered(string email)
        {
            string sql = @"SELECT TOP 1 [Date]
FROM [Registrations]
WHERE [Email] = @Email
ORDER BY [Date] DESC;";
            using (SqlConnection connection = Open())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Email", email));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime date = (DateTime)reader["Date"];
                            return date > DateTime.Now.AddYears(-3);
                        }
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Subscribe to the mailing list.
        /// </summary>
        /// <param name="email">Email address.</param>
        public void Subscribe(string email)
        {
            if (!string.IsNullOrWhiteSpace(email))
            {
                string sql = @"IF NOT EXISTS (SELECT *
FROM Subscribers
WHERE Email = @email)
BEGIN
	INSERT INTO Subscribers (Email, [Date])
	VALUES (@email, @date)
END";
                using (SqlConnection connection = Open())
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@email", email));
                        command.Parameters.Add(new SqlParameter("@date", DateTime.Now));
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Unsubscribe to the mailing list.
        /// </summary>
        /// <param name="email">Email address.</param>
        public void Unsubscribe(string email)
        {
            if (!string.IsNullOrWhiteSpace(email))
            {
                string sql = @"DELETE FROM Subscribers WHERE Email = @email";
                using (SqlConnection connection = Open())
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@email", email));
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Checks if an email is registered to a commercial licence.
        /// </summary>
        /// <param name="email">Email address.</param>
        private bool IsCommercialUser(string email)
        {
            using (SqlConnection connection = Open())
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Registrations WHERE Email = @Email AND LicenceType = @LicenceType"))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@LicenceType", commercialLicenceName);

                    int numRows = Convert.ToInt32(command.ExecuteScalar());
                    return numRows > 0;
                }
            }
        }

        /// <summary>Return the valid password for this web service.</summary>
        private static string GetValidPassword()
        {
            string connectionString = File.ReadAllText(@"D:\Websites\ChangeDBPassword.txt");
            int posPassword = connectionString.IndexOf("Password=");
            return connectionString.Substring(posPassword + "Password=".Length);
        }

        /// <summary>Open the SoilsDB ready for use.</summary>
        private static SqlConnection Open()
        {
            string connectionString = File.ReadAllText(@"D:\Websites\dbConnect.txt") + ";Database=\"APSIM.Registration\""; ;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
