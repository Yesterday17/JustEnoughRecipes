using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using JustEnoughRecipes.UI.Components;

namespace JustEnoughRecipes.UI {
  public class RecipeUI : UIState {

    public RecipeUIPanel RecipeUIPanel;
    public static UIItemNameText panelTitle;

    public static bool Visible;

    public override void OnInitialize() {
      RecipeUIPanel = new RecipeUIPanel();
      RecipeUIPanel.Left.Set(400f, 0f);
      RecipeUIPanel.Top.Set(400f, 0f);
      RecipeUIPanel.Width.Set(500f, 0f);
      RecipeUIPanel.Height.Set(300f, 0f);
      RecipeUIPanel.BackgroundColor = new Color(73, 94, 171);

      // title
      panelTitle = new UIItemNameText();
      panelTitle.Left.Set(RecipeUIPanel.Width.Pixels / 2 - RecipeUIPanel.PaddingLeft - RecipeUIPanel.PaddingRight, 0f);
      RecipeUIPanel.Append(panelTitle);

      // page
      UIPageNavigator pages = new UIPageNavigator();
      pages.Top.Set(32f, 0f); // the height of text is 30, add 2px gap
      RecipeUIPanel.Append(pages);

      // button
      UITextButton button = new UITextButton("2333");
      button.Top.Set(100f, 0f);
      RecipeUIPanel.Append(button);

      Append(RecipeUIPanel);
    }

    public override void Update(GameTime gameTime) {
      base.Update(gameTime);
    }
  }
}