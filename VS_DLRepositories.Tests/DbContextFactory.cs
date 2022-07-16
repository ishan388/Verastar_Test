using Microsoft.EntityFrameworkCore;

namespace VS_DLRepositories.Tests
{
    public class DbContextFactory
    {
        /// <summary>
        /// Create DbContext for every test - In Memory Db
        /// </summary>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        public static MyShopContext Create(string databaseName)
        {
            var options = new DbContextOptionsBuilder<MyShopContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;

            return new MyShopContext(options);
        }

        /// <summary>
        /// Create DbContext for every test - Existing Sql Db
        /// </summary>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        public static MyShopContext Create()
        {
            var options = new DbContextOptionsBuilder<MyShopContext>()
                .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=MyShop;Integrated Security=True;Trusted_Connection=True;")
                .Options;

            return new MyShopContext(options);
        }
    }
}
