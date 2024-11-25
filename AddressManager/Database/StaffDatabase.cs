using System.Data.SQLite;
using System.Runtime.InteropServices;
public class StaffDatabase
{
    private SQLiteConnection conn;

    public StaffDatabase() {
        conn = new SQLiteConnection("Data Source=addressmanager.db;Version=3;");
        conn.Open();

    
        //Staff table
        string createStaffTable = @"CREATE TABLE IF NOT EXISTS Staff (
                                    StaffId INTEGER PRIMARY KEY AUTOINCREMENT,
                                    title TEXT,
                                    firstName TEXT,
                                    lastName TEXT,
                                    phone TEXT,
                                    email TEXT,
                                    OrganizationId INTEGER,
                                    FOREIGN KEY (OrganizationId) REFERENCES Organizations (OrganizationId)
                                )";
        
        ExecuteCommand(createStaffTable);
    }

    private void ExecuteCommand(string commandText) {
        using(var cmd = new SQLiteCommand(commandText, conn)) {
            cmd.ExecuteNonQuery();
        }
    }

    
    //insert, update, delete, and retrieve data
public void insertStaff(string title, string firstName, string lastName, string phone, string email, int organizationId) {
    try {
        string sql = @"
            INSERT INTO Staff (title, firstName, lastName, phone, email, OrganizationId)
            VALUES (@Title, @FirstName, @LastName, @Phone, @Email, @OrganizationId)";

        using (var cmd = new SQLiteCommand(sql, conn)) {
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@OrganizationId", organizationId);

            cmd.ExecuteNonQuery();
        }
    }
    catch (Exception ex) {
        Console.WriteLine("An error occurred while inserting into Staff: " + ex.Message);
        // Optionally, handle the error by logging to a file, notifying a user interface, or rethrowing.
        throw;
    }
}

public void updateStaff(int staffId, string title, string firstName, string lastName, string phone, string email, int organizationId) {
    try {
        string sql = @"
            UPDATE Staff SET title = @Title, firstName = @FirstName, lastName = @LastName,
             phone = @Phone, email = @Email, organizationId = @OrganizationId WHERE StaffId = @StaffId";

        using (var cmd = new SQLiteCommand(sql, conn)) {
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@OrganizationId", organizationId);
            cmd.Parameters.AddWithValue("@StaffId", staffId);

            cmd.ExecuteNonQuery();
        }
    }
    catch (Exception ex) {
        Console.WriteLine("An error occurred while updating Staff: " + ex.Message);
        // Optionally, handle the error by logging to a file, notifying a user interface, or rethrowing.
        throw;
    }
}

public void deleteStaff(int staffId) {
    try {
        string sql = @"
            DELETE FROM Staff WHERE StaffId = @StaffId";

        using (var cmd = new SQLiteCommand(sql, conn)) {
            cmd.Parameters.AddWithValue("@StaffId", staffId);
            cmd.ExecuteNonQuery();
        }
    }
    catch (Exception ex) {
        Console.WriteLine("An error occurred while deleting from Staff: " + ex.Message);
        // Optionally, handle the error by logging to a file, notifying a user interface, or rethrowing.
        throw;
    }
}

public List<Staff> GetAllStaff() {
        List<Staff> staffList = new List<Staff>();
        
        try {
            string sql = "SELECT StaffId, title, firstName, lastName, phone, email, OrganizationId FROM Staff";
            using (var cmd = new SQLiteCommand(sql, conn)) {
                using (var reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        Staff staff = new Staff() {
                            StaffId = Convert.ToInt32(reader["StaffId"]),
                            title = reader["title"].ToString(),
                            firstName = reader["firstName"].ToString(),
                            lastName = reader["lastName"].ToString(),
                            phone = reader["phone"].ToString(),
                            email = reader["email"].ToString(),
                            OrganizationId = Convert.ToInt32(reader["OrganizationId"])
                        };
                        staffList.Add(staff);
                    }
                }
            }
        }
        catch (Exception ex) {
            Console.WriteLine("An error occurred while retrieving staff: " + ex.Message);
            throw;  // Consider handling or logging the exception as appropriate
        }
        return staffList;
    }

}
