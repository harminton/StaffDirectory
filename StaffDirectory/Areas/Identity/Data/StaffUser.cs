using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StaffDirectory.Areas.Identity.Data;

// Add profile data for application users by adding properties to the StaffUser class
public class StaffUser : IdentityUser
{
    public String? FirstName { get; set; }
    public String? LastName { get; set; }
}

