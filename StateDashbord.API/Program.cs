using StateDashbord.Application.IRepository;
using StateDashbord.Infrastructure.Persistence;
using StateDashbord.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddTransient<IFriDetailsRepo, FriDetailsRepo>();
builder.Services.AddTransient<IFetchFriDetails, FetchFriDetails>();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddHttpClient<IFetchFriDetails, FetchFriDetails>();
builder.Services.AddScoped(typeof(IGenericServices<>), typeof(GenericServices<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
