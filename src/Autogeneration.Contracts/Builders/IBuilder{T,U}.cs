using System;

namespace Autogeneration.Contracts.Builders
{
    public interface IBuilder<T,U>
    {
        U Build(T item);
    }
}
