using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using System;

namespace NAL.Api.Domain
{
    public class Agents
    {
        [BsonElement("id")]
        public ObjectId  Id { get; set; }
        [BsonElement("location")]
        public GeoJsonPoint<GeoJson2DCoordinates> Location { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("address")]
        public string Address { get; set; }
        [BsonElement("lga")]
        public string Lga { get; set; }
        [BsonElement("state")]
        public string State { get; set; }
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
