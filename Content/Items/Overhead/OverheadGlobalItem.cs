using Terraria;
using Terraria.ModLoader;

namespace RSProtectionPrayers.Content.Items.Overhead
{
	// See: https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod/Common/CustomVisualEquipType/README.md
	public class OverheadGlobalItem : GlobalItem
	{
		public override void UpdateVisibleAccessory(Item item, Player player, bool hideVisual) {
			// UpdateVisibleAccessory is called even when not visible to allow for some advanced usages, so we need this check
			if (hideVisual) {
				return;
			}

			if (OverheadLoader.overheadItemToTexture.ContainsKey(item.type)) {
				player.GetModPlayer<OverheadPlayer>().overhead = item.type;
			}
		}

		public override void UpdateItemDye(Item item, Player player, int dye, bool hideVisual) {
			// UpdateItemDye is called even when not visible to allow for some advanced usages, so we need this check
			if (hideVisual) {
				return;
			}

			if (OverheadLoader.overheadItemToTexture.ContainsKey(item.type)) {
				player.GetModPlayer<OverheadPlayer>().overheadShader = dye;
			}
		}
	}
}
