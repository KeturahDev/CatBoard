using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using CatBoardApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;
using Microsoft.OpenApi.Models;

namespace CatBoardApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddSwaggerGen(c =>
      {
          c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
      });
      
      services.AddDbContext<CatBoardApiContext>(opt =>
          opt.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      services.Configure<TokenManagement>(Configuration.GetSection("tokenManagement"));
      var token = Configuration.GetSection("tokenManagement").Get<TokenManagement>();
      var secret = Encoding.ASCII.GetBytes(token.Secret);

    //   services.Configure<TokenManagement>(Configuration.GetSection("tokenManagement"));

      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(x =>
      {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret)),
          ValidIssuer = token.Issuer,
          ValidAudience = token.Audience,
          ValidateIssuer = false,
          ValidateAudience = false
        };
      });

        services.AddScoped<IAuthenticateService, TokenAuthenticationService>();

        services.AddScoped<IUserManagementService, UserManagementService>();

      services.AddSwaggerDocument();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {


      // Register the Swagger generator and the Swagger UI middlewares
      app.UseOpenApi();
      app.UseSwaggerUi3();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
      app.UseAuthentication();
      // app.UseHttpsRedirection();
      app.UseMvc();

      // app.UseHttpsRedirection();
      // app.UseMvc();
    }

  }


}

