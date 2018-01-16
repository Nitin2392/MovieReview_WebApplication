using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieReview_Website_Adv_DotNet.Models
{
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

        public System.Data.Entity.DbSet<MovieReview_Website_Adv_DotNet.Models.Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<MovieReview_Website_Adv_DotNet.Models.MovieCategory> MovieCategories { get; set; }
    }
}