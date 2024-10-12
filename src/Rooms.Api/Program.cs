using Rooms.Api.Extensions;
using Rooms.Shared.Ioc;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDefaultCors();
builder.Services.AddLogging();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddInfra(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddAppServices();
builder.Services.AddGzipResponseCompression();
builder.Services.AddCors();
builder.Services.AddGlobalExceptionMiddleware();

WebApplication app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseResponseCompression();
app.MapControllers();
app.UseGlobalExceptionMiddleware();

app.Run();
