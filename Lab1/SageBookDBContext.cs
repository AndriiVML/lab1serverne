using Lab1.Models;
using System.Data.Entity;
using System.Linq;

namespace Lab1
{
    public class SageBookDBContext: DbContext
    {
        public SageBookDBContext() : base("DBConnection")
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Sage> Sages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                        .HasMany<Sage>(s => s.Sages)
                        .WithMany(c => c.Books)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("IdBook");
                            cs.MapRightKey("IdSage");
                            cs.ToTable("SageBooks");
                        });
        }
        public void RollBack()
        {
            var changedEntries = ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
            SaveChanges();
        }

    }
}
