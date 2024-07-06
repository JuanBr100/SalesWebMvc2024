using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMvc.Data;
using SalesWebMvc.Services;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Globalization;


var builder = WebApplication.CreateBuilder(args);

// Configure o contexto do banco de dados
builder.Services.AddDbContext<SalesWebMvcContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("SalesWebMvcContext") ?? throw new InvalidOperationException("Connection string 'SalesWebMvcContext' not found."),
    new MySqlServerVersion(new Version(8, 0, 26)))); // Especificar a versão do MySQL

// Adicionar serviços ao contêiner
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<SeedingService>();
builder.Services.AddTransient<SellerService>();
builder.Services.AddTransient<DepartmentService>();
builder.Services.AddTransient<SalesRecordService>();


var enUs = new CultureInfo("en-US");
var localizationOption = new RequestLocalizationOptions
{
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(enUs),
    SupportedCultures = new List<CultureInfo> { enUs }
};




var app = builder.Build();


app.UseRequestLocalization(localizationOption);

// Configurar o pipeline de requisição HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    // Este bloco de código só deve ser executado em ambiente de desenvolvimento
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<SalesWebMvcContext>();
        context.Database.EnsureCreated(); // Cria o banco de dados se ele não existir
        var seedingService = new SeedingService(context);
        seedingService.Seed();

        // Adicionar mais inicializações se necessário
        var sellerService = services.GetRequiredService<SellerService>();
        var departmentService = services.GetRequiredService<DepartmentService>();

        // Chame métodos de inicialização no sellerService, se houver
    }
}

// Popular as tabelas do sistema fora do bloco de desenvolvimento, se necessário
// app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
