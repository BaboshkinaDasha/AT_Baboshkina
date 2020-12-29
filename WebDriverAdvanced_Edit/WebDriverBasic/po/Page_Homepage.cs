using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestWebDriverAdvanced.po
{
    class Page_Homepage
    {
        private IWebDriver driver;

        public Page_Homepage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement FindHomePage => driver.FindElement(By.XPath("//h2"));
        private IWebElement FindAllProducts => driver.FindElement(By.LinkText("All Products"));
        private IWebElement LogOut => driver.FindElement(By.LinkText("Logout"));

        public string FindHomePageIn()
        {
            return FindHomePage.Text;
        }

        public void ToAllProducts()
        {
            new Actions(driver).MoveToElement(FindAllProducts).Click(FindAllProducts).Build().Perform();
        }

        public void ToLogOut()
        {
            new Actions(driver).MoveToElement(LogOut).Click(LogOut).Build().Perform();
        }
    }
}
