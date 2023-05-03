using TechnicalTest.Models.Services;

namespace TechnicalTest.Helpers
{
    public class JsonReader
    {
        public static StoredProcedureData GetConfigurationStoredProcedure(IConfiguration configuration, string repositoryKey)
        {
            StoredProcedureData storedProcedureData = new StoredProcedureData();
            storedProcedureData.IdConnectionString = configuration[$"{repositoryKey}:ConnectionId"];
            storedProcedureData.SchemaName = configuration[$"{repositoryKey}:SchemaName"];
            storedProcedureData.Name = configuration[$"{repositoryKey}:SpName"];
            return storedProcedureData;
        }
    }
}
