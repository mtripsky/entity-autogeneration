using System;
using System.Collections.Generic;

namespace Autogeneration.Contracts
{
    public interface IEntity
    {
        string Name { get; set; }
    
        IEnumerable<IFieldTypePair> Fields { get; set; }
    }
}
