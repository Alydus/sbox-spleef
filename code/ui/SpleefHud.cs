using Sandbox.UI;
using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alydus.Spleef
{
	[Library]
	public partial class SpleefHud : HudEntity<RootPanel>
	{
		public SpleefHud()
		{
			if ( !IsClient )
				return;

			RootPanel.StyleSheet.Load( "/ui/SandboxHud.scss" );

			RootPanel.AddChild<ChatBox>();
			RootPanel.AddChild<VoiceList>();
			RootPanel.AddChild<VoiceSpeaker>();
			RootPanel.AddChild<Scoreboard<ScoreboardEntry>>();
			RootPanel.AddChild<Crosshair>();
		}
	}
}
