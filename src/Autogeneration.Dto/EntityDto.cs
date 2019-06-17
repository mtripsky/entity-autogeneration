using System;
using System.Collections.Generic;

namespace Autogeneration.Dto
{
    public class EntityDto
    {
        public string Name { get; set; }

        public List<FieldTypePairDto> Fields { get; set; } = new List<FieldTypePairDto>();
    }
}
