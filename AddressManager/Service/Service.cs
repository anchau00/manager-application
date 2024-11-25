public class Service{
      public static void addOrganization(string name, string street, string zip, string city, string country){
        OrgDatabase db = new OrgDatabase();
        db.insertOrg(name, street, zip, city, country);
    }
}