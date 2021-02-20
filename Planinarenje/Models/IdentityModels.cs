using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Planinarenje.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
 
    public class ApplicationUser : IdentityUser
    {
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
             
                userIdentity.AddClaim(new Claim("RealUserName", RealUserName));
                userIdentity.AddClaim(new Claim("UserID",Id));
              
            Claim claim = new Claim("UserImage", Image);

            userIdentity.AddClaim(claim);


            return userIdentity;
        }
        public bool IsGuid { get; set; }
        [MaxLength(50,ErrorMessage ="Maximum 50 characters  allowed! ")]
        public  string RealUserName { get; set; }
        public int NivoTure { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum 50 characters  allowed! ")]
        public string Image { get; set; }
    }
     
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //DefaultConnection
        //PlaninarenjeConnection
        public ApplicationDbContext()
            : base("PlaninarenjeConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}