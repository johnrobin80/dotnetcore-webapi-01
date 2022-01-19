using Microsoft.EntityFrameworkCore;
using webapi_01.Models;

namespace webapi_01.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Character> Characters { get; set; }
    }
}