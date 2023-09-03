using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Entity;

namespace Common.Serializers
{
    public class AddressSerializer : SerializerBase<Address>
    {
        public override Address Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var serializer = BsonSerializer.LookupSerializer(typeof(string));
            var data = serializer.Deserialize(context, args);
            return data as Address;
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Address value)
        {
            var serializer = BsonSerializer.LookupSerializer(typeof(string));
            serializer.Serialize(context, value);
        }
    }
}
