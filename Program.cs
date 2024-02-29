using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class Property
{
    public int Id { get; set; }
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
    public string Address { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
    public double Price { get; set; }
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
    public string District { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
    public int Rooms { get; set; }
    public double Area { get; set; }
    public int Floor { get; set; }
    public double EstimatedPrice { get; set; }
    public double SalePrice { get; set; }
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
    public string RealtorLastName { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
    public string RealtorFirstName { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
    public string RealtorMiddleName { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
    public string ObjectType { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
    public double Rating { get; set; }
    public DateTime SaleDate { get; set; } // Добавляем свойство SaleDate
}

public class PropertyContext : DbContext
{
    public DbSet<Property> Properties { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=12345678;");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        using (var db = new PropertyContext())
        {
            
            var propertiesInRange = db.Properties
                .Where(p => p.District == "Кировский" && p.Price > 1000000 && p.Price < 2000000)
                .OrderByDescending(p => p.Price)
                .Select(p => new { p.Address, p.Area, p.Floor })
                .ToList();
var realtorsForTwoRooms = db.Properties
                .Where(p => p.Rooms == 2)
                .Select(p => p.RealtorLastName + " " + p.RealtorFirstName + " " + p.RealtorMiddleName)
                .Distinct()
                .ToList();

            var totalValueTwoRoomsInDistrict = db.Properties
                .Where(p => p.Rooms == 2 && p.District == "Ленинский")
                .Sum(p => p.Price);

            var minMaxPriceByRealtor = db.Properties
                .Where(p => p.RealtorLastName == "Иванов")
                .Select(p => new { MaxPrice = p.Price, MinPrice = p.Price })
                .FirstOrDefault();

            var avgRatingApartmentsByRealtor = db.Properties
                .Where(p => p.ObjectType == "апартаменты" && p.RealtorLastName == "Иванов")
                .Average(p => p.Rating);

            var countPropertiesByFloorAndDistrict = db.Properties
                .Where(p => p.Floor == 2)
                .GroupBy(p => p.District)
                .Select(g => new { District = g.Key, Count = g.Count() })
                .ToList();

            var countApartmentsByRealtor = db.Properties
                .Where(p => p.ObjectType == "квартира")
                .GroupBy(p => p.RealtorLastName)
                .Select(g => new { Realtor = g.Key, Count = g.Count() })
                .ToList();

            var topThreeExpensivePropertiesByDistrict = db.Properties
                .GroupBy(p => p.District)
                .Select(g => g.OrderByDescending(p => p.Price).ThenBy(p => p.Floor).Take(3))
                .ToList();

            var yearsWithMoreThanTwoPropertiesSoldByRealtor = db.Properties
                .GroupBy(p => p.RealtorLastName)
                .Where(g => g.Count() > 2)
                .Select(g => new { Realtor = g.Key, Years = g.Select(p => p.SaleDate.Year).Distinct() })
                .ToList();

            var yearsWithTwoToThreeProperties = db.Properties
                .GroupBy(p => p.SaleDate.Year)
                .Where(g => g.Count() >= 2 && g.Count() <= 3)
                .Select(g => g.Key)
                .ToList();

            var propertiesWithClosePrices = db.Properties
                .Where(p => (p.EstimatedPrice - p.SalePrice) / p.EstimatedPrice <= 0.2)
                .Select(p => new { Address = p.Address, District = p.District })
                .ToList();

            var apartmentsWithPricePerSquareMeterBelowDistrictAvg = db.Properties
                .Where(p => p.ObjectType == "квартира")
                .GroupBy(p => p.District)
                .Select(g => new { District = g.Key, AvgPricePerSqMeter = g.Average(p => p.Price / p.Area) })
                .ToList();

            var realtorsWithNoSalesThisYear = db.Properties
                .GroupBy(p => p.RealtorLastName)
                .Where(g => !g.Any(p => p.SaleDate.Year == DateTime.Now.Year))
                .Select(g => g.Key)
                .ToList();

            var salesByDistrict = db.Properties
                .GroupBy(p => p.District)
                .Select(g => new
                {
                    District = g.Key,
                    Year2022 = g.Count(p => p.SaleDate.Year == 2022),
                    Year2023 = g.Count(p => p.SaleDate.Year == 2023),
                    PercentChange = ((double)g.Count(p => p.SaleDate.Year == 2023) - g.Count(p => p.SaleDate.Year == 2022)) / g.Count(p => p.SaleDate.Year == 2022) * 100
                })
                .ToList();

            var criteriaAverageRating = db.Properties
                .GroupBy(p => p.District) // Изменяем группировку на основе района
                .Select(g => new
                {
                    District = g.Key, // Изменяем District на ключ группировки
                    AverageRating = g.Average(p => p.Rating) // Изменяем Criteria на Rating
                })
                .ToList();
foreach (var item in criteriaAverageRating)
            {
                string text;
                if (item.AverageRating >= 90)
                    text = "превосходно";
                else if (item.AverageRating >= 80)
                    text = "очень хорошо";
                else if (item.AverageRating >= 70)
                    text = "хорошо";
                else if (item.AverageRating >= 60)
                    text = "удовлетворительно";
                else
                    text = "неудовлетворительно";

                Console.WriteLine($"Район: {item.District}, Средняя оценка: {item.AverageRating}, Текст: {text}");
            }
        }
    }
}