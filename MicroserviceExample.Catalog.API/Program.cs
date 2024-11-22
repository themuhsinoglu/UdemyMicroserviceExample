using MicroserviceExample.Catalog.API;
using MicroserviceExample.Catalog.API.Features.Category;
using MicroserviceExample.Catalog.API.Options;
using MicroserviceExample.Catalog.API.Repositories;
using MicroserviceExample.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptionsExt();
builder.Services.AddDatabaseServiceExt();

builder.Services.AddCommonServiceExt(typeof(CatalogAssembly));


var app = builder.Build();

app.AddCategoryGroupEndpointExt();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
