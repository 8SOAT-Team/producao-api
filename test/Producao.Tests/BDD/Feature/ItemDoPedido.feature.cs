﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Pedidos.Tests.BDD.Feature
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class GerenciarItensDoPedidoFeature : object, Xunit.IClassFixture<GerenciarItensDoPedidoFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "ItemDoPedido.feature"
#line hidden
        
        public GerenciarItensDoPedidoFeature(GerenciarItensDoPedidoFeature.FixtureData fixtureData, Pedidos_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "BDD/Feature", "Gerenciar itens do pedido", "  Para garantir que os itens de um pedido sejam gerenciados corretamente,\r\n  Como" +
                    " desenvolvedor\r\n  Eu quero realizar testes de comportamento na classe ItemDoPedi" +
                    "do.", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Criar um item do pedido válido")]
        [Xunit.TraitAttribute("FeatureTitle", "Gerenciar itens do pedido")]
        [Xunit.TraitAttribute("Description", "Criar um item do pedido válido")]
        public void CriarUmItemDoPedidoValido()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Criar um item do pedido válido", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 7
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 8
    testRunner.Given("que eu tenha um pedido com ID \"c6e5d33d-7c1e-48a5-8a94-d40b317915bc\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
#line 9
      testRunner.And("um produto com ID \"f0fdbefb-08b2-4ad7-bdfc-8c3f0e070d8e\" e preço de 50.00", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 10
      testRunner.And("uma quantidade igual a 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 11
    testRunner.When("eu criar o item do pedido", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
#line 12
    testRunner.Then("o item deve ser criado com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
#line 13
      testRunner.And("o valor total do item deve ser 100.00", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Tentar criar um item com quantidade inválida")]
        [Xunit.TraitAttribute("FeatureTitle", "Gerenciar itens do pedido")]
        [Xunit.TraitAttribute("Description", "Tentar criar um item com quantidade inválida")]
        public void TentarCriarUmItemComQuantidadeInvalida()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Tentar criar um item com quantidade inválida", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 15
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 16
    testRunner.Given("que eu tenha um pedido com ID \"c6e5d33d-7c1e-48a5-8a94-d40b317915bc\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
#line 17
      testRunner.And("um produto com ID \"f0fdbefb-08b2-4ad7-bdfc-8c3f0e070d8e\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 18
      testRunner.And("uma quantidade igual a 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 19
    testRunner.Then("uma exceção deve ser lançada com a mensagem \"Obrigatório informar uma quantidade " +
                        "maior que zero.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Adicionar quantidade ao item do pedido")]
        [Xunit.TraitAttribute("FeatureTitle", "Gerenciar itens do pedido")]
        [Xunit.TraitAttribute("Description", "Adicionar quantidade ao item do pedido")]
        public void AdicionarQuantidadeAoItemDoPedido()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Adicionar quantidade ao item do pedido", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 21
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 22
    testRunner.Given("que eu tenha um item do pedido com ID \"e5e1f4b4-bbca-4c94-9d77-37d517918e24\" e qu" +
                        "antidade inicial igual a 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
#line 23
    testRunner.When("eu adicionar uma quantidade igual a 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
#line 24
    testRunner.Then("o item deve ter uma quantidade total igual a 5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Remover quantidade do item do pedido")]
        [Xunit.TraitAttribute("FeatureTitle", "Gerenciar itens do pedido")]
        [Xunit.TraitAttribute("Description", "Remover quantidade do item do pedido")]
        public void RemoverQuantidadeDoItemDoPedido()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Remover quantidade do item do pedido", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 26
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 27
    testRunner.Given("que eu tenha um item do pedido com ID \"e5e1f4b4-bbca-4c94-9d77-37d517918e24\" e qu" +
                        "antidade inicial igual a 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
#line 28
    testRunner.When("eu remover uma quantidade igual a 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
#line 29
    testRunner.Then("o item deve ter uma quantidade total igual a 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                GerenciarItensDoPedidoFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                GerenciarItensDoPedidoFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
