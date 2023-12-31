using Microsoft.IdentityModel.Tokens;
using Postgres.Context.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using User.Authorization.Request.ComesInRequests;

namespace AthletesTests;

public class MockHelper
{
    public TokenForRegister tokenForRegister()
    {
        var token = new TokenForRegister() {
            Email = "test@test.com",
            Username = "testUser",
            Token = "randomToken"
        };
        return token;
    }    
}
