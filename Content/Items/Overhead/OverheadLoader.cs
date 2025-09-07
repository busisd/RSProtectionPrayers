using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Utilities;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace RSProtectionPrayers.Content.Items.Overhead
{
	// See: https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod/Common/CustomVisualEquipType/README.md
	public class OverheadLoader : ModSystem
	{
		/// <summary> Maps an item type to its corresponding overhead equipment texture. </summary>
		internal static readonly Dictionary<int, Asset<Texture2D>> overheadItemToTexture = new();

		public override void ResizeArrays() {
			// After all content is loaded, autoload overhead equipment textures
			for (int i = ItemID.Count; i < ItemLoader.ItemCount; i++) {
				ModItem modItem = ItemLoader.GetItem(i);
				if (modItem.GetType().GetAttribute<AutoloadEquip_OverheadAttribute>() != null) {
					AddOverheadTexture(modItem.Type, $"{modItem.Texture}_Overhead");
				}
			}
		}

		public static void AddOverheadTexture(int type, string texture) {
			var asset = ModContent.Request<Texture2D>(texture);
			overheadItemToTexture[type] = asset;
		}
	}
}
