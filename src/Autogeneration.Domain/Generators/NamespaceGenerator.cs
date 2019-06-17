using System;
using Autogeneration.Contracts.Generators;

namespace Autogeneration.Domain.Generators
{
    public class NamespaceGenerator : IGenerator<string, string>
    {
        public string Generate(string @namespace)
        {
            return String.Join(
                        Environment.NewLine,
                        $"namespace {@namespace}",
                        "{");
        }
    }
}
