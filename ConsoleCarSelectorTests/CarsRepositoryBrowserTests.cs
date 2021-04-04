using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleCarSelector;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCarSelector.Tests
{
    [TestClass]
    public class CarsRepositoryBrowserTests
    {
        [TestMethod()]
        public void FindCarsByPriceAndDescriptionTest()
        {
            try
            {
                var browser = new CarsRepositoryBrowser(
                    new CarRepository("ab.onliner.by"), 500);
                Assert.IsInstanceOfType(
                    browser.FindCarsByPriceAndDescription(1000, 3000, "USD", "техосмотр"),
                    typeof(string));
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}