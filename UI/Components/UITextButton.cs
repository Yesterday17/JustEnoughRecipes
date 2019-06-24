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
    public Color BackgroundColor = new Color(63, 82, 151) * 0.7f;

    protected string text;
    protected Color textColor;

    private float _visibilityActive = 1.0f;
    private float _visibilityInactive = 0.7f;
    private float _widthPadding = 14f;
    private float _heightPadding = 5f;

    public UITextButton(string text, Color color) {
      this.textColor = color;
      _backgroundTexture = ModLoader.GetTexture("Terraria/UI/PanelBackground");
      _borderTexture = ModLoader.GetTexture("Terraria/UI/PanelBorder");

      UpdateText(text);
    }

    public UITextButton(string text) : this(text, Color.White) { }

    public void UpdateText(string text) {
      this.text = text;

      // Initialize width & height
      var fontSize = Main.fontMouseText.MeasureString(text);
      this.Width.Set(fontSize.X + _widthPadding * 2, 0f);
      this.Height.Set(fontSize.Y + _heightPadding * 2, 0f);
    }

    protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch) {
      CalculatedStyle dimensions = GetInnerDimensions();

      // Draw border
      spriteBatch.Draw(_borderTexture, new Rectangle((int)dimensions.X, (int)dimensions.Y, (int)this.Width.Pixels, (int)this.Height.Pixels), BackgroundColor);

      // Draw background

      // Draw Text
      dimensions = GetInnerDimensions();
      Vector2 textPosition = new Vector2(dimensions.X + _widthPadding, dimensions.Y + _heightPadding);
      Terraria.Utils.DrawBorderString(spriteBatch, text, textPosition, textColor * (IsMouseHovering ? _visibilityActive : _visibilityInactive));
    }

    public override void MouseOver(UIMouseEvent evt) {
      base.MouseOver(evt);
      Main.PlaySound(12, -1, -1, 1, 1f, 0.0f);
    }

    public void SetVisibility(float whenActive, float whenInactive) {
      this._visibilityActive = MathHelper.Clamp(whenActive, 0.0f, 1f);
      this._visibilityInactive = MathHelper.Clamp(whenInactive, 0.0f, 1f);
    }

    public override void Click(UIMouseEvent evt) {
      UpdateText(text + "1");
      Utils.Logger.Log("Button Clicked: " + text);
    }
  }
}