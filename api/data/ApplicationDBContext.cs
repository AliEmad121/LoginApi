using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {}
    

    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<User> Users { get; set; }

}}