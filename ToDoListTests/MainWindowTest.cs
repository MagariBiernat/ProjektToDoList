using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList;


namespace ToDoListTests
{
    [TestClass]
    public class MainWindowTest
    {
        [TestMethod]
        public void Create_Task_Query_Test()
        {
            MainWindow test = new MainWindow();
            DateTime ddt = DateTime.Now;
            DateTime stara_data = new DateTime(2017, 5, 12, 22, 15, 00);
            DateTime nowsza_data = new DateTime(2023, 5, 12, 22, 15, 00);

            int value = MainWindow.CompareDates(ddt, stara_data);
            int valuee = MainWindow.CompareDates(ddt, nowsza_data);

            Assert.AreNotEqual(value, valuee);

        }
        [TestMethod]
        public void Get_CompletedValue()
        {
            MainWindow test = new MainWindow();
            test.wynik = (test.temp / test.suma) * 100;
            test.CompletedValue = Convert.ToDecimal(Math.Round(test.wynik, 0));
            var wynik = Convert.ToDouble(test.CompletedValue);
            Assert.IsNotNull(wynik);

        }
    }
}
