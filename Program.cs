using BlazingPizza.Data;
using BlazingPizza.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
// AddHttpClient statement allows the app to access HTTP commands
builder.Services.AddSqlite<PizzaStoreContext>("Data Source=pizza.db");
// registers the new PizzaStoreContext and provides the filename for the SQLite database
builder.Services.AddScoped<OrderState>();
// adds the new OrderState service. 
// With this code in place, we can now use it in the index.razor component.

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

// Initialize the database
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
    if (db.Database.EnsureCreated())
    {
        SeedData.Initialize(db);
    }
}

app.Run();