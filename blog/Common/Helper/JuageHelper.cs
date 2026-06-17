using System.Text.RegularExpressions;
using blog.Common.Enum;

namespace blog.Common.Helper
{
    public class JuageHelper
    {
        public static readonly string SplitSpecialSymbols = "===SPLIT===";

        public static readonly Dictionary<
            JudgeLanguageEnum,
            (string Before, string After, string CatchBefore, string CatchAfter)
        > PrintWrapper = new()
        {
            [JudgeLanguageEnum.python] = (
                "try:\n   print(",
                ")\n",
                "except Exception as e:\n   print(",
                "str(e))"
            ),
            [JudgeLanguageEnum.csharp] = (
                "try{Console.WriteLine(",
                ")",
                ";}catch(Exception e){Console.WriteLine(",
                "e.Message);};"
            ),
        };

        public string SplicingTestAndCode(
            JudgeLanguageEnum languageEnum,
            string code,
            Dictionary<int, string> testCases
        )
        {
            var (before, after, beforeCatch, afterCatch) = PrintWrapper[languageEnum];

            foreach (var testCase in testCases)
            {
                code +=
                    before
                    + "\""
                    + SplitSpecialSymbols
                    + $"===RESULT_{testCase.Key}===\""
                    + " + System.Text.Json.JsonSerializer.Serialize("
                    + testCase.Value
                    + ")"
                    + after
                    + beforeCatch
                    + "\""
                    + $"===ERROR_{testCase.Key}===\" +"
                    + afterCatch;
            }

            return code;
        }

        //public Dictionary<int, string> CoverntLogResultToDic(List<string> splitTests)
        //{
        //    foreach (var test in splitTests)
        //    {
        //        if (string.IsNullOrEmpty(test))
        //            continue;
        //        Match match = Regex.Match(test, @"===RESULT_(.+?)===");
        //        string? key = match.Success ? match.Groups[1].Value : null;
        //    }
        //}
    }
}
