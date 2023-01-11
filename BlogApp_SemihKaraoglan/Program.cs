using BlogApp_SemihKaraoglan.Business.Abstract;
using BlogApp_SemihKaraoglan.Business.Concrete;
using BlogApp_SemihKaraoglan.Data;
using BlogApp_SemihKaraoglan.Data.Abstract;
using BlogApp_SemihKaraoglan.Data.Concrete;
using BlogApp_SemihKaraoglan.Data.Concrete.EFCore;
using BlogApp_SemihKaraoglan.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<CustomUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddDbContext<BlogAppContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteCon")));

builder.Services.AddScoped<ICategoryRepository, EFCoreCategoryRepository>();
builder.Services.AddScoped<IPostRepository, EFCorePostRepository>();
builder.Services.AddScoped<IPostExtensionRepository, EFCorePostExtensionRepository>();
builder.Services.AddScoped<ITagRepository, EFCoreTagRepository>();
builder.Services.AddScoped<ICommentRepository, EFCoreCommentRepository>();
builder.Services.AddScoped<ICommentReplyRepository, EFCoreCommentReplyRepository>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IPostService, PostManager>();
builder.Services.AddScoped<IPostExtensionService, PostExtensionManager>();
builder.Services.AddScoped<ITagService, TagManager>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<ICommentReplyService, CommentReplyManager>();




builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
