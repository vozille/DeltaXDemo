using DeltaX.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaX.Mongo
{
    public partial class MongoConnnector
    {
        private static IMongoClient _server;
        private static IMongoDatabase _database;


        internal static void Initialise()
        {
            _server = new MongoClient("mongodb://db:27017");
            _database = _server.GetDatabase("HollyWood");
        }

        internal static void InsertRecord()
        {
            if (_database == null)
                Initialise();
        }

        internal static ActorModel GetAllMovies()
        {
            if (_database == null)
                Initialise();

            var _actor = _database.GetCollection<ActorModel>("Actors");
            var filter = Builders<ActorModel>.Filter.Empty;
            return _actor.Find(filter).FirstOrDefault();
        }
    }
}
