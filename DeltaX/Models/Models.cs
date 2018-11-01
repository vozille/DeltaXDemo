using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaX.Models
{
    public class PersonModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Bio { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public Gender Sex { get; set; }
    }

    public enum Gender
    {
        MALE,
        FEMALE
    }

    public class ActorModel: PersonModel
    {
        public ObjectId _id { get; set; }
    }

    public class ProducerModel: PersonModel
    {
        public ObjectId _id { get; set; }
    }
    
    public class MovieRequestModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Plot { get; set; }
        [Required]
        public int YearOfRelease { get; set; }
        [Required]
        public string PosterImage { get; set; }
        [Required]
        public string ProducerId { get; set; }
        [Required]
        public List<string> ActorIds { get; set; }
    }

    public class MovieModel: MovieRequestModel
    {
        public ObjectId _id { get; set; }

    }

}
