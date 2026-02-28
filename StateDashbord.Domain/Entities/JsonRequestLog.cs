using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StateDashbord.Domain.Entities
{
    public class JsonRequestLog
    {

        [BsonId]
        public ObjectId Id { get; set; }

        public BsonDocument Data { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
