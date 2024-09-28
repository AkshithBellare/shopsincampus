using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace shopsincampus.data.Models;

public class Shop
{
    [BsonId]
    public ObjectId Id {get;set;}
    
    [BsonElement("collegeId")] 
    public string? CollegeId { get; set; }

    [BsonElement("campusId")] 

    public string? CampusId {get;set;}

    public BasicDetails? BasicDetails { get; set; }

    [BsonElement("shopStatus")] 
    public ShopStatus? ShopStatus {get; set;}
}

public class BasicDetails {
    public string? Name { get; set; }

    public string? Descriptions {get; set;}
}

public class ShopStatus {
    [BsonElement("code")] 

    public int? Code { get; set; }

    [BsonElement("name")]
    public string? Name {get;set;}
}