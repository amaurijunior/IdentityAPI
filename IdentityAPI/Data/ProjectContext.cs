using IdentityAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityAPI.Data
{
    public class ProjectContext : IdentityDbContext<User>
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        
    }
}
