using WebApplication2;
using TeacherServices;
using TeacherRepository;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*builder.Services.AddScoped<IStudentLogic, StudentLogic>();*/
builder.Services.AddScoped<IServices, Services>();

builder.Services.AddScoped<IRepository, Repository>();
/*Services.AddScoped<IServices, Services>();
Services.AddScoped<IRepository, Repository>();*/


/*var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();*/

var cosmosDBConfig = builder.Configuration.GetSection("CosmosDB");
var endpointUrl = cosmosDBConfig.GetValue<string>("EndpointUrl");
var primaryKey = cosmosDBConfig.GetValue<string>("PrimaryKey");
var cosmosClient = new CosmosClient(endpointUrl, primaryKey);

var databaseName = "OnlineLab"; // Provide your database name
var containerName = "Quiz"; // Provide your container name

builder.Services.AddSingleton<Container>(sp =>
{
    var database = cosmosClient.GetDatabase(databaseName);
    return database.GetContainer(containerName);
});


builder.Services.AddCors(options=>{
    var frontendURL = builder.Configuration.GetValue<string>("frontend_url");

    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
    });
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
