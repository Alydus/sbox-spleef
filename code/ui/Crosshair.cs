using Sandbox.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alydus.Spleef
{
	/// <summary>
	/// Represents the user's crosshair
	/// </summary>
	public partial class Crosshair : Panel
	{
		public static Crosshair Current;

		public Crosshair()
		{
			Current = this;
			StyleSheet.Load( "/ui/Crosshair.scss" );
		}
	}
}
