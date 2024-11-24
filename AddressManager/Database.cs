using System.Data.SQLite;
public class Database
{
    private SQLiteConnection conn;

    public Database() {
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
        
        //Staff table
        string createStaffTable = @"CREATE TABLE IF NOT EXISTS STAFF (
                                    StaffId INTEGER PRIMARY KEY AUTOINCREMENT,
                                    title TEXT,
                                    firstName TEXT,
                                    lastName TEXT,
                                    phone TEXT,
                                    email TEXT,
                                    OrganizationId INTEGER,
                                    FOREIGN KEY (OrganizationId) REFERENCES Organizations (OrganizationId)
                                )";
        
        ExecuteCommand(createOrgTable);
        ExecuteCommand(createStaffTable);
    }

    private void ExecuteCommand(string commandText) {
        using(var cmd = new SQLiteCommand(commandText, conn)) {
            cmd.ExecuteNonQuery();
        }
    }

    
    //insert, update, delete, and retrieve data
}
