using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;
using Terraria.ModLoader;

namespace RSProtectionPrayers
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class RSProtectionPrayers : Mod
	{
		public readonly static SoundStyle CancelPrayerSound = new SoundStyle("RSProtectionPrayers/Content/Items/Overhead/Sounds/CancelPrayerSound");
		public readonly static SoundStyle ProtectMeleeSound = new SoundStyle("RSProtectionPrayers/Content/Items/Overhead/Sounds/ProtectMeleeSound");
		public readonly static SoundStyle ProtectMissilesSound = new SoundStyle("RSProtectionPrayers/Content/Items/Overhead/Sounds/ProtectMissilesSound");
		public readonly static SoundStyle ProtectMagicSound = new SoundStyle("RSProtectionPrayers/Content/Items/Overhead/Sounds/ProtectMagicSound");

		public enum ActiveOverhead
		{
			None,
			Melee,
			Missiles,
			Magic
		}
	}
}
