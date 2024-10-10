using PersoApp.Models;
using PersoApp.Services; // Sørg for at importere EmployeeService

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PersoAppDBContext>();

// Registrer EmployeeService som en service
builder.Services.AddScoped<EmployeeService>();

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

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();



// Tilføj Razor Pages
builder.Services.AddRazorPages();




app.UseRouting();

app.MapRazorPages(); // Sørg for, at Razor Pages routing er aktiveret

app.Run();