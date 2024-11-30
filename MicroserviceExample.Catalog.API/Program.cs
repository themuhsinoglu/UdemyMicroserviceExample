using MicroserviceExample.Catalog.API;
using MicroserviceExample.Catalog.API.Features.Categories;
using MicroserviceExample.Catalog.API.Features.Courses;
using MicroserviceExample.Catalog.API.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptionsExt();
builder.Services.AddDatabaseServiceExt();

builder.Services.AddCommonServiceExt(typeof(CatalogAssembly));

builder.Services.AddVersioningExt();

var app = builder.Build();

app.AddSeedDataExt()?.ContinueWith(x =>
{
    Console.WriteLine(x.IsFaulted ? x.Exception?.Message : "Seed Data has been saved successfully.");
});

app.AddCategoryGroupEndpointExt(app.AddVersionSetExt());
app.AddCourseGroupEndpointExt(app.AddVersionSetExt());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();