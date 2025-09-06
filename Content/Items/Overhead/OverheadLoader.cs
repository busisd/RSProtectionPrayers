using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Utilities;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace RSProtectionPrayers.Content.Items.Overhead
{
	// Note: To fully understand this example, please start by reading https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod/Common/CustomVisualEquipType/README.md

	/// <summary>
	/// OverheadLoader manages loading overhead equipment textures for each item using this custom EquipType. 
	/// </summary>
	public class OverheadLoader : ModSystem
	{
		/// <summary> Maps an item type to it's corresponding overhead equipment texture. </summary>
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
