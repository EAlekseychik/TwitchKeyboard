using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using TwitchKeyboard.Classes.Controllers;
using TwitchKeyboard.Classes.Rules;
using TwitchKeyboard.Enums;

namespace TwitchKeyboard.Classes.Managers
{
    public class CmdRuleManager : BaseRuleManager
    {

        public void CreateControllers (List<CmdRule> rules)
        {
            CreateControllers<CmdRuleController>(rules.ToArray());
        }

        public override void UpdateRule(BaseRuleController baseRule, int elapsedTime)
        {
            base.UpdateRule(baseRule, elapsedTime);
            if (baseRule.state != RuleState.Active) return;
            baseRule.state = RuleState.Inactive;

            var ruleController = (CmdRuleController)baseRule;
            var rule = (CmdRule)ruleController.model;

            if (rule.openFile)
            {
                Task.Run(() =>
                {
                    try
                    {
                        new Process { StartInfo = new ProcessStartInfo(rule.file) { UseShellExecute = true } }.Start();
                    }
                    catch { }
                });
            }
            else
            {
                Task.Run(() =>
                {
                    try
                    {
                        Process process = new();
                        ProcessStartInfo startInfo = new()
                        {
                            WindowStyle = ProcessWindowStyle.Hidden,
                            FileName = "cmd.exe",
                            CreateNoWindow = true,
                            Arguments = $"/c \"{rule.cmd}\""
                        };

                        process.StartInfo = startInfo;
                        process.Start();
                    }
                    catch { }
                });
            }
        }
    }
}
