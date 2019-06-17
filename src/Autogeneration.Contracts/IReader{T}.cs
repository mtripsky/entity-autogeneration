using System;

namespace Autogeneration.Contracts
{
    public interface IReader<T>
    {
        T ReadFile(string filePath);
    }
}
