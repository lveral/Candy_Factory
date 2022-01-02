using System;
using System.Collections.Generic;
using System.IO;

namespace Candy_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\ureki\Documents\GitHub\Candy_Factory\Candy_Factory\Orders.txt";
           
            int choise;
            bool stop = false;
            BoxCollection<Box> bxList = new BoxCollection<Box>();

            Logging log = new Logging("Console&File");
            log.Information("Start");
            bxList.Added += log.Information;

            Console.WriteLine("\n\nИнформация о собранных конфетах из файла:\n");
            bxList = ReadFromFile(log, path);
            Display(bxList);

            while (!stop)
            {
                try
                {
                    Flavor flavor = new Flavor();
                    Glaze glaze = new Glaze();
                    Wrapper wrapper = new Wrapper();

                    Console.WriteLine($"\nШаг №1 Выберите глазурь конфет:\n" +
                        $"1. Темный шоколад" +
                        $"\n2. Без глазури");
                    choise = Convert.ToInt32(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            glaze = new DarkChocolateGlaze();
                            break;
                        case 2:
                            glaze = new WithoutGlaze();
                            break;
                    }

                    Console.WriteLine($"Шаг №2 Выберите начинку(вкус) конфет:\n" +
                        $"1. Желе" +
                        $"\n2. Марципан" +
                        $"\n3. Пралине");
                    choise = Convert.ToInt32(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            flavor = new JellyFlavor();
                            break;
                        case 2:
                            flavor = new MarzipanFlavor();
                            break;
                        case 3:
                            flavor = new PralineFlavor();
                            break;
                    }

                    Console.WriteLine($"Шаг №3 Выберите обертку конфет:\n" +
                        $"1. Фольга" +
                        $"\n2. Бумага");
                    choise = Convert.ToInt32(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            wrapper = new FoilWrapper();
                            break;
                        case 2:
                            wrapper = new PaperWrapper();
                            break;
                    }
                    if (flavor.title == null || glaze.title == null || wrapper.title == null)
                    {
                        throw new NotCreatedCandy("Конфета не собрана. Некорректно введены данные данные.");
                    }
                    else
                    {
                        Candy candy = new Candy(flavor, glaze, wrapper);
                        candy.Created += log.Information;
                        candy.LogEntry();

                        Console.WriteLine($"Шаг №4 Введите количество конфет: ");
                        int count = Convert.ToInt32(Console.ReadLine());

                        if (count < 100)
                        {
                            throw new ZeroCandy("Нельзя добавить меньше 100 конфет.");
                        }
                        Box box = new Box(candy, count);

                        box.Created += log.Information;
                        box.LogEntry();

                        Console.WriteLine(box.GetInfoToString());

                        bxList.Add(box);

                        Console.WriteLine("\n\nСобрать ещё одну конфету?\n1.Да\n2.Нет\n");
                        choise = Convert.ToInt32(Console.ReadLine());
                        switch (choise)
                        {
                            case 2:
                                stop = true;
                                break;
                        }
                    }
                }
                catch(Exception ex)
                {
                    log.Error(ex.Message);
                }
            }

            Func<Box, Box, bool> Func1 = BoxCost;
            bxList.Sort(Func1);


            Console.WriteLine("\n\nИнформация о собранных конфетах:\n");
            Display(bxList);
            WriteToFile(bxList, path, log);
        }

        public static void Display(BoxCollection<Box> bxList)
        {
            foreach (Box bx in bxList)
            {
                Console.WriteLine(bx.GetInfoToString());
            }
        }

        public static bool BoxCost(Box bx1, Box bx2)
        {
            return bx1.GetCost() > bx2.GetCost();
        }

        public static BoxCollection<Box> ReadFromFile(Logging log,string path)
        {
            String line;
            BoxCollection<Box> orders = new BoxCollection<Box>();
            try
            {
                StreamReader sr = new StreamReader(path);
                line = sr.ReadLine();

                Flavor flavor = new Flavor();
                Glaze glaze = new Glaze();
                Wrapper wrapper = new Wrapper();
                int count;
                int cost;
                while (line != null)
                {
                    switch(line)
                    {
                        case "Начинка: Желе":
                            flavor = new JellyFlavor();
                            break;
                        case "Начинка: Пралине":
                            flavor = new PralineFlavor();
                            break;
                        case "Начинка: Марципан":
                            flavor = new MarzipanFlavor();
                            break;
                    }
                    line = sr.ReadLine();
                    switch (line)
                    {
                        case "Глазурь: Без глазури":
                            glaze = new WithoutGlaze();
                            break;
                        case "Глазурь: Темный шоколад":
                            glaze = new DarkChocolateGlaze();
                            break;
                    }
                    line = sr.ReadLine();
                    switch (line)
                    {
                        case "Упаковка: бумага":
                            wrapper = new PaperWrapper();
                            break;
                        case "Упаковка: фольга":
                            wrapper = new FoilWrapper();
                            break;
                    }
                    Candy candy = new Candy(flavor, glaze, wrapper);
                    line = sr.ReadLine();
                    count = Convert.ToInt32(line.Substring(11));
                    line = sr.ReadLine();
                    cost = Convert.ToInt32(line.Substring(11));
                    Box box = new Box(candy, count);
                    orders.Add(box);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            return orders;
        }

        public static void WriteToFile(BoxCollection<Box> bxList, string path, Logging log)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path);
                foreach (Box bx in bxList)
                {
                    sw.WriteLine(bx.GetInfoToString());
                }
                sw.Close();
                log.Information("Данные записаны в файл");
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
        }
    }
}
