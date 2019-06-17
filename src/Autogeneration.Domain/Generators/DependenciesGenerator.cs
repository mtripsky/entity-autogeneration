using System;
using System.Collections.Generic;
using System.Linq;
using Autogeneration.Contracts.Generators;
using Autogeneration.Domain.Helpers;

namespace Autogeneration.Domain.Generators
{
    public class DependenciesGenerator : IGenerator<string>
    {
        private readonly IEnumerable<string> _dependencies;

        public DependenciesGenerator(IEnumerable<string> dependencies)
        {
            _dependencies = dependencies;
        }

        public string Generate()
        {
            if (_dependencies.Any())
            {
                var result = "";

                foreach (var dependency in _dependencies)
                {
                    result = String.Join(
                        Environment.NewLine,
                        result,
                        $"using {dependency};");
                }

                result = String.Join(
                        Environment.NewLine,
                        result,
                        "");

                return StringExtensions.RemoveFirstLines(result, 1);
            }

            return "";
        }
    }
}
