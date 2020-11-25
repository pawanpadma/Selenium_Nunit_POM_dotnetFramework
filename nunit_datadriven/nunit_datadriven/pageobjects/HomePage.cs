using NUnit.Framework;
using nunit_datadriven.commons;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit_datadriven.pageobjects
{
    public class HomePage
    {
        public IWebDriver driver = InitBrowser.Getbrowser();
        public CommonCode common;

        public Read_ini read;

        public By loginLink = By.ClassName(Elements.loginLink);
        public By logoutLink = By.ClassName(Elements.logoutLink);
        public By searchtextbox = By.Id(Elements.searchtext);
        public By productsList = By.XPath(Elements.productsList);
        public By productsPrice = By.XPath(Elements.productsPrice);

        public HomePage()
        {
            common = new CommonCode();
        }

        public void TapLoginLink()
        {
            driver.FindElement(loginLink).Click();
        }

        public void validateHome()
        {
            Assert.AreEqual(read.GetProperty("homePage", "homeTitle"), driver.Title);
        }

        public void logout()
        {
            common.ElementExists(logoutLink, 3);
            driver.FindElement(logoutLink).Click();
            // driver.FindElement(loginLink).Click();
        }

        //Below method we will give one input as Product 'printed' but
        //we want to check exact product and its price if available(here printed chiffon dress and 16.80)
        //hence we pass total 3 paramteres as dynamic so in future we don't need to hardcode input.
        public void searchProduct(string prodcut, string productResult, string price)
        {
            bool b = false;
            driver.FindElement(searchtextbox).SendKeys(prodcut);
            driver.FindElement(searchtextbox).SendKeys(Keys.Enter);
            int count = driver.FindElements(productsList).Count;
            for (int i = 0; i < count; i++)
            {
                if (driver.FindElements(productsList)[i].Text.Trim().Equals(productResult))
                {
                    string disPrice = driver.FindElements(productsPrice)[i].Text.Trim();
                    Assert.AreEqual(price, disPrice);
                    b = true;
                    break;
                }
            }
            //Here we are expecting 'b' as true (Istrue)but b is false hence product not found as its outisde for loop
            Assert.IsTrue(b, "product not found");
        }
    }
}