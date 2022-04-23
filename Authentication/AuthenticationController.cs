using Microsoft.AspNetCore.Mvc;

namespace Authentication;

[Route("[controller]")]
public class AuthenticationController
{
    private readonly Credentials credentials = new();
    public AuthenticationController()
    {

    }

    [HttpPost]
    public async Task Post(string username, string password)
    {
        var credentials = new Credentials
        {
            Username = username,
            Password = password
        };
        await credentials.AuthToken(username, password);
    }
}