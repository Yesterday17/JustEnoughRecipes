using Microsoft.Xna.Framework;
using Terraria;
using Terraria.UI;

namespace JustEnoughRecipes.UI.Components {
  public class UIItemNameText : UIElement {
    public Item bindItem;

    public UIItemNameText() {
      UpdateItem(null);
    }

    public UIItemNameText(Item item) {
      UpdateItem(item);
    }

    public void UpdateItem(Item item) {
      this.bindItem = item;

      if (item != null) {
        var fontSize = Main.fontMouseText.MeasureString(item.Name);
        this.Width.Set(fontSize.X, 0f);
        this.Height.Set(fontSize.Y, 0f);
        this.Left.Set(Parent.Width.Pixels / 2 - fontSize.X / 2 - Parent.PaddingRight, 0f);
      }
    }

    public void UnbindItem() {
      UpdateItem(null);
    }

    protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch) {
      CalculatedStyle innerDimensions = GetInnerDimensions();
      string name = bindItem == null ? "" : bindItem.Name;
      Terraria.Utils.DrawBorderString(spriteBatch, name, innerDimensions.Position(), Color.White);
    }
  }
}