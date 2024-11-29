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


var app = builder.Build();

app.AddCategoryGroupEndpointExt();
app.AddCourseGroupEndpointExt();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();