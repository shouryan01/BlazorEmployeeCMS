using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using epitec.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddSqlite<ContactStoreContext>("Data Source=contacts.db");
builder.Services.AddControllers().AddNewtonsoftJson();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");


// Initialize the database
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ContactStoreContext>();
    if (db.Database.EnsureCreated())
    {
        SeedData.Initialize(db);
    }
}

app.Run();