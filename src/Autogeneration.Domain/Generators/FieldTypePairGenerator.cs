using System;
using Autogeneration.Contracts.Generators;
using Autogeneration.Dto;

namespace Autogeneration.Domain.Generators
{
    public class FieldTypePairGenerator : IGenerator<string ,FieldTypePairDto>
    { 
        public string Generate(FieldTypePairDto item)
        {
            return $"\t\t{item.Type} {item.FieldName} {{ get; set; }}";
        }
    }
}
