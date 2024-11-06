using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ThueDat.EntityFrameworkCore
{
    public static class ThueDatDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ThueDatDbContext> builder, string connectionString)
        {
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            builder.UseMySql(connectionString, serverVersion);
        }

        public static void Configure(DbContextOptionsBuilder<ThueDatDbContext> builder, DbConnection connection)
        {
            var serverVersion = ServerVersion.AutoDetect(connection.ConnectionString);
            builder.UseMySql(connection, serverVersion);
        }
    }
}
