using EcoNotifications.Backend.Application;
using EcoNotifications.Backend.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddEndpointsApiExplorer();

//Add components
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddDataAccess(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();