using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CatBoardApi.Models
{
  public class CatBoardApiContextFactory : IDesignTimeDbContextFactory<CatBoardApiContext>
  {

    CatBoardApiContext IDesignTimeDbContextFactory<CatBoardApiContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<CatBoardApiContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new CatBoardApiContext(builder.Options);
    }
  }
}