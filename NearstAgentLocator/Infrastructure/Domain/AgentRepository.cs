using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using NAL.Api.Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NAL.Api.Infrastructure
{
    public class AgentRepository : IAgentRepository
    {
        private readonly IConfiguration _configuration;

        private IMongoCollection<Agents> _agentCollection;
        public AgentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            var client = new MongoClient(_configuration.GetConnectionString("MongoDbConnection"));

            var database = client.GetDatabase("test");
            _agentCollection = database.GetCollection<Agents>("agents");
        }

        public async Task<List<Agents>> NearAsync(double longitude, double latitude, long maximumDistance = 0, long minimumDistance = 5000)
        {
            var builder = Builders<Agents>.Filter;

            var point = GeoJson.Point(GeoJson.Position(longitude, latitude));
            var filter = builder.Near(x => x.Location, point, maximumDistance, minimumDistance);

            var result = await _agentCollection.FindAsync(filter).ConfigureAwait(false);
            return await result.ToListAsync();
        }
    }
}
