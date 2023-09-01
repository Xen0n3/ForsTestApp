using ForsTestApp.TableSettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ForsTestApp.Tables
{
    public class HistoryTable : DataTable, ITable
    {
        public HistoryTable(ITableSetting tableSetting)
        {
            TableSetting = tableSetting;
            if (tableSetting is HistoryTableSetting historyTableSetting)
            {
                _tableSetting = historyTableSetting;
                TableName = "Временная таблица";
                Columns.Add("Id", typeof(uint));
                Columns.Add("Время записи", typeof(DateTime));
                Columns.Add("Время измерения", typeof(DateTime));
                Columns.Add("Темп.", typeof(int));
                Columns.Add("Давл.", typeof(int));
                Columns.Add("Влажность", typeof(int));
                Columns.Add("Осадки", typeof(string));
                Columns.Add("Гололед", typeof(bool));
                Columns.Add("Рад. фон", typeof(double));
                Columns.Add("Опасн. рад. фона", typeof(bool));
                Columns.Add("Вероятность ДТП", typeof(string));
            }
        }
        public ITableSetting TableSetting { get; set; }
        private HistoryTableSetting _tableSetting;
        public void Fill(DataTable data)
        {
            //план такой:пробегаемся циклом for(i=начальное время; i<=конечное время;i++ c заданным шагом)
            //по ровному времени (допустим i=10:00:00), тогда цикл будет i=10:00:00,потом i=11:00:00, i=12:00:00 и т д;
            //теперь для каждого ровного времени пробегаемся по нашей тестовой таблице и ищем ту строчку, у которой модуль разницы с ровным временем 
            //будет наименьшим. Выводим эту строчку. Идем к следующему ровному времени, ищем максимально близкую строчку, выводим ее и т д.

            //берем все значения < текущего dateTime и выбираем наибольшее.
            //DateTime? dateTimeStart = (DateTime?)data.Rows[0].ItemArray[1];
            int index = 0;
            for (DateTime dateTime = _tableSetting.StartDateTime; dateTime <= _tableSetting.EndDateTime; dateTime += _tableSetting.DataStep)
            {
                DataRow sourceRow = data.Rows[0];
                for (int i = index; i < data.Rows.Count; i++)
                {
                    if (data.Rows[i].Field<DateTime?>("Время измерения") <= dateTime)
                    {
                        sourceRow = data.Rows[i];
                        continue;
                    }
                    else
                    {
                        index = i;
                        break;
                    }

                }
                DataRow historyRow= this.NewRow();
                historyRow.SetField("Время записи", dateTime);
                FillRowFromSource(historyRow, sourceRow);
                Rows.Add(historyRow);
            }
        }

        public void FillRowFromSource(DataRow historyRow, DataRow sourceRow)
        {
            int points=0;
            historyRow.SetField("Id", sourceRow.Field<uint>("Id"));
            historyRow.SetField("Время измерения", sourceRow.Field<DateTime?>("Время измерения"));
            historyRow.SetField("Темп.", sourceRow.Field<int>("Темп."));
            historyRow.SetField("Давл.", sourceRow.Field<int>("Давл."));
            historyRow.SetField("Влажность", sourceRow.Field<int>("Влажность"));
            historyRow.SetField("Осадки", sourceRow.Field<string>("Осадки"));
            historyRow.SetField("Гололед", sourceRow.Field<bool>("Гололед"));
            historyRow.SetField("Рад. фон", sourceRow.Field<double>("Рад. фон"));
            if (sourceRow.Field<bool>("Гололед"))
            {
                points += 1;
            }
            if (sourceRow.Field<int>("Влажность") > 90)
            {
                points += 1;
            }
            if (sourceRow.Field<string>("Осадки")!="Нет")
            {
                points += 1;
            }

            if (sourceRow.Field<double>("Рад. фон") > 1.2)
            {
                historyRow.SetField("Опасн. рад. фона",true);
            }
            else
            {
                historyRow.SetField("Опасн. рад. фона", false);
            }

            if (points == 0)
            {
                historyRow.SetField("Вероятность ДТП", "Умеренная");

            }
            if(points == 1)
            {
                historyRow.SetField("Вероятность ДТП", "Повышенная");
            }
            if (points == 2)
            {
                historyRow.SetField("Вероятность ДТП", "Высокая");
            }
            if (points == 3)
            {
                historyRow.SetField("Вероятность ДТП", "Очень высокая");
            }

        }
    }
}
