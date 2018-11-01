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
        internal static List<MovieModel> GetAllMoviesV1()
        {
            if (_database == null)
                Initialise();

            var _movie = _database.GetCollection<MovieModel>("Movies");
            var filter = Builders<MovieModel>.Filter.Empty;
            return _movie.Find(filter).ToList();
        }

        internal static bool AddMovieV1(MovieRequestModel requestModel)
        {
            if (_database == null)
                Initialise();

            var _movie = _database.GetCollection<MovieModel>("Movies");
            var newMovieDetails = new MovieModel
            {
                _id = ObjectId.GenerateNewId(),
                ActorIds = requestModel.ActorIds,
                Name = requestModel.Name,
                Plot = requestModel.Plot,
                PosterImage = requestModel.PosterImage,
                ProducerId = requestModel.ProducerId,
                YearOfRelease = requestModel.YearOfRelease
            };

            _movie.InsertOne(newMovieDetails);
            return true;
        }
    }
}
