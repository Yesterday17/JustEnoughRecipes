using Terraria.ModLoader;

namespace JustEnoughRecipes.Items {
  public class ItemCraftEnvironment : ModItem {
    public override void SetStaticDefaults() {
      Tooltip.SetDefault("制作环境");
    }

    public override void SetDefaults() {
      item.width = 20;
      item.height = 20;
      item.maxStack = 1;
      item.value = 0;
      item.rare = 0;
    }
  }
}