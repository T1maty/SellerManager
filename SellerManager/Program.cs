using Microsoft.EntityFrameworkCore;
using SellerManager.Data;
using SellerManager.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataClass>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/v1/sellers", (DataClass context) =>
{
    var sellers = context.Sellers;

    var sellersDtoList = new List<SellerDtO>();

    if (sellers is not null)
    {
        sellersDtoList = sellers.Select(c => new SellerDtO(c.Name, c.Email)).ToList();
    }

    return sellersDtoList.Any() ? Results.Ok(sellersDtoList) : Results.NotFound();

}).Produces<Seller>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
