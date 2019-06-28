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
      Logger.Log("TileID: " + tileID.ToString());
      switch (tileID) {
        // pre-hardmode
        case -1:
          return NewItem(ItemID.DirtBlock);
        // 工作台
        case TileID.WorkBenches:
          return NewItem(ItemID.WorkBench);
        // 熔炉
        case TileID.Furnaces:
          return NewItem(ItemID.Furnace);
        // 地狱熔炉
        case TileID.Hellforge:
          return NewItem(ItemID.Hellforge);
        // 铁砧
        case TileID.Anvils:
          return NewItem(ItemID.IronAnvil);
        // 玻璃瓶
        case TileID.Bottles:
          return NewItem(ItemID.Bottle);
        // 锯木机
        case TileID.Sawmill:
          return NewItem(ItemID.Sawmill);
        // 织布机
        case TileID.Loom:
          return NewItem(ItemID.Loom);
        // FIXME: 桌子&椅子
        case TileID.Tables:
          return NewItem(ItemID.WoodenTable);
        // TODO: 工作台&椅子
        // 烹饪锅
        case TileID.CookingPots:
          return NewItem(ItemID.CookingPot);
        // 工匠作坊
        case TileID.TinkerersWorkbench:
          return NewItem(ItemID.TinkerersWorkshop);
        // 灌注站
        case TileID.ImbuingStation:
          return NewItem(ItemID.ImbuingStation);
        // 染料
        case TileID.DyeVat:
          return NewItem(ItemID.DyeVat);
        // 祭坛
        case TileID.DemonAltar:
        case TileID.LihzahrdAltar:
          return NewItem(ItemID.SoulofNight);
        // specialized
        case TileID.Kegs:
          return NewItem(ItemID.Keg);
        case TileID.HeavyWorkBench:
          return NewItem(ItemID.HeavyWorkBench);
        case TileID.Sinks:
          return NewItem(ItemID.WoodenSink);
        // themed-furniture
        case TileID.BoneWelder:
          return NewItem(ItemID.BoneWelder);
        case TileID.GlassKiln:
          return NewItem(ItemID.GlassKiln);
        case TileID.HoneyDispenser:
          return NewItem(ItemID.HoneyDispenser);
        case TileID.IceMachine:
          return NewItem(ItemID.IceMachine);
        case TileID.LivingLoom:
          return NewItem(ItemID.LivingLoom);
        case TileID.SkyMill:
          return NewItem(ItemID.SkyMill);
        case TileID.Solidifier:
          return NewItem(ItemID.Solidifier);

        // hardmode
        // 秘银砧
        case TileID.MythrilAnvil:
          return NewItem(ItemID.MythrilAnvil);
        // 熔炉
        case TileID.AdamantiteForge:
          return NewItem(ItemID.AdamantiteForge);
        // 书架
        case TileID.Bookcases:
          return NewItem(ItemID.Bookcase);
        // 水晶球
        case TileID.CrystalBall:
          return NewItem(ItemID.CrystalBall);
        // 自动锻造机
        case TileID.Autohammer:
          return NewItem(ItemID.Autohammer);
        // 远古操控器
        case TileID.LunarCraftingStation:
          return NewItem(ItemID.LunarCraftingStation);
        // specialized
        case TileID.Blendomatic:
          return NewItem(ItemID.BlendOMatic);
        case TileID.MeatGrinder:
          return NewItem(ItemID.MeatGrinder);
        // themed-furniture
        case TileID.SteampunkBoiler:
          return NewItem(ItemID.SteampunkBoiler);
        case TileID.FleshCloningVat:
          return NewItem(ItemID.FleshCloningVaat);
        case TileID.LihzahrdFurnace:
          return NewItem(ItemID.LihzahrdFurnace);

        default:
          return new ItemCraftEnvironment().item;
      }
    }
  }
}