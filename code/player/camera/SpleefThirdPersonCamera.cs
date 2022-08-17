using Sandbox;

namespace Alydus.Spleef
{
	class SpleefThirdPersonCamera : Sandbox.CameraMode
	{
		public override void Update()
		{
			if ( Local.Pawn is not AnimatedEntity pawn )
				return;

			Position = pawn.Position;
			Vector3 targetPos;

			var center = pawn.Position + Vector3.Up * 64;

			Position = center;
			Rotation = Rotation.FromAxis( Vector3.Up, 4 ) * Input.Rotation;

			float distance = 200.0f * pawn.Scale;
			targetPos = Position + Input.Rotation.Right * ((pawn.CollisionBounds.Maxs.x + 15) * pawn.Scale);
			targetPos += Input.Rotation.Forward * -distance;

			var tr = Trace.Ray( Position, targetPos )
				.WithAnyTags( "solid" )
				.Ignore( pawn )
				.Radius( 8 )
				.Run();

			Position = tr.EndPosition;

			FieldOfView = 70;

			Viewer = null;
		}
	}
}
