using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace shopsincampus.data.Models;

public class Shop
{
    [BsonId]
    public string? Id {get;set;}
    
    [BsonElement("collegeId")] 
    public string? CollegeId { get; set; }

    [BsonElement("campusId")] 

    public string? CampusId {get;set;}

    [BsonElement("basicDetails")] 

    public BasicDetails? BasicDetails { get; set; }

    [BsonElement("shopStatus")] 
    public ShopStatus? ShopStatus {get; set;}
}

public class BasicDetails {
    [BsonElement("name")] 

    public string? Name { get; set; }

    [BsonElement("description")] 

    public string? Description {get; set;}
}

public class ShopStatus {
    [BsonElement("code")] 

    public int? Code { get; set; }

    [BsonElement("name")]
    public string? Name {get;set;}
}