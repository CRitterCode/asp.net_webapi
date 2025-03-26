using Application.Interfaces;
using Application.Services;
using asp.net_mvc.Extensions;
using Domain.Entities;
using Domain.Entities.Reservation;

using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InitializeDatabase(builder.Configuration);
builder.Services.InitializeIdentityDatabase(builder.Configuration);
builder.Services.AddAutoMapper();

# region Identity

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationIdentityDbContext>();
#endregion

#region Services

//TODO: register specific Repos
builder.Services.AddTransient<IRepositoryBase<User>, UserRepository>(); 
builder.Services.AddTransient<IRepositoryBase<Business>, BusinessRepository>(); 
builder.Services.AddTransient<IRepositoryBase<TimeTable>, TimeTableRepository>(); 


builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IBusinessService, BusinessService>();

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
