using SandboxEditor;
using Sandbox;
using Alydus.Spleef;

namespace Spleef.entities;

public interface IPlatform
{
	void TriggerCountdown();
	void CountdownEnded();
	void Reset();
}
