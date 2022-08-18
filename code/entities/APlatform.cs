using Sandbox;

namespace Spleef.entities;

public abstract partial class APlatform : BasePhysics, IPlatform
{
	[Net]
	public bool IsTriggered { get; private set; }

	protected float ExpireTime = 3f;

	private TimeUntil ExpireCountdown { get; set; }

	public void TriggerCountdown()
	{
		IsTriggered = true;
		ExpireCountdown = ExpireTime;
	}

	public override void Simulate(Client cl)
	{
		base.Simulate(cl);

		if (!( IsServer && IsTriggered )) return;

		if (ExpireCountdown < 0)
		{
			CountdownEnded();
		}
	}

	public virtual void CountdownEnded()
	{
		EnableSolidCollisions = false;
	}

	public virtual void Reset()
	{
		EnableSolidCollisions = true;
	}

	protected void ConfigureModel(string modelName)
	{
		SetModel(modelName);
		SetupPhysicsFromModel( PhysicsMotionType.Static );
		EnableSelfCollisions = false;
	}
}

