using SandboxEditor;
using Sandbox;
using Alydus.Spleef;
using Spleef.weapons;

namespace Spleef.entities;

/// <summary>
/// Represents a Spleef platform.<br/>
/// <br/>
/// This platform is activated in gameplay by hitting it with the <see cref="Crowbar"/>
/// </summary>

[HammerEntity, Model, RenderFields, VisGroup( VisGroup.Physics )]

public partial class PlatformHit : APlatform
{
	public override void Spawn()
	{
		base.Spawn();

		ExpireTime = 3.5f;

		ConfigureModel( "models/citizen_props/crate01.vmdl" );
	}
}
