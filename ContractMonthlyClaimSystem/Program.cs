using ContractMonthlyClaimSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Ensure all services are registered before calling `builder.Build()`
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ClaimService>(); // Register ClaimService here

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


