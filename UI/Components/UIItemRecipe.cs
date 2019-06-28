using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.UI;

namespace JustEnoughRecipes.UI.Components {
  public class UIItemRecipe : UIElement {
    private Recipe _activeRecipe;
    private UIItemSlot craftingEnvironment;
    private List<UIItemSlot> _slots = new List<UIItemSlot>(Recipe.maxRequirements);

    private static float globalTextHeightOffset = 20f;
    private static float globalGapPixels = 5f;
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
      craftingEnvironment.Top.Set(globalTextHeightOffset + globalGapPixels, 0f);
      this.Append(craftingEnvironment);

      var lineCount = Parent.Width.Pixels / (craftingEnvironment.Width.Pixels + globalGapPixels * 2);
      int i = 0, j = 0;

      for (int k = 0; k < _slots.Capacity; k++) {
        var currentSlot = new UIItemSlot();
        currentSlot.Top.Set(globalTextHeightOffset * 2 + globalGapPixels * 3 + craftingEnvironment.Height.Pixels + craftingEnvironment.Height.Pixels * j, 0f);
        currentSlot.Left.Set((craftingEnvironment.Width.Pixels + globalGapPixels * 2) * i, 0f);

        if (++i >= lineCount) {
          i = 0;
          ++j;
        }
        this._slots.Add(currentSlot);
        this.Append(currentSlot);
      }
    }

    protected override void DrawSelf(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch) {
      CalculatedStyle dimensions = base.GetInnerDimensions();

      if (!this.craftingEnvironment.IsEmpty()) {
        // Help text
        var envText = Utils.I18n.GetLocalizedString(Utils.I18n.craftingEnvironment) + ":";
        var matText = Utils.I18n.GetLocalizedString(Utils.I18n.craftingMaterials) + ":";
        Terraria.Utils.DrawBorderString(spriteBatch, envText, dimensions.Position(), Color.White);
        Terraria.Utils.DrawBorderString(spriteBatch, matText, dimensions.Position() + new Vector2(0f, globalTextHeightOffset + craftingEnvironment.Height.Pixels + globalGapPixels * 2), Color.White);
      } else {
        var noRecipeText = Utils.I18n.GetLocalizedString(Utils.I18n.recipeNotFound);
        var fontPos = dimensions.Position() + new Vector2(this.Width.Pixels / 2, this.Height.Pixels / 2) - Main.fontMouseText.MeasureString(noRecipeText) / 2;
        Terraria.Utils.DrawBorderString(spriteBatch, noRecipeText, fontPos, Color.White);
      }
    }
  }
}