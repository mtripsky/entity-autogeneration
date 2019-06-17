using System;
using Autogeneration.Domain.Generators;
using Autogeneration.Dto;
using Xunit;

namespace EntityGenerator.Domain.Tests
{
    public class FieldTypePairGeneratorTests
    {
        [Theory]
        [InlineData("Id", "string")]
        [InlineData("Grades", "List<string>")]
        public void Given_FieldName_And_Type_When_Testing_FieldTypePairGenerator_Generate(
            string fieldName,
            string type)
        {
            var item = new FieldTypePairDto
            {
                FieldName = fieldName,
                Type = type
            };

            var sut = new FieldTypePairGenerator();

            var result = sut.Generate(item);

            var expected = "\t\t" + type + " " + fieldName + " { get; set; }";

            Assert.Equal(expected, result);
        }
    }
}
