using mission06_Hagerty.Models;
using mission06_Hagerty.Utilities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Entity Framework Core with SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieConnection")));

var app = builder.Build();

// // Ensure database is created and import CSV
// using (var scope = app.Services.CreateScope())
// {
//     var dbContext = scope.ServiceProvider.GetRequiredService<MovieContext>();
//     dbContext.Database.Migrate(); // Apply migrations
//
//     string csvFilePath = "movies.csv"; // Ensure the file is in the project root
//     if (File.Exists(csvFilePath))
//     {
//         CSVImporter.ImportMovies(dbContext, csvFilePath);
//     }
//     else
//     {
//         Console.WriteLine("CSV file not found. Skipping import.");
//     }
// }

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();