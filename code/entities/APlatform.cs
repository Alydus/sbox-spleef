using Sandbox;

namespace Spleef.entities;

/// <summary>
/// An abstract class that makes creating platform entities less repetitive.
/// </summary>
public abstract partial class APlatform : BasePhysics, IPlatform
{
	/// <summary>
	/// Returns <see langword="true"/> if the platform has been activated for removal.
	/// </summary>
	[Net]
	public bool IsTriggered { get; private set; }

	/// <summary>
	/// The length of time this platform takes to be removed after it is triggered.
	/// </summary>
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

	/// <summary>
	/// Sets the platform's model and configures the appropriate physics.
	/// </summary>
	/// <param name="modelName">The path of the prop you want to use.</param>
	protected void ConfigureModel(string modelName)
	{
		SetModel(modelName);
		SetupPhysicsFromModel( PhysicsMotionType.Static );
		EnableSelfCollisions = false;
	}
}

