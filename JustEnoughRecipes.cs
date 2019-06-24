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

    public RecipeUI recipeUI;
    public UserInterface UI;
    public JustEnoughRecipes() {
      instance = this;
    }

    public override void Load() {
      if (!Main.dedServ) {
        recipeUI = new RecipeUI();
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
      if (!Main.gameMenu && JustEnoughRecipes.instance.recipeUI.Visible) {
        UI.Update(gameTime);
      }
    }
    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
      int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
      if (mouseTextIndex != -1) {
        layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
          "JustEnoughRecipes: Recipe UI",
          delegate {
            if (!Main.gameMenu && JustEnoughRecipes.instance.recipeUI.Visible && Main.playerInventory) {
              UI.Draw(Main.spriteBatch, new GameTime());
            }
            return true;
          },
          InterfaceScaleType.UI)
        );
      }
    }
  }
}
