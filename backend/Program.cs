
using Google.Cloud.Firestore;
using backend.Models;
using backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<FirestoreServices>(); 
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddSingleton(FirestoreDb.Create("byteback-6bb5d"));

var app = builder.Build();

app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

/*using Google.Cloud.Firestore;
using backend.Models;
using backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<FirestoreServices>(); 
builder.Services.AddControllers();


string path = Path.Combine(Directory.GetCurrentDirectory(), "firebase-key.json");
Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
builder.Services.AddSingleton(FirestoreDb.Create("byteback-544d6"));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run(); this is my program.cs file*/

