using OpenQA.Selenium;
using TestWebDriverAdvanced.po;
using WebDriverFramework.business_objects;

namespace WebDriverFramework.service.ui
{
    class Create_NewUser
    {
        public static string NewUser(User testus, IWebDriver driver)
        {
            Page_Login page_login = new Page_Login(driver);
            Page_Homepage homepage = new Page_Homepage(driver);
            page_login.TestLogin(testus);
            return homepage.FindHomePageIn();
        }
    }
}
