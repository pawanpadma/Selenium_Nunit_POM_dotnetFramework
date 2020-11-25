using nunit_datadriven.commons;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit_datadriven.pageobjects
{
    internal class SummaryPage
    {
        public IWebDriver driver = InitBrowser.Getbrowser();
    }
}