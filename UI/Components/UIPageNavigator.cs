using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;

namespace JustEnoughRecipes.UI.Components {
  public class UIPageNavigator : UIElement {

    UIImageButton prevButton;
    UIImageButton nextButton;
    UIText pageText;

    private static Texture2D prevTexture;
    private static Texture2D nextTexture;

    private int _now;
    private int _total;

    public UIPageNavigator() {
      prevTexture = JustEnoughRecipes.instance.GetTexture("UI/arrow_prev");
      nextTexture = JustEnoughRecipes.instance.GetTexture("UI/arrow_next");

      _now = 0;
      _total = 0;
    }

    public override void OnInitialize() {
      this.Width.Set(Parent.Width.Pixels, 0f);
      this.Height.Set(16f, 0f);

      // prev button
      prevButton = new UIImageButton(prevTexture);
      prevButton.Width.Set(16f, 0f);
      prevButton.Height.Set(16f, 0f);
      prevButton.Top.Set(0f, 0f);
      prevButton.Left.Set(0f, 0f);
      Append(prevButton);

      // next button
      nextButton = new UIImageButton(nextTexture);
      nextButton.Width.Set(16f, 0f);
      nextButton.Height.Set(16f, 0f);
      nextButton.Top.Set(0f, 0f);
      nextButton.Left.Set(Parent.Width.Pixels - nextButton.Width.Pixels - Parent.PaddingLeft - Parent.PaddingRight, 0f);
      Append(nextButton);

      // page text
      pageText = new UIText(_now.ToString() + "/" + _total.ToString());
      pageText.Left.Set(Parent.Width.Pixels / 2 - Parent.PaddingLeft - Parent.PaddingRight, 0f);
      Append(pageText);
    }
  }
}