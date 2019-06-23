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