using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForsTestApp.Tables
{
    public interface ITable
    {
        ITableSetting TableSetting { get; set; }
        void Fill(DataTable data);
    }
}
