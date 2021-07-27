using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Helpers;
using Server.Services;


using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Google.Apis.Auth;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Server.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("v1/[controller]")]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("google")]
        public async Task<IActionResult> Google([FromBody]UserView userView)
        {
            try
            {
                SimpleLogger.Log("userView = " + userView.tokenId);
                var payload = GoogleJsonWebSignature.ValidateAsync(userView.tokenId, new GoogleJsonWebSignature.ValidationSettings()).Result;
                var user = await _authService.Authenticate(payload);
                SimpleLogger.Log(payload.ExpirationTimeSeconds.ToString());

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, Security.Encrypt(AppSettings.appSettings.JwtEmailEncryption,user.email)),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AppSettings.appSettings.JwtSecret));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(String.Empty,
                  String.Empty,
                  claims,
                  expires: DateTime.Now.AddSeconds(55*60),
                  signingCredentials: creds);
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                Helpers.SimpleLogger.Log(ex);
                BadRequest(ex.Message);
            }
            return BadRequest();
        }
        // [AllowAnonymous]
        // [HttpPost("hue")]
        // public async Task<IActionResult> Hue([FromBody]UserView userView)
        // {

        //     string appId = AppSettings.appSettings.HueAppId; //q42-hueapi-test
        //     string clientId = AppSettings.appSettings.HueClientId;
        //     string clientSecret = AppSettings.appSettings.HueClientSecret;
        //     IRemoteAuthenticationClient authClient = new RemoteAuthenticationClient(clientId, clientSecret, appId);

        //     //If you already have an accessToken, call:
        //     //AccessTokenResponse storedAccessToken = SomehwereFrom.Storage();
        //     //authClient.Initialize(storedAccessToken);
        //     //IRemoteHueClient client = new RemoteHueClient(authClient.GetValidToken);

        //     //Else, reinitialize:

        //     var authorizeUri = authClient.BuildAuthorizeUri("sample", "consoleapp");

        //     var webAuthenticationResult = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, authorizeUri, callbackUri);

        //     if (webAuthenticationResult != null)
        //     {
        //         var result = authClient.ProcessAuthorizeResponse(webAuthenticationResult.ResponseData);

        //         if (!string.IsNullOrEmpty(result.Code))
        //         {
        //         //You can store the accessToken for later use
        //         var accessToken = await authClient.GetToken(result.Code);

        //         IRemoteHueClient client = new RemoteHueClient(authClient.GetValidToken);
        //         var bridges = await client.GetBridgesAsync();

        //             if (bridges != null)
        //             {
        //                 //Register app
        //                 //var key = await client.RegisterAsync(bridges.First().Id, "Sample App");

        //                 //Or initialize with saved key:
        //                 client.Initialize(bridges.First().Id, "C95sK6Cchq2LfbkbVkfpRKSBlns2CylN-VxxDD8F");

        //                 //Turn all lights on
        //                 var lightResult = await client.SendCommandAsync(new LightCommand().TurnOn());

        //             }
        //         }
        //     }
        // }
    }

}

/*SimpleLogger.Log(payload.Name);
                SimpleLogger.Log(payload.Email);
                SimpleLogger.Log(payload.Subject);
                SimpleLogger.Log(payload.Issuer);
                SimpleLogger.Log(payload.ExpirationTimeSeconds.ToString());

                SimpleLogger.Log(DateUtil.FromUnixTime((long)payload.ExpirationTimeSeconds).ToString());
                SimpleLogger.Log(payload.JwtId);*/
