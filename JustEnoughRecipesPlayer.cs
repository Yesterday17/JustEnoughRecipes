using JustEnoughRecipes.UI;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace JustEnoughRecipes {
  public class JustEnoughRecipesPlayer : ModPlayer {
    public override void ProcessTriggers(TriggersSet triggersSet) {
      if (JustEnoughRecipes.ItemRecipeKey.JustPressed) {
        Item selected = Main.mouseItem.netID != 0 ? Main.mouseItem : Main.HoverItem;
        Main.NewText(selected.ToString());
        if (selected.netID != 0) {
          RecipeUI.panelTitle.UpdateItem(selected);
          RecipeUI.Visible = true;
        } else {
          RecipeUI.Visible = false;
        }
      }
    }

    public override void OnEnterWorld(Player player) {
      RecipeUI.Visible = false;
    }
  }
}