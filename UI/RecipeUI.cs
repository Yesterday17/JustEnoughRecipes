using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using JustEnoughRecipes.UI.Components;

namespace JustEnoughRecipes.UI {
  public class RecipeUI : UIState {
    private List<Recipe> _recipes;
    public RecipeUIPanel RecipeUIPanel;
    public UIItemNameText panelTitle;
    public UIPageNavigator pageNavigator;
    public UIItemRecipe recipeManager;
    public bool Visible;

    public void SetRecipes(List<Recipe> recipes) {
      this._recipes = recipes;
    }

    public override void OnInitialize() {
      RecipeUIPanel = new RecipeUIPanel();
      RecipeUIPanel.Left.Set(400f, 0f);
      RecipeUIPanel.Top.Set(400f, 0f);
      RecipeUIPanel.Width.Set(500f, 0f);
      RecipeUIPanel.Height.Set(300f, 0f);
      RecipeUIPanel.BackgroundColor = new Color(73, 94, 171);

      // title
      panelTitle = new UIItemNameText();
      RecipeUIPanel.Append(panelTitle);

      // page
      pageNavigator = new UIPageNavigator();
      pageNavigator.Top.Set(32f, 0f); // the height of text is 30, add 2px gap
      pageNavigator.PageUpdateEvent += UpdateRecipe;
      RecipeUIPanel.Append(pageNavigator);

      // recipe
      recipeManager = new UIItemRecipe();
      recipeManager.Top.Set(55f, 0f);
      RecipeUIPanel.Append(recipeManager);

      // button(test)
      // UITextButton button = new UITextButton("2333");
      // button.Top.Set(100f, 0f);
      // RecipeUIPanel.Append(button);

      Append(RecipeUIPanel);
    }

    public override void Update(GameTime gameTime) {
      base.Update(gameTime);
    }

    public void UpdateRecipe(object sender, PageUpdateEventArgs e) {
      // TODO: Update recipe here
      if (e.Now <= this._recipes.Count && e.Now > 0) {
        recipeManager.SetRecipe(this._recipes[e.Now - 1]);
      } else {
        recipeManager.ClearRecipe();
      }
    }
  }
}