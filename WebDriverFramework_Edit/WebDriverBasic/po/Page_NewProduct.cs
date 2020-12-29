using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WebDriverFramework.business_objects;

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

        public void TestNewProduct(Product product)
        {
            new Actions(driver).SendKeys(ProductName, product.ProductName).Build().Perform();
            new Actions(driver).SendKeys(CategoryId, product.CategoryId).Build().Perform();
            new Actions(driver).SendKeys(SupplierId, product.SupplierId).Build().Perform();
            new Actions(driver).SendKeys(UnitPrice, product.UnitPrice).Build().Perform();
            new Actions(driver).SendKeys(QuantityPerUnit, product.QuantityPerUnit).Build().Perform();
            new Actions(driver).SendKeys(UnitsInStock, product.UnitsInStock).Build().Perform();
            new Actions(driver).SendKeys(UnitsOnOrder, product.UnitsOnOrder).Build().Perform();
            new Actions(driver).SendKeys(ReorderLevel, product.ReorderLevel).Build().Perform();
            new Actions(driver).MoveToElement(Discontinued).Click(Discontinued).Build().Perform();
            new Actions(driver).MoveToElement(Findbtn).Click(Findbtn).Build().Perform();
        }
    }
}
