var builder = WebApplication.CreateBuilder(args);

// Database initialization
Console.WriteLine("Initializing database and creating tables...");
Database db = new Database();  // This triggers your database setup logic
Console.WriteLine("Database setup complete.");


Service.addOrganization("Company name", "street name", "zip", "city", "country");

var app = builder.Build();

app.Run();
