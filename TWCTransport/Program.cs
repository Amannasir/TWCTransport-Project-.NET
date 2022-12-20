using TWCTransport.Business;
using TWCTransport.Model.Config;
using TWCTransport.Provider;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var config = builder.Configuration;
builder.Services.AddControllersWithViews();
builder.Services.Configure<DataverseConfig>(config.GetSection(nameof(DataverseConfig)));
builder.Services.AddSingleton<IDataverseProvider, DataverseProvider>();
builder.Services.AddTransient<ITransportRequestManager, TransportRequestManager>();
builder.Services.AddTransient<IOptionSetManager, OptionSetManager>();
builder.Services.Configure<DataverseConfig>(builder.Configuration.GetSection("PowerPlatformConfig"));

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
AddBusinessManagers(builder.Services);
void AddBusinessManagers(IServiceCollection services)
{


}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
