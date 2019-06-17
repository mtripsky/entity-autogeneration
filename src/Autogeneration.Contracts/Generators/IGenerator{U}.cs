using System;
namespace Autogeneration.Contracts.Generators
{
    public interface IGenerator<U>
    {
        U Generate();
    }
}
