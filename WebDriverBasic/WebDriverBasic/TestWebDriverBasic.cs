using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverBasic
{
    [TestFixture]
    public class TestWebDriverBasic
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();
        }

        [Test, Order(1)]
        public void Test1_Login()
        {
            driver.FindElement(By.Id("Name")).SendKeys("user");
            driver.FindElement(By.Id("Password")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            var FindHomePage = driver.FindElement(By.XPath("//h2")).Text;
            Assert.AreEqual("Home page", FindHomePage);
        }

        [Test, Order(2)]
        public void Test2_NewProduct()
        {
            driver.FindElement(By.LinkText("All Products")).Click();
            driver.FindElement(By.LinkText("Create new")).Click();
            driver.FindElement(By.Id("ProductName")).SendKeys("Fanta");
            driver.FindElement(By.Id("CategoryId")).SendKeys("Beverages");
            driver.FindElement(By.Id("SupplierId")).SendKeys("Exotic Liquids");
            driver.FindElement(By.Id("UnitPrice")).SendKeys("40");
            driver.FindElement(By.Id("QuantityPerUnit")).SendKeys("50");
            driver.FindElement(By.Id("UnitsInStock")).SendKeys("20");
            driver.FindElement(By.Id("UnitsOnOrder")).SendKeys("0");
            driver.FindElement(By.Id("ReorderLevel")).SendKeys("10");
            driver.FindElement(By.Id("Discontinued")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            var CloseForm = driver.FindElement(By.XPath("//h2")).Text;
            Assert.AreNotEqual("editing", CloseForm);
        }

        [Test, Order(3)]
        public void Test3_CheckProduct()
        {
            driver.FindElement(By.LinkText("Fanta")).Click();
            var CheckProductName = driver.FindElement(By.XPath("//input[@id=\"ProductName\"]")).GetAttribute("value");
            string CheckCategory = driver.FindElement(By.XPath("//*[@id=\"CategoryId\"]/option[2]")).Text;
            string CheckSupplier = driver.FindElement(By.XPath("//*[@id=\"SupplierId\"]/option[2]")).Text;
            string CheckUnitPrice = driver.FindElement(By.Id("UnitPrice")).GetAttribute("value");
            string CheckQuantityPerUnit = driver.FindElement(By.Id("QuantityPerUnit")).GetAttribute("value");
            string CheckUnitsInStock = driver.FindElement(By.Id("UnitsInStock")).GetAttribute("value");
            string CheckUnitsOnOrder = driver.FindElement(By.Id("UnitsOnOrder")).GetAttribute("value");
            string CheckReorderLevel = driver.FindElement(By.Id("ReorderLevel")).GetAttribute("value");
            string CheckDiscontinued = driver.FindElement(By.XPath("//*[@type=\"checkbox\"]")).GetAttribute("checked");
            Assert.AreEqual("Fanta", CheckProductName);
            Assert.AreEqual("Beverages", CheckCategory);
            Assert.AreEqual("Exotic Liquids", CheckSupplier);
            Assert.AreEqual("40,0000", CheckUnitPrice);
            Assert.AreEqual("50", CheckQuantityPerUnit);
            Assert.AreEqual("20", CheckUnitsInStock);
            Assert.AreEqual("0", CheckUnitsOnOrder);
            Assert.AreEqual("10", CheckReorderLevel);
            Assert.AreEqual("true", CheckDiscontinued);
        }
        [Test, Order(4)]
        public void Test4_RemoveProduct()
        {
            driver.FindElement(By.LinkText("All Products")).Click();
            driver.FindElement(By.XPath("//*[a[text()=\"Fanta\"]]/following-sibling::*[10]/a[text()=\"Remove\"]")).Click();
            driver.SwitchTo().Alert().Accept();
            Assert.Throws<OpenQA.Selenium.InvalidSelectorException>(() => driver.FindElement(By.XPath("=//td/a[text()=\"Fanta\"]")));
        }
        
        [Test, Order(5)]
        public void Test5_Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            var FindLogin = driver.FindElement(By.XPath("//h2")).Text;
            Assert.AreEqual("Login", FindLogin);
        }
        
        [OneTimeTearDown]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
