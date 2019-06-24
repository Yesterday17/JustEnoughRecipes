using JustEnoughRecipes.UI;
using JustEnoughRecipes.Utils;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace JustEnoughRecipes {
  public class JustEnoughRecipesPlayer : ModPlayer {
    public override void ProcessTriggers(TriggersSet triggersSet) {
      if (JustEnoughRecipes.ItemRecipeKey.JustPressed) {
        Item selected = Main.mouseItem.netID != 0 ? Main.mouseItem : Main.HoverItem;
        if (selected.netID != 0) {
          Logger.Log(selected.ToString());
          RecipeUI.panelTitle.UpdateItem(selected);
          RecipeUI.slot.SetItem(selected);

          RecipeFinder finder = new RecipeFinder();
          finder.SetResult(selected.netID);
          var result = finder.SearchRecipes();
          RecipeUI.pageNavigator.SetTotal(result.Count);
          RecipeUI.Visible = true;
        } else {
          RecipeUI.Visible = false;
        }
      } else if (JustEnoughRecipes.ItemUsageKey.JustPressed) {
        // TODO: Usage page
        Item selected = Main.mouseItem.netID != 0 ? Main.mouseItem : Main.HoverItem;
        if (selected.netID != 0) {
          RecipeFinder finder = new RecipeFinder();
          finder.AddIngredient(selected.netID);
          foreach (var r in finder.SearchRecipes()) {
            Logger.Log(r.createItem.Name);
          }
        }
      }
    }

    public override void OnEnterWorld(Player player) {
      RecipeUI.Visible = false;
    }
  }
}