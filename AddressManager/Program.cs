var builder = WebApplication.CreateBuilder(args);

// Database initialization
Console.WriteLine("Initializing database and creating tables...");
Database db = new Database();  // This triggers your database setup logic
Console.WriteLine("Database setup complete.");

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
