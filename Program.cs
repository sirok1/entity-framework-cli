using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using working_with_db;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

Console.WriteLine("Hello, World!");
var root = Directory.GetCurrentDirectory();
var dotenv = Path.Combine(root, ".env");
DotEnv.Load(dotenv);

var config =
    new ConfigurationBuilder()
        .AddEnvironmentVariables()
        .Build();

