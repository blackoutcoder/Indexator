using System;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services
{
    //[Keyless]
    public class FileDbContext : DbContext
    {
        public DbSet<IndexedFile> Files { get; set; }
        public DbSet<IndexedFolder> IndexedFolders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
