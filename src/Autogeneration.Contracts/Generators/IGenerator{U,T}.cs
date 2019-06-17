using System;

namespace Autogeneration.Contracts.Generators
{
    public interface IGenerator<U,T>
    {
        U Generate(T item);
    }
}
