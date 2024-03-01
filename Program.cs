using Microsoft.EntityFrameworkCore;
using Entity_framework_cli.db;
using Entity_framework_cli.utils;

namespace Entity_framework_cli
{
    public static class Program
    {
        public static void Main()
        {
            var root = Directory.GetCurrentDirectory();
            var dotenv = Path.Combine(root, ".env");
            DotEnv.Load(dotenv);
            using (var dbContext = new ApplicationDbContext())
            {
                ShowMenu(dbContext, "main");
            }
        }

        private static void ShowMenu(DbContext db, string menuType)
        {
            var choice = 0;
            switch (menuType)
            {
                case "main":
                    Console.WriteLine("ВЫБЕРИТЕ ОДИН ИЗ ПРЕДЛОЖЕННЫХ НИЖЕ ВАРИАНТОВ:");
                    Console.WriteLine(
                        "1. Вывести объекты недвижимости, расположенные в указанном районе стоимостью «ОТ» и «ДО»");
                    Console.WriteLine("2. Вывести фамилии риэлтор, которые продали двухкомнатные объекты недвижимости");
                    Console.WriteLine(
                        "3. Определить общую стоимость всех двухкомнатных объектов недвижимости,расположенных в указанном районе");
                    Console.WriteLine(
                        "4. Определить максимальную и минимальную стоимости объекта недвижимости, проданного указанным риэлтором");
                    Console.WriteLine(
                        "5. Определить среднюю оценку апартаментов по критерию «Безопасность», проданных указанным риэлтором");
                    Console.WriteLine(
                        "6. Вывести информацию о количестве объектов недвижимости, расположенных на 2 этаже по каждому району");
                    Console.WriteLine("7. Вывести информацию о количестве квартир, проданных каждым риэлтором");
                    Console.WriteLine(
                        "8. Вывести информацию о трех самых дорогих объектах недвижимости,расположенных в каждом районе.");
                    Console.WriteLine(
                        "9. Вывести для указанного риэлтора (ФИО) года, в которых он продал больше 2 объектов недвижимости.");
                    Console.WriteLine("10. Определить годы, в которых было размещено от 2 до 3 объектов недвижимости.");
                    Console.WriteLine(
                        "11. Вывести информацию об объектах недвижимости, у которых разница между заявленной и продажной стоимостью составляет не более 20 %");
                    Console.WriteLine("12. Определить адреса квартир, стоимость 1м2 которых меньше средней по району.");
                    Console.WriteLine("13. Определить ФИО риэлторов, которые ничего не продали в текущем году.");
                    Console.WriteLine(
                        "14. Вывести информацию о количество продаж в предыдущем и текущем годах по каждому району, а также процент изменения.");
                    Console.WriteLine(
                        "15. Определить среднюю оценку по каждому критерию для указанного объекта недвижимости");
                    Console.WriteLine("16. Заселить базу данных");
                    Console.WriteLine("17. Завершить программу");
                    Console.Write("Введите ваш выбор: ");

                    choice = int.Parse(Console.ReadLine()!);
                    switch (choice)
                    {
                        case 16:
                            ShowMenu(db, "seed");
                            break;
                        case 17:
                            ShowMenu(db, "exit");
                            break;
                        default:
                            Console.WriteLine("Выбрана неизвестная опция...");
                            Timer t = new Timer((object? o) => ShowMenu(db, "main"), null,
                                TimeSpan.FromMilliseconds(500), TimeSpan.FromMilliseconds(-1));
                            break;
                    }

                    break;
                case "seed":
                    Console.WriteLine("База данных будет заселена используя данные из файла seed.json. Продолжить ?");
                    Console.WriteLine("1. Да");
                    Console.WriteLine("2. Нет");
                    Console.Write("Введите ваш выбор: ");
                    
                    break;
                case "exit":
                    Console.WriteLine("Вы уверены что хотите завершить программу ?");
                    Console.WriteLine("1. Да");
                    Console.WriteLine("2. Нет");
                    Console.Write("Введите ваш выбор: ");
                    choice = int.Parse(Console.ReadLine()!);
                    switch (choice)
                    {
                        case 1:
                            Environment.Exit(0);
                            break;
                        case 2:
                            ShowMenu(db, "main");
                            break;
                    }

                    break;
            }
        }
    }
}