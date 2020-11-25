using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit_datadriven.pageobjects
{
    public class Elements
    {
        //Home Page Elements
        public static string loginLink = "login";

        public static string logoutLink = "logout";
        public static string searchtext = "search_query_top";
        public static string productsList = "//h5[@itemprop='name']//a[@class='product-name']";
        public static string productsPrice = "//div[@class='product-container']//div[@class='right-block']//span[@itemprop='price']";

        //Login Page Elements
        public static string EmailTextBox = "email";

        public static string PasswordTextBox = "passwd";
        public static string SubmitButton = "SubmitLogin";
        public static string loginError = "//ol//li";
    }
}