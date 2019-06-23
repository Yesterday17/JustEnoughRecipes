using Terraria;
using Terraria.GameContent.UI.Elements;

namespace JustEnoughRecipes.UI {
  public class RecipeUIPanel : UIPanel {
    public override void Update(Microsoft.Xna.Framework.GameTime gameTime) {
      base.Update(gameTime);

      if (Main.playerInventory && ContainsPoint(Main.MouseScreen)) {
        Main.LocalPlayer.mouseInterface = true;
      }
    }
  }
}