using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaX.Models
{
    public class PersonModel
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Sex { get; set; }
    }

    public enum Gender
    {
        MALE,
        FEMALE
    }

    public class ActorModel: PersonModel
    {
        public ObjectId _id;
    }

    public class ProducerModel: PersonModel
    {
        public ObjectId _id;
    }
}
