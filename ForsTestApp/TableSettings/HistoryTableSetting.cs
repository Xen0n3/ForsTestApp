using ForsTestApp.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForsTestApp.TableSettings
{
    public class HistoryTableSetting : ITableSetting
    {
        public HistoryTableSetting(TimeSpan datastep, DateTime startDateTime, DateTime endDateTime)
        {
            DataStep = datastep;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }
        public TimeSpan DataStep { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }


    }
}
