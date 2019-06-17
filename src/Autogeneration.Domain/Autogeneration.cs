using System;
using Autogeneration.Contracts;
using Autogeneration.Contracts.Generators;
using Autogeneration.Dto;

namespace Autogeneration.Domain
{
    public class AutoGenerator : IGenerator
    {
        private readonly IReader<ProblemDto> _reader;
        private readonly IFileGenerator<EntityDto> _interfaceGen;
        private readonly string _filePath;

        public AutoGenerator(
            IReader<ProblemDto> reader,
            IFileGenerator<EntityDto> interfaceGen,
            string filePath)
        {
            _reader = reader;
            _interfaceGen = interfaceGen;
            _filePath = filePath;
        }

        public void Generate()
        {
            var problem = _reader.ReadFile(_filePath);

            foreach(var entity in problem.Entities)
            {
                _interfaceGen?.GenerateFile(entity.Name, entity);
            }
        }
    }
}
