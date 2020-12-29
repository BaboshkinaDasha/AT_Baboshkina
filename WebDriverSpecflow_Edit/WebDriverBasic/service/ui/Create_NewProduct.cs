using OpenQA.Selenium;
using TestWebDriverAdvanced.po;
using WebDriverFramework.business_objects;

namespace WebDriverFramework.service.ui
{
    class Create_NewProduct
    {
        public static string NewProduct(Product testpr, IWebDriver driver)
        {
            Page_AllProducts page_allpr = new Page_AllProducts(driver);
            Page_NewProduct newpr = new Page_NewProduct(driver);
            Page_Homepage homepage = new Page_Homepage(driver);
            homepage.ToAllProducts();
            page_allpr.ToNewProduct();
            newpr.TestNewProduct(testpr);
            return page_allpr.CloseFormEdit();
        }
    }
}
