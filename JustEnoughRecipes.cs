using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.UI;
using Terraria.ModLoader;

using JustEnoughRecipes.UI;

namespace JustEnoughRecipes {
  public class JustEnoughRecipes : Mod {
    // Debug, set to false when release
    public static bool DEBUG = true;

    // Mod instance
    internal static JustEnoughRecipes instance;
    public static ModHotKey ItemRecipeKey;
    public static ModHotKey ItemUsageKey;

    public UserInterface UI;
    public JustEnoughRecipes() {
      instance = this;
    }

    public override void Load() {
      if (!Main.dedServ) {
        RecipeUI recipeUI = new RecipeUI();
        recipeUI.Activate();

        UI = new UserInterface();
        UI.SetState(recipeUI);
        ItemRecipeKey = RegisterHotKey("Show Item Recipe", "R");
        ItemUsageKey = RegisterHotKey("Show Item Usage", "U");
      }
    }

    public override void Unload() {
      instance = null;
      ItemRecipeKey = null;
      ItemUsageKey = null;
    }

    public override void UpdateUI(GameTime gameTime) {
      if (!Main.gameMenu && RecipeUI.Visible) {
        UI.Update(gameTime);
      }
    }
    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
      layers.Add(new LegacyGameInterfaceLayer("Recipe UI", DrawRecipeUI, InterfaceScaleType.UI));
    }

    private bool DrawRecipeUI() {
      // in-game && is-visible && in-inventory-ui
      if (!Main.gameMenu && RecipeUI.Visible && Main.playerInventory) {
        UI.Draw(Main.spriteBatch, new GameTime());
      }
      return true;
    }
  }
}
