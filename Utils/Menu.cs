using System.Text.Json;
using Entity_framework_cli.Json.MenuSettings;
using Entity_framework_cli.Utils.Exceptions;

namespace Entity_framework_cli.Utils;

public class Menu
{
    public MenuModel MenuSettings { get; set; }
    public Menu()
    {
        string json = File.ReadAllText("./menusettings.json");
        var test = JsonSerializer.Deserialize<MenuModel>(json);
        MenuSettings = JsonSerializer.Deserialize<MenuModel>(json);
    }
    public void PrintMenu(string menuType)
    {
        if (!MenuSettings.types.Contains(menuType))
            throw new MissingMenuTypeException("This menu type does not exist");
        var optionsWithNumbers = MenuSettings.options[menuType].items.Select((x, i) => $"{i + 1}. {x}");
        Console.WriteLine(MenuSettings.options[menuType].title);
        foreach (var option in optionsWithNumbers)
        {
            Console.WriteLine(option);
        }
        Console.Write(MenuSettings.endPrompt);
    }

    public bool IsOptionExists(string menuType, int optionNumber)
    {
        if (!MenuSettings.types.Contains(menuType))
            throw new MissingMenuTypeException("This menu type does not exist");
        return MenuSettings.options[menuType].items?.ElementAtOrDefault(optionNumber - 1) != default(string);
    }
}