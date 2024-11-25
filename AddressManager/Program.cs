var builder = WebApplication.CreateBuilder(args);

// Database initialization
Console.WriteLine("Initializing database and creating tables...");
OrgDatabase orgdb = new OrgDatabase();  // This triggers your database setup logic
StaffDatabase staffdb = new StaffDatabase();
Console.WriteLine("Database setup complete.");


//Service.addOrganization("Company name", "street name", "zip", "city", "country");
//orgdb.insertOrg("Company", "street name", "zip", "city", "country");
//staffdb.insertStaff("title name", "An", "Chau", "210", "email", 4);

//orgdb.deleteOrg(3);
//staffdb.deleteStaff(2);

//staffdb.updateStaff(3, "giggity", "An", "Chau", "210", "email", 4);
//orgdb.updateOrg(4, "Yup", "street name", "zip", "city", "country");

/** testing the get all method
try
        {
            // Assuming StaffDatabase is the class that contains your method
            List<Organization> organizations = orgdb.GetAllOrganizations();

            // Print the fetched organizations to verify the results
            foreach (var org in organizations)
            {
                Console.WriteLine($"ID: {org.OrganizationId}, Name: {org.name}, Street: {org.street}, Zip: {org.zip}, City: {org.city}, Country: {org.country}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
**/

var app = builder.Build();

app.Run();
