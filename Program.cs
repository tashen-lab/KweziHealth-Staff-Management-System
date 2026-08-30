using StaffManagementApp.Services;

var builder = WebApplication.CreateBuilder(args);

//Register application services
builder.Services.AddControllersWithViews();

//In-memory staff service registered as a Singleton so the same list instance is shared and persists across requests for the app's lifetime
builder.Services.AddSingleton<IStaffService, StaffService>();

//Session requires a cache backend, the in-memory cache is enough here since there is no database in this project
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

//Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Authentication middleware: session must come before authorization so the RequireAdmin filter can read the session state
app.UseSession();
app.UseAuthorization();

//Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Login}/{id?}");

app.Run();
