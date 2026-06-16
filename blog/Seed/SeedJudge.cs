using blog.Common.Enum;
using blog.Entities;
using blog.Entities.Judge;

namespace blog.Seed
{
    public class SeedJudge
    {
        public static async Task SeedJudgeAsync(BlogContext context)
        {
            if (context.Problems.Any())
                return;

            var now = DateTime.UtcNow;

            var twoSum = new Problem
            {
                ProblemName = "兩數之和",
                Description =
                    "給定一個整數陣列 nums 和一個目標值 target，找出陣列中兩個數字的索引，使它們相加等於 target。每個輸入只有一組答案，且不能使用同一個元素兩次。",
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new() { Language = JudgeLanguageEnum.python, FunctionName = "two_sum" },
                    new() { Language = JudgeLanguageEnum.csharp, FunctionName = "TwoSum" },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2,7,11,15], \"target\": 9}",
                        Expected = "[0, 1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [3,2,4], \"target\": 6}",
                        Expected = "[1, 2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [3,3], \"target\": 6}",
                        Expected = "[0, 1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1,2,3,4,5], \"target\": 9}",
                        Expected = "[3, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-1,-2,-3,-4,-5], \"target\": -8}",
                        Expected = "[2, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0,4,3,0], \"target\": 0}",
                        Expected = "[0, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1000000,999999], \"target\": 1999999}",
                        Expected = "[0, 1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2,7,11,15], \"target\": 9}",
                        Expected = "[0, 1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [3,2,4], \"target\": 6}",
                        Expected = "[1, 2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [3,3], \"target\": 6}",
                        Expected = "[0, 1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1,2,3,4,5], \"target\": 9}",
                        Expected = "[3, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-1,-2,-3,-4,-5], \"target\": -8}",
                        Expected = "[2, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0,4,3,0], \"target\": 0}",
                        Expected = "[0, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1000000,999999], \"target\": 1999999}",
                        Expected = "[0, 1]",
                    },
                ],
            };

            var climbStairs = new Problem
            {
                ProblemName = "爬樓梯",
                Description =
                    "你正在爬樓梯，需要 n 步才能到達頂部。每次可以爬 1 或 2 步，有多少種不同的方法可以爬到頂部？",
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new() { Language = JudgeLanguageEnum.python, FunctionName = "climb_stairs" },
                    new() { Language = JudgeLanguageEnum.csharp, FunctionName = "ClimbStairs" },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 1}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 2}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 3}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 4}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 5}",
                        Expected = "8",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 10}",
                        Expected = "89",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 45}",
                        Expected = "1836311903",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 1}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 2}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 3}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 4}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 5}",
                        Expected = "8",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 10}",
                        Expected = "89",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 45}",
                        Expected = "1836311903",
                    },
                ],
            };

            var reverseString = new Problem
            {
                ProblemName = "反轉字串",
                Description = "給定一個字串 s，回傳反轉後的字串。",
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new() { Language = JudgeLanguageEnum.python, FunctionName = "reverse_string" },
                    new() { Language = JudgeLanguageEnum.csharp, FunctionName = "ReverseString" },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"hello\"}",
                        Expected = "\"olleh\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"Hannah\"}",
                        Expected = "\"hannaH\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"a\"}",
                        Expected = "\"a\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"\"}",
                        Expected = "\"\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"abcde\"}",
                        Expected = "\"edcba\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"hello\"}",
                        Expected = "\"olleh\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"Hannah\"}",
                        Expected = "\"hannaH\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"a\"}",
                        Expected = "\"a\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"\"}",
                        Expected = "\"\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"abcde\"}",
                        Expected = "\"edcba\"",
                    },
                ],
            };

            context.Problems.AddRange(twoSum, climbStairs, reverseString);
            await context.SaveChangesAsync();
        }
    }
}
