using System.Collections.Generic;
using Terraria;
using Terraria.UI;

namespace JustEnoughRecipes.UI.Components {
  public class UIItemRecipe : UIElement {
    private Recipe _activeRecipe;

    private UIItemSlot craftingEnvironment;
    private List<UIItemSlot> _slots = new List<UIItemSlot>(Recipe.maxRequirements);

    public UIItemRecipe() { }

    public void SetRecipe(Recipe recipe) {
      this._activeRecipe = recipe;
      ClearRecipe();
      this.SetCraftingEnvironment(Utils.TileItemMap.GetTileItem(recipe.requiredTile[0]));

      for (var i = 0; i < recipe.requiredItem.Length; i++) {
        this._slots[i].SetItem(recipe.requiredItem[i].IsAir ? null : recipe.requiredItem[i]);
      }
    }

    public void ClearRecipe() {
      this.SetCraftingEnvironment(null);
      foreach (var slot in this._slots) {
        slot.SetItem(null);
      }
    }

    public void SetCraftingEnvironment(Item item) {
      if (craftingEnvironment != null)
        craftingEnvironment.SetItem(item);
    }

    public override void OnInitialize() {
      this.Width.Set(Parent.Width.Pixels, 0f);
      this.Height.Set(150f, 0f);

      craftingEnvironment = new UIItemSlot();
      this.Append(craftingEnvironment);

      var lineCount = (Parent.Width.Pixels - craftingEnvironment.Width.Pixels - 10f) / (craftingEnvironment.Width.Pixels + 15f);
      int i = 0, j = 0;

      for (int k = 0; k < _slots.Capacity; k++) {
        var currentSlot = new UIItemSlot();
        currentSlot.Top.Set(craftingEnvironment.Height.Pixels * j, 0f);
        currentSlot.Left.Set(craftingEnvironment.Width.Pixels + 10f + (craftingEnvironment.Width.Pixels + 5f) * i, 0f);

        if (++i >= lineCount) {
          i = 0;
          ++j;
        }
        this._slots.Add(currentSlot);
        this.Append(currentSlot);
      }
    }
  }
}