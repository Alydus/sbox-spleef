using SandboxEditor;

namespace Sandbox.entities;

[Library( "platform" )]
[HammerEntity, Model, RenderFields, VisGroup( VisGroup.Physics )]
[Title( "Platform" ), Category( "Gameplay" ), Icon( "chair" )]
public partial class Platform : BasePhysics
{
	[Net]
	public bool IsTriggered { get; private set; }

	private readonly float ExpireTime = 3f;

	public override void Spawn()
	{
		base.Spawn();

		PhysicsEnabled = false;
	}

	protected override void OnPhysicsCollision( CollisionEventData eventData )
	{
		if ( !IsServer || IsTriggered ) return;

		var other = eventData.Other;

		if ( other.Entity is not Player player ) return;

		StartCountdown();
	}

	private RealTimeUntil ExpireCountdown { get; set; }

	private void StartCountdown()
	{
		ExpireCountdown = ExpireTime;
	}

	public override void Simulate( Client cl )
	{
		base.Simulate( cl );

		if ( ExpireCountdown < 0 ) return;

		Delete();
	}
}

