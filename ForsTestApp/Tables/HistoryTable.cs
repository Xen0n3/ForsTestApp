using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForsTestApp.Tables
{
    public class HistoryTable:ITable
    {
        public ITableSetting TableSetting { get; set; }
        public List<Row> Rows { get; set; }
        public void Fill(DataTable data,DateTime startTime, DateTime endTime)
        {
            //план такой:пробегаемся циклом for(i=начальное время; i<=конечное время;i++ c заданным шагом)
            //по ровному времени (допустим i=10:00:00), тогда цикл будет i=10:00:00,потом i=11:00:00, i=12:00:00 и т д;
            //теперь для каждого ровного времени пробегаемся по нашей тестовой таблице и ищем ту строчку, у которой модуль разницы с ровным временем 
            //будет наименьшим. Выводим эту строчку. Идем к следующему ровному времени, ищем максимально близкую строчку, выводим ее и т д.
            DateTime? dateTimeStart = (DateTime?)data.Rows[0].ItemArray[1];

            for(DateTime i=startTime; i<=endTime; i++)
            {
                
            }

        }

    }
}
