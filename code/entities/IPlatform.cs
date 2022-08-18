using SandboxEditor;
using Sandbox;
using Alydus.Spleef;

namespace Spleef.entities;

/// <summary>
/// Represents a platform entity in the Spleef gamemode.
/// </summary>
public interface IPlatform
{
	/// <summary>
	/// This method starts the process of making a platform disappear.
	/// </summary>
	void TriggerCountdown();

	/// <summary>
	/// This method is invoked when the platform's countdown timer (triggered by <see cref="TriggerCountdown"/>) has reached zero.
	/// </summary>
	void CountdownEnded();

	/// <summary>
	/// This method resets the platform. Useful for repeating a stage multiple times.
	/// </summary>
	void Reset();
}
