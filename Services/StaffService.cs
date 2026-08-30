using StaffManagementApp.Models;

namespace StaffManagementApp.Services
{
    public class StaffService : IStaffService
    {
        private readonly List<StaffMember> _staffMembers = new();
        private int _nextId = 1;

        public StaffService()
        {
            //Seed a couple of records so the app has data to show on first run.
            Add(new StaffMember
            {
                FullName = "Thabo Mokoena",
                Email = "thabo.mokoena@company.co.za",
                Position = "IT Support Technician",
                Unit = "IT Department"
            });

            Add(new StaffMember
            {
                FullName = "Naledi Dlamini",
                Email = "naledi.dlamini@company.co.za",
                Position = "HR Officer",
                Unit = "Human Resources"
            });
        }

        public List<StaffMember> GetAll()
        {
            return _staffMembers;
        }

        public StaffMember? GetById(int id)
        {
            return _staffMembers.FirstOrDefault(s => s.StaffId == id);
        }

        public StaffMember Add(StaffMember staff)
        {
            staff.StaffId = _nextId++;
            _staffMembers.Add(staff);
            return staff;
        }

        public bool Update(int id, StaffMember updatedStaff)
        {
            var existing = GetById(id);
            if (existing == null)
            {
                return false;
            }

            existing.FullName = updatedStaff.FullName;
            existing.Email = updatedStaff.Email;
            existing.Position = updatedStaff.Position;
            existing.Unit = updatedStaff.Unit;
            return true;
        }

        public bool Delete(int id)
        {
            var existing = GetById(id);
            if (existing == null)
            {
                return false;
            }

            return _staffMembers.Remove(existing);
        }
    }
}
