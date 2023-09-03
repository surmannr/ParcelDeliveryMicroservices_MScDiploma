using Common.Entity;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Serializers
{
    public class PaymentOptionSerializer : SerializerBase<PaymentOption>
    {
        public override PaymentOption Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var serializer = BsonSerializer.LookupSerializer(typeof(string));
            var data = serializer.Deserialize(context, args);
            return data as PaymentOption;
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, PaymentOption value)
        {
            var serializer = BsonSerializer.LookupSerializer(typeof(string));
            serializer.Serialize(context, value);
        }
    }
}
