using System.Text.RegularExpressions;

namespace DevExtreme.NETCore.Demos.Models.Demos.Parsers {
    public class ActionTextParser : IParser {
        string actionName;
        public ActionTextParser(string actionName) {
            this.actionName = actionName;
        }

        public string Parse(string text) {
            var controllerMath = Regex.Match(text,
                  @"(?<controller>.*Controller[\s\r\n]*{)"
                             + @"((?<regionSpace>\s*).*("
                                     + @"(#region " + actionName + @"\s*(?<region>.*?)\s*#endregion?).*[^\s])"
                                     + @"|((?<actionSpace1>\s*).*((?<action>public ActionResult " + actionName + @"[\s]{0,1}[(]{1}.*?)[^}]*public.*[^\s])"
                                     + @"|((?<actionSpace2>\s*).*(?<actionLast>public ActionResult " + actionName + @"[\s]{0,1}[(]{1}.*?)))"
                             + @")"
                             + @"(?<end>\s*}.*}$)",
                 RegexOptions.Singleline);

            var value = controllerMath.Groups["region"].Value;
            if(string.IsNullOrEmpty(value)) {
                value = controllerMath.Groups["action"].Value;
                if(string.IsNullOrEmpty(value)) {
                    value = controllerMath.Groups["actionLast"].Value;
                }
            }

            value = controllerMath.Groups["regionSpace"].Value
                + controllerMath.Groups["actionSpace1"].Value
                + controllerMath.Groups["actionSpace2"].Value
                + value;

            var result = controllerMath.Groups["controller"].Value + value + controllerMath.Groups["end"].Value;
            return result;
        }
    }
}
