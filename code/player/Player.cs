using Sandbox;
using System;
using System.Linq;
using Spleef.entities;

namespace Alydus.Spleef
{

	/// <summary>
	/// Default player pawn for the Spleef gamemode.
	/// </summary>
	public partial class SpleefPlayer : Player
	{
		public static readonly Model WorldModel = Model.Load("models/citizen/citizen.vmdl");

		/// <summary>
		/// The clothing container is what dresses the citizen
		/// </summary>
		public ClothingContainer Clothing = new();

		public SpleefPlayer()
		{
			//Inventory = new Inventory( this );
		}

		public SpleefPlayer(Client cl) : this()
		{
			// Load clothing from client data
			Clothing.LoadFromClient(cl);
		}

		public override void Respawn()
		{
			Model = WorldModel;

			Controller = new WalkController();
			Animator = new StandardPlayerAnimator();
			CameraMode = new SpleefThirdPersonCamera();

			EnableDrawing = true;
			EnableAllCollisions = true;

			Clothing.DressEntity(this);

			base.Respawn();
		}

		public override void Simulate( Client cl )
		{
			PawnController controller = GetActiveController();
			controller?.Simulate( cl, this, GetActiveAnimator() );

			//if ( IsServer )
			//{
			//	if ( Input.Pressed( InputButton.PrimaryAttack ) )
			//	{
			//		var tr = Trace.Ray( EyePosition, EyePosition + EyeRotation.Forward * 4000 ).WorldOnly().Run();

			//		if ( tr.Hit )
			//		{
			//			new PlatformWalk
			//			{
			//				Position = tr.EndPosition,
			//				Rotation = Rotation.From( 0f, EyeRotation.Yaw(), 0f )
			//			};
			//		}

			//	}
			//}
		}

		public override void OnKilled()
		{
			base.OnKilled();
		}
	}

}
