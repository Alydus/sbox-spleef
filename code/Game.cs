using Sandbox;

namespace Alydus.Spleef
{
	/// <summary>
	/// Alydus Spleef
	/// </summary>
	public partial class Spleef : Sandbox.Game
	{
		public Spleef()
		{
			if ( IsServer )
			{
				// Create the HUD
				_ = new SpleefHud();
			}
		}

		/// <summary>
		/// A client has joined the server. Create SpleefPlayer pawn.
		/// </summary>
		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			// Create a pawn for this client to play with
			var player = new SpleefPlayer(client);
			player.Respawn();

			client.Pawn = player;
		}

		public override void DoPlayerNoclip(Client client)
		{
			// Noclip not allowed
		}
	}

}
