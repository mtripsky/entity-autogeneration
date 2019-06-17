using System;
using System.IO;
using Autogeneration.Contracts.Generators;
using Autogeneration.Dto;

namespace Autogeneration.Domain.Generators
{
    public class InterfaceFileGenerator : IFileGenerator<EntityDto>
    {
        private readonly string _path;
        private readonly string _namespace;
        private readonly IGenerator<string> _dependencyGenerator;
        private readonly IGenerator<string, string> _namespaceGenerator;
        private readonly IGenerator<string, FieldTypePairDto> _fieldsGenerator;
        private readonly IGenerator<string, string> _bracketGenerator;

        public InterfaceFileGenerator(
            string path,
            string @namespace,
            IGenerator<string> dependecyGenerator,
            IGenerator<string, string> namespaceGenerator,
            IGenerator<string, FieldTypePairDto> fieldsGenerator,
            IGenerator<string, string> bracketGenerator)
        {
            _path = path;
            _namespace = @namespace;
            _dependencyGenerator = dependecyGenerator;
            _namespaceGenerator = namespaceGenerator;
            _fieldsGenerator = fieldsGenerator;
            _bracketGenerator = bracketGenerator;
        }

        public void GenerateFile(string name, EntityDto entity)
        {
            var fileName = $"{_path}I{name}.cs";

            //File.Create(fileName).Dispose();

            using (StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                file.WriteLine(_dependencyGenerator.Generate());
                file.WriteLine(_namespaceGenerator.Generate(_namespace));
                file.WriteLine(GenerateName(entity.Name));

                foreach(var field in entity.Fields)
                {
                    file.WriteLine(_fieldsGenerator.Generate(field));
                    file.WriteLine();
                }

                file.WriteLine(_bracketGenerator.Generate("\t"));
                file.WriteLine(_bracketGenerator.Generate(""));
            }
        }

        private string GenerateName(string name)
        {
            return String.Join(
                        Environment.NewLine,
                        $"\tpublic interface I{name}",
                        "\t{");
        }
    }
}
