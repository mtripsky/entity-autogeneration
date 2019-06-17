using System;

namespace Autogeneration.Contracts.Generators
{
    public interface IFileGenerator<T>
    {
        void GenerateFile(string fileName, T entity);
    }
}
