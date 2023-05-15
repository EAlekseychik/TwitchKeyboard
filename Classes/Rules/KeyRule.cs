using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TwitchKeyboard.Enums;
using WindowsInput;

namespace TwitchKeyboard.Classes.Rules
{
    public class KeyRule : BaseRule
    {
        public List<VirtualKeyCode> keys = new();
        public KeyPressMode mode = KeyPressMode.Press;
        public int duration = 0;

        public override string GetName()
        {
            var keysDesc = new StringBuilder();
            for (int i = 0; i < keys.Count; i++)
            {
                keysDesc.Append($"{KeyInterop.KeyFromVirtualKey((int)keys[i])}+");
            }
            keysDesc.Length--;

            return keysDesc.ToString();
        }
    }
}
