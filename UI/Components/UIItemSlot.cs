using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.UI;

namespace JustEnoughRecipes.UI.Components {
  public class UIItemSlot : UIElement {
    public static Texture2D backgroundTexture = Main.inventoryBack9Texture;
    private Item _item;
    private float _scale;
    private bool _drawBackground;

    public UIItemSlot(Item item = null, float scale = 0.75f, bool drawBackground = true) {
      SetItem(item);
      this._scale = scale;
      this._drawBackground = drawBackground;

      this.Width.Set(backgroundTexture.Width * this._scale, 0f);
      this.Height.Set(backgroundTexture.Height * this._scale, 0f);
    }

    public void SetItem(Item item) {
      this._item = item;
    }

    public void SetBackground(bool enable) {
      this._drawBackground = enable;
    }

    public bool IsEmpty() {
      return this._item == null;
    }

    protected override void DrawSelf(SpriteBatch spriteBatch) {
      if (this._item != null) {
        CalculatedStyle dimensions = base.GetInnerDimensions();
        Rectangle rectangle = dimensions.ToRectangle();

        if (this._drawBackground) {
          // draw slot background
          spriteBatch.Draw(backgroundTexture, dimensions.Position(), null, Color.White, 0f, Vector2.Zero, this._scale, SpriteEffects.None, 0f);
        }

        if (!this._item.IsAir) {
          // Draw item
          Texture2D itemTexture = Main.itemTexture[this._item.type];
          Vector2 bgSize = backgroundTexture.Size() * this._scale;
          Rectangle itemRectangle = itemTexture.Frame(1, 1, 0, 0);
          Vector2 position2 = dimensions.Position() + bgSize / 2f - itemRectangle.Size() * this._scale / 2f;
          spriteBatch.Draw(itemTexture, position2, null, Color.White, 0f, Vector2.Zero, this._scale, SpriteEffects.None, 0f);

          // Draw item count if larger than 1
          if (this._item.stack > 1) {
            var fontSize = Main.fontMouseText.MeasureString(this._item.stack.ToString()) * this._scale;
            var fontPos = dimensions.Position() + bgSize - fontSize;
            Terraria.Utils.DrawBorderString(spriteBatch, this._item.stack.ToString(), fontPos, Color.White, this._scale);
          }

          if (IsMouseHovering) {
            Main.HoverItem = this._item.Clone();
            Main.hoverItemName = this._item.Name;
          }
        }
      }
    }
  }
}