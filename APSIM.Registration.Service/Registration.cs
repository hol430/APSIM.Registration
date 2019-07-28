
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

    public class Registration : IRegistration
    {
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
            string sql = "INSERT INTO Registrations (Date, FirstName, LastName, Organisation, Address1, Address2, City, State, Postcode, Country, Email, Product) " +
                            "VALUES (@Date, @FirstName, @LastName, @Organisation, @Address1, @Address2, @City, @State, @Postcode, @Country, @Email, @Product)";

            // Address2 and state are optional so check for them and give default values.
            if (address2 == null || address2 == "")
                address2 = "-";
            if (state == null || state == "")
                state = "-";

            using (SqlConnection connection = Open())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Date", DateTime.Now));
                    command.Parameters.Add(new SqlParameter("@FirstName", firstName));
                    command.Parameters.Add(new SqlParameter("@LastName", lastName));
                    command.Parameters.Add(new SqlParameter("@Organisation", organisation));
                    command.Parameters.Add(new SqlParameter("@Address1", address1));
                    command.Parameters.Add(new SqlParameter("@Address2", address2));
                    command.Parameters.Add(new SqlParameter("@City", city));
                    command.Parameters.Add(new SqlParameter("@State", state));
                    command.Parameters.Add(new SqlParameter("@Postcode", postcode));
                    command.Parameters.Add(new SqlParameter("@Country", country));
                    command.Parameters.Add(new SqlParameter("@Email", email));
                    command.Parameters.Add(new SqlParameter("@Product", product));
                    command.ExecuteNonQuery();

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
