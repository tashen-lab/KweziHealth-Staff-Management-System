using StaffManagementApp.Models;

namespace StaffManagementApp.Services
{
    public interface IStaffService
    {
        List<StaffMember> GetAll();
        StaffMember? GetById(int id);
        StaffMember Add(StaffMember staff);
        bool Update(int id, StaffMember updatedStaff);
        bool Delete(int id);
    }
}
