using Microsoft.EntityFrameworkCore;
using DepartmentCURD_DBFirst.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

    var connectionString = builder.Configuration.GetConnectionString("obj1");
    builder.Services.AddDbContextPool<TestDepartmentContext>(option =>
    option.UseSqlServer(connectionString));
    // Add services to the container.
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddCors();

/* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
       => optionsBuilder.UseSqlServer("Server=WJLP-1424;Database=TestDepartment;User=DJ;Password=Password@1997;TrustServerCertificate=true;Trusted_Connection=True;");
*/

var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
