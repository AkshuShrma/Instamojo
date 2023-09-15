using PaymentInstamojo.models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add InstamojoService
builder.Services.AddScoped<InstamojoService>(provider =>
{
    string clientId = builder.Configuration["Instamojo:ClientId"];
    string clientSecret = builder.Configuration["Instamojo:ClientSecret"];
    return new InstamojoService(clientId,clientSecret);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// adding cors policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "My", policy =>
    {
        policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
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
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("My");

app.MapControllers();

app.Run();
