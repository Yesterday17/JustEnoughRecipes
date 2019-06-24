using JustEnoughRecipes.Items;
using Terraria;
using Terraria.ID;

namespace JustEnoughRecipes.Utils {
  public static class TileItemMap {
    public static Item NewItem(int itemID = 0) {
      var item = new Item();
      item.SetDefaults(itemID, false);
      item.stack = 1;
      return item;
    }
    public static Item GetTileItem(int tileID) {
      // TODO: Finish Map
      Logger.Log(tileID.ToString());
      switch (tileID) {
        case -1:
          return NewItem(ItemID.DirtBlock);
        case TileID.WorkBenches:
          return NewItem(ItemID.WorkBench);
        case TileID.Anvils:
          return NewItem(ItemID.IronAnvil);
        case TileID.Furnaces:
          return NewItem(ItemID.Furnace);
        case TileID.HeavyWorkBench:
          return NewItem(ItemID.HeavyWorkBench);
        case TileID.TinkerersWorkbench:
          return NewItem(ItemID.TinkerersWorkshop);
        default:
          return new ItemCraftEnvironment().item;
      }
    }
  }
}