using Microsoft.Xna.Framework;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using JustEnoughRecipes.UI.Components;

namespace JustEnoughRecipes.UI {
  public class RecipeUI : UIState {

    public UIPanel RecipeUIPanel;
    public static UIItemNameText panelTitle;

    public static bool Visible;

    public override void OnInitialize() {
      RecipeUIPanel = new UIPanel();

      RecipeUIPanel.Left.Set(400f, 0f);
      RecipeUIPanel.Top.Set(100f, 0f);
      RecipeUIPanel.Width.Set(500f, 0f);
      RecipeUIPanel.Height.Set(300f, 0f);
      RecipeUIPanel.BackgroundColor = new Color(73, 94, 171);

      panelTitle = new UIItemNameText();
      RecipeUIPanel.Append(panelTitle);

      Append(RecipeUIPanel);
    }

    public override void Update(GameTime gameTime) {
      base.Update(gameTime);
    }
  }
}