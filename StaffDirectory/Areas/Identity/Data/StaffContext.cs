using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Build.Logging;
using Microsoft.EntityFrameworkCore;
using StaffDirectory.Areas.Identity.Data;
using StaffDirectory.Models;

namespace StaffDirectory.Areas.Identity.Data;

public class StaffContext : IdentityDbContext<StaffUser>
{
    public StaffContext(DbContextOptions<StaffContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<StaffDirectory.Models.Staff>? StaffMembers { get; set; }

    public DbSet<StaffDirectory.Models.Students>? Students { get; set; }

    public DbSet<StaffDirectory.Models.Subjects>? Subjects { get; set; }

    public DbSet<StaffDirectory.Models.Departments>? Departments { get; set; }

    public DbSet<StaffDirectory.Models.DepartmentStaff>? DepartmentStaff { get; set; }

    public DbSet<StaffDirectory.Models.TimeTable>? Time { get; set; }

    public DbSet<StaffDirectory.Models.PersonalInformation>? PersonalInformation { get; set; }

}
