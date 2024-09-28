using System;
using MongoDB.Bson.Serialization.Attributes;

namespace shopsincampus.data.Models;

public class Campus
{
    [BsonId]
    public string? Id {get;set;}

    [BsonElement("collegeId")]
    
    public required string CollegeId {get;set;}
    [BsonElement("basicDetails")] 

    public BasicDetails? BasicDetails { get; set; }
}
