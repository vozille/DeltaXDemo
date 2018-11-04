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
        internal static List<ActorModel> GetAllActors()
        {
            if (_database == null)
                Initialise();

            var _actor = _database.GetCollection<ActorModel>("Actors");
            var filter = Builders<ActorModel>.Filter.Empty;
            return _actor.Find(filter).ToList();
        }

        internal static bool AddNewActor(PersonModel request)
        {
            var _actor = _database.GetCollection<ActorModel>("Actors");

            ActorModel actorData = new ActorModel
            {
                _id = ObjectId.GenerateNewId(),
                Bio = request.Bio,
                DateOfBirth = request.DateOfBirth,
                Name = request.Name,
                Sex = request.Sex
            };

            _actor.InsertOne(actorData);
            return true;
        }
    }
}
