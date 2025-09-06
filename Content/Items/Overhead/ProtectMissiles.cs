using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RSProtectionPrayers.Content.Items.Overhead
{
	// A vanity accessory showcasing our custom overhead EquipType
	[AutoloadEquip_Overhead]
	public class ProtectMissiles : ModItem
	{
		public override void SetDefaults()
		{
			Item.SetNameOverride("Protect from Missiles");
			Item.DefaultToAccessory(30, 30);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Bone, 99);
			recipe.Register();
		}

		public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
		{
			return !(incomingItem.ModItem is ProtectMelee || incomingItem.ModItem is ProtectMagic);
		}

    public override void UpdateEquip(Player player)
    {
    	player.GetModPlayer<OverheadPlayer>().activeOverhead = ActiveOverhead.Missiles;
      base.UpdateEquip(player);
    }
	}
}
