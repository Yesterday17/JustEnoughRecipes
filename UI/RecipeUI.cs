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

      panelTitle = new UIItemNameText();
      RecipeUIPanel.Append(panelTitle);

      UITextButton button = new UITextButton("2333");
      button.Top.Set(100f, 0f);
      RecipeUIPanel.Append(button);

      Texture2D prevTexture = JustEnoughRecipes.instance.GetTexture("UI/arrow_prev");
      UIImageButton prevButton = new UIImageButton(prevTexture);
      prevButton.Width.Set(32f, 0f);
      prevButton.Height.Set(32f, 0f);
      prevButton.Top.Set(200f, 0f);
      prevButton.Left.Set(0f, 0f);
      RecipeUIPanel.Append(prevButton);

      Append(RecipeUIPanel);
    }

    public override void Update(GameTime gameTime) {
      base.Update(gameTime);
    }
  }
}