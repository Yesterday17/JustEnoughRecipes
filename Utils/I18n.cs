using Terraria.Localization;
using Terraria.ModLoader;

namespace JustEnoughRecipes.Utils {
  public class I18n {
    public static ModTranslation recipeNotFound;
    public static ModTranslation craftingEnvironment;
    public static ModTranslation craftingMaterials;

    public static void InitializeI18n() {
      recipeNotFound = NewTranslation("Recipe.NotFound", "No recipe found.");
      recipeNotFound.AddTranslation(GameCulture.Chinese, "未找到合成");

      craftingEnvironment = NewTranslation("Crafting.Environment", "Crafting Station");
      craftingEnvironment.AddTranslation(GameCulture.Chinese, "合成环境");

      craftingMaterials = NewTranslation("Crafting.Materials", "Materials");
      craftingMaterials.AddTranslation(GameCulture.Chinese, "材料");
    }

    public static ModTranslation NewTranslation(string key, string defaultString) {
      ModTranslation translation = JustEnoughRecipes.instance.CreateTranslation(key);
      translation.SetDefault(defaultString);
      return translation;
    }

    public static LocalizedText GetLocalizedText(string key) {
      return Language.GetText(key);
    }

    public static string GetLocalizedString(string key) {
      return GetLocalizedText(key).Value;
    }

    public static string GetLocalizedString(ModTranslation translation) {
      return translation.GetTranslation(LanguageManager.Instance.ActiveCulture);
    }
  }
}