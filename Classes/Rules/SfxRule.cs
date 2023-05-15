using System;

namespace TwitchKeyboard.Classes.Rules
{
    public class SfxRule : BaseRule
    {
        public Uri file = null;
        public int volume = 100;
        public int balance = 0;
        public int loopCount = 0;

        public override string GetName()
        {
            return file == null ? "No SFX" : System.IO.Path.GetFileName(file.ToString());
        }
    }
}
