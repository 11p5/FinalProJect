using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;
using FinalProJect.POMPages;
using System.Threading;

namespace FinalProJect.test
{   [TestFixture]
    public class testFolder : Utilites.TestBaseClass
    {
        [Test, Category("open and input ")] // this test is to make sure that we can login on the page an imput our name and password 
        public void accountTest()
        {
               
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/"; //using base account to make my life easier

            TopNavToPages TNTP = new TopNavToPages(driver);
            TNTP.waitfor2seconds();
            
            //login section
            TNTP.GoToAccount();
            //TNTP.waitfor2seconds();
            driver.FindElement(By.Id("username")).SendKeys("smythpeter908@gmail.com");
            //TNTP.waitfor2seconds();
            driver.FindElement(By.Id("password")).SendKeys("TheBlankMan123");
            //TNTP.waitfor2seconds();
            driver.FindElement(By.Id("rememberme")).Click(); //rememer the username and password;
            //TNTP.waitfor2seconds();
            driver.FindElement(By.Name("login")).Click();

            //TNTP.waitfor2seconds();
            //buy cloting
            TNTP.GoToShop();
            //TNTP.waitfor2seconds();
            driver.FindElement(By.XPath("//main[@id='main']/ul//a[@href='https://www.edgewordstraining.co.uk/demo-site/product/beanie/']/img")).Click();
            TNTP.waitfor2seconds(); ;
            driver.FindElement(By.CssSelector("button[name='add-to-cart']")).Click();
            //TNTP.waitfor2seconds();
            //cart with dicount code
            TNTP.GoToCart();
            //TNTP.waitfor2seconds();
            driver.FindElement(By.Name("coupon_code")).SendKeys("edgewords");
            //TNTP.waitfor2seconds();
            driver.FindElement(By.CssSelector("button[name='apply_coupon']")).Click();
            //TNTP.waitfor2seconds();

            string baseTotal = driver.FindElement(By.CssSelector(".product-subtotal > .amount.woocommerce-Price-amount")).Text;
            baseTotal = baseTotal.Substring(1);

            string subTotal = driver.FindElement(By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount")).Text;
            subTotal = subTotal.Substring(1);

            string coupon = driver.FindElement(By.CssSelector(".shipping > td > .amount.woocommerce-Price-amount")).Text;
            coupon = coupon.Substring(1);
            string shipping = driver.FindElement(By.CssSelector(".shipping > td > .amount.woocommerce-Price-amount")).GetAttribute("textContent");
            shipping = shipping.Substring(1);
            string Grandtotal = driver.FindElement(By.CssSelector("strong > .amount.woocommerce-Price-amount")).GetAttribute("textContent");
            Grandtotal = Grandtotal.Substring(1);
            decimal BaseTotal = Convert.ToDecimal(baseTotal);
            //Console.WriteLine(BaseTotal);
            decimal SubTotal = Convert.ToDecimal(subTotal);
            decimal CouponTotal = Convert.ToDecimal(coupon);
            decimal ShippingTotal = Convert.ToDecimal(shipping);
            decimal GrandTotal = Convert.ToDecimal(Grandtotal);
             decimal tenPersent = Convert.ToDecimal(0.1);
             decimal fitheteenPersent = Convert.ToDecimal(0.15);
            decimal discount = SubTotal * fitheteenPersent;
            decimal CalulatedGrandTotal = (BaseTotal - discount) + ShippingTotal;
           // Assert.AreEqual(GrandTotal, CalulatedGrandTotal);
            driver.FindElement(By.LinkText("Checkout")).Click();
            driver.FindElement(By.Id("billing_first_name")).Clear();
            driver.FindElement(By.Id("billing_last_name")).Clear();
            driver.FindElement(By.Id("billing_address_1")).Clear();
            driver.FindElement(By.Id("billing_address_2")).Clear();
            driver.FindElement(By.Id("billing_city")).Clear();
            driver.FindElement(By.Id("billing_state")).Clear();
            driver.FindElement(By.Id("billing_postcode")).Clear();
            driver.FindElement(By.Id("billing_phone")).Clear();
            driver.FindElement(By.Id("billing_email")).Clear();
            driver.FindElement(By.Id("billing_first_name")).SendKeys("Peter");
            driver.FindElement(By.Id("billing_last_name")).SendKeys("Smyth");
            driver.FindElement(By.Id("billing_address_1")).SendKeys("80 sunright road");
            driver.FindElement(By.Id("billing_address_2")).SendKeys("80 sunright road");
            driver.FindElement(By.Id("billing_city")).SendKeys("birmingham");
            driver.FindElement(By.Id("billing_state")).SendKeys("drep derp derp this is alax and this is how i talk");
            driver.FindElement(By.Id("billing_postcode")).SendKeys("B74 3JZ");
            driver.FindElement(By.Id("billing_phone")).SendKeys("13223546532544234");
            driver.FindElement(By.Id("billing_email")).SendKeys("smythpeter908@gmail.com");
            TNTP.waitfor2seconds(); // this wait is need due to line 98
            driver.FindElement(By.CssSelector("button#place_order")).Click();
            string order_number = driver.FindElement(By.CssSelector(".order_details.woocommerce-thankyou-order-details > .order")).Text;
            Console.WriteLine(order_number);
            TNTP.GoToAccount();
            driver.FindElement(By.LinkText("Orders")).Click();
           // TNTP.waitfor2seconds();
            string StoredOrder = driver.FindElement(By.CssSelector(".woocommerce-orders-table__header.woocommerce-orders-table__header-order-number > .nobr")).Text;
            // Console.WriteLine(StoredOrder);
           // Assert.AreEqual(order_number,StoredOrder);
            driver.FindElement(By.LinkText("Logout")).Click();
        }

    }
}
