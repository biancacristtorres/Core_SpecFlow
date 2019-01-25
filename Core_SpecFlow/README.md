# CORE SpecFlow - Klov
 Este projeto tem como principal propósito a criação de um CORE de SpecFlow(Gherkin + C#) juntamente com Reports feitos no Klov.
 
# Principais Assuntos
 - [PageObjects](https://www.swtestacademy.com/page-object-model-c/)
 - [Hooks](https://github.com/techtalk/SpecFlow/wiki/Hooks)
 - [Klov](http://extentreports.com/docs/klov/)
 - [BDD(SpecFlow)](https://www.toolsqa.com/specflow/specflow-tutorial/)
 
# Ferramentas

  - Visual Studio Enterprise (Instalar UnitTestAdaptor, Nunit e Selenium)
  - Chrome Driver (http://www.seleniumhq.org/download/)
  - Pacotes do NuGet - NUnit(3.1.1), ExtentReports(3.1.3), MongoDBDriver(2.7.2), MSTest.Adapter(1.2), SpecFlow(2.4.1), Selenium.WebDriver(3.141),
  - Instalar "NUnit Test Adapter"
   ```Tools -> Extensions And Updates -> Online -> Search for "Nunit Test Adapter" -> Click on "NUnit Test Adapter" in results list -> Click on Download button ```

# Fluxo de execução
* Criação do Gherkin para testes orientados à comportamento
* Geração dos Steps(Passos) do Gherkin
* Comunicação da Classe de PageObjects com Steps
* Orquestramento de execução dos testes através da classe Hooks

 Classe | Função |
| ------ | ------ |
| [Feature](https://github.com/Sayoan/Core_SpecFlow/wiki/Feature)| Classe responsável por ter a escrita Gherkin |
| [Steps](https://github.com/Sayoan/Core_SpecFlow/wiki/Steps)| Classe responsável pelos passos descritos no Gherkin(feature)
| [Hooks](https://github.com/Sayoan/Core_SpecFlow/wiki/Hooks)| Classe responsável pelo fluxo de execução dos testes. Esta classe é responsável pelo relatório, chamada do DriverFactory(abertura do navegador) e finalização dos testes |
| SeleniumPath | Classe responsável pelo path do driver (Pode ser substituido por urls estáticas) |
| [DriverFactory](https://github.com/Sayoan/Core_SpecFlow/wiki/Driver-Factory)| Cria o Driver(recebe o patch, aqui ele pode ser estático), navega para URL e amplia a tela |
| [Page Objects](https://github.com/Sayoan/Core_SpecFlow/wiki/PageObjects)| Classe responsável pelo mapeamento dos elementos da tela e seus métodos|
| Uteis | Classe responsável por conter funções genéricas com os IWebelements(click, selecionar combobox, asserts) |



Agradecimentos: [Saymon Oliveira](https://github.com/saymowan)

[Fonte com mais informações do Selenium Grid - QATools](https://www.toolsqa.com/)

[SpecFlow](https://github.com/techtalk/SpecFlow/wiki/Scoped-bindings)







