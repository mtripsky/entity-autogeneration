using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Autogeneration.Contracts;
using Autogeneration.Contracts.Builders;
using Autogeneration.Contracts.Generators;
using Autogeneration.Domain;
using Autogeneration.Domain.Generators;
using Autogeneration.Dto;

namespace AutoGen.Application
{
    public class AutoGeneratorApplication : IBuilder<AutoGeneratorApplication>
    {
        private readonly ContainerBuilder _containerBuilder;
        private IGenerator _generator;
        private IContainer _container;

        public AutoGeneratorApplication()
        {
            _containerBuilder = new ContainerBuilder();
        }

        public AutoGeneratorApplication WithInterfaceGenerator(string @namespace, string targetPath)
        {
            _containerBuilder.RegisterType<NamespaceGenerator>()
                .Named<IGenerator<string, string>>("namespaceGenerator");
            _containerBuilder.RegisterType<ClosedCurlyBracketGenerator>()
                .Named<IGenerator<string, string>>("bracketGenerator");
            _containerBuilder.RegisterType<FieldTypePairGenerator>()
                .Named<IGenerator<string, FieldTypePairDto>>("fieldTypeGenerator")
                .As<IGenerator<string, FieldTypePairDto>>();

            _containerBuilder.RegisterType<InterfaceFileGenerator>()
                .WithParameter("path", targetPath)
                .WithParameter("namespace", @namespace)
                .WithParameter(
                    new ResolvedParameter(
                        (pi, ctx) => pi.Name == "namespaceGenerator",
                        (pi, ctx) => ctx.ResolveNamed<IGenerator<string,string>>("namespaceGenerator")))
                .WithParameter(
                    new ResolvedParameter(
                        (pi, ctx) => pi.Name == "bracketGenerator",
                        (pi, ctx) => ctx.ResolveNamed<IGenerator<string, string>>("bracketGenerator")))
                .As<IFileGenerator<EntityDto>>();

            return this;
        }

        public AutoGeneratorApplication WithInterfaceDependencies(IEnumerable<string> dependencies)
        {
            _containerBuilder.RegisterType<DependenciesGenerator>()
                .WithParameter("dependencies", dependencies)
                .Named<IGenerator<string>>("dependecyGenerator")
                .As<IGenerator<string>>();


            return this;
        }

        public AutoGeneratorApplication Build()
        {
            _containerBuilder.RegisterType<JsonReader>()
                .As<IReader<ProblemDto>>();


            _container = _containerBuilder.Build();

            return this;
        }

        public void Run(string sourceName)
        {
            _generator = new AutoGenerator(
                _container.Resolve<IReader<ProblemDto>>(),
                _container.ResolveOptional<IFileGenerator<EntityDto>>(),
                sourceName);

            _generator.Generate();
        }

    }
}
