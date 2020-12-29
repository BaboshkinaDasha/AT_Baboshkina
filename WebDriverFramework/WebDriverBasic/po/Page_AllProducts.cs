using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

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

        public void ToEditProduct()
        {
            new Actions(driver).MoveToElement(EditProduct).Click(EditProduct).Build().Perform();
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
    }
}
