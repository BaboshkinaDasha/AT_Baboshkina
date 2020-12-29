using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverFramework.business_objects;
using TechTalk.SpecFlow;
using TestWebDriverAdvanced.po;
using WebDriverFramework.service;
using WebDriverFramework.service.ui;

namespace WebDriverFramework
{
    [Binding]
    class Createnewproduct
    {
        private IWebDriver driver;
        private readonly User testus = new User("user", "user");
        private Product product = new Product("Fanta", "Beverages", "Exotic Liquids", "40", "50", "20", "0", "10", true);
        private Page_Login page_login;
        private Page_AllProducts page_allproducts;
        private Page_Homepage page_homepage;
        Page_NewProduct page_newproduct;
        private Page_EditProduct page_editproduct;


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
            Product testpr = new Product(productName, categoryId, supplierId, unitPrice, quantityPerUnit, unitsInStock, unitsOnOrder, reorderLevel, discontinued);
            page_newproduct = new Page_NewProduct(driver);
            page_newproduct.TestNewProduct(testpr);
        }

        [When(@"Edit form close")]
        public void CloseForm()
        {
            page_editproduct = new Page_EditProduct(driver);
            page_allproducts.ToEditProduct(product);
            Assert.AreNotEqual(page_editproduct.Closeformedit(), Create_NewProduct.NewProduct(product, driver));
        }

        [Then(@"A product - ""(.+)"" should be on page")]
        public void ProductOnPage(string productname)
        {
            Assert.IsTrue(page_allproducts.FindProduct(productname));
        }

        [AfterScenario]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}