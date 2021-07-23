using Server.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Server.Services
{

  public async Task<User> Authenticate(Google.Apis.Auth.GoogleJsonWebSignature.Payload payload)
  {
    await Task.Delay(1);
    return this.FindUserOrAdd(payload);
  }

  private User FindUserOrADd(Google.Apis.Auth.GoogleJsonWebSignature.Payload payload)
  {
    var u = _users.Where(x => x.email == payload.Email).FirstOrDefault();
    if (u == null)
    {
      u = new User()
      {
        id = Guid.NewGuid(),
        name = payload.Name,
        email = payload.Email,
        oauthSubject = payload.Subject,
        oauthIssuer = payload.Issuer
      };
      _users.Add(u);
  }
  this.PrintUsers();
  return u;
}