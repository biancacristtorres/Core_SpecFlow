using Core_SpecFlow.Comuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using Core_SpecFlow.Uteis;
using OpenQA.Selenium.Support.PageObjects;

namespace Core_SpecFlow.PageObjects
{
    class LoginPageObjects 
    {

        public LoginPageObjects()
        {
            PageFactory.InitElements(DriverFactory.INSTANCE, this);
        }


        [FindsBy(How = How.Name, Using = "matricula")]
        public IWebElement TfMatricula { get; set; }

        [FindsBy(How = How.Name, Using = "senha")]
        public IWebElement TfSenha { get; set; }

        [FindsBy(How = How.Id, Using = "logar")]
        public IWebElement BtLogin { get; set; }

        [FindsBy(How = How.XPath, Using = "//button/span")]
        public IWebElement LtAlertaSenha { get; set; }

        public void LoginSolAluno(string username, string password)
       {
            SeleniumUteis Uteis = new SeleniumUteis();
            WebDriverWait espera = new WebDriverWait(DriverFactory.INSTANCE, TimeSpan.FromSeconds(5));
            Uteis.PreencherCampo(TfMatricula, username, username);
            Uteis.PreencherCampo(TfSenha, password, password);
            


        }

        public void BotaoLoginSolAluno()
        {
            SeleniumUteis Uteis = new SeleniumUteis();
            WebDriverWait espera = new WebDriverWait(DriverFactory.INSTANCE, TimeSpan.FromSeconds(5));
            Uteis.ClicarBotao(BtLogin);
            
        }

        public void AlertaSenhaErrada()
        {
            SeleniumUteis Uteis = new SeleniumUteis();
            WebDriverWait espera = new WebDriverWait(DriverFactory.INSTANCE, TimeSpan.FromSeconds(5));
            Uteis.ClicarBotao(LtAlertaSenha);

        }






    }
}
