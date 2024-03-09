using Microsoft.EntityFrameworkCore;
using TestCase.Parameter;
using TestCase.Parameter.SearchModel;
using static TestCase.Parameter.SearchModel.UserSearchModel;

namespace TestCase.DataAccessLayer
{
    public class MvcDBContext : DbContext
    {       
        public MvcDBContext(DbContextOptions<MvcDBContext> options) : base(options) { }
        public DbSet<M_Note> M_Note { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 配置 M_Note 實體類型為索引鍵實體類型
            modelBuilder.Entity<M_Note>().HasNoKey();
        }
    }
}
