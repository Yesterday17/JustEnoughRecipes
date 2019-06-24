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
      prevTexture = JustEnoughRecipes.instance.GetTexture("Assets/arrow_prev");
      nextTexture = JustEnoughRecipes.instance.GetTexture("Assets/arrow_next");
      SetPages(0, 0);
    }

    protected string progress {
      get {
        return _now.ToString() + "/" + _total.ToString();
      }
    }

    public int SetPages(int now, int total) {
      if (total < 0) total = 0;
      if (now < 1) now = total > 0 ? 1 : 0;
      if (now > total) now = total;
      this._now = now;
      this._total = total;

      if (pageText != null)
        pageText.SetText(progress);

      return this._now;
    }

    public int SetNow(int now) {
      return SetPages(now, this._total);
    }

    public int SetTotal(int total) {
      return SetPages(total == 0 ? 0 : 1, total);
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
      prevButton.OnClick += this.PrevButtonClicked;
      Append(prevButton);

      // next button
      nextButton = new UIImageButton(nextTexture);
      nextButton.Width.Set(16f, 0f);
      nextButton.Height.Set(16f, 0f);
      nextButton.Top.Set(0f, 0f);
      nextButton.Left.Set(Parent.Width.Pixels - nextButton.Width.Pixels - Parent.PaddingLeft - Parent.PaddingRight, 0f);
      nextButton.OnClick += this.NextButtonClicked;
      Append(nextButton);

      // page text
      pageText = new UIText(progress);
      pageText.Left.Set(Parent.Width.Pixels / 2 - Parent.PaddingLeft - Parent.PaddingRight, 0f);
      Append(pageText);
    }

    public void NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
      Utils.Logger.Log("Next");
      this.SetNow(this._now + 1);
    }

    public void PrevButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
      Utils.Logger.Log("Prev");
      this.SetNow(this._now - 1);
    }
  }
}