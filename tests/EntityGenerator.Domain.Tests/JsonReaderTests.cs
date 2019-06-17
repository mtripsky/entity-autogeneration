using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Autogeneration.Domain;
using Xunit;

namespace EntityGenerator.Domain.Tests
{
    public class JsonReaderTests
    {
        [Fact]
        public void Given_Json_With_Person_And_Student_Entities_When_Testing_Json_Reader()
        {
            var solution_dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = solution_dir + "/inputJsons/PersonStudentEntities.json";

            var sut = new JsonReader();

            var result = sut.ReadFile(filePath);

            Assert.Equal(2, result.Entities.Count);
            var person = result.Entities[0];
            var student = result.Entities[1];
            Assert.Equal("Person", person.Name);
            Assert.Equal("Student", student.Name);
            Assert.Equal(4, person.Fields.Count);
            Assert.Equal(6, student.Fields.Count);
            Assert.Equal("Id", person.Fields[0].FieldName);
            Assert.Equal("string", person.Fields[0].Type);
            Assert.Equal("Name", person.Fields[1].FieldName);
            Assert.Equal("string", person.Fields[1].Type);
            Assert.Equal("Age", person.Fields[2].FieldName);
            Assert.Equal("int", person.Fields[2].Type);
            Assert.Equal("Friends", person.Fields[3].FieldName);
            Assert.Equal("List<Person>", person.Fields[3].Type);
            Assert.Equal("Id", student.Fields[0].FieldName);
            Assert.Equal("string", student.Fields[0].Type);
            Assert.Equal("Name", student.Fields[1].FieldName);
            Assert.Equal("string", student.Fields[1].Type);
            Assert.Equal("Age", student.Fields[2].FieldName);
            Assert.Equal("int", student.Fields[2].Type);
            Assert.Equal("Friends", student.Fields[3].FieldName);
            Assert.Equal("List<Person>", student.Fields[3].Type);
            Assert.Equal("School", student.Fields[4].FieldName);
            Assert.Equal("string", student.Fields[4].Type);
            Assert.Equal("Grades", student.Fields[5].FieldName);
            Assert.Equal("List<string>", student.Fields[5].Type);
        }
    }
}
