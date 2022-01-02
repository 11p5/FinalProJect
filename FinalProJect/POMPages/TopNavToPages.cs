using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalProJect.POMPages
{
    public class TopNavToPages
    {
        private IWebDriver _driver;

        public TopNavToPages(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement account_page => _driver.FindElement(By.LinkText("My account"));
        private IWebElement Shop => _driver.FindElement(By.LinkText("Shop"));
        private IWebElement cart => _driver.FindElement(By.LinkText("Cart"));

        

        public void GoToAccount() { 
            account_page.Click(); 
            
        }
        public void GoToShop() { 
            Shop.Click();
        }
        public void GoToCart()
        {
            cart.Click();
        }
       public void waitfor2seconds() //the reason that i am using wait is that you are able to see the process as it going long so you can un comment this
        {
            Thread.Sleep(200);
        }

        
    }
}
