using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

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

        public void ToEditProduct(string productname)
        {
            driver.FindElement(By.LinkText(productname)).Click();
        }

        public string CloseFormEdit()
        {
            return CloseForm.Text;
        }

        public void ToRemoveProduct(string productname)
        {
            driver.FindElement(By.XPath(String.Format("//*[a[text()=\"{0}\"]]/following-sibling::*[10]/a[text()=\"Remove\"]", productname))).Click();
            driver.SwitchTo().Alert().Accept();
        }

        public Boolean ProductIsRemove(string productname)
        {
            try
            {
                WebDriverWait pr = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                pr.Until(ExpectedConditions.InvisibilityOfElementLocated(By.LinkText(productname)));
                return driver.FindElement(By.LinkText(productname)).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
