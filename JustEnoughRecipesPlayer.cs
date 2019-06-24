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
          JustEnoughRecipes.instance.recipeUI.panelTitle.UpdateItem(selected);

          RecipeFinder finder = new RecipeFinder();
          finder.SetResult(selected.netID);
          var result = finder.SearchRecipes();
          JustEnoughRecipes.instance.recipeUI.SetRecipes(result);
          JustEnoughRecipes.instance.recipeUI.pageNavigator.SetTotal(result.Count);

          JustEnoughRecipes.instance.recipeUI.Visible = true;
        } else {
          JustEnoughRecipes.instance.recipeUI.Visible = false;
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
      JustEnoughRecipes.instance.recipeUI.Visible = false;
    }
  }
}