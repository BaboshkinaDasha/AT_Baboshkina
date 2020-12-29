using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestWebDriverAdvanced.po;

namespace TestWebDriverAdvanced
{
    [TestFixture]
    public class TestAdvanced
    {
        private IWebDriver driver;
        private Page_Login page_login;
        private Page_Homepage page_homepage;
        private Page_AllProducts page_allproducts;
        private Page_NewProduct page_newproduct;
        private Page_EditProduct page_editproduct;


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
            page_login = new Page_Login(driver);
            page_homepage = new Page_Homepage(driver);
            page_login.TestLogin("user", "user");
            Assert.AreEqual("Home page", page_homepage.FindHomePageIn());
        }

        [Test, Order(2)]
        public void Test2_NewProduct()
        {
            page_allproducts = new Page_AllProducts(driver);
            page_newproduct = new Page_NewProduct(driver);
            page_homepage.ToAllProducts();
            page_allproducts.ToNewProduct();
            page_newproduct.TestNewProduct("Fanta", "Beverages", "Exotic Liquids", "40", "50", "20", "0", "10");
            Assert.AreNotEqual("editing", page_allproducts.CloseFormEdit());
        }

        [Test, Order(3)]
        public void Test3_CheckProduct()
        {
            page_editproduct = new Page_EditProduct(driver);
            page_allproducts.ToEditProduct();
            Assert.AreEqual("Fanta", page_editproduct.ProductName());
            Assert.AreEqual("Beverages", page_editproduct.Category());
            Assert.AreEqual("Exotic Liquids", page_editproduct.Supplier());
            Assert.AreEqual("40,0000", page_editproduct.UnitPrice());
            Assert.AreEqual("50", page_editproduct.QuantityPerUnit());
            Assert.AreEqual("20", page_editproduct.UnitsInStock());
            Assert.AreEqual("0", page_editproduct.UnitsOnOrder());
            Assert.AreEqual("10", page_editproduct.ReorderLevel());
            Assert.AreEqual("true", page_editproduct.Discontinued());
        }
        [Test, Order(4)]
        public void Test4_RemoveProduct()
        {
            page_homepage.ToAllProducts();
            page_allproducts.ToRemoveProduct();
            Assert.Throws<OpenQA.Selenium.InvalidSelectorException>(() => driver.FindElement(By.XPath("=//td/a[text()=\"Fanta\"]")));
        }

        [Test, Order(5)]
        public void Test5_Logout()
        {
            page_homepage.ToLogOut();
            Assert.AreEqual("Login", page_login.ToFindLogin()); ;
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
