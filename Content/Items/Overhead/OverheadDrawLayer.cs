using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace RSProtectionPrayers.Content.Items.Overhead
{
	// Note: To fully understand this example, please start by reading https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod/Common/CustomVisualEquipType/README.md

	/// <summary>
	/// OverheadDrawLayer is a PlayerDrawLayer that renders a custom EquipType. 
	/// </summary>
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
				(int)(drawInfo.Position.X - Main.screenPosition.X), //+ overheadTexture.Width()/2,
				(int)(drawInfo.Position.Y - Main.screenPosition.Y) - (34 * drawPlayer.gravDir)
			);

			// Source rectangle. Player.bodyFrame corresponds to the animation frame (pose) that the player is currently in.
			// Vanilla player layers for EquipTypes have a separate image for each pose to account for how layers move in relation to each other while the player is animating, but this example doesn't need that so we use the same image all the time.
			// Rectangle drawFrame = drawPlayer.bodyFrame;
			// drawFrame.Y = 0;

			var drawData = new DrawData(
				overheadTexture.Value,
				drawPosition,
				Color.White
			);
			// drawData.ignorePlayerRotation = true;
			drawData.shader = OverheadPlayer.overheadShader;
			drawInfo.DrawDataCache.Add(drawData);
		}
	}
}
