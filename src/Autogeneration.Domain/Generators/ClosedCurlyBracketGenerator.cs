using Autogeneration.Contracts.Generators;

namespace Autogeneration.Domain.Generators
{
    public class ClosedCurlyBracketGenerator : IGenerator<string, string>
    {
        public string Generate(string level)
        {
            return level + "}";
        }
    }
}
