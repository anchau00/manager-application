public class OrgControl{

    private OrgService orgServ;

    public OrgControl(){
        orgServ = new OrgService();
    }

    public void addOrg(Organization org) {
        orgServ.addOrg(org);
    }

    public void updateOrg(Organization org){
        orgServ.updateOrg(org);
    }

    public void deleteOrg(Organization org){
        orgServ.deleteOrg(org);
    }

    public List<Organization> GetAllOrganizations(){
        return orgServ.GetAllOrganizations();
    }


}