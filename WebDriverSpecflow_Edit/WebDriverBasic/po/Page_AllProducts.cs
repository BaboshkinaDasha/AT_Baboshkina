using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using WebDriverFramework.business_objects;

namespace TestWebDriverAdvanced.po
{
    class Page_AllProducts
    {
        private IWebDriver driver;

        public Page_AllProducts(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement NewProduct => driver.FindElement(By.LinkText("Create new"));
        private IWebElement EditProduct => driver.FindElement(By.LinkText("Fanta"));
        private IWebElement CloseForm => driver.FindElement(By.XPath("//h2"));
        private IWebElement RemoveProduct => driver.FindElement(By.XPath("//*[a[text()=\"Fanta\"]]/following-sibling::*[10]/a[text()=\"Remove\"]"));


        public void ToNewProduct()
        {
            new Actions(driver).MoveToElement(NewProduct).Click(NewProduct).Build().Perform();
        }

        public void ToEditProduct(Product prod1)
        {
            driver.FindElement(By.LinkText(prod1.ProductName)).Click();
        }

        public string CloseFormEdit()
        {
            return CloseForm.Text;
        }

        public void ToRemoveProduct()
        {
            new Actions(driver).MoveToElement(RemoveProduct).Click(RemoveProduct).Build().Perform();
            driver.SwitchTo().Alert().Accept();
        }

        public bool FindProduct(string productname)
        {
            return driver.FindElements(By.LinkText(productname)).Count != 0;
        }
    }
}
