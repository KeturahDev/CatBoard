using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatBoardApi.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace CatBoardApi.Models
{
  public class TokenAuthenticationService : IAuthenticateService
  {
    private readonly IUserManagementService _userManagementService;
    private readonly TokenManagement _tokenManagement;
    
    public TokenAuthenticationService(IUserManagementService service, IOptions<TokenManagement> tokenManagement)
    {
        _userManagementService = service;
        _tokenManagement = tokenManagement.Value;
    }
    public bool IsAuthenticated(TokenRequest request, out string token)
    {
      token = string.Empty;
      bool check = _userManagementService.IsValidUser(request.Username, request.Password);
      if (check == false) return false;
      
      var claim = new[]
      {
        new Claim(ClaimTypes.Name, request.Username)
      };
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
      var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
          
      var jwtToken = new JwtSecurityToken(
          _tokenManagement.Issuer,
          _tokenManagement.Audience,
          claim,
          expires:DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
          signingCredentials: credentials
      );
      token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
      return true;
    }
  }
}