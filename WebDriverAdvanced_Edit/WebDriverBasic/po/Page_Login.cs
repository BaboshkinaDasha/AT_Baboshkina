using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

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

        public void TestLogin(string findname, string findpassword)
        {
            new Actions(driver).SendKeys(Findname, findname).Build().Perform();
            new Actions(driver).SendKeys(Findpassword, findpassword).Build().Perform();
            new Actions(driver).MoveToElement(Findbtn).Click(Findbtn).Build().Perform();
        }

        public bool ToFindLogin(string login)
        {
                WebDriverWait log = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                log.IgnoreExceptionTypes(typeof(NoSuchElementException));
                log.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(String.Format(("//h2"), login))));
                return driver.FindElement(By.XPath(String.Format(("//h2"), login))).Displayed;

        }
    }
}
