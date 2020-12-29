using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverFramework.business_objects;
using TechTalk.SpecFlow;
using TestWebDriverAdvanced.po;

namespace WebDriverFramework
{
    [Binding]
    class Createnewproduct
    {
        private IWebDriver driver;
        private readonly User testus = new User("user", "user");
        private Page_Login page_login;
        private Page_AllProducts page_allproducts;
        private Page_Homepage page_homepage;


        [Given(@"I login to ""(.+)""")]
        public void Testlogin(string url)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            page_login = new Page_Login(driver);
            page_login.TestLogin(testus);
        }

        [When(@"I click on All Products button")]
        public void ClickAllProduct()
        {
            page_homepage = new Page_Homepage(driver);
            page_homepage.ToAllProducts();
        }

        [When(@"I click on Create New button")]
        public void ClickCreateNew()
        {
            page_allproducts = new Page_AllProducts(driver);
            page_allproducts.ToNewProduct();
        }

        [When(@"I enter values ""(.+)"", ""(.+)"", ""(.+)"", ""(.+)"", ""(.+)"", ""(.+)"", ""(.+)"", ""(.+)"", ""(.*)"" and click btn")]
        public void EnterValues(string productName, string categoryId, string supplierId, string unitPrice, string quantityPerUnit, string unitsInStock, string unitsOnOrder, string reorderLevel, bool discontinued)
        {
            Product testproduct = new Product(productName, categoryId, supplierId, unitPrice, quantityPerUnit, unitsInStock, unitsOnOrder, reorderLevel, discontinued);
            Page_NewProduct page_newproduct = new Page_NewProduct(driver);
            page_newproduct.TestNewProduct(testproduct);
        }

        [Then(@"Edit form close")]
        public void CloseForm()
        {
            Assert.AreNotEqual("editing", page_allproducts.CloseFormEdit());
        }

        [AfterScenario]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}