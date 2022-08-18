using SandboxEditor;
using Sandbox;
using Alydus.Spleef;

namespace Spleef.entities;

//[Library( "platform" )]
[HammerEntity, Model, RenderFields, VisGroup( VisGroup.Physics )]
//[Title( "Platform" ), Category( "Gameplay" ), Icon( "chair" )]
public partial class PlatformWalk : BasePhysics
{
	[Net]
	public bool IsTriggered { get; private set; }

	private readonly float ExpireTime = 3f;

	public override void Spawn()
	{
		base.Spawn();

		var modelName = "models/citizen_props/crate01.vmdl";

		SetModel( modelName );
		SetupPhysicsFromModel( PhysicsMotionType.Keyframed );
		EnableSelfCollisions = false;

		var trigger = new ModelEntity
		{
			Parent = this,
			Position = Position,
			Rotation = Rotation,
			EnableTouch = true,
			Transmit = TransmitType.Never,
			EnableSelfCollisions = false
		};

		//var trigger = new BaseTrigger
		//{
		//	Parent = this,
		//	Position = Position,
		//	Rotation = Rotation,
		//};

		trigger.SetModel( modelName );
	}

	//protected override void OnPhysicsCollision( CollisionEventData eventData )
	//{
	//	Log.Info( "Run" );
	//	if ( !IsServer || IsTriggered ) return;

	//	var other = eventData.Other;

	//	if ( other.Entity is not SpleefPlayer player ) return;

	//	StartCountdown();
	//}

	public override void StartTouch( Entity other )
	{
		base.StartTouch( other );

		if (IsServer)
			Log.Info( "touch" );
	}

	private RealTimeUntil ExpireCountdown { get; set; }

	private void StartCountdown()
	{
		ExpireCountdown = ExpireTime;
	}

	public override void Simulate( Client cl )
	{
		base.Simulate( cl );
	}
}

