using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Autogeneration.Domain.Generators;
using Autogeneration.Dto;
using Xunit;

namespace EntityGenerator.Domain.Tests
{
    public class InterfaceFileGeneratorTests
    {
        [Fact]
        public void Given_Class_Name_Person_When_Testing_Generating_Interface_IPerson()
        {
            var solution_dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = solution_dir.Replace("bin/Debug/netcoreapp2.0", "");
            var expectedFileName = path + "IPerson.cs";

            var dependencies = new List<string>
            {
                "System",
                "System.Collections.Generic"               
            };

            var personEntityDto = new EntityDto
            {
                Name = "Person",
                Fields = new List<FieldTypePairDto>
                {
                    {
                        new FieldTypePairDto
                        {
                            FieldName = "Name",
                            Type = "string"
                        }
                    },
                    {
                        new FieldTypePairDto
                        {
                            FieldName = "Age",
                            Type = "int"
                        }
                    },
                    {
                        new FieldTypePairDto
                        {
                            FieldName = "Friends",
                            Type = "IEnumerable<IPerson>"
                        }
                    }
                }
            };

            var dependencyGen = new DependenciesGenerator(dependencies);
            var namespaceGen = new NamespaceGenerator();
            var fieldsGen = new FieldTypePairGenerator();
            var bracketGen = new ClosedCurlyBracketGenerator();

            var sut = new InterfaceFileGenerator(
                path,
                "Autogeneration.Entities.Test.Contracts",
                dependencyGen,
                namespaceGen,
                fieldsGen,
                bracketGen);

            sut.GenerateFile("Person", personEntityDto);


            Assert.True(File.Exists(expectedFileName));
        }
    }
}
