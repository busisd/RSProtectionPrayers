using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace RSProtectionPrayers.Content.Items.Overhead
{
	// Note: To fully understand this example, please start by reading https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod/Common/CustomVisualEquipType/README.md

  public enum ActiveOverhead
  {
    None,
    Melee,
    Missiles,
    Magic
  }

	/// <summary>
	/// OverheadPlayer stores which overhead will be drawn, and with which dye/shader.
	/// </summary>
	public class OverheadPlayer : ModPlayer
	{
		SoundStyle CancelPrayerSound = new SoundStyle("RSProtectionPrayers/Content/Items/Overhead/Sounds/CancelPrayerSound");
		SoundStyle ProtectMeleeSound = new SoundStyle("RSProtectionPrayers/Content/Items/Overhead/Sounds/ProtectMeleeSound");
		SoundStyle ProtectMissilesSound = new SoundStyle("RSProtectionPrayers/Content/Items/Overhead/Sounds/ProtectMissilesSound");
		SoundStyle ProtectMagicSound = new SoundStyle("RSProtectionPrayers/Content/Items/Overhead/Sounds/ProtectMagicSound");


		// The overhead item type.
		public int overhead;
		// The dye/shader used to draw the overhead.
		public int overheadShader;

		public ActiveOverhead activeOverhead = ActiveOverhead.None;
		private ActiveOverhead previousActiveOverhead = ActiveOverhead.None;

		public override void ResetEffects()
		{
			overhead = 0;
			overheadShader = 0;

			activeOverhead = ActiveOverhead.None;
		}

		public override void PostUpdate()
		{
			if (activeOverhead != previousActiveOverhead)
			{
				switch (activeOverhead)
				{
					case ActiveOverhead.Melee:
						SoundEngine.PlaySound(ProtectMeleeSound);
						break;
					case ActiveOverhead.Missiles:
						SoundEngine.PlaySound(ProtectMissilesSound);
						break;
					case ActiveOverhead.Magic:
						SoundEngine.PlaySound(ProtectMagicSound);
						break;
					case ActiveOverhead.None:
					default:
						SoundEngine.PlaySound(CancelPrayerSound);
						break;
				}
			}
			previousActiveOverhead = activeOverhead;
			base.PostUpdate();
		}

    public override bool FreeDodge(Player.HurtInfo info)
    {
			Entity damageSource;
			info.DamageSource.TryGetCausingEntity(out damageSource);
			if (damageSource == null)
			{
				return false;
			}

			switch (activeOverhead)
			{
				case ActiveOverhead.Melee:
					return damageSource is NPC && (damageSource as NPC).aiStyle != 9;
				case ActiveOverhead.Missiles:
					return damageSource is Projectile;
				case ActiveOverhead.Magic:
					return damageSource is NPC && (damageSource as NPC).aiStyle == 9;
				case ActiveOverhead.None:
				default:
					return base.FreeDodge(info);
			}
    }
	}
}
