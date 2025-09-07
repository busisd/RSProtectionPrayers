using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace RSProtectionPrayers.Content.Items.Overhead
{
	// See: https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod/Common/CustomVisualEquipType/README.md
	public class OverheadDrawLayer : PlayerDrawLayer
	{
		public override bool IsHeadLayer => true;

		public override bool GetDefaultVisibility(PlayerDrawSet drawInfo) {
			return drawInfo.drawPlayer.GetModPlayer<OverheadPlayer>().overhead > 0;
		}

		public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Head);

		protected override void Draw(ref PlayerDrawSet drawInfo) {
			Player drawPlayer = drawInfo.drawPlayer;
			OverheadPlayer OverheadPlayer = drawPlayer.GetModPlayer<OverheadPlayer>();
			int overhead = OverheadPlayer.overhead;
			var overheadTexture = OverheadLoader.overheadItemToTexture[overhead];

			// Calculate where to draw this layer. 
			var drawPosition = new Vector2(
				(int)(drawInfo.Position.X - Main.screenPosition.X),
				(int)(drawInfo.Position.Y - Main.screenPosition.Y) - 34
			);

			var drawData = new DrawData(
				overheadTexture.Value,
				drawPosition,
				Color.White
			);
			drawData.shader = OverheadPlayer.overheadShader;
			drawInfo.DrawDataCache.Add(drawData);
		}
	}
}
