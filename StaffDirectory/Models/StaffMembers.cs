using MessagePack;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
namespace StaffDirectory.Models

{
    public class StaffMembers
    {
        [Key]
        public int StaffId { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? StaffStatus { get; set; }
        public String? HomeRoom { get; set; }
        public String? TeacherCode { get; set; }    
        
        public String? Email { get; set; }
        public String? Phone { get; set; }
        



    }
}
