using System.Text.Json;
using Entity_framework_cli.Db;
using Entity_framework_cli.Json;
using Entity_framework_cli.Utils;
using Microsoft.EntityFrameworkCore;

namespace Entity_framework_cli;

public class Cli
{
    private Menu Menu { get; set; } = new Menu();
    private DbContext DbContext { get; set; } = new ApplicationDbContext();

    public void Start()
    {
        Menu.PrintMenu("main");
        var choice = int.Parse(Console.ReadLine()!);
        ProcessChoice("main", choice);
    }

    private void Loop(string menu)
    {
        Menu.PrintMenu(menu);
        var choice = int.Parse(Console.ReadLine()!);
        ProcessChoice(menu, choice);
    }

    private void ProcessChoice(string fromMenu, int choice)
    {
        if (!Menu.IsOptionExists(fromMenu, choice))
        {
            // var t = new Timer((object? o) => Loop("main"), null,
            //     TimeSpan.FromMilliseconds(500), TimeSpan.FromMilliseconds(-1));
            // Console.WriteLine(Menu.MenuSettings.unknownChoicePrompt);
            // Console.ReadLine();
            Loop("main");
        }
            
        else
        {
            switch (fromMenu)
            {
                case "main":
                    switch (choice)
                    {
                        case 16:
                            Loop("seed");
                            break;
                        case 17:
                            Loop("exit");
                            break;
                    }
                    break;
                case "seed":
                    switch (choice)
                    {
                        case 1:
                            seedDb();
                            break;
                        case 2:
                            Loop("main");
                            break;
                            
                    }
                    break;
                case "exit":
                    switch (choice)
                    {
                        case 1:
                            Environment.Exit(0);
                            break;
                        case 2:
                            Loop("main");
                            break;
                    }
                    break;
            } 
        }
        
    }

    private void seedDb()
    {
        string json = File.ReadAllText("./seed.json");
        var scheme = JsonSerializer.Deserialize<Dictionary<string, List<object>>>(json);
        foreach (var tableName in scheme.Keys)
        {
            var tableData = scheme[tableName];
            var entityType = DbContext.Model.FindEntityType(tableName);
            // var dbSet = DbContext.Set(entityType);
            // foreach (var rowData in tableData)
            // {
            //     dbSet.Add(rowData);
            // }
        }

        DbContext.SaveChanges();
    }
    
}