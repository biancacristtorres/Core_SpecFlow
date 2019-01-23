using Core_SpecFlow.Uteis;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_SpecFlow.Comuns
{
    class DriverFactory
    {
        public static IWebDriver INSTANCE { get; set; } = null;

        public static void CreateInstance()
        {

            //criado um appconfig com a configuração desejada
           

            if (INSTANCE == null)
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                //chromeOptions.AddArguments("headless");
                INSTANCE = new ChromeDriver(chromeOptions);
                INSTANCE.Manage().Window.Maximize();
                //Criei um método que retorna o path do driver: SeleniumUteis.SeleniumUteis.getPathSeleniumDriver



            }



        
        }

        public static void QuitInstace()
        {
            INSTANCE.Quit();
            INSTANCE = null;
        }


    }
}
