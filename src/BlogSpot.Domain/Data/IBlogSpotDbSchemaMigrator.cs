using System.Threading.Tasks;

namespace BlogSpot.Data;

public interface IBlogSpotDbSchemaMigrator
{
    Task MigrateAsync();
}
