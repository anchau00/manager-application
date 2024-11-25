public class Service{
      public static void addOrganization(string name, string street, string zip, string city, string country){
        Database db = new Database();
        db.insertOrg(name, street, zip, city, country);
    }
}