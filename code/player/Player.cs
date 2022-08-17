using Sandbox;
using System;
using System.Linq;
using Spleef.entities;

namespace Alydus.Spleef
{

	public partial class SpleefPlayer : Player
	{
		public static readonly Model WorldModel = Model.Load("models/citizen/citizen.vmdl");

		/// <summary>
		/// The clothing container is what dresses the citizen
		/// </summary>
		public ClothingContainer Clothing = new();
		public SpleefPlayer()
		{
		}

		public SpleefPlayer(Client cl) : this()
		{
			// Load clothing from client data
			Clothing.LoadFromClient(cl);
		}

		public override void Spawn()
		{
			base.Spawn();
		}

		public override void Respawn()
		{
			Model = WorldModel;

			Controller = new WalkController();
			Animator = new StandardPlayerAnimator();
			CameraMode = new SpleefThirdPersonCamera();

			EnableDrawing = true;
			EnableAllCollisions = true;

			Clothing.DressEntity(this, false);

			base.Respawn();
		}

		public override void Simulate( Client cl )
		{
			PawnController controller = GetActiveController();
			controller?.Simulate( cl, this, GetActiveAnimator() );

			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.PrimaryAttack ) )
				{
					var tr = Trace.Ray( EyePosition, EyePosition + EyeRotation.Forward * 4000 ).WorldOnly().Run();

					if ( tr.Hit )
					{
						var ent = new Platform
						{
							Position = tr.EndPosition,
							Rotation = Rotation.From( 0f, EyeRotation.Yaw(), 0f )
						};

						ent.SetModel( "models/citizen_props/crate01.vmdl" );
					}

				}
			}
		}

		public override void OnKilled()
		{
			base.OnKilled();
		}
	}

}
