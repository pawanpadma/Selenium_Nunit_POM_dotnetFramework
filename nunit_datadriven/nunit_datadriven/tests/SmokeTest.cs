using NUnit.Framework;
using nunit_datadriven.commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit_datadriven.tests
{
    public class SmokeTest : SetupClass
    {
        [Category("smoke")]
        [Description("Negative credentials test case")]
        [Test]
        public void LoginNegative()
        {
            home.logout();
            login.loginToApplication("abcdd", "abcdd");
            login.validateLoginError();
            login.loginToApplication(ReadEnv.ReadData("base", "username"), ReadEnv.ReadData("base", "password"));
        }

        [Category("smoke")]
        [Description("Search Product")]
        [Test]
        public void SearchProduct()
        {
            home.searchProduct(read.GetProperty("homePage", "prodSearch"), read.GetProperty("homePage", "prodname"), read.GetProperty("homePage", "prodPrice"));
        }
    }
}