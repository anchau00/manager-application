var builder = WebApplication.CreateBuilder(args);

// Database initialization
Console.WriteLine("Initializing database and creating tables...");
OrgControl oc = new OrgControl();
StaffControl sc = new StaffControl();

Organization org = new Organization {
    name = "Mcdonalds",
    street = "That Street",
    zip = "78218",
    city = "San Antonio",
    country = "U.S.",
};


  Staff staff = new Staff
    {
        StaffId = 1,
        title = "Mr.",
        firstName = "An",
        lastName = "Chau",
        phone = "210",
        email = "anchau001",
        OrganizationId = 1  // Make sure this corresponds to an existing Organization ID in your database
    };

//oc.addOrg(org);
//sc.addStaff(staff);
var organizations = oc.GetAllOrganizations();
foreach (var o in organizations)
{
    Console.WriteLine($"ID: {o.OrganizationId}, Name: {o.name}, Street: {org.street}, Zip: {o.zip}, City: {o.city}, Country: {o.country}");
}

var staffMembers = sc.GetAllStaff();
foreach (var s in staffMembers)
{
    Console.WriteLine($"ID: {s.StaffId}, Title: {s.title}, Name: {s.firstName} {s.lastName}, Phone: {s.phone}, Email: {s.email}, Org ID: {s.OrganizationId}");
}


var app = builder.Build();

app.Run();
