using System;
using System.Collections.Generic;
using Autogeneration.Domain.Generators;
using Xunit;

namespace EntityGenerator.Domain.Tests
{
    public class NamespaceGeneratorTests
    {
        [Fact]
        public void Given_Empty_List_Of_Strings_When_Testing_DependenciesGenerator()
        {
            var input = new List<string>();

            var sut = new DependenciesGenerator(input);
            var result = sut.Generate();

            var expected = "";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_List_Of_Strings_When_Testing_DependenciesGenerator()
        {
            var input = new List<string>
            {
                "System",
                "System.Collections.Generic",
                "Autogeneration.Domain",
                "Xunit"
            };

            var sut = new DependenciesGenerator(input);
            var result = sut.Generate();

            var expected = String.Join(
            Environment.NewLine,
            "using System;",
            "using System.Collections.Generic;",
            "using Autogeneration.Domain;",
            "using Xunit;",
            "");

            Assert.Equal(expected, result);
        }
    }
}
