using Microsoft.EntityFrameworkCore;
using Entity_framework_cli.Db;
using Entity_framework_cli.Utils;

namespace Entity_framework_cli
{
    public static class Program
    {
        public static void Main()
        {
            var root = Directory.GetCurrentDirectory();
            var dotenv = Path.Combine(root, ".env");
            DotEnv.Load(dotenv);
            var cli = new Cli();
            cli.Start();
        }
    }
}