using ForsTestApp.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForsTestApp.DataSources
{
    internal class TestDataSource
    {
        public DataTable GetData(DateTime startTime, DateTime endTime)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Id", typeof(uint));
            dataTable.Columns.Add("Время измерения", typeof(DateTime));
            dataTable.Columns.Add("Температура", typeof(int));
            dataTable.Columns.Add("Давление", typeof(int));
            dataTable.Columns.Add("Влажность", typeof(int));
            dataTable.Columns.Add("Осадки", typeof(string));
            dataTable.Columns.Add("Гололед", typeof(bool));
            dataTable.Columns.Add("Радиационный фон", typeof(double));
            
            dataTable.Rows.Add(101, new DateTime(2022, 10, 15, 9, 52, 40), 2, 761, 95, "Ливень", true, 0.1);
            dataTable.Rows.Add(102, new DateTime(2022, 10, 15, 10, 22, 5), 3, 761, 95, "Дождь", true, 0.1);
            dataTable.Rows.Add(103, new DateTime(2022, 10, 15, 10, 58, 7), 4, 765, 90, "Дождь", true, 0.1);
            dataTable.Rows.Add(104, new DateTime(2022, 10, 15, 11, 31, 17), 6, 770, 80, "Нет", true, 0.1);
            dataTable.Rows.Add(105, new DateTime(2022, 10, 15, 12, 1, 54), 9, 761, 85, "Дождь", false, 0.1);
            dataTable.Rows.Add(106, new DateTime(2022, 10, 15, 12, 27, 26), 8, 761, 91, "Дождь", false, 0.1);
            dataTable.Rows.Add(107, new DateTime(2022, 10, 15, 13, 3, 35), 10, 754, 75, "Нет", false, 0.1);
            dataTable.Rows.Add(108, new DateTime(2022, 10, 15, 13, 40, 12), 10, 761, 70, "Нет", false, 0.1);
            dataTable.Rows.Add(109, new DateTime(2022, 10, 15, 14, 2, 31), 10, 761, 65, "Нет", false, 0.1);
            dataTable.Rows.Add(110, new DateTime(2022, 10, 15, 14, 38, 52), 11, 761, 60, "Нет", false, 0.1);
            dataTable.Rows.Add(111, new DateTime(2022, 10, 15, 15, 9, 40), 10, 751, 55, "Нет", false, 0.1);
            dataTable.Rows.Add(112, new DateTime(2022, 10, 15, 15, 39, 5), 11, 761, 50, "Нет", false, 0.1);
            dataTable.Rows.Add(113, new DateTime(2022, 10, 15, 16, 1, 7), 10, 753, 40, "Нет", false, 0.1);
            dataTable.Rows.Add(114, new DateTime(2022, 10, 15, 16, 34, 17), 11, 761, 30, "Нет", false, 0.1);
            dataTable.Rows.Add(115, new DateTime(2022, 10, 15, 16, 59, 54), 12, 761, 30, "Нет", false, 1.3);
            dataTable.Rows.Add(116, new DateTime(2022, 10, 15, 17, 28, 26), 10, 748, 35, "Дождь", false, 1.5);
            dataTable.Rows.Add(117, new DateTime(2022, 10, 15, 17, 58, 35), 11, 769, 40, "Нет", false, 1.4);
            dataTable.Rows.Add(118, new DateTime(2022, 10, 15, 18, 35, 12), 11, 761, 35, "Нет", false, 0.1);
            dataTable.Rows.Add(119, new DateTime(2022, 10, 15, 18, 52, 31), 10, 768, 30, "Нет", false, 0.1);

            return dataTable;


        }
    }
}
