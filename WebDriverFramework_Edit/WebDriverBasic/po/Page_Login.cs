using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WebDriverFramework.business_objects;

namespace TestWebDriverAdvanced.po
{
    class Page_Login
    {
        private IWebDriver driver;

        public Page_Login(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement Findname => driver.FindElement(By.Id("Name"));
        private IWebElement Findpassword => driver.FindElement(By.Id("Password"));
        private IWebElement Findbtn => driver.FindElement(By.CssSelector(".btn"));
        private IWebElement FindLogin => driver.FindElement(By.XPath("//h2"));

        public void TestLogin(User user)
        {
            new Actions(driver).SendKeys(Findname, user.Name).Build().Perform();
            new Actions(driver).SendKeys(Findpassword, user.Password).Build().Perform();
            new Actions(driver).MoveToElement(Findbtn).Click(Findbtn).Build().Perform();
        }

        public string ToFindLogin()
        {
            return FindLogin.Text;
        }
    }
}
