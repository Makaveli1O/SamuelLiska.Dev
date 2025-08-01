using BusinessLayer.Services;
using DataAccess.Db;
using Microsoft.EntityFrameworkCore;
using Infrastructure.UnitOfWork;
using BusinessLayer.Mapping;
using BusinessLayer.Dto.Game;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//DI
//builder.Services.AddScoped<IGenericRepository<Game>, GenericRepository<Game>>();
builder.Services.AddScoped<IGenericService<GameViewDto, GameCreateDto>, GameService>();
builder.Services.AddAutoMapper(typeof(GameMappingProfile).Assembly);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

app.MapGet("/games/ProceduralRpg", async context =>
{
    context.Response.Redirect("/games/proceduralrpg/index.html");
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();



app.Run();
