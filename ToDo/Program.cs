using Microsoft.Extensions.Configuration;
using System.Data.Common;
using ToDo.Domain.Connections;
using ToDo.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddRazorPages().Services.AddSingleton<IConnections, Connections>();
builder.Services.AddRazorPages().Services.AddSingleton<ITaskServices, TaskServices>();
builder.Services.AddRazorPages().Services.AddSingleton<IUserService, UserServices>();
builder.Services.AddSession(option => { option.IdleTimeout = TimeSpan.FromMinutes(30); }).
    AddMemoryCache().
    AddMvc().
    AddRazorPagesOptions(option => { option.Conventions.AddPageRoute("/UsersPage/LoginPage", ""); });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
