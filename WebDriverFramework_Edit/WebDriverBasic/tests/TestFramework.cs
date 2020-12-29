using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestWebDriverAdvanced.po;
using WebDriverFramework.tests;
using WebDriverFramework.business_objects;
using WebDriverFramework.service;
using WebDriverFramework.service.ui;

namespace TestWebDriverAdvanced
{
    public class TestFramework : BaseTest
    {
        private Page_Login page_login;
        private Page_Homepage page_homepage;
        private Page_AllProducts page_allproducts;
        private Page_NewProduct page_newproduct;
        private Page_EditProduct page_editproduct;
        private Product product = new Product("Fanta", "Beverages", "Exotic Liquids", "40", "50", "20", "0", "10");
        private User user = new User("user", "user");

        [Test, Order(1)]
        public void Test1_Login()
        {
            page_login = new Page_Login(driver);
            page_homepage = new Page_Homepage(driver);
            page_login.TestLogin(user);
            Assert.AreEqual("Home page", page_homepage.FindHomePageIn());
        }
       
        [Test, Order(2)]
        public void Test2_NewProduct()
        {
            page_editproduct = new Page_EditProduct(driver);
            Assert.AreNotEqual(page_editproduct.Closeformedit(), Create_NewProduct.NewProduct(product, driver));
        }

        [Test, Order(3)]
        public void Test3_CheckProduct()
        {
            page_allproducts = new Page_AllProducts(driver);
            page_editproduct = new Page_EditProduct(driver);
            page_allproducts.ToEditProduct(product);
            Assert.AreEqual(product.ProductName, page_editproduct.ProductName());
            Assert.AreEqual(product.CategoryId, page_editproduct.Category());
            Assert.AreEqual(product.SupplierId, page_editproduct.Supplier());
            Assert.AreEqual(product.UnitPrice+",0000", page_editproduct.UnitPrice());
            Assert.AreEqual(product.QuantityPerUnit, page_editproduct.QuantityPerUnit());
            Assert.AreEqual(product.UnitsInStock, page_editproduct.UnitsInStock());
            Assert.AreEqual(product.UnitsOnOrder, page_editproduct.UnitsOnOrder());
            Assert.AreEqual(product.ReorderLevel, page_editproduct.ReorderLevel());
        }
        [Test, Order(4)]
        public void Test4_RemoveProduct()
        {
            page_allproducts = new Page_AllProducts(driver);
            page_homepage = new Page_Homepage(driver);
            page_homepage.ToAllProducts();
            page_allproducts.ToRemoveProduct(product);
            Assert.IsFalse(page_allproducts.ProductIsRemove(product));
        }

        [Test, Order(5)]
        public void Test5_Logout()
        {
            page_homepage.ToLogOut();
            Assert.AreEqual("Login", page_login.ToFindLogin()); ;
        }
    }
}
