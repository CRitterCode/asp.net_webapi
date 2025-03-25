using Application.Extensions;
using Application.Services;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InitializeDatabase(builder.Configuration);
builder.Services.InitializeIdentityDatabase(builder.Configuration);

# region Identity

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationIdentityDbContext>();
#endregion

#region Services

builder.Services.AddTransient<IRepositoryBase<User>, UserRepository>();
builder.Services.AddTransient<UserService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
