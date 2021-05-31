using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Project
{
    public partial class Project : DbContext
    {
        public Project()
            : base("name=Project")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<History_Buy> History_Buy { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
