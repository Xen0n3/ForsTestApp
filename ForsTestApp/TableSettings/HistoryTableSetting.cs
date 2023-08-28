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
        public TimeSpan DataStep { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }


    }
}
