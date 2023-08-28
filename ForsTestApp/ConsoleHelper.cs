using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForsTestApp
{
    public static class ConsoleHelper
    {
        public static bool ChooseDataSource(out int dataSourceChoose)
        {
            Console.WriteLine("Выберите источник данных:");
            Console.WriteLine("1) Тестовый источник данных");
            Console.WriteLine("2) Источник данных Xml");

            ConsoleKeyInfo dataSourceNumber = Console.ReadKey();
            Console.WriteLine();

            if (dataSourceNumber.Key == ConsoleKey.D1)
            {
                Console.WriteLine("Успешно выбран: тестовый источник данных");
                dataSourceChoose = 1;
                return true;
            }
            else if (dataSourceNumber.Key == ConsoleKey.D2)
            {
                Console.WriteLine("Успешно выбран: источник данных Xml");
                dataSourceChoose = 2;
                return true;
            }
            else
            {
                Console.WriteLine("Неверно введен номер источника данных. Просьба ввести заново.");
                dataSourceChoose = 0;
                return false;
            }
        }
        public static bool ChooseDateTime(string chooseLine,ref DateTime dateTimeChoose)
        {
            Console.WriteLine(chooseLine);
            string? dateTimeString = Console.ReadLine();
            bool isCorrectTime = DateTime.TryParse(dateTimeString, out DateTime dateTime);
            dateTimeChoose = dateTime;
            return isCorrectTime;
        }
        public static bool ChooseDataTableType(out int dataSourceTypeChoose)
        {
            Console.WriteLine("Выберите тип таблицы:");
            Console.WriteLine("1) Временная");
            Console.WriteLine("2) Событийная");

            ConsoleKeyInfo dataSourceTypeNumber = Console.ReadKey();
            Console.WriteLine();

            if (dataSourceTypeNumber.Key == ConsoleKey.D1)
            {
                Console.WriteLine("Успешно выбрана: временная таблица");
                dataSourceTypeChoose = 1;
                return true;
            }
            else if (dataSourceTypeNumber.Key == ConsoleKey.D2)
            {
                Console.WriteLine("Успешно выбрана: истрическая таблица");
                dataSourceTypeChoose = 2;
                return true;
            }
            else
            {
                Console.WriteLine("Неверно введен номер выбранного типа таблицы. Просьба ввести заново.");
                dataSourceTypeChoose = 0;
                return false;
            }
        }
        public static bool ChooseOutputStep(out int dataSourceStepChoose)
        {
            Console.WriteLine("Выберите шаг заполнения данными:");
            Console.WriteLine("1) 1 час");
            Console.WriteLine("2) 2 часа");
            Console.WriteLine("3) 6 часов");
            Console.WriteLine("4) 12 часов");
            Console.WriteLine("5) 24 часа");
            ConsoleKeyInfo dataSourceStepNumber = Console.ReadKey();
            Console.WriteLine();
            if (dataSourceStepNumber.Key == ConsoleKey.D1)
            {
                Console.WriteLine("Успешно выбран: одночасовой шаг");
                dataSourceStepChoose = 1;
                return true;
            }
            else if (dataSourceStepNumber.Key == ConsoleKey.D2)
            {
                Console.WriteLine("Успешно выбран: двухчасовой шаг");
                dataSourceStepChoose = 2;
                return true;
            }
            else if (dataSourceStepNumber.Key == ConsoleKey.D3)
            {
                Console.WriteLine("Успешно выбран: шестичасовой шаг");
                dataSourceStepChoose = 3;
                return true;
            }
            else if (dataSourceStepNumber.Key == ConsoleKey.D4)
            {
                Console.WriteLine("Успешно выбран: двеннадцатичасовой шаг");
                dataSourceStepChoose = 4;
                return true;
            }
            else if (dataSourceStepNumber.Key == ConsoleKey.D1)
            {
                Console.WriteLine("Успешно выбран: суточный шаг");
                dataSourceStepChoose = 5;
                return true;
            }
            else
            {
                Console.WriteLine("Неверно введен номер источника данных. Просьба ввести заново.");
                dataSourceStepChoose = 0;
                return false;
            }
        }
    }
}
