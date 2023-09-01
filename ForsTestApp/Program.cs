
using ForsTestApp;
using ForsTestApp.DataSources;
using ForsTestApp.Tables;
using ForsTestApp.TableSettings;
using System.Data;



bool isCorrectDataSource = false;
while (!isCorrectDataSource)
{
    isCorrectDataSource = ConsoleHelper.ChooseDataSource(out int dataSourceNumber);

}

bool isCorrectStartTime = false;
DateTime startDateTimeChoose=DateTime.MinValue;
while (!isCorrectStartTime)
{
    isCorrectStartTime = ConsoleHelper.ChooseDateTime("Выберите дату начала(дд.мм.гггг чч:мм:сс):", ref startDateTimeChoose);
}

bool isCorrectEndTime = false;
DateTime endDateTimeChoose = DateTime.MinValue;
while (!isCorrectEndTime)
{
    isCorrectEndTime = ConsoleHelper.ChooseDateTime("Выберите дату окончания(дд.мм.гггг чч:мм:сс):", ref endDateTimeChoose);
}



bool isCorrectDataTableType = false;
int tableTypeChoose = 0;
while (!isCorrectDataTableType)
{
    isCorrectDataTableType = ConsoleHelper.ChooseDataTableType(out int dataSourceTypeChoose);
    tableTypeChoose = dataSourceTypeChoose;
}



if (tableTypeChoose == 1)
{
    bool isCorrectStepChoose = false;
    TimeSpan dataSourceStepChoose =new TimeSpan(0,0,0);
    while (!isCorrectStepChoose)
    {
        isCorrectStepChoose = ConsoleHelper.ChooseOutputStep(out dataSourceStepChoose);
    }
    HistoryTableSetting historyTableSetting = new HistoryTableSetting(dataSourceStepChoose,startDateTimeChoose,endDateTimeChoose);
    HistoryTable historyTable = new HistoryTable(historyTableSetting);
    TestDataSource dataSource = new TestDataSource();
    DataTable data = dataSource.GetData(startDateTimeChoose, endDateTimeChoose);
    historyTable.Fill(data);
    historyTable.TableName = "Временная таблица";
    ConsoleHelper.PrintTable(historyTable);
    //historyTablesetting.DataStep = dataSourceStepChoose;
}
else
{
    
    //Console.WriteLine("Выберите поле для начала события:");
    //Console.WriteLine("1) Температура");
    //Console.WriteLine("2) Давление");
    //Console.WriteLine("3) Влажность");
    //Console.WriteLine("4) Осадки");
    //Console.WriteLine("5) Гололед");
    //Console.WriteLine("6) Радиационный фон");
    //int ans5 = Console.Read();
    //Console.WriteLine("Выберите значение поле для начала события:");
    //string? ans6 = Console.ReadLine();
}

//data.Rows.Find()



