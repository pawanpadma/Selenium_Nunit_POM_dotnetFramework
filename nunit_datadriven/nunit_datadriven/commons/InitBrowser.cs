using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace nunit_datadriven.commons
{
    public class InitBrowser
    {
        public static IWebDriver driver;

        // public ReadEnv env;
        public string browser = null;

        public InitBrowser()
        {
            //  env = new ReadEnv();
            //  browser = env.GetProperty("base", "browser");
        }

        public static IWebDriver Getbrowser()
        {
            //string browser =
            //below line paramter value passed  "base" and "browser" from dev.ini file which is argument in
            //Readdata(section,key)method in ReadEnv.cs
            string browser = ReadEnv.ReadData("base", "browser");
            if (browser.Equals("chrome", StringComparison.OrdinalIgnoreCase))
            {
                if (driver == null)
                {
                    driver = new ChromeDriver();
                    return driver;
                }
                else
                    return driver;
            }
            if (browser.Equals("firefox", StringComparison.OrdinalIgnoreCase))
            {
                if (driver == null)
                {
                    driver = new FirefoxDriver();
                    return driver;
                }
                else
                    return driver;
            }
            return driver;
        }
    }
}