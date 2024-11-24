public class Organization {
    public int OrganizationId { get; set; }
    public string name { get; set; }
    public string street { get; set; }
    public string zip { get; set; }
    public string city { get; set; }
    public string country { get; set; }

}

public class Staff {
    public int StaffId { get; set; }
    public string title { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string phone { get; set; }
    public string email { get; set; }
    public int OrganizationId { get; set; } //foreign key

}