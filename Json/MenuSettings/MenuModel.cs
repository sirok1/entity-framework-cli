namespace Entity_framework_cli.Json.MenuSettings;

public class MenuModel
{
    public List<string> types { get; set; } = null!;
    public Dictionary<string, Options> options { get; set; } = null!;
    public string endPrompt { get; set; } = null!;
    public string unknownChoicePrompt { get; set; } = null!;
}