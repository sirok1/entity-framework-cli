using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using working_with_db;

namespace working_with_db
{
    class Program
    {
        public static void Main(string[] args)
            => CreateHostBuilder().Build().Run();
        
        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
    }
}


