using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Portfolio.IOC.Dependencies;
using System.Runtime.CompilerServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region "App Dependencies"

builder.Services.AddContextDependency(builder.Configuration.GetConnectionString("ApplicationDbContext"));
builder.Services.AddContentDependency();
builder.Services.AddSecurityDependency();

#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


#region "Swagger Config"
builder.Services.AddSwaggerGen( C=> 
    {
        C.SwaggerDoc("v1", new OpenApiInfo { Title = "Portfolio", Version = "v1" });

        C.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "Input your Bearer token in this format - Bearer {Token} to access this endpoint",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
            
        });

        C.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer",
                    }
                }, new string[] { }
            },
        });
    }
);
#endregion

#region "Token Info"
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options => 
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["TokenInfo:Issuer"],
        ValidAudience = builder.Configuration["TokenInfo:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenInfo:SignKey"])),
    };
});
#endregion

#region "CORS"
builder.Services.AddCors(
    op =>
    {
        op.AddPolicy("AllowAll",
            bu => { 
                bu.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }
        );
    }
    );
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use JWT
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();