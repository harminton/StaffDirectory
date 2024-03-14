using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace StaffDirectory.Models
{
    public class Students
    {
        [Key]
        public int StudentId { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? AcNumber { get; set; }
        public String? Phone { get; set; }
        public String? ParentEmail { get; set; }
        public String? ParentPhone { get; set; }


    }
}
