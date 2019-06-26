using Terraria.Localization;
using Terraria.ModLoader;

namespace JustEnoughRecipes.Utils {
  public class I18n {
    public static ModTranslation recipeNotFound;
    public static void InitializeI18n() {
      recipeNotFound = JustEnoughRecipes.instance.CreateTranslation("Recipe.NotFound");
      recipeNotFound.SetDefault("No recipe found.");
      recipeNotFound.AddTranslation(GameCulture.Chinese, "未找到合成");
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