using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace shopsincampus.data.Models;

public class College
{
    [BsonId]
    public string? Id {get;set;}

    [BsonElement("basicDetails")] 

    public BasicDetails? BasicDetails { get; set; }
}
