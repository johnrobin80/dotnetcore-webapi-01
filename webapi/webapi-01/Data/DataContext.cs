using Microsoft.EntityFrameworkCore;

namespace webapi_01.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        {

        }
    }
}