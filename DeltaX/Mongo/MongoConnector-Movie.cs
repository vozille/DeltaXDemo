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

        internal static bool EditMovieV1(MovieEditRequestModel requestModel)
        {
            var _movie = _database.GetCollection<MovieModel>("Movies");
            var filter = Builders<MovieModel>.Filter.Eq(x=>x._id, new ObjectId(requestModel._id));
            var update = Builders<MovieModel>.Update
                .Set(x => x.YearOfRelease, requestModel.YearOfRelease)
                .Set(x => x.ActorIds, requestModel.ActorIds)
                .Set(x => x.Name, requestModel.Name)
                .Set(x => x.Plot, requestModel.Plot)
                .Set(x => x.PosterImage, requestModel.PosterImage)
                .Set(x => x.ProducerId, requestModel.ProducerId);
            var updateResult = _movie.UpdateOne(filter, update);
            if (updateResult.ModifiedCount > 0)
                return true;
            return false;
        }
    }
}
