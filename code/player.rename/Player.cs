using Sandbox;
using System;
using System.Linq;

namespace Alydus.Spleef
{

	partial class SpleefPlayer : Sandbox.Player
	{
		public static readonly Model WorldModel = Model.Load( "models/citizen/citizen.vmdl" );

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

			base.Respawn();
		}

		public override void Simulate( Client cl )
		{
			PawnController controller = GetActiveController();
			controller?.Simulate( cl, this, GetActiveAnimator() );
		}

		public override void OnKilled()
		{
			base.OnKilled();
		}
	}

}
