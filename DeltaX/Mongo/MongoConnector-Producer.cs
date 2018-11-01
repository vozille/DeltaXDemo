using DeltaX.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaX.Mongo
{
    public partial class MongoConnnector
    {
        internal static List<ProducerModel> GetAllProducers()
        {
            if (_database == null)
                Initialise();

            var _producer = _database.GetCollection<ProducerModel>("Producers");
            var filter = Builders<ProducerModel>.Filter.Empty;
            return _producer.Find(filter).ToList();
        }

        internal static bool AddNewProducer(PersonModel request)
        {
            var _producer = _database.GetCollection<ProducerModel>("Producers");

            ProducerModel producerData = new ProducerModel
            {
                _id = ObjectId.GenerateNewId(),
                Bio = request.Bio,
                DateOfBirth = request.DateOfBirth,
                Name = request.Name,
                Sex = request.Sex
            };

            _producer.InsertOne(producerData);
            return true;
        }
    }
}
