using System.Data.SQLite;
using System.Runtime.InteropServices;
public class OrgDatabase
{
    private SQLiteConnection conn;

    public OrgDatabase() {
        conn = new SQLiteConnection("Data Source=addressmanager.db;Version=3;");
        conn.Open();

        //Organization table
        string createOrgTable = @"CREATE TABLE IF NOT EXISTS Organizations (
                                    OrganizationId INTEGER PRIMARY KEY AUTOINCREMENT,
                                    name TEXT,
                                    street TEXT,
                                    zip TEXT,
                                    city TEXT,
                                    country text                 
                                )";

        ExecuteCommand(createOrgTable);
       
    }

    private void ExecuteCommand(string commandText) {
        using(var cmd = new SQLiteCommand(commandText, conn)) {
            cmd.ExecuteNonQuery();
        }
    }

    
    //insert, update, delete, and retrieve data
    public void insertOrg(string name, string street, string zip, string city, string country) {
    try {
        string sql = @"
            INSERT INTO Organizations (name, street, zip, city, country)
            VALUES (@Name, @Street, @Zip, @City, @Country)";

        using (var cmd = new SQLiteCommand(sql, conn)) {
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Street", street);
            cmd.Parameters.AddWithValue("@Zip", zip);
            cmd.Parameters.AddWithValue("@City", city);
            cmd.Parameters.AddWithValue("@Country", country);

            cmd.ExecuteNonQuery();
        }
    }
    catch (Exception ex) {
        Console.WriteLine("An error occurred while inserting into Organizations: " + ex.Message);
        // Optionally, handle the error by logging to a file, notifying a user interface, or rethrowing.
        throw;
    }
}

public void updateOrg(int organizationId, string name, string street, string zip, string city, string country) {
    try {
        string sql = @"
            UPDATE Organizations SET name = @Name, street = @Street, zip = @Zip,
            city = @City, country = @Country WHERE OrganizationId = @OrganizationId";

        using (var cmd = new SQLiteCommand(sql, conn)) {
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Street", street);
            cmd.Parameters.AddWithValue("@Zip", zip);
            cmd.Parameters.AddWithValue("@City", city);
            cmd.Parameters.AddWithValue("@Country", country);
            cmd.Parameters.AddWithValue("@OrganizationId", organizationId);

            cmd.ExecuteNonQuery();
        }
    }
    catch (Exception ex) {
        Console.WriteLine("An error occurred while updating Organization: " + ex.Message);
        // Optionally, handle the error by logging to a file, notifying a user interface, or rethrowing.
        throw;
    }
}


public void deleteOrg(int organizationId) {
    try {
        string sql = @"
            DELETE FROM Organizations WHERE OrganizationId = @OrganizationId";

        using (var cmd = new SQLiteCommand(sql, conn)) {
            cmd.Parameters.AddWithValue("@OrganizationId", organizationId);
            cmd.ExecuteNonQuery();
        }
    }
    catch (Exception ex) {
        Console.WriteLine("An error occurred while deleting from Organizations: " + ex.Message);
        // Optionally, handle the error by logging to a file, notifying a user interface, or rethrowing.
        throw;
    }
}

public List<Organization> GetAllOrganizations()
{
    List<Organization> organizations = new List<Organization>();
    
    try {
        string sql = "SELECT OrganizationId, name, street, zip, city, country FROM Organizations";
        using (var cmd = new SQLiteCommand(sql, conn)) {

            using (var reader = cmd.ExecuteReader()) {
            
                while (reader.Read()) {
                    Organization org = new Organization() {
                        OrganizationId = Convert.ToInt32(reader["OrganizationId"]),
                        name = reader["name"].ToString(),
                        street = reader["street"].ToString(),
                        zip = reader["zip"].ToString(),
                        city = reader["city"].ToString(),
                        country = reader["country"].ToString()
                    };
                    organizations.Add(org);
                }
            }
        }
    }
    catch (Exception ex) {
        Console.WriteLine("An error occurred while retrieving organizations: " + ex.Message);
        // Optionally, log this exception to a file or database
        // Consider whether to rethrow the exception or handle it differently
        throw;
    }
    return organizations;
}





}
