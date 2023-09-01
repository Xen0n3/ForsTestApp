using ForsTestApp.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
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
            if(isCorrectTime==false) 
            {
                Console.WriteLine("Время введено некорректно. Просьба ввести заново.");
                return false;
            }
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
        public static bool ChooseOutputStep(out TimeSpan dataSourceStepChoose)
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
                dataSourceStepChoose = new TimeSpan(1,0,0);
                return true;
            }
            else if (dataSourceStepNumber.Key == ConsoleKey.D2)
            {
                Console.WriteLine("Успешно выбран: двухчасовой шаг");
                dataSourceStepChoose = new TimeSpan(2, 0, 0);
                return true;
            }
            else if (dataSourceStepNumber.Key == ConsoleKey.D3)
            {
                Console.WriteLine("Успешно выбран: шестичасовой шаг");
                dataSourceStepChoose = new TimeSpan(6, 0, 0);
                return true;
            }
            else if (dataSourceStepNumber.Key == ConsoleKey.D4)
            {
                Console.WriteLine("Успешно выбран: двеннадцатичасовой шаг");
                dataSourceStepChoose = new TimeSpan(12, 0, 0);
                return true;
            }
            else if (dataSourceStepNumber.Key == ConsoleKey.D1)
            {
                Console.WriteLine("Успешно выбран: суточный шаг");
                dataSourceStepChoose = new TimeSpan(24, 0, 0);
                return true;
            }
            else
            {
                Console.WriteLine("Неверно введен номер источника данных. Просьба ввести заново.");
                dataSourceStepChoose = new TimeSpan(0,0,0);
                return false;
            }
        }
        
       
        //заведем словарь (dictionary) в котором будет храниться слово как ключ название колонки, а значением ширина колонки
        //иду по колонке, ищу максимальное длинное слово(название колонки тоже имеет значение!)
        //нашел максимальное длинное слово, для него делаю 5 отступов, для остальных же слов разница длинны слов +5 пробелов;
        //
        /// <summary>
        /// вывод данных в виде таблицы в консоль
        /// </summary>
        /// <param name="table">таблица с данными для вывода</param>
        public static void PrintTable(DataTable table)
        {
            //List<string> id = new List<string>();
            //List<string> dateWrite = new List<string>();
            //List<string> dateCheck = new List<string>();
            //List <string> temperature = new List<string>();
            //List<string> pressure = new List<string>();
            //List <string> humidity = new List<string>();
            //List <string> precipitation = new List<string>();
            //List<string> blackIce = new List<string>();
            //List <string> radiation = new List<string>();
            //List <string> radiatonDanger = new List<string>();
            //List <string> dtpProbability = new List<string>();
            //for(int i = 0; i < table.Columns.Count; i++) 
            //{
            //    id[i] = table.Columns[1].ColumnName
            //    dateWrite[i] = table.Columns[2].ColumnName;
            //    dateCheck[i] = table.Columns[3].ColumnName;
            //    temperature[i] = table.Columns[4].ColumnName;
            //    pressure[i] = table.Columns[5].ColumnName;
            //    humidity[i] = table.Columns[6].ColumnName;
            //    precipitation[i] = table.Columns[7].ColumnName;
            //    blackIce[i] = table.Columns[8].ColumnName;
            //    radiation[i] = table.Columns[9].ColumnName;
            //    radiatonDanger[i] = table.Columns[10].ColumnName;
            //    dtpProbability[i]= table.Columns[11].ColumnName;

            //}

            Dictionary<string,int> dict = new Dictionary<string,int>();
            foreach (DataColumn column in table.Columns) 
            {
                var lenght = column.ColumnName.Length;
                foreach (DataRow row in table.Rows)
                {
                    int fieldLength = row.Field<object>(column).ToString().Length;
                    if (fieldLength > lenght)
                    {
                        lenght = fieldLength;
                    }
                }
                dict.Add(column.ColumnName, lenght+3);
            }
            
            Console.WriteLine(table.TableName);
            foreach(DataColumn column in table.Columns)
            {
                Console.Write(column.ColumnName);
                Console.Write(new string(' ', dict[column.ColumnName]-column.ColumnName.Length));
            }
            Console.WriteLine();
            foreach(DataRow row in table.Rows)
            {
                foreach(DataColumn column in table.Columns)
                {
                    Console.Write(row.Field<object>(column).ToString());
                    Console.Write(new string(' ', dict[column.ColumnName]- row.Field<object>(column).ToString().Length));
                    
                }
                Console.WriteLine();
            }
        }
    }
}
