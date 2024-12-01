public class StaffControl{

    private StaffService staffServ;

    public StaffControl(){
        staffServ = new StaffService();
    }

    
    public void addStaff(Staff staff) {
        staffServ.addStaff(staff);
    }

    public void updateStaff(Staff staff){
         staffServ.addStaff(staff);
    }

    
    public void deleteStaff(Staff staff){
         staffServ.deleteStaff(staff);
    }

    public List<Staff> GetAllStaff(){
        return staffServ.GetAllStaff();
    }





}