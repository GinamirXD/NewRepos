namespace LinQ2
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            Console.WriteLine("task 7******");
            Console.WriteLine();
            int K = 12345;

            List<(int Duration, int Year, int Month, int Client)> data = new List<(int, int, int, int)>
            {
                (321, 2021, 1, 12345),
                (123, 2021, 2, 12345),
                (450, 2021, 3, 12345),
                (342, 2021, 4, 12345),
                (173, 2022, 2, 12345),
                (472, 2022, 3, 12345),
                (796, 2022, 4, 12345),
                (172, 2023, 1, 12345),
                (124, 2023, 2, 54321),
                (333, 2023, 3, 12345),
                (320, 2023, 4, 12345),
            };

            var query = from d in data
                        where d.Client == K
                        group d by d.Year into g
                        orderby g.Key descending
                        select new
                        {
                            Year = g.Key,
                            Month = g.OrderByDescending(x => x.Duration).ThenBy(x => x.Month).First().Month,
                            Duration = g.OrderByDescending(x => x.Duration).ThenBy(x => x.Month).First().Duration
                        };

            if (query.Count() == 0)
            {
                Console.WriteLine("Нет данных");
            }
            else
            {
                foreach (var item in query)
                {
                    Console.WriteLine("{0} {1} {2}", item.Year, item.Month, item.Duration);
                }
            }
            Console.WriteLine();
            Console.WriteLine("task 17******");
            Console.WriteLine();

            List<string> students = new List<string> 
            {
            "1 2022 Иванов",
            "2 2022 Петров",
            "3 2022 Сидоров",
            "2 2021 Кузнецов",
            "1 2021 Смирнов",
            "3 2021 Козлов",
            "4 2021 Новиков",
            "1 2020 Иванов",
            "2 2020 Петров",
            "4 2020 Сидоров",
            "3 2020 Кузнецов",
            "2 2020 Смирнов",
            "1 2019 Козлов",
            "3 2019 Новиков"
            };


            var result = students.GroupBy(
                s => s.Split(' ')[1],
                (year, schools) => new
                {
                    Year = year,
                    Count = schools.Select(s => s.Split(' ')[0]).Distinct().Count()
                })
                .OrderBy(x => x.Count);


            foreach (var r in result)
            {
                Console.WriteLine($"{r.Count} {r.Year}");
            }
            Console.WriteLine();
            Console.WriteLine("task 37******");
            Console.WriteLine();

            List<string> gasStations = new List<string>()
            {
                "Gazprom 92 45000 Moskovskaya",
                "Lukoil 95 48000 Nevsky",
                "Rosneft 92 44500 Liteyny",
                "TNK 98 52000 Moskovskaya",
                "Gazprom 95 47000 Liteyny"
            };

            var minMaxPrices = from gasStation in gasStations
                               let parts = gasStation.Split(' ')
                               let company = parts[0]
                               let gasolineType = int.Parse(parts[1])
                               let price = int.Parse(parts[2])
                               group new { gasolineType, price } by gasolineType into gasolineTypeGroup
                               select new
                               {
                                   GasolineType = gasolineTypeGroup.Key,
                                   MinPrice = gasolineTypeGroup.Min(x => x.price),
                                   MaxPrice = gasolineTypeGroup.Max(x => x.price)
                               };

            foreach (var item in minMaxPrices.OrderByDescending(x => x.GasolineType))
            {
                Console.WriteLine($"{item.GasolineType} {item.MinPrice} {item.MaxPrice}");
            }
            Console.WriteLine();
            Console.WriteLine("task 47******");
            Console.WriteLine();

            List<GasStation> gasStations1 = new List<GasStation>()
        {
            new GasStation() { Price = 500, Company = "Gazprom", Street = "Lenina", GasolineType = 92 },
            new GasStation() { Price = 510, Company = "Gazprom", Street = "Lenina", GasolineType = 95 },
            new GasStation() { Price = 520, Company = "Gazprom", Street = "Pobedy", GasolineType = 92 },
            new GasStation() { Price = 530, Company = "Lukoil", Street = "Pobedy", GasolineType = 98 },
            new GasStation() { Price = 540, Company = "Lukoil", Street = "Sovetskaya", GasolineType = 92 },
            new GasStation() { Price = 550, Company = "Lukoil", Street = "Sovetskaya", GasolineType = 95 },
            new GasStation() { Price = 560, Company = "Rosneft", Street = "Sovetskaya", GasolineType = 92 },
            new GasStation() { Price = 570, Company = "Rosneft", Street = "Pobedy", GasolineType = 95 },
            new GasStation() { Price = 580, Company = "Rosneft", Street = "Lenina", GasolineType = 98 }
        };

            var _result = gasStations1.GroupBy(
                    gs => new { gs.Company, gs.Street },
                    gs => gs.GasolineType)
                .Select(g => new { g.Key.Company, g.Key.Street, NumGasolineTypes = g.Select(gt => gt).Distinct().Count() })
                .Where(g => g.NumGasolineTypes >= 2)
                .OrderBy(g => g.Company)
                .ThenBy(g => g.Street);

            foreach (var group in _result)
            {
                Console.WriteLine($"{group.Company} {group.Street} {group.NumGasolineTypes}");
            }

            if (!_result.Any())
            {
                Console.WriteLine("Нет");
            }
            Console.WriteLine();
            Console.WriteLine("Task 57**********");
            Console.WriteLine();

            List<string> students1 = new List<string>()
        {
            "1 Иванов И.И. 60 40 40",
            "1 Петров П.П. 40 70 90",
            "1 Сидоров С.С. 20 30 20",
            "2 Козлов К.К. 40 50 60",
            "2 Смирнова О.В. 20 30 50",
            "3 Иванова Е.А. 20 30 40",
            "3 Петрова О.С. 10 20 30",
            "3 Сидорова А.В. 40 50 60",
            "3 Федорова Н.С. 30 40 50"
        };

            var result1 = students1
                .Select(s => s.Split())
                .GroupBy(s => s[0])
                .Select(g => new
                {
                    School = g.Key,
                    Students = g.Where(s =>
                        int.Parse(s[3]) < 50 &&
                        int.Parse(s[4]) < 50 &&
                        int.Parse(s[5]) < 50)
                        .OrderBy(s => s[1])
                        .ThenBy(s => s[2])
                        .Take(3)
                })
                .Where(g => g.Students.Any())
                .OrderBy(g => g.School);

            if (result1.Any())
            {
                foreach (var group in result1)
                {
                    Console.WriteLine($"Школа {group.School}");

                    foreach (var student in group.Students)
                    {
                        Console.WriteLine($"{student[1]} {student[2]} {student[3]} {student[4]} {student[5]}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Требуемые учащиеся не найдены");
            }
            Console.WriteLine();
            Console.WriteLine("Task 67**********");
            Console.WriteLine();

            List<object[]> marks = new List<object[]>()
            {
                new object[] { 10, "Алгебра", "Кузнецов", "И.А.", 4 },
                new object[] { 11, "Геометрия", "Петров", "П.П.", 3 },
                new object[] { 9, "Алгебра", "Сидоров", "С.С.", 2 },
                new object[] { 11, "Информатика", "Петров", "П.П.", 2 },
                new object[] { 11, "Алгебра", "Петров", "П.П.", 2 },
                new object[] { 9, "Геометрия", "Смирнов", "С.И.", 5 },
                new object[] { 11, "Алгебра", "Иванов", "И.И.", 2 }
            };

            var result2 = from mark in marks
                         where (int)mark[4] == 2
                         group mark by new { ClassNumber = (int)mark[0], Surname = (string)mark[2], Initials = (string)mark[3] } into g
                         orderby g.Key.ClassNumber descending, g.Key.Surname, g.Key.Initials
                         select new
                         {
                             ClassNumber = g.Key.ClassNumber,
                             Surname = g.Key.Surname,
                             Initials = g.Key.Initials,
                             TwosCount = g.Count()
                         };

            if (result2.Any())
            {
                Console.WriteLine("Номер класса\tФамилия и инициалы\tКоличество двоек");
                foreach (var item in result2)
                {
                    Console.WriteLine($"{item.ClassNumber}\t\t{item.Surname} {item.Initials}\t\t{item.TwosCount}");
                }
            }
            else
            {
                Console.WriteLine("Требуемые учащиеся не найдены");
            }

            Console.WriteLine();
            Console.WriteLine("Task 77**********");
            Console.WriteLine();

            List<(string category, string article, string country)> B = new List<(string, string, string)>
            {
                ("Электроника", "A123", "Китай"),
                ("Электроника", "B456", "США"),
                ("Одежда", "C789", "Италия"),
                 ("Косметика", "D012", "Франция"),
                ("Одежда", "E345", "Франция"),
                ("Электроника", "F678", "Япония")
            };

            List<(string article, decimal price, string store)> D = new List<(string, decimal, string)>
            {
               ("A123", 10000, "Магазин1"),
               ("B456", 15000, "Магазин1"),
               ("C789", 5000, "Магазин2"),
               ("D012", 2000, "Магазин3"),
               ("E345", 7000, "Магазин2"),
               ("F678", 12000, "Магазин1")
            };

            var query2 = from b in B
                        join d in D on b.article equals d.article
                        group b by b.category into g
                        orderby g.Select(x => x.country).Distinct().Count() descending, g.Key
                        select new { Category = g.Key, StoreCount = g.Select(x => x.country).Distinct().Count() };

            foreach (var item in query2)
            {
                Console.WriteLine($"{item.StoreCount} {item.Category} {item.StoreCount}");
            }

            Console.WriteLine();
            Console.WriteLine("Task 87**********");
            Console.WriteLine();

            var aList = new List<(int, string, int)> { (1990, "ул. А", 123), (2000, "ул. Б", 456), (1985, "ул. А", 789) };
            var dList = new List<(int, string, decimal)> { (123, "магазин 1", 100.50m), (456, "магазин 2", 50.75m), (789, "магазин 1", 75.30m) };
            var eList = new List<(string, int, int)> { ("магазин 1", 123, 10), ("магазин 2", 456, 20), ("магазин 1", 789, 30) };

            var joinedList = from a1 in aList
                             join e1 in eList on a1.Item3 equals e1.Item2
                             join d1 in dList on new { e1.Item1, e1.Item3 } equals new { d1.Item2, d1.Item1 }
                             select new { a1.Item2, d1.Item2, d1.Item3 };

            var grouped = from j in joinedList
                          group j by new { j.Item1, j.Item2 } into g
                          select new { g.Key.Item1, g.Key.Item2, Total = g.Sum(x => x.Item3) };

            var ordered = grouped.OrderBy(g => g.Item1).ThenBy(g => g.Item2);

            foreach (var g in ordered)
            {
                Console.WriteLine($"{g.Item1} {g.Item2} {g.Total}");
            }


           /* Console.WriteLine();
            Console.WriteLine("Task 97**********");
            Console.WriteLine();

            List<string> bList = new List<string> { "A 123 RU", "B 456 US", "C 789 RU" };
            List<string> cList = new List<string> { "10 Shop1 123", "20 Shop2 456" };
            List<string> dList = new List<string> { "100 Shop1 123", "200 Shop2 456", "300 Shop3 789" };
            List<string> eList = new List<string> { "Shop1 123 100", "Shop2 456 200" };

            var results = from b in bList
                          let bSplit = b.Split(' ')
                          let category = bSplit[0]
                          let article = bSplit[1]
                          let country = bSplit[2]
                          join d in dList
                          on article equals d.Split(' ')[2]
                          into joinedBAndD
                          from bd in joinedBAndD.DefaultIfEmpty()
                          where bd != null
                          let dSplit = bd.Split(' ')
                          let price = int.Parse(dSplit[0])
                          let store = dSplit[1]
                          join c in cList
                          on store equals c.Split(' ')[1]
                          into joinedBAndC
                          from bc in joinedBAndC.DefaultIfEmpty()
                          where bc != null
                          let cSplit = bc.Split(' ')
                          let discount = int.Parse(cSplit[0])
                          let customer = cSplit[2]
                          join e in eList
                          on article equals e.Split(' ')[2]
                          into joinedAll
                          from all in joinedAll.DefaultIfEmpty()
                          where all != null
                          let eSplit = all.Split(' ')
                          let customerId = eSplit[1]
                          let itemTotalPrice = price * (100 - discount) / 100
                          group itemTotalPrice by new { Country = country, CustomerId = customerId } into g
                          select new
                          {
                              g.Key.Country,
                              g.Key.CustomerId,
                              TotalPrice = g.Sum()
                          };

            foreach (var r in results)
            {
                Console.WriteLine($"{r.Country} {r.CustomerId} {r.TotalPrice}");
            }
           */
        }
    }
}