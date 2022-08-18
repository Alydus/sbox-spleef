using Sandbox;
using Alydus.Spleef;
using Spleef.entities;

namespace Speef.weapons;

public partial class Crowbar : BaseWeapon
{
	public override string ViewModelPath => "models/crowbar/view/v.crowbar.vmdl";

	public override float PrimaryRate => 1.0f;
	public override float SecondaryRate => 0.5f;

	public override bool CanReload()
	{
		return false;
	}

	private float Range = 70f;

	public override void AttackPrimary()
	{
		TimeSincePrimaryAttack = 0;

		PlaySound( "sounds/crowbar/cbar_miss.sound" ); // fix
		ViewModelEntity?.SetAnimParameter( "attack_has_hit", false );

		var trace = Trace.Ray( Owner.EyePosition, Owner.EyePosition + Owner.EyeRotation.Forward * Range )
			.Run();

		if (trace.Hit && trace.Entity is IPlatform plat)
		{
			plat.TriggerCountdown();
			ViewModelEntity?.SetAnimParameter( "attack_has_hit", true );

			using ( Prediction.Off() )
				PlaySound( "sounds/crowbar/cbar_hit.sound" ); // fix
		}

		ViewModelEntity?.SetAnimParameter( "attack", true );
		ViewModelEntity?.SetAnimParameter( "holdtype_attack", false ? 2 : 1 );

		(Owner as AnimatedEntity).SetAnimParameter( "b_attack", true );

	}

	public override bool CanSecondaryAttack()
	{
		return true;
	}

	public override void AttackSecondary()
	{
		if ( !IsServer ) return;

		var tr = Trace.Ray( EyePosition, EyePosition + EyeRotation.Forward * 4000 ).WorldOnly().Run();

		if ( tr.Hit )
		{
			new PlatformHit
			{
				Position = tr.EndPosition,
				Rotation = Rotation.From( 0f, EyeRotation.Yaw(), 0f )
			};
		}
	}

	public override void SimulateAnimator( PawnAnimator anim )
	{
		anim.SetAnimParameter( "holdtype", 7 );
		anim.SetAnimParameter( "aim_body_weight", 1.0f );

		if ( Owner.IsValid() )
		{
			ViewModelEntity?.SetAnimParameter( "b_grounded", Owner.GroundEntity.IsValid() );
			ViewModelEntity?.SetAnimParameter( "aim_pitch", Owner.EyeRotation.Pitch() );

		}
	}
}
