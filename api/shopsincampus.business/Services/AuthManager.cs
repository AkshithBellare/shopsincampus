using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using shopsincampus.business.Interfaces;
namespace shopsincampus.business.Services;

public class AuthManager : IAuthManager
{
public string GenerateJwtToken(string userId)
{
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("%fR{T%3e>k^}<+Li-bwP.f}hI5EEq>zzw80&B4D2;n}GIym5W2hK>cs_P{7`@2I"));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    
    var token = new JwtSecurityToken(
        issuer: null, // Specify the issuer if necessary
        audience: null, // Specify the audience if necessary
        claims: null, // Add any claims if needed
        expires: DateTime.Now.AddMinutes(30), // Set token expiration
        signingCredentials: creds);

    return new JwtSecurityTokenHandler().WriteToken(token);
}
}
