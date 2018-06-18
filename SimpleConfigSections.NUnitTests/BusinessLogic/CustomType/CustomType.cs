using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConfigSections.Tests.BusinessLogic
{
	public class CustomTypeA : CustomType
	{
		public override string Name { get { return "A"; } }
	}

	public class CustomTypeB : CustomType
	{
		public override string Name { get { return "B"; } }
	}

	public class CustomTypeC : CustomType
	{
		public override string Name { get { return "C"; } }
	}

	public abstract class CustomType
	{
		public abstract string Name { get; }

		public static CustomType[] GetCustomTypes()
		{
			return new CustomType[] { new CustomTypeA(), new CustomTypeB(), new CustomTypeC() };
		}
	}
}
