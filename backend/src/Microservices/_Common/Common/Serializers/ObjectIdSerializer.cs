using Common.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Serializers
{
    public class ObjectIdSerializer : SerializerBase<string>
    {
        public override string Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var serializer = BsonSerializer.LookupSerializer(typeof(string));
            var data = serializer.Deserialize(context, args);
            return data.ToString();
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, string value)
        {
            var serializer = BsonSerializer.LookupSerializer(typeof(string));
            serializer.Serialize(context, ObjectId.Parse(value));
        }
    }
}
