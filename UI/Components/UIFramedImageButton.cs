using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;

namespace JustEnoughRecipes.UI.Components {
  public class UIFramedImageButton : UIImageButton {
    private Texture2D _texture;
    private Rectangle _frame;
    public UIFramedImageButton(Texture2D texture, Rectangle frame) : base(texture) {
      this._texture = texture;
      this._frame = frame;
      this.Width.Set(frame.Width, 0f);
      this.Height.Set(frame.Height, 0f);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch) {
      CalculatedStyle dimensions = this.GetDimensions();
      spriteBatch.Draw(this._texture, dimensions.Position(), this._frame, Color.White);
    }
  }
}