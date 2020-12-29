using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestWebDriverAdvanced.po
{
    class Page_NewProduct
    {
        private IWebDriver driver;

        public Page_NewProduct(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement ProductName => driver.FindElement(By.Id("ProductName"));
        private IWebElement CategoryId => driver.FindElement(By.Id("CategoryId"));
        private IWebElement SupplierId => driver.FindElement(By.Id("SupplierId"));
        private IWebElement UnitPrice => driver.FindElement(By.Id("UnitPrice"));
        private IWebElement QuantityPerUnit => driver.FindElement(By.Id("QuantityPerUnit"));
        private IWebElement UnitsInStock => driver.FindElement(By.Id("UnitsInStock"));
        private IWebElement UnitsOnOrder => driver.FindElement(By.Id("UnitsOnOrder"));
        private IWebElement ReorderLevel => driver.FindElement(By.Id("ReorderLevel"));
        private IWebElement Discontinued => driver.FindElement(By.Id("Discontinued"));
        private IWebElement Findbtn => driver.FindElement(By.CssSelector(".btn"));

        public void TestNewProduct(string productname, string Category, string Supplier, string Price, string Quantity, string InStock, string OnOrder, string Reorder)
        {
            new Actions(driver).SendKeys(ProductName, productname).Build().Perform();
            new Actions(driver).SendKeys(CategoryId, Category).Build().Perform();
            new Actions(driver).SendKeys(SupplierId, Supplier).Build().Perform();
            new Actions(driver).SendKeys(UnitPrice, Price).Build().Perform();
            new Actions(driver).SendKeys(QuantityPerUnit, Quantity).Build().Perform();
            new Actions(driver).SendKeys(UnitsInStock, InStock).Build().Perform();
            new Actions(driver).SendKeys(UnitsOnOrder, OnOrder).Build().Perform();
            new Actions(driver).SendKeys(ReorderLevel, Reorder).Build().Perform();
            new Actions(driver).MoveToElement(Discontinued).Click(Discontinued).Build().Perform();
            new Actions(driver).MoveToElement(Findbtn).Click(Findbtn).Build().Perform();
        }
    }
}
