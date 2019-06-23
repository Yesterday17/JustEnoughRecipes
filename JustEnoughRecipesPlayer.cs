using JustEnoughRecipes.UI;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace JustEnoughRecipes {
  public class JustEnoughRecipesPlayer : ModPlayer {
    public override void ProcessTriggers(TriggersSet triggersSet) {
      if (JustEnoughRecipes.ItemRecipeKey.JustPressed) {
        Item selected = Main.mouseItem != null ? Main.mouseItem : Main.HoverItem;
        if (selected != null) {
          RecipeUI.panelTitle.UpdateItem(selected);
        }

        RecipeUI.Visible = true;
      }
    }

    public override void OnEnterWorld(Player player) {
      RecipeUI.Visible = false;
    }
  }
}