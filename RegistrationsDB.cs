using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

public class RegistrationsDB
{
    private SqlConnection Connection;

    /// <summary>
    /// Open the SoilsDB ready for use.
    /// </summary>
    public void Open()
    {
        string ConnectionString = System.IO.File.ReadAllText(@"D:\Websites\dbConnect.txt") + ";Database=ProductRegistrations";
        Connection = new SqlConnection(ConnectionString);
        Connection.Open();
    }

    /// <summary>   
    /// Close the SoilsDB connection
    /// </summary>
    public void Close()
    {
        if (Connection != null)
        {
            Connection.Close();
            Connection = null;
        }
    }

    /// <summary>
    /// Add a new entry to the registrations database.
    /// </summary>
    public void Add(string FirstName, string LastName, string Organisation, string Address1, string Address2,
                    string City, string State, string Postcode, string Country, string Email, string Product)
    {
        Add(DateTime.Now, FirstName, LastName, Organisation, Address1, Address2, City, State, Postcode, Country, Email, Product);
    }
    /// <summary>
    /// Add a new entry to the registrations database.
    /// </summary>
    public void Add(DateTime Date, string FirstName, string LastName, string Organisation, string Address1, string Address2, 
                    string City, string State, string Postcode, string Country, string Email, string Product)
    {
        string SQL = "INSERT INTO Registrations (Date, FirstName, LastName, Organisation, Address1, Address2, City, State, Postcode, Country, Email, Product) " +
                        "VALUES (@Date, @FirstName, @LastName, @Organisation, @Address1, @Address2, @City, @State, @Postcode, @Country, @Email, @Product)";

        SqlCommand Cmd = new SqlCommand(SQL, Connection);
        Cmd.Parameters.Add(new SqlParameter("@Date", Date));
        Cmd.Parameters.Add(new SqlParameter("@FirstName", FirstName));
        Cmd.Parameters.Add(new SqlParameter("@LastName", LastName));
        Cmd.Parameters.Add(new SqlParameter("@Organisation", Organisation));
        Cmd.Parameters.Add(new SqlParameter("@Address1", Address1));
        Cmd.Parameters.Add(new SqlParameter("@Address2", Address2));
        Cmd.Parameters.Add(new SqlParameter("@City", City));
        Cmd.Parameters.Add(new SqlParameter("@State", State));
        Cmd.Parameters.Add(new SqlParameter("@Postcode", Postcode));
        Cmd.Parameters.Add(new SqlParameter("@Country", Country));
        Cmd.Parameters.Add(new SqlParameter("@Email", Email));
        Cmd.Parameters.Add(new SqlParameter("@Product", Product));
        Cmd.ExecuteNonQuery();
    }

    private bool AlreadyExists(string Email, string Product)
    {
        string SQL = "SELECT ID FROM Registrations WHERE Email = @Email AND Product = @Product";

        SqlCommand Command = new SqlCommand(SQL, Connection);
        Command.Parameters.Add(new SqlParameter("@Email", Email));
        Command.Parameters.Add(new SqlParameter("@Product", Product));

        SqlDataReader Reader = Command.ExecuteReader();
        bool Found = Reader.Read();
        Reader.Close();
        return Found;
    }


    /// <summary>
    /// Clear all rows in DB
    /// </summary>
    public void Clear()
    {
        string SQL = "DELETE FROM Registrations";
        SqlCommand Command = new SqlCommand(SQL, Connection);
        Command.ExecuteNonQuery();
    }

}
