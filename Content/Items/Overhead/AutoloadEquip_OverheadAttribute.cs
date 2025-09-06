using System;

namespace RSProtectionPrayers.Content.Items.Overhead
{
	/// <summary>
	/// This attribute will cause an annotated ModItem class to attempt to autoload an equipment texture for this custom EquipType. This works even in other mods. This is similar to how AutoloadEquip is used to autoload textures for vanilla EquipType.
	/// <para/> The autoloaded texture's path will be Texture + _Overhead.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class AutoloadEquip_OverheadAttribute : Attribute
	{
	}
}
