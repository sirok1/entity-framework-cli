using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using working_with_db.db;

namespace working_with_db;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton(Configuration);
        string connectionString = $"Host={Configuration["DB_HOST"]};Port={Configuration["DB_PORT"]};Database={Configuration["POSTGRES_DB"]};Username={Configuration["POSTGRES_USER"]};Password={Configuration["POSTGRES_PASSWORD"]}";
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseNpgsql(connectionString));
    }
}