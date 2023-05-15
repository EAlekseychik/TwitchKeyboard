namespace TwitchKeyboard.Classes.Rules
{
    public class CmdRule : BaseRule
    {
        public string name = "";
        public string cmd = "";
        public string file = "";
        public bool openFile = false;

        public override string GetName()
        {
            return name;
        }
    }
}
