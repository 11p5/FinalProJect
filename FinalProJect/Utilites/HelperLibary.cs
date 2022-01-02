using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalProJect.Utilites
{
    public static class HelperLibary
    {

        public static void HandleAlert(OpenQA.Selenium.IWebDriver driver) { 
            //Thread.Sleep(1000);
            //IAlert logoutAl;
        } 
        
        public static void waitmethod(IWebDriver driver, int time, By Locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(drv => drv.FindElement(Locator).Displayed);
        }
        
        }
        
       
    }
