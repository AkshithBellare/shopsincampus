using System;

namespace shopsincampus.business.Interfaces;

public interface IAuthManager
{
    public string GenerateJwtToken(string userId);
}
