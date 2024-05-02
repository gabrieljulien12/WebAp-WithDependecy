using Microsoft.EntityFrameworkCore;
using WebApıWithDependecy.Entities;

namespace WebApıWithDependecy.Services.Context
{
    public class SutudentContext:DbContext
    {
        
        public SutudentContext(DbContextOptions options): base  (options) { 
        
        
        
        
        
        }
        public DbSet<Student> Students { get; set; }
    }
}
