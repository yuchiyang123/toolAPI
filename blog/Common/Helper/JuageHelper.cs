using System.Text.RegularExpressions;
using blog.Common.Enum;

namespace blog.Common.Helper
{
    public class JuageHelper
    {
        public static readonly string SplitSpecialSymbols = "===SPLIT===";

        public static readonly Dictionary<
            JudgeLanguageEnum,
            (string Before, string After, string CatchBefore, string CatchAfter, string sp)
        > PrintWrapper = new()
        {
            [JudgeLanguageEnum.python] = (
                ":\ntry:\n   print(",
                "))\n",
                "except Exception as e:\n   print(",
                "str(e))",
                "str("
            ),
            [JudgeLanguageEnum.csharp] = (
                "try{Console.WriteLine(",
                "))",
                ";}catch(Exception e){Console.WriteLine(",
                "e.Message);};",
                "System.Text.Json.JsonSerializer.Serialize("
            ),
        };

        public string SplicingTestAndCode(
            JudgeLanguageEnum languageEnum,
            string code,
            Dictionary<int, string> testCases
        )
        {
            var (before, after, beforeCatch, afterCatch, sp) = PrintWrapper[languageEnum];

            foreach (var testCase in testCases)
            {
                code +=
                    before
                    + "\""
                    + SplitSpecialSymbols
                    + $"===RESULT_{testCase.Key}===\""
                    + " + "
                    + sp
                    + testCase.Value
                    + after
                    + beforeCatch
                    + "\""
                    + SplitSpecialSymbols
                    + $"===ERROR_{testCase.Key}===\" +"
                    + afterCatch;
            }

            return code;
        }
    }
}
