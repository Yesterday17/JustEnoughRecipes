using Terraria.ModLoader;

namespace JustEnoughRecipes.Commands {
  public class TestCommand : ModCommand {
    public override CommandType Type {
      get {
        return CommandType.Chat;
      }
    }

    public override string Command {
      get {
        return "test";
      }
    }

    public override string Description {
      get {
        return "测试功能用，请不要提交任何关于该文件的 commit，并且在 release 时删除该文件。";
      }
    }

    public override void Action(CommandCaller caller, string input, string[] args) {
      caller.Reply("测试命令已运行！");
    }
  }
}