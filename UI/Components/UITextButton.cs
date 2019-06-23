using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.UI;
using Terraria.ModLoader;

namespace JustEnoughRecipes.UI.Components {
  public class UITextButton : UIElement {
    private static Texture2D _borderTexture;
    private static Texture2D _backgroundTexture;

    public Color BorderColor = Color.Black;
    public Color BackgroundColor = Color.Multiply(new Color(63, 82, 151), 0.7f);

    protected string text;
    protected Color textColor;

    public UITextButton(string text, Color color) {
      this.text = text;
      this.textColor = color;
      _backgroundTexture = ModLoader.GetTexture("Terraria/UI/PanelBackground");
      _borderTexture = ModLoader.GetTexture("Terraria/UI/PanelBorder");
    }

    public UITextButton(string text) : this(text, Color.White) { }

    protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch) {
      CalculatedStyle dimensions = GetInnerDimensions();
      var fontSize = Main.fontMouseText.MeasureString(text);

      // Draw background
      spriteBatch.Draw(_borderTexture, new Rectangle((int)dimensions.X, (int)dimensions.Y, (int)fontSize.X + 24, (int)fontSize.Y + 10), BackgroundColor);

      // Draw Text
      dimensions = GetInnerDimensions();
      Vector2 textPosition = new Vector2(dimensions.X + 12, dimensions.Y + 5);
      Terraria.Utils.DrawBorderString(spriteBatch, text, textPosition, textColor);
    }
  }
}