using Core_SpecFlow.Comuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using Core_SpecFlow.Uteis;
using OpenQA.Selenium.Support.PageObjects;

namespace Core_SpecFlow.PageObjects
{
    class LoginPageObjects 
    {

        private IWebDriver driver;

        public LoginPageObjects()
        {
            this.driver = DriverFactory.INSTANCE;
        }

        By TfMatricula = By.Name("matricula");
        By TfSenha = By.Name("senha");
        By BtLogin = By.Id("logar");
        By LtAlertaSenha = By.XPath("//button/span");

        public void LoginSolAluno(string username, string password)
       {
            SeleniumUteis Uteis = new SeleniumUteis();
            WebDriverWait espera = new WebDriverWait(DriverFactory.INSTANCE, TimeSpan.FromSeconds(5));
            Uteis.PreencherCampo(driver.FindElement(TfMatricula), username, username);
            Uteis.PreencherCampo(driver.FindElement(TfSenha), password, password);
        }

        public void BotaoLoginSolAluno()
        {
            SeleniumUteis Uteis = new SeleniumUteis();
            WebDriverWait espera = new WebDriverWait(DriverFactory.INSTANCE, TimeSpan.FromSeconds(5));
            Uteis.ClicarBotao(driver.FindElement(BtLogin));
            
        }

        public void AlertaSenhaErrada()
        {
            SeleniumUteis Uteis = new SeleniumUteis();
            WebDriverWait espera = new WebDriverWait(DriverFactory.INSTANCE, TimeSpan.FromSeconds(5));
            Uteis.ClicarBotao(driver.FindElement(LtAlertaSenha));

        }
    }
}
