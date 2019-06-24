using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;

namespace JustEnoughRecipes.UI {
  public class RecipeUIPanel : UIPanel {
    private Vector2 offset;
    private bool isDragging = false;

    public override void MouseDown(Terraria.UI.UIMouseEvent evt) {
      isDragging = true;
      offset = new Vector2(evt.MousePosition.X - Left.Pixels, evt.MousePosition.Y - Top.Pixels);
    }

    public override void MouseUp(Terraria.UI.UIMouseEvent evt) {
      isDragging = false;
      Left.Set(evt.MousePosition.X - offset.X, 0f);
      Top.Set(evt.MousePosition.Y - offset.Y, 0f);
      Recalculate();
    }

    public override void Update(Microsoft.Xna.Framework.GameTime gameTime) {
      base.Update(gameTime);

      if (Main.playerInventory && ContainsPoint(Main.MouseScreen)) {
        Main.LocalPlayer.mouseInterface = true;
      }

      if (isDragging) {
        Left.Set(Main.mouseX - offset.X, 0f);
        Top.Set(Main.mouseY - offset.Y, 0f);
        Recalculate();
      }

      var parentSpace = Parent.GetDimensions().ToRectangle();
      if (!GetDimensions().ToRectangle().Intersects(parentSpace)) {
        Left.Pixels = Terraria.Utils.Clamp(Left.Pixels, 0, parentSpace.Right - Width.Pixels);
        Top.Pixels = Terraria.Utils.Clamp(Top.Pixels, 0, parentSpace.Bottom - Height.Pixels);
        Recalculate();
      }
    }
  }
}