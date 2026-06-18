using System.Text.RegularExpressions;
using blog.Common.Enum;
using blog.Dtos.Judge;
using blog.Entities;

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
                "\ntry:\n   print(",
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

        public static readonly Dictionary<
            JudgeLanguageEnum,
            (string before, string beforeSy, string afterSy)
        > PrintFunction = new()
        {
            [JudgeLanguageEnum.python] = ("def", ":\n", ""),
            [JudgeLanguageEnum.csharp] = ("static", " {", "}"),
        };

        public List<CombinStartCode> CombinStratCode(
            string functionName,
            List<ParameterTypeDto> parameters
        )
        {
            var startCodeList = new List<CombinStartCode>();
            foreach (var items in parameters)
            {
                (string before, string beforeSy, string afterSy) = PrintFunction[items.Language];
                string parameterStr = CombinParameter(items.Language, items.ParameterTypes);
                string returnStr = CombinReturnType(items.Language, items.ReturnTypes);
                string startCode =
                    before + returnStr + functionName + parameterStr + beforeSy + afterSy;
                startCodeList.Add(
                    new CombinStartCode { Language = items.Language, StartCode = startCode }
                );
            }

            return startCodeList;
        }

        private static string PrintParameter(
            JudgeLanguageEnum judgeLanguage,
            ParameterTypesValue parameterTypes
        )
        {
            return judgeLanguage switch
            {
                JudgeLanguageEnum.python => CombinParameterByPython(parameterTypes),
                JudgeLanguageEnum.csharp => CombinParameterByCsharper(parameterTypes),
                _ => string.Empty,
            };
        }

        private static string PringReturn(
            JudgeLanguageEnum judgeLanguage,
            ReturnTypeValue returnTypeValue
        )
        {
            return judgeLanguage switch
            {
                JudgeLanguageEnum.csharp => CombinReturnTypeByCsharper(returnTypeValue),
                _ => string.Empty,
            };
        }

        private static string CombinParameter(
            JudgeLanguageEnum judgeLanguage,
            List<ParameterTypesValue>? parameterTypes
        )
        {
            if (parameterTypes == null || parameterTypes.Count == 0)
                return "()";
            string param = string.Empty;
            bool isStart = true;
            foreach (var type in parameterTypes)
            {
                if (isStart)
                    param += "(";
                param += isStart
                    ? PrintParameter(judgeLanguage, type)
                    : "," + PrintParameter(judgeLanguage, type);
                isStart = false;
            }
            param += ")";
            return param;
        }

        private static string CombinParameterByCsharper(ParameterTypesValue parameterTypes)
        {
            return parameterTypes.ParameterType + " " + parameterTypes.ParameterName;
        }

        private static string CombinParameterByPython(ParameterTypesValue parameterTypes)
        {
            return parameterTypes.ParameterName;
        }

        private static string CombinReturnType(
            JudgeLanguageEnum judgeLanguage,
            List<ReturnTypeValue>? returnTypes
        )
        {
            if (returnTypes == null || returnTypes.Count == 0)
                return string.Empty;
            if (returnTypes.Count == 1)
            {
                return judgeLanguage switch
                {
                    JudgeLanguageEnum.csharp => returnTypes[0].ReturnType + " ",
                    _ => string.Empty,
                };
            }
            var parts = returnTypes.Select(r => PringReturn(judgeLanguage, r));
            return "(" + string.Join(", ", parts) + ") ";
        }

        private static string CombinReturnTypeByCsharper(ReturnTypeValue returnType)
        {
            return returnType.ReturnType + " " + returnType.ReturnName;
        }
    }
}
