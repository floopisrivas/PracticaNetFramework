using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
                                                                                                                        
namespace Net_Framework_Identity.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }



    public class MyUserCustom : IdentityUser
    {
        [Required]
        [MaxLength(200, ErrorMessage = "Debe tener entre 200 caracteres o menos"), MinLength(5)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Debe tener entre 200 caracteres o menos"), MinLength(5)]
        public string Apellido { get; set; }

    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>  
    {   
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
                                                
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}