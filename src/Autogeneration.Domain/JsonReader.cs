using System;
using Autogeneration.Contracts;
using Autogeneration.Dto;
using Newtonsoft.Json;

namespace Autogeneration.Domain
{
    public class JsonReader : IReader<ProblemDto>
    { 
        public ProblemDto ReadFile(string filePath)
        {
            var file = System.IO.File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<ProblemDto>(file);
        }
    }
}
