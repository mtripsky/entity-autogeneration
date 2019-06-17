using System;
using System.Collections.Generic;

namespace Autogeneration.Entities.Test.Contracts
{
	public interface IPerson
	{
		string Name { get; set; }

		int Age { get; set; }

		IEnumerable<IPerson> Friends { get; set; }

	}
}
