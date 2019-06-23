using Terraria;

namespace JustEnoughRecipes.Utils {
  public static class Logger {
    public static void LOG(string prefix, string message, byte R = 255, byte G = 255, byte B = 255, bool force = false) {
      if (force || JustEnoughRecipes.DEBUG) {
        prefix = prefix == "" ? "" : "[" + prefix + "]";
        Main.NewText("[JER]" + prefix + ": " + message, R, G, B);
      }
    }

    public static void Log(string message) {
      LOG("", message);
    }

    public static void Warn(string message) {
      LOG("WARN", message, 255, 255, 0);
    }

    public static void Error(string message) {
      LOG("ERROR", message, 255, 0, 0, true);
    }
  }
}