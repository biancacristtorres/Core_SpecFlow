using Core_SpecFlow.Comuns;
using Core_SpecFlow.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace Core_SpecFlow.Steps
{
    [Binding]
    public class SolAlunoAcesso_LoginSteps 
    {
        LoginPageObjects loginPageObjects = new LoginPageObjects();

       

        [Given(@"Acesso a pagina de login do Sol Aluno")]
        public void UsuarioAcessaSolAluno()
        {

            DriverFactory.INSTANCE.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL_Sol_UNIBH"].ToString());



        }

        [When(@"Entro com as credenciais(.*) e(.*)")]
        public void AlunoInsereUsuarioSenha(string username, string password)
        {
            loginPageObjects.LoginSolAluno(username, password);
        }

        [When(@"Clico no botao Login")]
        public void AlunoClicaLogin()
        {
            loginPageObjects.BotaoLoginSolAluno();
        }

        [Then(@"Deve entrar na pagina inicial do Sol Aluno")]
        public void ValidacaoAcessoAluno()
        {
            Thread.Sleep(5000);
            String URL = DriverFactory.INSTANCE.Url;
            Assert.AreEqual(URL, ConfigurationManager.AppSettings["URL_Sol_Home"].ToString());

           
        }

        [Then(@"Deve aparecer uma mensagem de alerta 'Login ou senha inválido'")]
        public void AlertaFalhaLogin()
        {
            Thread.Sleep(5000);
            loginPageObjects.AlertaSenhaErrada();
        }
    }
}
