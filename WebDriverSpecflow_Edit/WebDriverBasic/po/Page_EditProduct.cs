using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestWebDriverAdvanced.po
{
    class Page_EditProduct
    {
        private IWebDriver driver;

        public Page_EditProduct(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement CheckProductName => driver.FindElement(By.XPath("//input[@id=\"ProductName\"]"));
        private IWebElement CheckCategory => driver.FindElement(By.XPath("//*[@id=\"CategoryId\"]/option[2]"));
        private IWebElement CheckSupplier => driver.FindElement(By.XPath("//*[@id=\"SupplierId\"]/option[2]"));
        private IWebElement CheckUnitPrice => driver.FindElement(By.Id("UnitPrice"));
        private IWebElement CheckQuantityPerUnit => driver.FindElement(By.Id("QuantityPerUnit"));
        private IWebElement CheckUnitsInStock => driver.FindElement(By.Id("UnitsInStock"));
        private IWebElement CheckUnitsOnOrder => driver.FindElement(By.Id("UnitsOnOrder"));
        private IWebElement CheckReorderLevel => driver.FindElement(By.Id("ReorderLevel"));
        private IWebElement CheckDiscontinued => driver.FindElement(By.XPath("//*[@type=\"checkbox\"]"));
        private IWebElement Closeform => driver.FindElement(By.XPath("//h2"));

        public string ProductName()
        {
            return CheckProductName.GetAttribute("value");
        }
        public string Category()
        {
            return CheckCategory.Text;
        }
        public string Supplier()
        {
            return CheckSupplier.Text;
        }
        public string UnitPrice()
        {
            return CheckUnitPrice.GetAttribute("value");
        }
        public string QuantityPerUnit()
        {
            return CheckQuantityPerUnit.GetAttribute("value");
        }
        public string UnitsInStock()
        {
            return CheckUnitsInStock.GetAttribute("value");
        }
        public string UnitsOnOrder()
        {
            return CheckUnitsOnOrder.GetAttribute("value");
        }
        public string ReorderLevel()
        {
            return CheckReorderLevel.GetAttribute("value");
        }
        public string Discontinued()
        {
            return CheckDiscontinued.GetAttribute("checked");
        }

        public string Closeformedit()
        {

            return Closeform.Text;
        }
    }
}
