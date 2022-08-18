using SandboxEditor;
using Sandbox;
using Alydus.Spleef;

namespace Spleef.entities;

//[Library( "platform" )]
[HammerEntity, Model, RenderFields, VisGroup( VisGroup.Physics )]
//[Title( "Platform" ), Category( "Gameplay" ), Icon( "chair" )]

public partial class PlatformHit : APlatform
{
	public override void Spawn()
	{
		base.Spawn();

		ExpireTime = 3.5f;

		ConfigureModel( "models/citizen_props/crate01.vmdl" );
	}
}
