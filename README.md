# CORE SpecFlow - Klov
 Este projeto tem como principal propósito a criação de um CORE de SpecFlow(Gherkin + C#) juntamente com Reports feitos no Klov.
 
# Projeto Mantis
- PageObjects
 - Hooks
 - Klov
 - BDD(SpecFlow)
 
# Ferramentas

  - Visual Studio Enterprise (Instalar UnitTestAdaptor, Nunit e Selenium)
  - Chrome Driver (http://www.seleniumhq.org/download/)
  - Pacotes do NuGet - NUnit(3.1.1), ExtentReports(3.1.3), MongoDBDriver(2.7.2), MSTest.Adapter(1.2), SpecFlow(2.4.1), Selenium.WebDriver(3.141),
  - Instalar "NUnit Test Adapter"
   ```Tools -> Extensions And Updates -> Online -> Search for "Nunit Test Adapter" -> Click on "NUnit Test Adapter" in results list -> Click on Download button ```

# Principais assuntos
  - Page Objects
  - Hooks
  - SpecFlow

# Classes criadas

| Classe | Função |
| ------ | ------ |
| Feature | Classe responsável por ter a escrita Gherkin |
| Steps | Classe responsável pelos passos descritos no Gherkin(feature)
| Hooks | Classe responsável pelo fluxo de execução dos testes. Esta classe é responsável pelo relatório, chamada do DriverFactory(abertura do navegador) e finalização dos testes |
| SeleniumPath | Classe responsável pelo path do driver (Pode ser substituido por urls estáticas) |
| DriverFactory | Cria o Driver(recebe o patch, aqui ele pode ser estático), navega para URL e amplia a tela |
| PageObjects | Classe responsável pelo mapeamento dos elementos da tela e seus métodos|
| Uteis | Classe responsável por conter funções genéricas com os IWebelements(click, selecionar combobox, asserts) |

# Fluxo de Execução

* Criação do Gherkin para testes orientados à comportamento
* Geração dos Steps(Passos) do Gherkin
* Comunicação da Classe de PageObjects com Steps
* Orquestramento de execução dos testes através da classe Hooks

# Feature
Classe responsável por  conter o padrão de escrita Gherkin, esta classe é criada com o tipo .feature(necessário instalar o NuGet do SpecFlow) e é gerado de forma automática o feature.cs. Após a criação do Gherkin é necessário clicar com o botão direito nas linhas da feature no item ***"Generate Step Definitions"*** assim é criado a classe Steps(items a seguir).

```sh
Feature: Sol Aluno Acesso - Login
	Como um aluno do Sol Aluno
	Eu quero realizar login
	Para acessar minhas informações acadêmicas

@automated
Scenario Outline: Aluno Ativo acessa Sol Aluno
	Given Acesso a pagina de login do Sol Aluno
	When Entro com as credenciais <username> e <password>
	And Clico no botao Login
	Then Deve entrar na pagina inicial do Sol Aluno 
Examples:
| username   | password |
|  114111561 | 1234 |
| 114110111 | 123 |

@automated
Scenario Outline: Aluno erra senha no acesso Sol Aluno
	Given Acesso a pagina de login do Sol Aluno
	When Entro com as credenciais <username> e <password>
	And Clico no botao Login
	Then Deve aparecer uma mensagem de alerta 'Login ou senha inválido'
Examples:
| username   | password |
|  114111561 | 123 |
| 114111561 | Test@153 |
```

# Steps
Classe responsável pelas implementações das funções relacionacionas a cada linha do Gherkin, nela são criadas funções com entrada de parâmetros e também comunicação direta com o PageObjects.
```sh
[Binding]
    public class SolAlunoAcesso_LoginSteps : WebDriver
    {
        LoginPageObjects loginPageObjects = new LoginPageObjects();
        
      [Given(@"Acesso a pagina de login do Sol Aluno")]
        public void UsuarioAcessaSolAluno()
        {
            DriverFactory.INSTANCE.Navigate().GoToUrl("https://homoaca-php.animaeducacao.com.br/branches/base2/SOL/aluno/index.php/index/seguranca/dev/instituicao/1");
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
            Assert.AreEqual(URL, "https://homoaca-php.animaeducacao.com.br/branches/base2/SOL/aluno/index.php/");
        }

        [Then(@"Deve aparecer uma mensagem de alerta 'Login ou senha inválido'")]
        public void AlertaFalhaLogin()
        {
            loginPageObjects.AlertaSenhaErrada();
        }
    }
```

# Hooks
Classe responsável por iniciar o navegador, finalizá-lo, orquestrar o que deve ser feito antes e depois de cada cenário/feature/teste além de ser responsável pelo relatório.
```sh
public class Hooks
    {
[BeforeTestRun]
    public static void InitializeReport()
        {}
[AfterTestRun]
        public static void TearDownReport()
        {}
[BeforeFeature]
        public static void BeforeFeature()
        {}
[BeforeScenario]
        public void Initialize()
        {}
[AfterStep]
        public void InsertReportingSteps()
        {}
 [AfterScenario]
        public void ExitTest()
        {}
        }
 ```
# Page Objects
Padrão de Projeto onde temos manipulação de Objetos através de Elementos da Tabela mapeados como IWebElement, classes genéricas e métodos genéricos.
```sh
  [FindsBy(How = How.XPath, Using = "//button/span")]
        public IWebElement LtAlertaSenha { get; set; }

        public void LoginSolAluno(string username, string password)
       {
            SeleniumUteis Uteis = new SeleniumUteis();
            WebDriverWait espera = new WebDriverWait(DriverFactory.INSTANCE, TimeSpan.FromSeconds(5));
            Uteis.PreencherCampo(TfMatricula, username, username);
            Uteis.PreencherCampo(TfSenha, password, password);
    
        }
 ```
# DriverFactory
Responsável por imiplementar métodos relacionados ao navegador, suas configurações e finalização do driver.
```sh
public static IWebDriver INSTANCE { get; set; } = null;

 public static void CreateInstance()
        {
            if (INSTANCE == null)
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                INSTANCE = new ChromeDriver(chromeOptions);
                INSTANCE.Manage().Window.Maximize();
            }
            }
public static void QuitInstace()
        {
            INSTANCE.Quit();
            INSTANCE = null;
        }

 ```
 
 

Agradecimentos: [Saymon Oliveira](https://github.com/saymowan)

[Fonte com mais informações do Selenium Grid - QATools](https://www.toolsqa.com/)
[SpecFlow](https://github.com/techtalk/SpecFlow/wiki/Scoped-bindings)
