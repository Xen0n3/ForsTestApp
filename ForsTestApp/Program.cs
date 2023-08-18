
using ForsTestApp.DataSources;
using ForsTestApp.Tables;
using System.Data;

TestDataSource dataSource = new TestDataSource();
DataTable data = dataSource.GetData(DateTime.Now,DateTime.Now);
HistoryTable historyTable = new HistoryTable();
historyTable.Fill(data);
//data.Rows.Find()

