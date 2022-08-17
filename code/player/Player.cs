using Sandbox;
using System;
using System.Linq;

namespace Alydus.Spleef
{

	partial class SpleefPlayer : Sandbox.Player
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

			Clothing.DressEntity(this, false);

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
