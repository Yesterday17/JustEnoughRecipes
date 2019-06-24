using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;

namespace JustEnoughRecipes.UI.Components {
  public class UIItemRecipe : UIElement {
    private List<Recipe> _recipes;
    private Recipe _activeRecipe;

    public UIItemRecipe() { }

    public void SetRecipes(List<Recipe> recipes) {
      this._recipes = recipes;
      if (recipes.Count != 0) {
        this._activeRecipe = recipes[0];
      }
    }

    public void SetActive(int count) {
      if (count >= this._recipes.Count) {
        count = this._recipes.Count - 1;
      } else if (count < 0) {
        count = 0;
      }
      this._activeRecipe = this._recipes[count];
    }

    public override void OnInitialize() {

    }
  }
}