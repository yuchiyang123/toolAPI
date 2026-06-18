using blog.Common.Enum;
using blog.Entities;
using blog.Entities.Judge;

namespace blog.Seed
{
    public class SeedJudge
    {
        public static async Task SeedJudgeAsync(BlogContext context)
        {
            if (context.Problems.Any(p => p.ProblemName == "合併排序陣列"))
                return;

            var now = DateTime.UtcNow;

            var mergeSortedArray = new Problem
            {
                ProblemName = "合併排序陣列",
                Description =
                    "給定兩個依升序排列的整數陣列 nums1 和 nums2，將 nums2 合併進 nums1，使 nums1 成為一個依升序排列的陣列。nums1 的長度為 m+n，前 m 個元素為有效值，其餘為佔位用的 0。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "merge",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "nums1" },
                            new() { Type = "int", ParameterName = "m" },
                            new() { Type = "List[int]", ParameterName = "nums2" },
                            new() { Type = "int", ParameterName = "n" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "nums1", ReturnType = "List[int]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "Merge",
                        ProblemParameters =
                        [
                            new() { Type = "int[]", ParameterName = "nums1" },
                            new() { Type = "int", ParameterName = "m" },
                            new() { Type = "int[]", ParameterName = "nums2" },
                            new() { Type = "int", ParameterName = "n" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "nums1", ReturnType = "int[]" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"nums1\": [1, 2, 3, 0, 0, 0], \"m\": 3, \"nums2\": [2, 5, 6], \"n\": 3}",
                        Expected = "[1, 2, 2, 3, 5, 6]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [1], \"m\": 1, \"nums2\": [], \"n\": 0}",
                        Expected = "[1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [0], \"m\": 0, \"nums2\": [1], \"n\": 1}",
                        Expected = "[1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"nums1\": [4, 5, 6, 0, 0, 0], \"m\": 3, \"nums2\": [1, 2, 3], \"n\": 3}",
                        Expected = "[1, 2, 3, 4, 5, 6]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [2, 0], \"m\": 1, \"nums2\": [1], \"n\": 1}",
                        Expected = "[1, 2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [0, 0, 0], \"m\": 0, \"nums2\": [1, 2, 3], \"n\": 3}",
                        Expected = "[1, 2, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"nums1\": [-3, -1, 0, 0, 0], \"m\": 2, \"nums2\": [-2, -1, 4], \"n\": 3}",
                        Expected = "[-3, -2, -1, -1, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [1, 2, 3], \"m\": 3, \"nums2\": [], \"n\": 0}",
                        Expected = "[1, 2, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [0, 0], \"m\": 0, \"nums2\": [2, 3], \"n\": 2}",
                        Expected = "[2, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"nums1\": [5, 6, 7, 8, 0, 0, 0, 0], \"m\": 4, \"nums2\": [1, 2, 3, 9], \"n\": 4}",
                        Expected = "[1, 2, 3, 5, 6, 7, 8, 9]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"nums1\": [1, 3, 5, 0, 0, 0, 0], \"m\": 3, \"nums2\": [2, 2, 4, 6], \"n\": 4}",
                        Expected = "[1, 2, 2, 3, 4, 5, 6]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"nums1\": [1, 2, 3, 0, 0, 0], \"m\": 3, \"nums2\": [2, 5, 6], \"n\": 3}",
                        Expected = "[1, 2, 2, 3, 5, 6]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [1], \"m\": 1, \"nums2\": [], \"n\": 0}",
                        Expected = "[1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [0], \"m\": 0, \"nums2\": [1], \"n\": 1}",
                        Expected = "[1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"nums1\": [4, 5, 6, 0, 0, 0], \"m\": 3, \"nums2\": [1, 2, 3], \"n\": 3}",
                        Expected = "[1, 2, 3, 4, 5, 6]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [2, 0], \"m\": 1, \"nums2\": [1], \"n\": 1}",
                        Expected = "[1, 2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [0, 0, 0], \"m\": 0, \"nums2\": [1, 2, 3], \"n\": 3}",
                        Expected = "[1, 2, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"nums1\": [-3, -1, 0, 0, 0], \"m\": 2, \"nums2\": [-2, -1, 4], \"n\": 3}",
                        Expected = "[-3, -2, -1, -1, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [1, 2, 3], \"m\": 3, \"nums2\": [], \"n\": 0}",
                        Expected = "[1, 2, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [0, 0], \"m\": 0, \"nums2\": [2, 3], \"n\": 2}",
                        Expected = "[2, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"nums1\": [5, 6, 7, 8, 0, 0, 0, 0], \"m\": 4, \"nums2\": [1, 2, 3, 9], \"n\": 4}",
                        Expected = "[1, 2, 3, 5, 6, 7, 8, 9]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"nums1\": [1, 3, 5, 0, 0, 0, 0], \"m\": 3, \"nums2\": [2, 2, 4, 6], \"n\": 4}",
                        Expected = "[1, 2, 2, 3, 4, 5, 6]",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Two Pointers" },
                    new() { Name = "Sorting" },
                ],
            };

            var removeElement = new Problem
            {
                ProblemName = "移除元素",
                Description =
                    "給定一個整數陣列 nums 和一個值 val，原地移除所有等於 val 的元素，回傳移除後陣列的長度與剩餘元素。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "remove_element",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "nums" },
                            new() { Type = "int", ParameterName = "val" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "k", ReturnType = "int" },
                            new() { ReturnName = "nums", ReturnType = "List[int]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "RemoveElement",
                        ProblemParameters =
                        [
                            new() { Type = "int[]", ParameterName = "nums" },
                            new() { Type = "int", ParameterName = "val" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "k", ReturnType = "int" },
                            new() { ReturnName = "nums", ReturnType = "int[]" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [3, 2, 2, 3], \"val\": 3}",
                        Expected = "[2, [2, 2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 1, 2, 2, 3, 0, 4, 2], \"val\": 2}",
                        Expected = "[5, [0, 0, 1, 3, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [], \"val\": 1}",
                        Expected = "[0, []]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1], \"val\": 1}",
                        Expected = "[0, []]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 2, 2, 2], \"val\": 2}",
                        Expected = "[0, []]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4], \"val\": 5}",
                        Expected = "[4, [1, 2, 3, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [4, 5, 6], \"val\": 5}",
                        Expected = "[2, [4, 6]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 0, 0, 0, 0], \"val\": 0}",
                        Expected = "[0, []]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 2, 3, 3, 3], \"val\": 3}",
                        Expected = "[3, [1, 2, 2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1, 1, 1, 1, 1], \"val\": 1}",
                        Expected = "[0, []]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [3, 2, 2, 3], \"val\": 3}",
                        Expected = "[2, [2, 2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 1, 2, 2, 3, 0, 4, 2], \"val\": 2}",
                        Expected = "[5, [0, 0, 1, 3, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [], \"val\": 1}",
                        Expected = "[0, []]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1], \"val\": 1}",
                        Expected = "[0, []]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 2, 2, 2], \"val\": 2}",
                        Expected = "[0, []]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4], \"val\": 5}",
                        Expected = "[4, [1, 2, 3, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [4, 5, 6], \"val\": 5}",
                        Expected = "[2, [4, 6]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 0, 0, 0, 0], \"val\": 0}",
                        Expected = "[0, []]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 2, 3, 3, 3], \"val\": 3}",
                        Expected = "[3, [1, 2, 2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1, 1, 1, 1, 1], \"val\": 1}",
                        Expected = "[0, []]",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Two Pointers" }],
            };

            var removeDuplicatesSortedArray = new Problem
            {
                ProblemName = "移除排序陣列中的重複項",
                Description =
                    "給定一個依升序排列的整數陣列 nums，原地移除重複出現的元素，使每個元素只出現一次，回傳移除後陣列的長度與結果。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "remove_dup",
                        ProblemParameters = [new() { Type = "List[int]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "k", ReturnType = "int" },
                            new() { ReturnName = "nums", ReturnType = "List[int]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "RemoveDuplicates",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "k", ReturnType = "int" },
                            new() { ReturnName = "nums", ReturnType = "int[]" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1, 2]}",
                        Expected = "[2, [1, 2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 0, 1, 1, 1, 2, 2, 3, 3, 4]}",
                        Expected = "[5, [0, 1, 2, 3, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": []}",
                        Expected = "[0, []]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1]}",
                        Expected = "[1, [1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1, 1, 1, 1]}",
                        Expected = "[1, [1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4, 5]}",
                        Expected = "[5, [1, 2, 3, 4, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-3, -3, -1, 0, 0, 0, 5]}",
                        Expected = "[4, [-3, -1, 0, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1]}",
                        Expected = "[1, [1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 2, 3]}",
                        Expected = "[2, [2, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-5, -5, -5, -2, 0, 3, 3, 3, 9]}",
                        Expected = "[5, [-5, -2, 0, 3, 9]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1, 2]}",
                        Expected = "[2, [1, 2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 0, 1, 1, 1, 2, 2, 3, 3, 4]}",
                        Expected = "[5, [0, 1, 2, 3, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": []}",
                        Expected = "[0, []]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1]}",
                        Expected = "[1, [1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1, 1, 1, 1]}",
                        Expected = "[1, [1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4, 5]}",
                        Expected = "[5, [1, 2, 3, 4, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-3, -3, -1, 0, 0, 0, 5]}",
                        Expected = "[4, [-3, -1, 0, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1]}",
                        Expected = "[1, [1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 2, 3]}",
                        Expected = "[2, [2, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-5, -5, -5, -2, 0, 3, 3, 3, 9]}",
                        Expected = "[5, [-5, -2, 0, 3, 9]]",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Two Pointers" }],
            };

            var removeDuplicatesSortedArrayIi = new Problem
            {
                ProblemName = "移除排序陣列中的重複項 II",
                Description =
                    "給定一個依升序排列的整數陣列 nums，原地移除重複元素，使每個元素最多出現兩次，回傳移除後陣列的長度與結果。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "remove_dup2",
                        ProblemParameters = [new() { Type = "List[int]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "k", ReturnType = "int" },
                            new() { ReturnName = "nums", ReturnType = "List[int]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "RemoveDuplicatesII",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "k", ReturnType = "int" },
                            new() { ReturnName = "nums", ReturnType = "int[]" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1, 1, 2, 2, 3]}",
                        Expected = "[5, [1, 1, 2, 2, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 0, 1, 1, 1, 1, 2, 3, 3]}",
                        Expected = "[7, [0, 0, 1, 1, 2, 3, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": []}",
                        Expected = "[0, []]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1]}",
                        Expected = "[1, [1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1]}",
                        Expected = "[2, [1, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1, 1]}",
                        Expected = "[2, [1, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1, 2, 2, 3, 3]}",
                        Expected = "[6, [1, 1, 2, 2, 3, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-2, -2, -2, -1, 0, 0, 0, 0, 3, 3]}",
                        Expected = "[7, [-2, -2, -1, 0, 0, 3, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4, 5]}",
                        Expected = "[5, [1, 2, 3, 4, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, 5, 5, 5, 5, 5, 5]}",
                        Expected = "[2, [5, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1, 1, 2, 2, 3]}",
                        Expected = "[5, [1, 1, 2, 2, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 0, 1, 1, 1, 1, 2, 3, 3]}",
                        Expected = "[7, [0, 0, 1, 1, 2, 3, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": []}",
                        Expected = "[0, []]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1]}",
                        Expected = "[1, [1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1]}",
                        Expected = "[2, [1, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1, 1]}",
                        Expected = "[2, [1, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1, 2, 2, 3, 3]}",
                        Expected = "[6, [1, 1, 2, 2, 3, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-2, -2, -2, -1, 0, 0, 0, 0, 3, 3]}",
                        Expected = "[7, [-2, -2, -1, 0, 0, 3, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4, 5]}",
                        Expected = "[5, [1, 2, 3, 4, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, 5, 5, 5, 5, 5, 5]}",
                        Expected = "[2, [5, 5]]",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Two Pointers" }],
            };

            var majorityElement = new Problem
            {
                ProblemName = "多數元素",
                Description =
                    "給定一個大小為 n 的整數陣列 nums，回傳其中出現次數超過 n/2 的元素，題目保證該元素一定存在。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "majority",
                        ProblemParameters = [new() { Type = "List[int]", ParameterName = "nums" }],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "MajorityElement",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "nums" }],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [3, 2, 3]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 2, 1, 1, 1, 2, 2]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [6, 5, 5]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1, 1, 1, 2, 2, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-1, -1, -1, 2, 2]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 0, 0, 0, 1, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [7, 7, 7, 7, 7, 7, 7]}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 2]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [4, 4, 4, 4, 1, 2, 3]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [3, 2, 3]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 2, 1, 1, 1, 2, 2]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [6, 5, 5]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1, 1, 1, 2, 2, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-1, -1, -1, 2, 2]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 0, 0, 0, 1, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [7, 7, 7, 7, 7, 7, 7]}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 2]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [4, 4, 4, 4, 1, 2, 3]}",
                        Expected = "4",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Hash Table" },
                    new() { Name = "Divide and Conquer" },
                ],
            };

            var rotateArray = new Problem
            {
                ProblemName = "旋轉陣列",
                Description = "給定一個整數陣列 nums，將陣列向右旋轉 k 個位置。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "rotate",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "nums" },
                            new() { Type = "int", ParameterName = "k" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "nums", ReturnType = "List[int]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "Rotate",
                        ProblemParameters =
                        [
                            new() { Type = "int[]", ParameterName = "nums" },
                            new() { Type = "int", ParameterName = "k" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "nums", ReturnType = "int[]" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4, 5, 6, 7], \"k\": 3}",
                        Expected = "[5, 6, 7, 1, 2, 3, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-1, -100, 3, 99], \"k\": 2}",
                        Expected = "[3, 99, -1, -100]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1], \"k\": 0}",
                        Expected = "[1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2], \"k\": 3}",
                        Expected = "[2, 1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3], \"k\": 0}",
                        Expected = "[1, 2, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4], \"k\": 4}",
                        Expected = "[1, 2, 3, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4, 5], \"k\": 7}",
                        Expected = "[4, 5, 1, 2, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, 5, 5, 5], \"k\": 2}",
                        Expected = "[5, 5, 5, 5]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4, 5, 6], \"k\": 1}",
                        Expected = "[6, 1, 2, 3, 4, 5]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, -1, -2, -3], \"k\": 5}",
                        Expected = "[-3, 0, -1, -2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4, 5, 6, 7], \"k\": 3}",
                        Expected = "[5, 6, 7, 1, 2, 3, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-1, -100, 3, 99], \"k\": 2}",
                        Expected = "[3, 99, -1, -100]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1], \"k\": 0}",
                        Expected = "[1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2], \"k\": 3}",
                        Expected = "[2, 1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3], \"k\": 0}",
                        Expected = "[1, 2, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4], \"k\": 4}",
                        Expected = "[1, 2, 3, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4, 5], \"k\": 7}",
                        Expected = "[4, 5, 1, 2, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, 5, 5, 5], \"k\": 2}",
                        Expected = "[5, 5, 5, 5]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4, 5, 6], \"k\": 1}",
                        Expected = "[6, 1, 2, 3, 4, 5]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, -1, -2, -3], \"k\": 5}",
                        Expected = "[-3, 0, -1, -2]",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Math" },
                    new() { Name = "Two Pointers" },
                ],
            };

            var bestTimeBuySellStock = new Problem
            {
                ProblemName = "買賣股票的最佳時機",
                Description =
                    "給定一個陣列 prices，第 i 個元素表示第 i 天的股價，只能進行一次交易，回傳能獲得的最大利潤；若不能獲利則回傳 0。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "max_profit1",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "prices" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "maxProfit", ReturnType = "int" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "MaxProfit",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "prices" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "maxProfit", ReturnType = "int" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [7, 1, 5, 3, 6, 4]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [7, 6, 4, 3, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": []}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [1, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [2, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [3, 3, 3, 3]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [1, 2, 3, 4, 5]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [5, 4, 3, 2, 1, 10]}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [2, 4, 1, 7]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [7, 1, 5, 3, 6, 4]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [7, 6, 4, 3, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": []}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [1, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [2, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [3, 3, 3, 3]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [1, 2, 3, 4, 5]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [5, 4, 3, 2, 1, 10]}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [2, 4, 1, 7]}",
                        Expected = "6",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Dynamic Programming" }],
            };

            var bestTimeBuySellStockIi = new Problem
            {
                ProblemName = "買賣股票的最佳時機 II",
                Description =
                    "給定一個陣列 prices，第 i 個元素表示第 i 天的股價，可進行任意次數的交易，回傳能獲得的最大利潤。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "max_profit2",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "prices" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "maxProfit", ReturnType = "int" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "MaxProfitII",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "prices" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "maxProfit", ReturnType = "int" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [7, 1, 5, 3, 6, 4]}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [1, 2, 3, 4, 5]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [7, 6, 4, 3, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": []}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [1, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [3, 3, 3, 3]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [1, 5, 2, 3, 7, 1]}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [2, 1, 2, 1, 2, 1]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [10, 1, 10, 1, 10]}",
                        Expected = "18",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [7, 1, 5, 3, 6, 4]}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [1, 2, 3, 4, 5]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [7, 6, 4, 3, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": []}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [1, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [3, 3, 3, 3]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [1, 5, 2, 3, 7, 1]}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [2, 1, 2, 1, 2, 1]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [10, 1, 10, 1, 10]}",
                        Expected = "18",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Dynamic Programming" },
                    new() { Name = "Greedy" },
                ],
            };

            var jumpGame = new Problem
            {
                ProblemName = "跳躍遊戲",
                Description =
                    "給定一個非負整數陣列 nums，初始位於索引 0，nums[i] 表示在索引 i 可跳躍的最大步數，判斷是否能到達陣列的最後一個索引。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "can_jump",
                        ProblemParameters = [new() { Type = "List[int]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "canReach", ReturnType = "bool" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "CanJump",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "canReach", ReturnType = "bool" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 3, 1, 1, 4]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [3, 2, 1, 0, 4]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 0]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 1]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 0, 0]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1, 1, 1]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, 0, 0, 0, 0]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 0, 1]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 5, 0, 0]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 3, 1, 1, 4]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [3, 2, 1, 0, 4]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 0]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 1]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 0, 0]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1, 1, 1]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, 0, 0, 0, 0]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 0, 1]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 5, 0, 0]}",
                        Expected = "true",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Dynamic Programming" },
                    new() { Name = "Greedy" },
                ],
            };

            var jumpGameIi = new Problem
            {
                ProblemName = "跳躍遊戲 II",
                Description =
                    "給定一個非負整數陣列 nums，初始位於索引 0，nums[i] 表示在索引 i 可跳躍的最大步數，回傳到達最後一個索引所需的最少跳躍次數。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "jump2",
                        ProblemParameters = [new() { Type = "List[int]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "minJumps", ReturnType = "int" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "JumpII",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "minJumps", ReturnType = "int" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 3, 1, 1, 4]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 3, 0, 1, 4]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1, 1, 1]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [10, 1, 1, 1, 1, 1, 1, 1, 1, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1, 1, 1, 1, 1]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [3, 2, 1, 0]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, 1, 1, 1, 1, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 3, 1, 1, 4]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 3, 0, 1, 4]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1, 1, 1]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [10, 1, 1, 1, 1, 1, 1, 1, 1, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1, 1, 1, 1, 1]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [3, 2, 1, 0]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, 1, 1, 1, 1, 1]}",
                        Expected = "1",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Dynamic Programming" },
                    new() { Name = "Greedy" },
                ],
            };

            var hIndex = new Problem
            {
                ProblemName = "H 指數",
                Description = "給定一位研究者的論文引用次數陣列 citations，回傳該研究者的 h 指數。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "h_index",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "citations" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "hIndex", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "HIndex",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "citations" }],
                        ProblemReturnTypes = [new() { ReturnName = "hIndex", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"citations\": [3, 0, 6, 1, 5]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"citations\": [1, 3, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"citations\": [0]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"citations\": []}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"citations\": [0, 0, 0, 0]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"citations\": [100]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"citations\": [1, 1, 1, 1, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"citations\": [10, 8, 5, 4, 3]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"citations\": [25, 8, 5, 3, 3]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"citations\": [0, 1, 3, 5, 6]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"citations\": [3, 0, 6, 1, 5]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"citations\": [1, 3, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"citations\": [0]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"citations\": []}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"citations\": [0, 0, 0, 0]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"citations\": [100]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"citations\": [1, 1, 1, 1, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"citations\": [10, 8, 5, 4, 3]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"citations\": [25, 8, 5, 3, 3]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"citations\": [0, 1, 3, 5, 6]}",
                        Expected = "3",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Sorting" },
                    new() { Name = "Counting Sort" },
                ],
            };

            var productOfArrayExceptSelf = new Problem
            {
                ProblemName = "除自身以外陣列的乘積",
                Description =
                    "給定一個整數陣列 nums，回傳一個陣列 answer，其中 answer[i] 等於 nums 中除 nums[i] 外其餘所有元素的乘積，不可使用除法。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "product_except_self",
                        ProblemParameters = [new() { Type = "List[int]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "answer", ReturnType = "List[int]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "ProductExceptSelf",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "answer", ReturnType = "int[]" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4]}",
                        Expected = "[24, 12, 8, 6]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-1, 1, 0, -3, 3]}",
                        Expected = "[0, 0, 9, 0, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 3]}",
                        Expected = "[3, 2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 0]}",
                        Expected = "[0, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 0]}",
                        Expected = "[0, 1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, 5, 5, 5]}",
                        Expected = "[125, 125, 125, 125]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-1, -2, -3, -4]}",
                        Expected = "[-24, -12, -8, -6]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1, 1, 1, 1]}",
                        Expected = "[1, 1, 1, 1, 1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [10, 3, 5, 2]}",
                        Expected = "[30, 100, 60, 150]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 4, 0]}",
                        Expected = "[0, 0, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4]}",
                        Expected = "[24, 12, 8, 6]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-1, 1, 0, -3, 3]}",
                        Expected = "[0, 0, 9, 0, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 3]}",
                        Expected = "[3, 2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 0]}",
                        Expected = "[0, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 0]}",
                        Expected = "[0, 1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, 5, 5, 5]}",
                        Expected = "[125, 125, 125, 125]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-1, -2, -3, -4]}",
                        Expected = "[-24, -12, -8, -6]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1, 1, 1, 1]}",
                        Expected = "[1, 1, 1, 1, 1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [10, 3, 5, 2]}",
                        Expected = "[30, 100, 60, 150]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 4, 0]}",
                        Expected = "[0, 0, 0]",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Prefix Sum" }],
            };

            var gasStation = new Problem
            {
                ProblemName = "加油站",
                Description =
                    "環形路線上有 n 個加油站，gas[i] 表示可加的油量，cost[i] 表示到下一站所需油量，回傳可環行一圈的起始站索引；不存在則回傳 -1。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "can_complete_circuit",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "gas" },
                            new() { Type = "List[int]", ParameterName = "cost" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "startIndex", ReturnType = "int" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "CanCompleteCircuit",
                        ProblemParameters =
                        [
                            new() { Type = "int[]", ParameterName = "gas" },
                            new() { Type = "int[]", ParameterName = "cost" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "startIndex", ReturnType = "int" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"gas\": [1, 2, 3, 4, 5], \"cost\": [3, 4, 5, 1, 2]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"gas\": [2, 3, 4], \"cost\": [3, 4, 3]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"gas\": [5], \"cost\": [4]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"gas\": [3], \"cost\": [3]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"gas\": [2], \"cost\": [3]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"gas\": [1, 2, 3, 4, 5], \"cost\": [2, 1, 5, 4, 3]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"gas\": [4, 5, 2, 6, 5, 3], \"cost\": [3, 3, 1, 5, 4, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"gas\": [0, 0, 0, 0], \"cost\": [0, 0, 0, 0]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"gas\": [1, 1, 1, 1, 1], \"cost\": [1, 1, 1, 1, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"gas\": [3, 1, 1], \"cost\": [1, 2, 2]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"gas\": [1, 2, 3, 4, 5], \"cost\": [3, 4, 5, 1, 2]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"gas\": [2, 3, 4], \"cost\": [3, 4, 3]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"gas\": [5], \"cost\": [4]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"gas\": [3], \"cost\": [3]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"gas\": [2], \"cost\": [3]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"gas\": [1, 2, 3, 4, 5], \"cost\": [2, 1, 5, 4, 3]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"gas\": [4, 5, 2, 6, 5, 3], \"cost\": [3, 3, 1, 5, 4, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"gas\": [0, 0, 0, 0], \"cost\": [0, 0, 0, 0]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"gas\": [1, 1, 1, 1, 1], \"cost\": [1, 1, 1, 1, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"gas\": [3, 1, 1], \"cost\": [1, 2, 2]}",
                        Expected = "0",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Greedy" }],
            };

            var candy = new Problem
            {
                ProblemName = "分糖果",
                Description =
                    "n 個小孩站成一排，每人有評分值 ratings[i]，需分配糖果使每人至少 1 顆且評分較高者比相鄰較低者多，求所需糖果最少總數。",
                Difficulty = ProblemDifficultyEnums.Hard,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "candy",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "ratings" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "minCandies", ReturnType = "int" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "Candy",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "ratings" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "minCandies", ReturnType = "int" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"ratings\": [1, 0, 2]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"ratings\": [1, 2, 2]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"ratings\": [1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"ratings\": [1, 1, 1, 1]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"ratings\": [1, 2, 3, 4, 5]}",
                        Expected = "15",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"ratings\": [5, 4, 3, 2, 1]}",
                        Expected = "15",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"ratings\": [1, 3, 2, 2, 1]}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"ratings\": [1, 2, 2, 1]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"ratings\": [2, 2, 2]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"ratings\": [1, 6, 10, 8, 7, 3, 2]}",
                        Expected = "18",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"ratings\": [1, 0, 2]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"ratings\": [1, 2, 2]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"ratings\": [1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"ratings\": [1, 1, 1, 1]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"ratings\": [1, 2, 3, 4, 5]}",
                        Expected = "15",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"ratings\": [5, 4, 3, 2, 1]}",
                        Expected = "15",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"ratings\": [1, 3, 2, 2, 1]}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"ratings\": [1, 2, 2, 1]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"ratings\": [2, 2, 2]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"ratings\": [1, 6, 10, 8, 7, 3, 2]}",
                        Expected = "18",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Greedy" }],
            };

            var trappingRainWater = new Problem
            {
                ProblemName = "接雨水",
                Description = "給定 n 個非負整數表示高度圖 height，計算下雨後能接住的雨水總量。",
                Difficulty = ProblemDifficultyEnums.Hard,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "trap",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "height" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "water", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "Trap",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "height" }],
                        ProblemReturnTypes = [new() { ReturnName = "water", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"height\": [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"height\": [4, 2, 0, 3, 2, 5]}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"height\": []}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"height\": [1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"height\": [1, 2]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"height\": [5, 5, 5, 5]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"height\": [0, 0, 0, 0]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"height\": [2, 0, 2]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"height\": [3, 0, 0, 2, 0, 4]}",
                        Expected = "10",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"height\": [1, 0, 1, 0, 1, 0, 1]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"height\": [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"height\": [4, 2, 0, 3, 2, 5]}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"height\": []}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"height\": [1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"height\": [1, 2]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"height\": [5, 5, 5, 5]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"height\": [0, 0, 0, 0]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"height\": [2, 0, 2]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"height\": [3, 0, 0, 2, 0, 4]}",
                        Expected = "10",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"height\": [1, 0, 1, 0, 1, 0, 1]}",
                        Expected = "3",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Two Pointers" },
                    new() { Name = "Dynamic Programming" },
                    new() { Name = "Stack" },
                ],
            };

            var romanToInteger = new Problem
            {
                ProblemName = "羅馬數字轉整數",
                Description = "給定一個羅馬數字字串 s，將其轉換為整數。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "roman_to_int",
                        ProblemParameters = [new() { Type = "str", ParameterName = "s" }],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "RomanToInt",
                        ProblemParameters = [new() { Type = "string", ParameterName = "s" }],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"III\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"XXXVI\"}",
                        Expected = "36",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"LVIII\"}",
                        Expected = "58",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"MCMXCIV\"}",
                        Expected = "1994",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"IX\"}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"IV\"}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"XL\"}",
                        Expected = "40",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"XC\"}",
                        Expected = "90",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"CD\"}",
                        Expected = "400",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"CM\"}",
                        Expected = "900",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"MMMCMXCIX\"}",
                        Expected = "3999",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"I\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"III\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"XXXVI\"}",
                        Expected = "36",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"LVIII\"}",
                        Expected = "58",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"MCMXCIV\"}",
                        Expected = "1994",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"IX\"}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"IV\"}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"XL\"}",
                        Expected = "40",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"XC\"}",
                        Expected = "90",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"CD\"}",
                        Expected = "400",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"CM\"}",
                        Expected = "900",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"MMMCMXCIX\"}",
                        Expected = "3999",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"I\"}",
                        Expected = "1",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Hash Table" },
                    new() { Name = "Math" },
                    new() { Name = "String" },
                ],
            };

            var integerToRoman = new Problem
            {
                ProblemName = "整數轉羅馬數字",
                Description = "給定一個整數，將其轉換成羅馬數字。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "int_to_roman",
                        ProblemParameters = [new() { Type = "int", ParameterName = "num" }],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "str" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "IntToRoman",
                        ProblemParameters = [new() { Type = "int", ParameterName = "num" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "result", ReturnType = "string" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"num\": 3749}",
                        Expected = "\"MMMDCCXLIX\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"num\": 58}",
                        Expected = "\"LVIII\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"num\": 1994}",
                        Expected = "\"MCMXCIV\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"num\": 1}",
                        Expected = "\"I\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"num\": 9}",
                        Expected = "\"IX\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"num\": 4}",
                        Expected = "\"IV\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"num\": 40}",
                        Expected = "\"XL\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"num\": 90}",
                        Expected = "\"XC\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"num\": 400}",
                        Expected = "\"CD\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"num\": 900}",
                        Expected = "\"CM\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"num\": 3999}",
                        Expected = "\"MMMCMXCIX\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"num\": 3000}",
                        Expected = "\"MMM\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"num\": 3749}",
                        Expected = "\"MMMDCCXLIX\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"num\": 58}",
                        Expected = "\"LVIII\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"num\": 1994}",
                        Expected = "\"MCMXCIV\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"num\": 1}",
                        Expected = "\"I\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"num\": 9}",
                        Expected = "\"IX\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"num\": 4}",
                        Expected = "\"IV\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"num\": 40}",
                        Expected = "\"XL\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"num\": 90}",
                        Expected = "\"XC\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"num\": 400}",
                        Expected = "\"CD\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"num\": 900}",
                        Expected = "\"CM\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"num\": 3999}",
                        Expected = "\"MMMCMXCIX\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"num\": 3000}",
                        Expected = "\"MMM\"",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Hash Table" },
                    new() { Name = "Math" },
                    new() { Name = "String" },
                ],
            };

            var lengthOfLastWord = new Problem
            {
                ProblemName = "最後一個單字的長度",
                Description = "給定一個字串 s，回傳字串中最後一個單字的長度。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "length_of_last_word",
                        ProblemParameters = [new() { Type = "str", ParameterName = "s" }],
                        ProblemReturnTypes = [new() { ReturnName = "length", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "LengthOfLastWord",
                        ProblemParameters = [new() { Type = "string", ParameterName = "s" }],
                        ProblemReturnTypes = [new() { ReturnName = "length", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"Hello World\"}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"   fly me   to   the moon  \"}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"luffy is still joyboy\"}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"a\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"   a   \"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"day\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"  hello  world  \"}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"x\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"double  space\"}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"trailing \"}",
                        Expected = "8",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"Hello World\"}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"   fly me   to   the moon  \"}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"luffy is still joyboy\"}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"a\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"   a   \"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"day\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"  hello  world  \"}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"x\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"double  space\"}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"trailing \"}",
                        Expected = "8",
                    },
                ],
                ProblemTags = [new() { Name = "String" }],
            };

            var longestCommonPrefix = new Problem
            {
                ProblemName = "最長公共前綴",
                Description =
                    "給定一個字串陣列 strs，找出所有字串的最長公共前綴；不存在則回傳空字串。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "longest_common_prefix",
                        ProblemParameters = [new() { Type = "List[str]", ParameterName = "strs" }],
                        ProblemReturnTypes = [new() { ReturnName = "prefix", ReturnType = "str" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "LongestCommonPrefix",
                        ProblemParameters = [new() { Type = "string[]", ParameterName = "strs" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "prefix", ReturnType = "string" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"strs\": [\"flower\", \"flow\", \"flight\"]}",
                        Expected = "\"fl\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"strs\": [\"dog\", \"racecar\", \"car\"]}",
                        Expected = "\"\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"strs\": [\"interview\", \"internet\", \"internal\", \"interval\"]}",
                        Expected = "\"inter\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"strs\": [\"\"]}",
                        Expected = "\"\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"strs\": [\"a\"]}",
                        Expected = "\"a\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"strs\": [\"abc\"]}",
                        Expected = "\"abc\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"strs\": [\"\", \"abc\"]}",
                        Expected = "\"\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"strs\": [\"ab\", \"a\"]}",
                        Expected = "\"a\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"strs\": [\"same\", \"same\", \"same\"]}",
                        Expected = "\"same\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"strs\": [\"prefix\", \"pre\", \"pr\"]}",
                        Expected = "\"pr\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"strs\": [\"flower\", \"flow\", \"flight\"]}",
                        Expected = "\"fl\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"strs\": [\"dog\", \"racecar\", \"car\"]}",
                        Expected = "\"\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"strs\": [\"interview\", \"internet\", \"internal\", \"interval\"]}",
                        Expected = "\"inter\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"strs\": [\"\"]}",
                        Expected = "\"\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"strs\": [\"a\"]}",
                        Expected = "\"a\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"strs\": [\"abc\"]}",
                        Expected = "\"abc\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"strs\": [\"\", \"abc\"]}",
                        Expected = "\"\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"strs\": [\"ab\", \"a\"]}",
                        Expected = "\"a\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"strs\": [\"same\", \"same\", \"same\"]}",
                        Expected = "\"same\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"strs\": [\"prefix\", \"pre\", \"pr\"]}",
                        Expected = "\"pr\"",
                    },
                ],
                ProblemTags = [new() { Name = "String" }, new() { Name = "Trie" }],
            };

            var reverseWordsInString = new Problem
            {
                ProblemName = "反轉字串中的單字",
                Description =
                    "給定一個字串 s，反轉其中單字的順序，結果僅以單個空格分隔且無前後導空格。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "reverse_words",
                        ProblemParameters = [new() { Type = "str", ParameterName = "s" }],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "str" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "ReverseWords",
                        ProblemParameters = [new() { Type = "string", ParameterName = "s" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "result", ReturnType = "string" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"the sky is blue\"}",
                        Expected = "\"blue is sky the\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"  hello world  \"}",
                        Expected = "\"world hello\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"a good   example\"}",
                        Expected = "\"example good a\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"  Bob    Loves  Alice   \"}",
                        Expected = "\"Alice Loves Bob\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"Alice does not even like bob\"}",
                        Expected = "\"bob like even not does Alice\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"single\"}",
                        Expected = "\"single\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"  multiple   spaces   between  \"}",
                        Expected = "\"between spaces multiple\"",
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
                        Input = "{\"s\": \"  leading\"}",
                        Expected = "\"leading\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"trailing  \"}",
                        Expected = "\"trailing\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"the sky is blue\"}",
                        Expected = "\"blue is sky the\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"  hello world  \"}",
                        Expected = "\"world hello\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"a good   example\"}",
                        Expected = "\"example good a\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"  Bob    Loves  Alice   \"}",
                        Expected = "\"Alice Loves Bob\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"Alice does not even like bob\"}",
                        Expected = "\"bob like even not does Alice\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"single\"}",
                        Expected = "\"single\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"  multiple   spaces   between  \"}",
                        Expected = "\"between spaces multiple\"",
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
                        Input = "{\"s\": \"  leading\"}",
                        Expected = "\"leading\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"trailing  \"}",
                        Expected = "\"trailing\"",
                    },
                ],
                ProblemTags = [new() { Name = "Two Pointers" }, new() { Name = "String" }],
            };

            var zigzagConversion = new Problem
            {
                ProblemName = "Z 字形變換",
                Description =
                    "將字串 s 以給定列數 numRows 進行 Z 字形排列後，依逐行順序回傳結果字串。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "convert",
                        ProblemParameters =
                        [
                            new() { Type = "str", ParameterName = "s" },
                            new() { Type = "int", ParameterName = "numRows" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "str" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "Convert",
                        ProblemParameters =
                        [
                            new() { Type = "string", ParameterName = "s" },
                            new() { Type = "int", ParameterName = "numRows" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "result", ReturnType = "string" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"PAYPALISHIRING\", \"numRows\": 3}",
                        Expected = "\"PAHNAPLSIIGYIR\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"PAYPALISHIRING\", \"numRows\": 4}",
                        Expected = "\"PINALSIGYAHRPI\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"A\", \"numRows\": 1}",
                        Expected = "\"A\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"AB\", \"numRows\": 1}",
                        Expected = "\"AB\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"ABC\", \"numRows\": 5}",
                        Expected = "\"ABC\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"ABCD\", \"numRows\": 2}",
                        Expected = "\"ACBD\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"0123456789\", \"numRows\": 4}",
                        Expected = "\"0615724839\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"abcdefghij\", \"numRows\": 3}",
                        Expected = "\"aeibdfhjcg\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"a\", \"numRows\": 1}",
                        Expected = "\"a\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"PAYPALISHIRING\", \"numRows\": 2}",
                        Expected = "\"PYAIHRNAPLSIIG\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"PAYPALISHIRING\", \"numRows\": 3}",
                        Expected = "\"PAHNAPLSIIGYIR\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"PAYPALISHIRING\", \"numRows\": 4}",
                        Expected = "\"PINALSIGYAHRPI\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"A\", \"numRows\": 1}",
                        Expected = "\"A\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"AB\", \"numRows\": 1}",
                        Expected = "\"AB\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"ABC\", \"numRows\": 5}",
                        Expected = "\"ABC\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"ABCD\", \"numRows\": 2}",
                        Expected = "\"ACBD\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"0123456789\", \"numRows\": 4}",
                        Expected = "\"0615724839\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"abcdefghij\", \"numRows\": 3}",
                        Expected = "\"aeibdfhjcg\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"a\", \"numRows\": 1}",
                        Expected = "\"a\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"PAYPALISHIRING\", \"numRows\": 2}",
                        Expected = "\"PYAIHRNAPLSIIG\"",
                    },
                ],
                ProblemTags = [new() { Name = "String" }],
            };

            var findFirstOccurrenceInString = new Problem
            {
                ProblemName = "字串中第一個匹配項的索引",
                Description =
                    "給定 haystack 和 needle，回傳 needle 在 haystack 中第一次出現的索引；不存在回傳 -1。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "str_str",
                        ProblemParameters =
                        [
                            new() { Type = "str", ParameterName = "haystack" },
                            new() { Type = "str", ParameterName = "needle" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "index", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "StrStr",
                        ProblemParameters =
                        [
                            new() { Type = "string", ParameterName = "haystack" },
                            new() { Type = "string", ParameterName = "needle" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "index", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"haystack\": \"sadbutsad\", \"needle\": \"sad\"}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"haystack\": \"leetcode\", \"needle\": \"leeto\"}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"haystack\": \"\", \"needle\": \"\"}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"haystack\": \"a\", \"needle\": \"\"}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"haystack\": \"\", \"needle\": \"a\"}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"haystack\": \"hello\", \"needle\": \"ll\"}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"haystack\": \"aaaaa\", \"needle\": \"bba\"}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"haystack\": \"mississippi\", \"needle\": \"issip\"}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"haystack\": \"abc\", \"needle\": \"abc\"}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"haystack\": \"abc\", \"needle\": \"abcd\"}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"haystack\": \"sadbutsad\", \"needle\": \"sad\"}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"haystack\": \"leetcode\", \"needle\": \"leeto\"}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"haystack\": \"\", \"needle\": \"\"}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"haystack\": \"a\", \"needle\": \"\"}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"haystack\": \"\", \"needle\": \"a\"}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"haystack\": \"hello\", \"needle\": \"ll\"}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"haystack\": \"aaaaa\", \"needle\": \"bba\"}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"haystack\": \"mississippi\", \"needle\": \"issip\"}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"haystack\": \"abc\", \"needle\": \"abc\"}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"haystack\": \"abc\", \"needle\": \"abcd\"}",
                        Expected = "-1",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Two Pointers" },
                    new() { Name = "String" },
                    new() { Name = "String Matching" },
                ],
            };

            var textJustification = new Problem
            {
                ProblemName = "文字對齊",
                Description =
                    "給定單字陣列 words 與最大寬度 maxWidth，格式化使每行恰好 maxWidth 字元且左右對齊。",
                Difficulty = ProblemDifficultyEnums.Hard,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "full_justify",
                        ProblemParameters =
                        [
                            new() { Type = "List[str]", ParameterName = "words" },
                            new() { Type = "int", ParameterName = "maxWidth" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "lines", ReturnType = "List[str]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "FullJustify",
                        ProblemParameters =
                        [
                            new() { Type = "string[]", ParameterName = "words" },
                            new() { Type = "int", ParameterName = "maxWidth" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "lines", ReturnType = "List<string>" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"words\": [\"This\", \"is\", \"an\", \"example\", \"of\", \"text\", \"justification.\"], \"maxWidth\": 16}",
                        Expected =
                            "[\"This    is    an\", \"example  of text\", \"justification.  \"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"words\": [\"What\", \"must\", \"be\", \"acknowledged\", \"and\", \"accepted.\"], \"maxWidth\": 16}",
                        Expected =
                            "[\"What   must   be\", \"acknowledged and\", \"accepted.       \"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"words\": [\"Science\", \"is\", \"what\", \"we\", \"understand\", \"well\", \"enough\", \"to\", \"explain\", \"to\", \"a\", \"computer.\", \"Art\", \"is\", \"everything\", \"else\", \"we\", \"do\"], \"maxWidth\": 20}",
                        Expected =
                            "[\"Science  is  what we\", \"understand      well\", \"enough to explain to\", \"a  computer.  Art is\", \"everything  else  we\", \"do                  \"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"words\": [\"a\"], \"maxWidth\": 5}",
                        Expected = "[\"a    \"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"words\": [\"a\", \"b\"], \"maxWidth\": 5}",
                        Expected = "[\"a b  \"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"words\": [\"Listen\", \"to\", \"many,\", \"speak\", \"to\", \"a\", \"few.\"], \"maxWidth\": 6}",
                        Expected =
                            "[\"Listen\", \"to    \", \"many, \", \"speak \", \"to   a\", \"few.  \"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"words\": [\"ab\", \"cd\", \"ef\"], \"maxWidth\": 6}",
                        Expected = "[\"ab  cd\", \"ef    \"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"words\": [\"one\"], \"maxWidth\": 3}",
                        Expected = "[\"one\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"words\": [\"This\", \"is\", \"a\", \"test\"], \"maxWidth\": 4}",
                        Expected = "[\"This\", \"is a\", \"test\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"words\": [\"Hello\"], \"maxWidth\": 10}",
                        Expected = "[\"Hello     \"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"words\": [\"This\", \"is\", \"an\", \"example\", \"of\", \"text\", \"justification.\"], \"maxWidth\": 16}",
                        Expected =
                            "[\"This    is    an\", \"example  of text\", \"justification.  \"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"words\": [\"What\", \"must\", \"be\", \"acknowledged\", \"and\", \"accepted.\"], \"maxWidth\": 16}",
                        Expected =
                            "[\"What   must   be\", \"acknowledged and\", \"accepted.       \"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"words\": [\"Science\", \"is\", \"what\", \"we\", \"understand\", \"well\", \"enough\", \"to\", \"explain\", \"to\", \"a\", \"computer.\", \"Art\", \"is\", \"everything\", \"else\", \"we\", \"do\"], \"maxWidth\": 20}",
                        Expected =
                            "[\"Science  is  what we\", \"understand      well\", \"enough to explain to\", \"a  computer.  Art is\", \"everything  else  we\", \"do                  \"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"words\": [\"a\"], \"maxWidth\": 5}",
                        Expected = "[\"a    \"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"words\": [\"a\", \"b\"], \"maxWidth\": 5}",
                        Expected = "[\"a b  \"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"words\": [\"Listen\", \"to\", \"many,\", \"speak\", \"to\", \"a\", \"few.\"], \"maxWidth\": 6}",
                        Expected =
                            "[\"Listen\", \"to    \", \"many, \", \"speak \", \"to   a\", \"few.  \"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"words\": [\"ab\", \"cd\", \"ef\"], \"maxWidth\": 6}",
                        Expected = "[\"ab  cd\", \"ef    \"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"words\": [\"one\"], \"maxWidth\": 3}",
                        Expected = "[\"one\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"words\": [\"This\", \"is\", \"a\", \"test\"], \"maxWidth\": 4}",
                        Expected = "[\"This\", \"is a\", \"test\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"words\": [\"Hello\"], \"maxWidth\": 10}",
                        Expected = "[\"Hello     \"]",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "String" },
                    new() { Name = "Simulation" },
                ],
            };

            var validPalindrome = new Problem
            {
                ProblemName = "驗證回文串",
                Description = "給定字串 s，僅考慮字母數字並忽略大小寫，判斷是否為回文串。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "is_palindrome",
                        ProblemParameters = [new() { Type = "str", ParameterName = "s" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "isPalindrome", ReturnType = "bool" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "IsPalindrome",
                        ProblemParameters = [new() { Type = "string", ParameterName = "s" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "isPalindrome", ReturnType = "bool" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"A man, a plan, a canal: Panama\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"race a car\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \" \"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"0P\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"ab_a\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"a.\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"Was it a car or a cat I saw?\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"12321\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"1a2\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"A man, a plan, a canal: Panama\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"race a car\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \" \"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"0P\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"ab_a\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"a.\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"Was it a car or a cat I saw?\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"12321\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"1a2\"}",
                        Expected = "false",
                    },
                ],
                ProblemTags = [new() { Name = "Two Pointers" }, new() { Name = "String" }],
            };

            var isSubsequence = new Problem
            {
                ProblemName = "判斷子序列",
                Description = "給定字串 s 和 t，判斷 s 是否為 t 的子序列。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "is_subsequence",
                        ProblemParameters =
                        [
                            new() { Type = "str", ParameterName = "s" },
                            new() { Type = "str", ParameterName = "t" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "isSubsequence", ReturnType = "bool" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "IsSubsequence",
                        ProblemParameters =
                        [
                            new() { Type = "string", ParameterName = "s" },
                            new() { Type = "string", ParameterName = "t" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "isSubsequence", ReturnType = "bool" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"abc\", \"t\": \"ahbgdc\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"axc\", \"t\": \"ahbgdc\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"\", \"t\": \"ahbgdc\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"abc\", \"t\": \"\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"\", \"t\": \"\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"b\", \"t\": \"abc\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"abc\", \"t\": \"abc\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"aaaaaa\", \"t\": \"bbaaaa\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"ace\", \"t\": \"abcde\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"aec\", \"t\": \"abcde\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"abc\", \"t\": \"ahbgdc\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"axc\", \"t\": \"ahbgdc\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"\", \"t\": \"ahbgdc\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"abc\", \"t\": \"\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"\", \"t\": \"\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"b\", \"t\": \"abc\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"abc\", \"t\": \"abc\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"aaaaaa\", \"t\": \"bbaaaa\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"ace\", \"t\": \"abcde\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"aec\", \"t\": \"abcde\"}",
                        Expected = "false",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Two Pointers" },
                    new() { Name = "String" },
                    new() { Name = "Dynamic Programming" },
                ],
            };

            var containerWithMostWater = new Problem
            {
                ProblemName = "盛最多水的容器",
                Description = "給定高度陣列 height，找出兩條垂線使其構成的容器能容納最多水。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "max_area",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "height" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "maxArea", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "MaxArea",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "height" }],
                        ProblemReturnTypes = [new() { ReturnName = "maxArea", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"height\": [1, 8, 6, 2, 5, 4, 8, 3, 7]}",
                        Expected = "49",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"height\": [1, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"height\": [4, 3, 2, 1, 4]}",
                        Expected = "16",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"height\": [1, 2, 1]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"height\": [2, 3, 4, 5, 18, 17, 6]}",
                        Expected = "17",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"height\": [1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"height\": [0, 0]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"height\": [5, 5, 5, 5, 5]}",
                        Expected = "20",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"height\": [1, 2, 3, 4, 5, 25]}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"height\": [3, 9, 3, 4, 7, 2, 12, 6]}",
                        Expected = "45",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"height\": [1, 8, 6, 2, 5, 4, 8, 3, 7]}",
                        Expected = "49",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"height\": [1, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"height\": [4, 3, 2, 1, 4]}",
                        Expected = "16",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"height\": [1, 2, 1]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"height\": [2, 3, 4, 5, 18, 17, 6]}",
                        Expected = "17",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"height\": [1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"height\": [0, 0]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"height\": [5, 5, 5, 5, 5]}",
                        Expected = "20",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"height\": [1, 2, 3, 4, 5, 25]}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"height\": [3, 9, 3, 4, 7, 2, 12, 6]}",
                        Expected = "45",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Two Pointers" },
                    new() { Name = "Greedy" },
                ],
            };

            var twoSumIiSorted = new Problem
            {
                ProblemName = "兩數之和 II - 輸入有序陣列",
                Description =
                    "給定依非遞減排列的整數陣列 numbers，找出兩數相加等於 target，回傳其索引（從 1 開始）。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "two_sum_ii",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "numbers" },
                            new() { Type = "int", ParameterName = "target" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "indices", ReturnType = "List[int]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "TwoSumII",
                        ProblemParameters =
                        [
                            new() { Type = "int[]", ParameterName = "numbers" },
                            new() { Type = "int", ParameterName = "target" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "indices", ReturnType = "int[]" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numbers\": [2, 7, 11, 15], \"target\": 9}",
                        Expected = "[1, 2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numbers\": [2, 3, 4], \"target\": 6}",
                        Expected = "[1, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numbers\": [-1, 0], \"target\": -1}",
                        Expected = "[1, 2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numbers\": [1, 2, 3, 4, 4, 9, 56, 90], \"target\": 8}",
                        Expected = "[4, 5]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numbers\": [-3, -1, 0, 2, 4, 6], \"target\": 1}",
                        Expected = "[1, 5]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numbers\": [5, 25, 75], \"target\": 100}",
                        Expected = "[2, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numbers\": [1, 2], \"target\": 3}",
                        Expected = "[1, 2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numbers\": [0, 0, 3, 4], \"target\": 0}",
                        Expected = "[1, 2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numbers\": [-10, -5, 0, 5, 10], \"target\": 0}",
                        Expected = "[1, 5]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numbers\": [1, 3, 4, 5, 7, 11], \"target\": 12}",
                        Expected = "[1, 6]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numbers\": [2, 7, 11, 15], \"target\": 9}",
                        Expected = "[1, 2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numbers\": [2, 3, 4], \"target\": 6}",
                        Expected = "[1, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numbers\": [-1, 0], \"target\": -1}",
                        Expected = "[1, 2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numbers\": [1, 2, 3, 4, 4, 9, 56, 90], \"target\": 8}",
                        Expected = "[4, 5]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numbers\": [-3, -1, 0, 2, 4, 6], \"target\": 1}",
                        Expected = "[1, 5]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numbers\": [5, 25, 75], \"target\": 100}",
                        Expected = "[2, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numbers\": [1, 2], \"target\": 3}",
                        Expected = "[1, 2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numbers\": [0, 0, 3, 4], \"target\": 0}",
                        Expected = "[1, 2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numbers\": [-10, -5, 0, 5, 10], \"target\": 0}",
                        Expected = "[1, 5]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numbers\": [1, 3, 4, 5, 7, 11], \"target\": 12}",
                        Expected = "[1, 6]",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Two Pointers" },
                    new() { Name = "Binary Search" },
                ],
            };

            var threeSum = new Problem
            {
                ProblemName = "三數之和",
                Description = "給定整數陣列 nums，找出所有相加和為 0 且不重複的三元組。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "three_sum",
                        ProblemParameters = [new() { Type = "List[int]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "triplets", ReturnType = "List[List[int]]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "ThreeSum",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "triplets", ReturnType = "List<List<int>>" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-1, 0, 1, 2, -1, -4]}",
                        Expected = "[[-1, -1, 2], [-1, 0, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 1, 1]}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 0, 0]}",
                        Expected = "[[0, 0, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": []}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 0, 0, 0]}",
                        Expected = "[[0, 0, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-2, 0, 1, 1, 2]}",
                        Expected = "[[-2, 0, 2], [-2, 1, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [3, -2, 1, 0, -1, -3, 2]}",
                        Expected = "[[-3, 0, 3], [-3, 1, 2], [-2, -1, 3], [-2, 0, 2], [-1, 0, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-1, -1, -1, 2, 2]}",
                        Expected = "[[-1, -1, 2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, -2, -1]}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-4, -2, -2, -2, 0, 1, 2, 2, 2, 3, 3, 4, 4, 6, 6]}",
                        Expected =
                            "[[-4, -2, 6], [-4, 0, 4], [-4, 1, 3], [-4, 2, 2], [-2, -2, 4], [-2, 0, 2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-1, 0, 1, 2, -1, -4]}",
                        Expected = "[[-1, -1, 2], [-1, 0, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 1, 1]}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 0, 0]}",
                        Expected = "[[0, 0, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": []}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 0, 0, 0]}",
                        Expected = "[[0, 0, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-2, 0, 1, 1, 2]}",
                        Expected = "[[-2, 0, 2], [-2, 1, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [3, -2, 1, 0, -1, -3, 2]}",
                        Expected = "[[-3, 0, 3], [-3, 1, 2], [-2, -1, 3], [-2, 0, 2], [-1, 0, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-1, -1, -1, 2, 2]}",
                        Expected = "[[-1, -1, 2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, -2, -1]}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-4, -2, -2, -2, 0, 1, 2, 2, 2, 3, 3, 4, 4, 6, 6]}",
                        Expected =
                            "[[-4, -2, 6], [-4, 0, 4], [-4, 1, 3], [-4, 2, 2], [-2, -2, 4], [-2, 0, 2]]",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Two Pointers" },
                    new() { Name = "Sorting" },
                ],
            };

            var happyNumber = new Problem
            {
                ProblemName = "快樂數",
                Description =
                    "對正整數 n 反覆執行各位數字平方和，若最終得到 1 則為快樂數，判斷 n 是否為快樂數。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "is_happy",
                        ProblemParameters = [new() { Type = "int", ParameterName = "n" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "isHappy", ReturnType = "bool" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "IsHappy",
                        ProblemParameters = [new() { Type = "int", ParameterName = "n" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "isHappy", ReturnType = "bool" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 19}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 2}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 1}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 7}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 4}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 100}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 1000}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 999999999}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 58}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 89}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 19}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 2}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 1}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 7}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 4}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 100}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 1000}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 999999999}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 58}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 89}",
                        Expected = "false",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Hash Table" },
                    new() { Name = "Math" },
                    new() { Name = "Two Pointers" },
                ],
            };

            var longestSubstringWithoutRepeat = new Problem
            {
                ProblemName = "無重複字元的最長子字串",
                Description = "給定字串 s，找出其中不含重複字元的最長子字串的長度。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "length_of_longest_substring",
                        ProblemParameters = [new() { Type = "str", ParameterName = "s" }],
                        ProblemReturnTypes = [new() { ReturnName = "length", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "LengthOfLongestSubstring",
                        ProblemParameters = [new() { Type = "string", ParameterName = "s" }],
                        ProblemReturnTypes = [new() { ReturnName = "length", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"abcabcbb\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"bbbbb\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"pwwkew\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"\"}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \" \"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"au\"}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"dvdf\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"abba\"}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"tmmzuxt\"}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"anviaj\"}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"abcabcbb\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"bbbbb\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"pwwkew\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"\"}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \" \"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"au\"}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"dvdf\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"abba\"}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"tmmzuxt\"}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"anviaj\"}",
                        Expected = "5",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Hash Table" },
                    new() { Name = "String" },
                    new() { Name = "Sliding Window" },
                ],
            };

            var minimumWindowSubstring = new Problem
            {
                ProblemName = "最小覆蓋子字串",
                Description =
                    "給定字串 s 和 t，找出 s 中包含 t 所有字元的最小子字串；不存在則回傳空字串。",
                Difficulty = ProblemDifficultyEnums.Hard,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "min_window",
                        ProblemParameters =
                        [
                            new() { Type = "str", ParameterName = "s" },
                            new() { Type = "str", ParameterName = "t" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "window", ReturnType = "str" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "MinWindow",
                        ProblemParameters =
                        [
                            new() { Type = "string", ParameterName = "s" },
                            new() { Type = "string", ParameterName = "t" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "window", ReturnType = "string" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"ADOBECODEBANC\", \"t\": \"ABC\"}",
                        Expected = "\"BANC\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"a\", \"t\": \"a\"}",
                        Expected = "\"a\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"a\", \"t\": \"aa\"}",
                        Expected = "\"\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"\", \"t\": \"a\"}",
                        Expected = "\"\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"a\", \"t\": \"\"}",
                        Expected = "\"\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"ab\", \"t\": \"b\"}",
                        Expected = "\"b\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"aa\", \"t\": \"aa\"}",
                        Expected = "\"aa\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"bba\", \"t\": \"ab\"}",
                        Expected = "\"ba\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"acbbaca\", \"t\": \"aba\"}",
                        Expected = "\"baca\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"ab\", \"t\": \"a\"}",
                        Expected = "\"a\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"ADOBECODEBANC\", \"t\": \"ABC\"}",
                        Expected = "\"BANC\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"a\", \"t\": \"a\"}",
                        Expected = "\"a\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"a\", \"t\": \"aa\"}",
                        Expected = "\"\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"\", \"t\": \"a\"}",
                        Expected = "\"\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"a\", \"t\": \"\"}",
                        Expected = "\"\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"ab\", \"t\": \"b\"}",
                        Expected = "\"b\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"aa\", \"t\": \"aa\"}",
                        Expected = "\"aa\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"bba\", \"t\": \"ab\"}",
                        Expected = "\"ba\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"acbbaca\", \"t\": \"aba\"}",
                        Expected = "\"baca\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"ab\", \"t\": \"a\"}",
                        Expected = "\"a\"",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Hash Table" },
                    new() { Name = "String" },
                    new() { Name = "Sliding Window" },
                ],
            };

            var substringConcatAllWords = new Problem
            {
                ProblemName = "串接所有單字的子字串",
                Description =
                    "給定字串 s 和長度相同的單字陣列 words，找出 s 中由 words 所有單字串接而成的子字串起始索引。",
                Difficulty = ProblemDifficultyEnums.Hard,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "find_substring",
                        ProblemParameters =
                        [
                            new() { Type = "str", ParameterName = "s" },
                            new() { Type = "List[str]", ParameterName = "words" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "indices", ReturnType = "List[int]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "FindSubstring",
                        ProblemParameters =
                        [
                            new() { Type = "string", ParameterName = "s" },
                            new() { Type = "string[]", ParameterName = "words" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "indices", ReturnType = "List<int>" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"barfoothefoobarman\", \"words\": [\"foo\", \"bar\"]}",
                        Expected = "[0, 9]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"s\": \"wordgoodgoodgoodbestword\", \"words\": [\"word\", \"good\", \"best\", \"word\"]}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"s\": \"barfoofoobarthefoobarman\", \"words\": [\"bar\", \"foo\", \"the\"]}",
                        Expected = "[6, 9, 12]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"aaaaaaaaaaaaaa\", \"words\": [\"aa\", \"aa\"]}",
                        Expected = "[0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"\", \"words\": [\"a\"]}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"ab\", \"words\": [\"ab\"]}",
                        Expected = "[0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"abcd\", \"words\": [\"ab\", \"cd\"]}",
                        Expected = "[0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"aaa\", \"words\": [\"a\", \"a\"]}",
                        Expected = "[0, 1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"s\": \"wordgoodbadgoodbest\", \"words\": [\"word\", \"good\", \"best\", \"word\"]}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"s\": \"lingmindraboofooowingdingbarrwingmonkeypoundcake\", \"words\": [\"fooo\", \"barr\", \"wing\", \"ding\", \"wing\"]}",
                        Expected = "[13]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"barfoothefoobarman\", \"words\": [\"foo\", \"bar\"]}",
                        Expected = "[0, 9]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"s\": \"wordgoodgoodgoodbestword\", \"words\": [\"word\", \"good\", \"best\", \"word\"]}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"s\": \"barfoofoobarthefoobarman\", \"words\": [\"bar\", \"foo\", \"the\"]}",
                        Expected = "[6, 9, 12]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"aaaaaaaaaaaaaa\", \"words\": [\"aa\", \"aa\"]}",
                        Expected = "[0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"\", \"words\": [\"a\"]}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"ab\", \"words\": [\"ab\"]}",
                        Expected = "[0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"abcd\", \"words\": [\"ab\", \"cd\"]}",
                        Expected = "[0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"aaa\", \"words\": [\"a\", \"a\"]}",
                        Expected = "[0, 1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"s\": \"wordgoodbadgoodbest\", \"words\": [\"word\", \"good\", \"best\", \"word\"]}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"s\": \"lingmindraboofooowingdingbarrwingmonkeypoundcake\", \"words\": [\"fooo\", \"barr\", \"wing\", \"ding\", \"wing\"]}",
                        Expected = "[13]",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Hash Table" },
                    new() { Name = "String" },
                    new() { Name = "Sliding Window" },
                ],
            };

            var minimumSizeSubarraySum = new Problem
            {
                ProblemName = "長度最小的子陣列",
                Description =
                    "給定正整數陣列 nums 與 target，找出總和大於等於 target 的最短連續子陣列長度；不存在則回傳 0。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "min_sub_array_len",
                        ProblemParameters =
                        [
                            new() { Type = "int", ParameterName = "target" },
                            new() { Type = "List[int]", ParameterName = "nums" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "length", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "MinSubArrayLen",
                        ProblemParameters =
                        [
                            new() { Type = "int", ParameterName = "target" },
                            new() { Type = "int[]", ParameterName = "nums" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "length", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"target\": 7, \"nums\": [2, 3, 1, 2, 4, 3]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"target\": 4, \"nums\": [1, 4, 4]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"target\": 11, \"nums\": [1, 1, 1, 1, 1, 1, 1, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"target\": 5, \"nums\": [1, 2, 3, 4, 5]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"target\": 15, \"nums\": [1, 2, 3, 4, 5]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"target\": 1, \"nums\": [1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"target\": 2, \"nums\": [1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"target\": 100, \"nums\": [1, 2, 3]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"target\": 3, \"nums\": [1, 1, 1, 1, 1]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"target\": 6, \"nums\": [10, 2, 3]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"target\": 7, \"nums\": [2, 3, 1, 2, 4, 3]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"target\": 4, \"nums\": [1, 4, 4]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"target\": 11, \"nums\": [1, 1, 1, 1, 1, 1, 1, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"target\": 5, \"nums\": [1, 2, 3, 4, 5]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"target\": 15, \"nums\": [1, 2, 3, 4, 5]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"target\": 1, \"nums\": [1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"target\": 2, \"nums\": [1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"target\": 100, \"nums\": [1, 2, 3]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"target\": 3, \"nums\": [1, 1, 1, 1, 1]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"target\": 6, \"nums\": [10, 2, 3]}",
                        Expected = "1",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Binary Search" },
                    new() { Name = "Sliding Window" },
                    new() { Name = "Prefix Sum" },
                ],
            };

            var validSudoku = new Problem
            {
                ProblemName = "有效的數獨",
                Description =
                    "判斷一個 9x9 的數獨棋盤是否有效（行、列、3x3子方格內 1-9 不重複），'.' 表示未填。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "is_valid_sudoku",
                        ProblemParameters =
                        [
                            new() { Type = "List[List[str]]", ParameterName = "board" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "isValid", ReturnType = "bool" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "IsValidSudoku",
                        ProblemParameters = [new() { Type = "char[][]", ParameterName = "board" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "isValid", ReturnType = "bool" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"5\", \"3\", \".\", \".\", \"7\", \".\", \".\", \".\", \".\"], [\"6\", \".\", \".\", \"1\", \"9\", \"5\", \".\", \".\", \".\"], [\".\", \"9\", \"8\", \".\", \".\", \".\", \".\", \"6\", \".\"], [\"8\", \".\", \".\", \".\", \"6\", \".\", \".\", \".\", \"3\"], [\"4\", \".\", \".\", \"8\", \".\", \"3\", \".\", \".\", \"1\"], [\"7\", \".\", \".\", \".\", \"2\", \".\", \".\", \".\", \"6\"], [\".\", \"6\", \".\", \".\", \".\", \".\", \"2\", \"8\", \".\"], [\".\", \".\", \".\", \"4\", \"1\", \"9\", \".\", \".\", \"5\"], [\".\", \".\", \".\", \".\", \"8\", \".\", \".\", \"7\", \"9\"]]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"8\", \"3\", \".\", \".\", \"7\", \".\", \".\", \".\", \".\"], [\"6\", \".\", \".\", \"1\", \"9\", \"5\", \".\", \".\", \".\"], [\".\", \"9\", \"8\", \".\", \".\", \".\", \".\", \"6\", \".\"], [\"8\", \".\", \".\", \".\", \"6\", \".\", \".\", \".\", \"3\"], [\"4\", \".\", \".\", \"8\", \".\", \"3\", \".\", \".\", \"1\"], [\"7\", \".\", \".\", \".\", \"2\", \".\", \".\", \".\", \"6\"], [\".\", \"6\", \".\", \".\", \".\", \".\", \"2\", \"8\", \".\"], [\".\", \".\", \".\", \"4\", \"1\", \"9\", \".\", \".\", \"5\"], [\".\", \".\", \".\", \".\", \"8\", \".\", \".\", \"7\", \"9\"]]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"]]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"5\", \"5\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"]]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"5\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\"5\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"]]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"5\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \"5\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"]]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \"9\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"]]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"5\", \"3\", \"4\", \"6\", \"7\", \"8\", \"9\", \"1\", \"2\"], [\"6\", \"7\", \"2\", \"1\", \"9\", \"5\", \"3\", \"4\", \"8\"], [\"1\", \"9\", \"8\", \"3\", \"4\", \"2\", \"5\", \"6\", \"7\"], [\"8\", \"5\", \"9\", \"7\", \"6\", \"1\", \"4\", \"2\", \"3\"], [\"4\", \"2\", \"6\", \"8\", \"5\", \"3\", \"7\", \"9\", \"1\"], [\"7\", \"1\", \"3\", \"9\", \"2\", \"4\", \"8\", \"5\", \"6\"], [\"9\", \"6\", \"1\", \"5\", \"3\", \"7\", \"2\", \"8\", \"4\"], [\"2\", \"8\", \"7\", \"4\", \"1\", \"9\", \"6\", \"3\", \"5\"], [\"3\", \"4\", \"5\", \"2\", \"8\", \"6\", \"1\", \"7\", \"9\"]]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"5\", \"3\", \"4\", \"6\", \"7\", \"8\", \"9\", \"1\", \"2\"], [\"6\", \"7\", \"2\", \"1\", \"9\", \"5\", \"3\", \"4\", \"8\"], [\"1\", \"9\", \"8\", \"3\", \"4\", \"2\", \"5\", \"6\", \"7\"], [\"8\", \"5\", \"9\", \"7\", \"6\", \"1\", \"4\", \"2\", \"3\"], [\"4\", \"2\", \"6\", \"8\", \"5\", \"3\", \"7\", \"9\", \"1\"], [\"7\", \"1\", \"3\", \"9\", \"2\", \"4\", \"8\", \"5\", \"6\"], [\"9\", \"6\", \"1\", \"5\", \"3\", \"7\", \"2\", \"8\", \"4\"], [\"2\", \"8\", \"7\", \"4\", \"1\", \"9\", \"6\", \"3\", \"5\"], [\"3\", \"4\", \"5\", \"2\", \"8\", \"6\", \"1\", \"7\", \"5\"]]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"]]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"5\", \"3\", \".\", \".\", \"7\", \".\", \".\", \".\", \".\"], [\"6\", \".\", \".\", \"1\", \"9\", \"5\", \".\", \".\", \".\"], [\".\", \"9\", \"8\", \".\", \".\", \".\", \".\", \"6\", \".\"], [\"8\", \".\", \".\", \".\", \"6\", \".\", \".\", \".\", \"3\"], [\"4\", \".\", \".\", \"8\", \".\", \"3\", \".\", \".\", \"1\"], [\"7\", \".\", \".\", \".\", \"2\", \".\", \".\", \".\", \"6\"], [\".\", \"6\", \".\", \".\", \".\", \".\", \"2\", \"8\", \".\"], [\".\", \".\", \".\", \"4\", \"1\", \"9\", \".\", \".\", \"5\"], [\".\", \".\", \".\", \".\", \"8\", \".\", \".\", \"7\", \"9\"]]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"8\", \"3\", \".\", \".\", \"7\", \".\", \".\", \".\", \".\"], [\"6\", \".\", \".\", \"1\", \"9\", \"5\", \".\", \".\", \".\"], [\".\", \"9\", \"8\", \".\", \".\", \".\", \".\", \"6\", \".\"], [\"8\", \".\", \".\", \".\", \"6\", \".\", \".\", \".\", \"3\"], [\"4\", \".\", \".\", \"8\", \".\", \"3\", \".\", \".\", \"1\"], [\"7\", \".\", \".\", \".\", \"2\", \".\", \".\", \".\", \"6\"], [\".\", \"6\", \".\", \".\", \".\", \".\", \"2\", \"8\", \".\"], [\".\", \".\", \".\", \"4\", \"1\", \"9\", \".\", \".\", \"5\"], [\".\", \".\", \".\", \".\", \"8\", \".\", \".\", \"7\", \"9\"]]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"]]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"5\", \"5\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"]]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"5\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\"5\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"]]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"5\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \"5\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"]]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \"9\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"]]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"5\", \"3\", \"4\", \"6\", \"7\", \"8\", \"9\", \"1\", \"2\"], [\"6\", \"7\", \"2\", \"1\", \"9\", \"5\", \"3\", \"4\", \"8\"], [\"1\", \"9\", \"8\", \"3\", \"4\", \"2\", \"5\", \"6\", \"7\"], [\"8\", \"5\", \"9\", \"7\", \"6\", \"1\", \"4\", \"2\", \"3\"], [\"4\", \"2\", \"6\", \"8\", \"5\", \"3\", \"7\", \"9\", \"1\"], [\"7\", \"1\", \"3\", \"9\", \"2\", \"4\", \"8\", \"5\", \"6\"], [\"9\", \"6\", \"1\", \"5\", \"3\", \"7\", \"2\", \"8\", \"4\"], [\"2\", \"8\", \"7\", \"4\", \"1\", \"9\", \"6\", \"3\", \"5\"], [\"3\", \"4\", \"5\", \"2\", \"8\", \"6\", \"1\", \"7\", \"9\"]]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"5\", \"3\", \"4\", \"6\", \"7\", \"8\", \"9\", \"1\", \"2\"], [\"6\", \"7\", \"2\", \"1\", \"9\", \"5\", \"3\", \"4\", \"8\"], [\"1\", \"9\", \"8\", \"3\", \"4\", \"2\", \"5\", \"6\", \"7\"], [\"8\", \"5\", \"9\", \"7\", \"6\", \"1\", \"4\", \"2\", \"3\"], [\"4\", \"2\", \"6\", \"8\", \"5\", \"3\", \"7\", \"9\", \"1\"], [\"7\", \"1\", \"3\", \"9\", \"2\", \"4\", \"8\", \"5\", \"6\"], [\"9\", \"6\", \"1\", \"5\", \"3\", \"7\", \"2\", \"8\", \"4\"], [\"2\", \"8\", \"7\", \"4\", \"1\", \"9\", \"6\", \"3\", \"5\"], [\"3\", \"4\", \"5\", \"2\", \"8\", \"6\", \"1\", \"7\", \"5\"]]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"], [\".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\", \".\"]]}",
                        Expected = "true",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Hash Table" },
                    new() { Name = "Matrix" },
                ],
            };

            var spiralMatrix = new Problem
            {
                ProblemName = "螺旋矩陣",
                Description = "給定 m x n 矩陣，按螺旋順序回傳矩陣中的所有元素。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "spiral_order",
                        ProblemParameters =
                        [
                            new() { Type = "List[List[int]]", ParameterName = "matrix" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "result", ReturnType = "List[int]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "SpiralOrder",
                        ProblemParameters = [new() { Type = "int[][]", ParameterName = "matrix" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "result", ReturnType = "List<int>" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1, 2, 3], [4, 5, 6], [7, 8, 9]]}",
                        Expected = "[1, 2, 3, 6, 9, 8, 7, 4, 5]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12]]}",
                        Expected = "[1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1]]}",
                        Expected = "[1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1, 2], [3, 4]]}",
                        Expected = "[1, 2, 4, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1], [2], [3]]}",
                        Expected = "[1, 2, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1, 2, 3]]}",
                        Expected = "[1, 2, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1, 2], [3, 4], [5, 6]]}",
                        Expected = "[1, 2, 4, 6, 5, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1, 2, 3, 4, 5]]}",
                        Expected = "[1, 2, 3, 4, 5]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1], [2], [3], [4]]}",
                        Expected = "[1, 2, 3, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[7]]}",
                        Expected = "[7]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1, 2, 3], [4, 5, 6], [7, 8, 9]]}",
                        Expected = "[1, 2, 3, 6, 9, 8, 7, 4, 5]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12]]}",
                        Expected = "[1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1]]}",
                        Expected = "[1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1, 2], [3, 4]]}",
                        Expected = "[1, 2, 4, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1], [2], [3]]}",
                        Expected = "[1, 2, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1, 2, 3]]}",
                        Expected = "[1, 2, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1, 2], [3, 4], [5, 6]]}",
                        Expected = "[1, 2, 4, 6, 5, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1, 2, 3, 4, 5]]}",
                        Expected = "[1, 2, 3, 4, 5]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1], [2], [3], [4]]}",
                        Expected = "[1, 2, 3, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[7]]}",
                        Expected = "[7]",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Matrix" },
                    new() { Name = "Simulation" },
                ],
            };

            var rotateImage = new Problem
            {
                ProblemName = "旋轉影像",
                Description = "給定 n x n 二維矩陣表示影像，將其原地順時針旋轉 90 度，回傳結果。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "rotate_image",
                        ProblemParameters =
                        [
                            new() { Type = "List[List[int]]", ParameterName = "matrix" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "matrix", ReturnType = "List[List[int]]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "RotateImage",
                        ProblemParameters = [new() { Type = "int[][]", ParameterName = "matrix" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "matrix", ReturnType = "int[][]" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1, 2, 3], [4, 5, 6], [7, 8, 9]]}",
                        Expected = "[[7, 4, 1], [8, 5, 2], [9, 6, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"matrix\": [[5, 1, 9, 11], [2, 4, 8, 10], [13, 3, 6, 7], [15, 14, 12, 16]]}",
                        Expected =
                            "[[15, 13, 2, 5], [14, 3, 4, 1], [12, 6, 8, 9], [16, 7, 10, 11]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1]]}",
                        Expected = "[[1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1, 2], [3, 4]]}",
                        Expected = "[[3, 1], [4, 2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1, 2, 3], [4, 5, 6], [7, 8, 9]]}",
                        Expected = "[[7, 4, 1], [8, 5, 2], [9, 6, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1, 0], [0, 1]]}",
                        Expected = "[[0, 1], [1, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[9, 9], [9, 9]]}",
                        Expected = "[[9, 9], [9, 9]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"matrix\": [[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12], [13, 14, 15, 16]]}",
                        Expected =
                            "[[13, 9, 5, 1], [14, 10, 6, 2], [15, 11, 7, 3], [16, 12, 8, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[0, 0, 0], [0, 1, 0], [0, 0, 0]]}",
                        Expected = "[[0, 0, 0], [0, 1, 0], [0, 0, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[3, 7], [1, 2]]}",
                        Expected = "[[1, 3], [2, 7]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1, 2, 3], [4, 5, 6], [7, 8, 9]]}",
                        Expected = "[[7, 4, 1], [8, 5, 2], [9, 6, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"matrix\": [[5, 1, 9, 11], [2, 4, 8, 10], [13, 3, 6, 7], [15, 14, 12, 16]]}",
                        Expected =
                            "[[15, 13, 2, 5], [14, 3, 4, 1], [12, 6, 8, 9], [16, 7, 10, 11]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1]]}",
                        Expected = "[[1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1, 2], [3, 4]]}",
                        Expected = "[[3, 1], [4, 2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1, 2, 3], [4, 5, 6], [7, 8, 9]]}",
                        Expected = "[[7, 4, 1], [8, 5, 2], [9, 6, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1, 0], [0, 1]]}",
                        Expected = "[[0, 1], [1, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[9, 9], [9, 9]]}",
                        Expected = "[[9, 9], [9, 9]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"matrix\": [[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12], [13, 14, 15, 16]]}",
                        Expected =
                            "[[13, 9, 5, 1], [14, 10, 6, 2], [15, 11, 7, 3], [16, 12, 8, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[0, 0, 0], [0, 1, 0], [0, 0, 0]]}",
                        Expected = "[[0, 0, 0], [0, 1, 0], [0, 0, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[3, 7], [1, 2]]}",
                        Expected = "[[1, 3], [2, 7]]",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Math" },
                    new() { Name = "Matrix" },
                ],
            };

            var setMatrixZeroes = new Problem
            {
                ProblemName = "矩陣置零",
                Description =
                    "給定 m x n 矩陣，若某元素為 0 則將其所在行列全部設為 0，回傳處理後的矩陣。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "set_zeroes",
                        ProblemParameters =
                        [
                            new() { Type = "List[List[int]]", ParameterName = "matrix" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "matrix", ReturnType = "List[List[int]]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "SetZeroes",
                        ProblemParameters = [new() { Type = "int[][]", ParameterName = "matrix" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "matrix", ReturnType = "int[][]" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1, 1, 1], [1, 0, 1], [1, 1, 1]]}",
                        Expected = "[[1, 0, 1], [0, 0, 0], [1, 0, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[0, 1, 2, 0], [3, 4, 5, 2], [1, 3, 1, 5]]}",
                        Expected = "[[0, 0, 0, 0], [0, 4, 5, 0], [0, 3, 1, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1]]}",
                        Expected = "[[1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[0]]}",
                        Expected = "[[0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1, 2], [3, 4]]}",
                        Expected = "[[1, 2], [3, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[0, 0], [0, 0]]}",
                        Expected = "[[0, 0], [0, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1, 0], [0, 1]]}",
                        Expected = "[[0, 0], [0, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[5, 5, 5], [5, 5, 5], [5, 0, 5]]}",
                        Expected = "[[5, 0, 5], [5, 0, 5], [0, 0, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1, 1, 1, 1]]}",
                        Expected = "[[1, 1, 1, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1], [0], [1]]}",
                        Expected = "[[0], [0], [0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1, 1, 1], [1, 0, 1], [1, 1, 1]]}",
                        Expected = "[[1, 0, 1], [0, 0, 0], [1, 0, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[0, 1, 2, 0], [3, 4, 5, 2], [1, 3, 1, 5]]}",
                        Expected = "[[0, 0, 0, 0], [0, 4, 5, 0], [0, 3, 1, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1]]}",
                        Expected = "[[1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[0]]}",
                        Expected = "[[0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1, 2], [3, 4]]}",
                        Expected = "[[1, 2], [3, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[0, 0], [0, 0]]}",
                        Expected = "[[0, 0], [0, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1, 0], [0, 1]]}",
                        Expected = "[[0, 0], [0, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[5, 5, 5], [5, 5, 5], [5, 0, 5]]}",
                        Expected = "[[5, 0, 5], [5, 0, 5], [0, 0, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1, 1, 1, 1]]}",
                        Expected = "[[1, 1, 1, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1], [0], [1]]}",
                        Expected = "[[0], [0], [0]]",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Hash Table" },
                    new() { Name = "Matrix" },
                ],
            };

            var gameOfLife = new Problem
            {
                ProblemName = "生命遊戲",
                Description =
                    "給定 m x n 二維陣列表示細胞狀態，依康威生命遊戲規則計算下一狀態矩陣。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "game_of_life",
                        ProblemParameters =
                        [
                            new() { Type = "List[List[int]]", ParameterName = "board" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "board", ReturnType = "List[List[int]]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "GameOfLife",
                        ProblemParameters = [new() { Type = "int[][]", ParameterName = "board" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "board", ReturnType = "int[][]" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[0, 1, 0], [0, 0, 1], [1, 1, 1], [0, 0, 0]]}",
                        Expected = "[[0, 0, 0], [1, 0, 1], [0, 1, 1], [0, 1, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[1, 1], [1, 0]]}",
                        Expected = "[[1, 1], [1, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[0, 0, 0], [0, 0, 0], [0, 0, 0]]}",
                        Expected = "[[0, 0, 0], [0, 0, 0], [0, 0, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[1, 1, 1], [1, 1, 1], [1, 1, 1]]}",
                        Expected = "[[1, 0, 1], [0, 0, 0], [1, 0, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[1]]}",
                        Expected = "[[0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[0]]}",
                        Expected = "[[0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[1, 0], [0, 1]]}",
                        Expected = "[[0, 0], [0, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[0, 1, 0]]}",
                        Expected = "[[0, 0, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[1], [1], [1]]}",
                        Expected = "[[0], [1], [0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[1, 1, 0, 0], [1, 1, 0, 0], [0, 0, 1, 1], [0, 0, 1, 1]]}",
                        Expected = "[[1, 1, 0, 0], [1, 0, 0, 0], [0, 0, 0, 1], [0, 0, 1, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[0, 1, 0], [0, 0, 1], [1, 1, 1], [0, 0, 0]]}",
                        Expected = "[[0, 0, 0], [1, 0, 1], [0, 1, 1], [0, 1, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[1, 1], [1, 0]]}",
                        Expected = "[[1, 1], [1, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[0, 0, 0], [0, 0, 0], [0, 0, 0]]}",
                        Expected = "[[0, 0, 0], [0, 0, 0], [0, 0, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[1, 1, 1], [1, 1, 1], [1, 1, 1]]}",
                        Expected = "[[1, 0, 1], [0, 0, 0], [1, 0, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[1]]}",
                        Expected = "[[0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[0]]}",
                        Expected = "[[0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[1, 0], [0, 1]]}",
                        Expected = "[[0, 0], [0, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[0, 1, 0]]}",
                        Expected = "[[0, 0, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[1], [1], [1]]}",
                        Expected = "[[0], [1], [0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[1, 1, 0, 0], [1, 1, 0, 0], [0, 0, 1, 1], [0, 0, 1, 1]]}",
                        Expected = "[[1, 1, 0, 0], [1, 0, 0, 0], [0, 0, 0, 1], [0, 0, 1, 1]]",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Matrix" },
                    new() { Name = "Simulation" },
                ],
            };

            var ransomNote = new Problem
            {
                ProblemName = "贖金信",
                Description =
                    "給定 ransomNote 和 magazine，判斷 ransomNote 能否僅用 magazine 中的字元構成。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "can_construct",
                        ProblemParameters =
                        [
                            new() { Type = "str", ParameterName = "ransomNote" },
                            new() { Type = "str", ParameterName = "magazine" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "canConstruct", ReturnType = "bool" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "CanConstruct",
                        ProblemParameters =
                        [
                            new() { Type = "string", ParameterName = "ransomNote" },
                            new() { Type = "string", ParameterName = "magazine" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "canConstruct", ReturnType = "bool" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"ransomNote\": \"a\", \"magazine\": \"b\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"ransomNote\": \"aa\", \"magazine\": \"ab\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"ransomNote\": \"aa\", \"magazine\": \"aab\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"ransomNote\": \"\", \"magazine\": \"\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"ransomNote\": \"\", \"magazine\": \"abc\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"ransomNote\": \"a\", \"magazine\": \"\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"ransomNote\": \"aabbcc\", \"magazine\": \"abcabc\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"ransomNote\": \"aabbcc\", \"magazine\": \"abc\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"ransomNote\": \"xyz\", \"magazine\": \"zyx\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"ransomNote\": \"aaa\", \"magazine\": \"aaaa\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"ransomNote\": \"a\", \"magazine\": \"b\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"ransomNote\": \"aa\", \"magazine\": \"ab\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"ransomNote\": \"aa\", \"magazine\": \"aab\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"ransomNote\": \"\", \"magazine\": \"\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"ransomNote\": \"\", \"magazine\": \"abc\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"ransomNote\": \"a\", \"magazine\": \"\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"ransomNote\": \"aabbcc\", \"magazine\": \"abcabc\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"ransomNote\": \"aabbcc\", \"magazine\": \"abc\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"ransomNote\": \"xyz\", \"magazine\": \"zyx\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"ransomNote\": \"aaa\", \"magazine\": \"aaaa\"}",
                        Expected = "true",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Hash Table" },
                    new() { Name = "String" },
                    new() { Name = "Counting" },
                ],
            };

            var isomorphicStrings = new Problem
            {
                ProblemName = "同構字串",
                Description = "給定字串 s 和 t，判斷是否為同構（字元一一對應替換）。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "is_isomorphic",
                        ProblemParameters =
                        [
                            new() { Type = "str", ParameterName = "s" },
                            new() { Type = "str", ParameterName = "t" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "isIsomorphic", ReturnType = "bool" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "IsIsomorphic",
                        ProblemParameters =
                        [
                            new() { Type = "string", ParameterName = "s" },
                            new() { Type = "string", ParameterName = "t" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "isIsomorphic", ReturnType = "bool" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"egg\", \"t\": \"add\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"foo\", \"t\": \"bar\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"paper\", \"t\": \"title\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"\", \"t\": \"\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"a\", \"t\": \"a\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"ab\", \"t\": \"aa\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"badc\", \"t\": \"baba\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"aa\", \"t\": \"ab\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"abc\", \"t\": \"def\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"ab\", \"t\": \"ca\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"egg\", \"t\": \"add\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"foo\", \"t\": \"bar\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"paper\", \"t\": \"title\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"\", \"t\": \"\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"a\", \"t\": \"a\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"ab\", \"t\": \"aa\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"badc\", \"t\": \"baba\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"aa\", \"t\": \"ab\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"abc\", \"t\": \"def\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"ab\", \"t\": \"ca\"}",
                        Expected = "true",
                    },
                ],
                ProblemTags = [new() { Name = "Hash Table" }, new() { Name = "String" }],
            };

            var wordPattern = new Problem
            {
                ProblemName = "單字規律",
                Description = "給定規律 pattern 和字串 s，判斷 s 是否遵循相同規律。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "word_pattern",
                        ProblemParameters =
                        [
                            new() { Type = "str", ParameterName = "pattern" },
                            new() { Type = "str", ParameterName = "s" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "matches", ReturnType = "bool" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "WordPattern",
                        ProblemParameters =
                        [
                            new() { Type = "string", ParameterName = "pattern" },
                            new() { Type = "string", ParameterName = "s" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "matches", ReturnType = "bool" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"pattern\": \"abba\", \"s\": \"dog cat cat dog\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"pattern\": \"abba\", \"s\": \"dog cat cat fish\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"pattern\": \"aaaa\", \"s\": \"dog cat cat dog\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"pattern\": \"abba\", \"s\": \"dog dog dog dog\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"pattern\": \"a\", \"s\": \"dog\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"pattern\": \"ab\", \"s\": \"dog dog\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"pattern\": \"\", \"s\": \"\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"pattern\": \"aa\", \"s\": \"dog dog\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"pattern\": \"abc\", \"s\": \"b c a\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"pattern\": \"aba\", \"s\": \"cat dog cat\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"pattern\": \"abba\", \"s\": \"dog cat cat dog\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"pattern\": \"abba\", \"s\": \"dog cat cat fish\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"pattern\": \"aaaa\", \"s\": \"dog cat cat dog\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"pattern\": \"abba\", \"s\": \"dog dog dog dog\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"pattern\": \"a\", \"s\": \"dog\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"pattern\": \"ab\", \"s\": \"dog dog\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"pattern\": \"\", \"s\": \"\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"pattern\": \"aa\", \"s\": \"dog dog\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"pattern\": \"abc\", \"s\": \"b c a\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"pattern\": \"aba\", \"s\": \"cat dog cat\"}",
                        Expected = "true",
                    },
                ],
                ProblemTags = [new() { Name = "Hash Table" }, new() { Name = "String" }],
            };

            var validAnagram = new Problem
            {
                ProblemName = "有效的字母異位詞",
                Description = "給定字串 s 和 t，判斷 t 是否為 s 的字母異位詞。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "is_anagram",
                        ProblemParameters =
                        [
                            new() { Type = "str", ParameterName = "s" },
                            new() { Type = "str", ParameterName = "t" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "isAnagram", ReturnType = "bool" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "IsAnagram",
                        ProblemParameters =
                        [
                            new() { Type = "string", ParameterName = "s" },
                            new() { Type = "string", ParameterName = "t" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "isAnagram", ReturnType = "bool" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"anagram\", \"t\": \"nagaram\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"rat\", \"t\": \"car\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"\", \"t\": \"\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"a\", \"t\": \"ab\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"ab\", \"t\": \"ba\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"aacc\", \"t\": \"ccac\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"a\", \"t\": \"a\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"abcd\", \"t\": \"dcba\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"aabbcc\", \"t\": \"abcabc\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"xyz\", \"t\": \"zyx\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"anagram\", \"t\": \"nagaram\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"rat\", \"t\": \"car\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"\", \"t\": \"\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"a\", \"t\": \"ab\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"ab\", \"t\": \"ba\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"aacc\", \"t\": \"ccac\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"a\", \"t\": \"a\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"abcd\", \"t\": \"dcba\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"aabbcc\", \"t\": \"abcabc\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"xyz\", \"t\": \"zyx\"}",
                        Expected = "true",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Hash Table" },
                    new() { Name = "String" },
                    new() { Name = "Sorting" },
                ],
            };

            var groupAnagrams = new Problem
            {
                ProblemName = "字母異位詞分組",
                Description = "給定字串陣列 strs，將字母異位詞分組，回傳分組結果。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "group_anagrams",
                        ProblemParameters = [new() { Type = "List[str]", ParameterName = "strs" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "groups", ReturnType = "List[List[str]]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "GroupAnagrams",
                        ProblemParameters = [new() { Type = "string[]", ParameterName = "strs" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "groups", ReturnType = "List<List<string>>" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"strs\": [\"eat\", \"tea\", \"tan\", \"ate\", \"nat\", \"bat\"]}",
                        Expected = "[[\"ate\", \"eat\", \"tea\"], [\"bat\"], [\"nat\", \"tan\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"strs\": [\"\"]}",
                        Expected = "[[\"\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"strs\": [\"a\"]}",
                        Expected = "[[\"a\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"strs\": [\"abc\", \"cba\", \"bac\", \"foo\"]}",
                        Expected = "[[\"abc\", \"bac\", \"cba\"], [\"foo\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"strs\": [\"a\", \"a\", \"a\"]}",
                        Expected = "[[\"a\", \"a\", \"a\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"strs\": [\"ab\", \"ba\", \"abc\"]}",
                        Expected = "[[\"ab\", \"ba\"], [\"abc\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"strs\": [\"\", \"\", \"\"]}",
                        Expected = "[[\"\", \"\", \"\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"strs\": [\"listen\", \"silent\", \"enlist\", \"google\", \"gogole\"]}",
                        Expected =
                            "[[\"enlist\", \"listen\", \"silent\"], [\"gogole\", \"google\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"strs\": [\"abc\", \"bca\", \"cab\", \"xyz\"]}",
                        Expected = "[[\"abc\", \"bca\", \"cab\"], [\"xyz\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"strs\": [\"x\"]}",
                        Expected = "[[\"x\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"strs\": [\"eat\", \"tea\", \"tan\", \"ate\", \"nat\", \"bat\"]}",
                        Expected = "[[\"ate\", \"eat\", \"tea\"], [\"bat\"], [\"nat\", \"tan\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"strs\": [\"\"]}",
                        Expected = "[[\"\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"strs\": [\"a\"]}",
                        Expected = "[[\"a\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"strs\": [\"abc\", \"cba\", \"bac\", \"foo\"]}",
                        Expected = "[[\"abc\", \"bac\", \"cba\"], [\"foo\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"strs\": [\"a\", \"a\", \"a\"]}",
                        Expected = "[[\"a\", \"a\", \"a\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"strs\": [\"ab\", \"ba\", \"abc\"]}",
                        Expected = "[[\"ab\", \"ba\"], [\"abc\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"strs\": [\"\", \"\", \"\"]}",
                        Expected = "[[\"\", \"\", \"\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"strs\": [\"listen\", \"silent\", \"enlist\", \"google\", \"gogole\"]}",
                        Expected =
                            "[[\"enlist\", \"listen\", \"silent\"], [\"gogole\", \"google\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"strs\": [\"abc\", \"bca\", \"cab\", \"xyz\"]}",
                        Expected = "[[\"abc\", \"bca\", \"cab\"], [\"xyz\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"strs\": [\"x\"]}",
                        Expected = "[[\"x\"]]",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Hash Table" },
                    new() { Name = "String" },
                    new() { Name = "Sorting" },
                ],
            };

            var containsDuplicate = new Problem
            {
                ProblemName = "存在重複元素",
                Description = "給定整數陣列 nums，判斷是否存在任意值出現至少兩次。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "contains_duplicate",
                        ProblemParameters = [new() { Type = "List[int]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "hasDuplicate", ReturnType = "bool" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "ContainsDuplicate",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "hasDuplicate", ReturnType = "bool" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 1]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1, 1, 3, 3, 4, 3, 2, 4, 2]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": []}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 0]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-1, -1, 2]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, 5, 5, 5, 5]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4, 5, 1]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 1]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1, 1, 3, 3, 4, 3, 2, 4, 2]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": []}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 0]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-1, -1, 2]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, 5, 5, 5, 5]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4, 5, 1]}",
                        Expected = "true",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Hash Table" },
                    new() { Name = "Sorting" },
                ],
            };

            var containsDuplicateIi = new Problem
            {
                ProblemName = "存在重複元素 II",
                Description =
                    "給定整數陣列 nums 和整數 k，判斷是否存在 nums[i]==nums[j] 且 |i-j|<=k。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "contains_nearby_duplicate",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "nums" },
                            new() { Type = "int", ParameterName = "k" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "hasNearbyDuplicate", ReturnType = "bool" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "ContainsNearbyDuplicate",
                        ProblemParameters =
                        [
                            new() { Type = "int[]", ParameterName = "nums" },
                            new() { Type = "int", ParameterName = "k" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "hasNearbyDuplicate", ReturnType = "bool" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 1], \"k\": 3}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 0, 1, 1], \"k\": 1}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 1, 2, 3], \"k\": 2}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [], \"k\": 1}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1], \"k\": 0}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1], \"k\": 0}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1], \"k\": 1}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [99, 99], \"k\": 2}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4, 5], \"k\": 0}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 1, 2, 1], \"k\": 1}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 1], \"k\": 3}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 0, 1, 1], \"k\": 1}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 1, 2, 3], \"k\": 2}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [], \"k\": 1}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1], \"k\": 0}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1], \"k\": 0}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1], \"k\": 1}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [99, 99], \"k\": 2}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4, 5], \"k\": 0}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 1, 2, 1], \"k\": 1}",
                        Expected = "false",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Hash Table" },
                    new() { Name = "Sliding Window" },
                ],
            };

            var longestConsecutiveSequence = new Problem
            {
                ProblemName = "最長連續序列",
                Description = "給定未排序整數陣列 nums，找出數字連續的最長序列長度。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "longest_consecutive",
                        ProblemParameters = [new() { Type = "List[int]", ParameterName = "nums" }],
                        ProblemReturnTypes = [new() { ReturnName = "length", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "LongestConsecutive",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "nums" }],
                        ProblemReturnTypes = [new() { ReturnName = "length", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [100, 4, 200, 1, 3, 2]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 3, 7, 2, 5, 8, 4, 6, 0, 1]}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": []}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 0, 1]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [9, 1, 4, 7, 3, -1, 0, 5, 8, -1, 6]}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4, 5]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, 4, 3, 2, 1]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [10, 5, 12]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-1, -2, -3, 0, 1]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [100, 4, 200, 1, 3, 2]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 3, 7, 2, 5, 8, 4, 6, 0, 1]}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": []}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 0, 1]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [9, 1, 4, 7, 3, -1, 0, 5, 8, -1, 6]}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4, 5]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, 4, 3, 2, 1]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [10, 5, 12]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-1, -2, -3, 0, 1]}",
                        Expected = "5",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Hash Table" },
                    new() { Name = "Union Find" },
                ],
            };

            var summaryRanges = new Problem
            {
                ProblemName = "彙總區間",
                Description =
                    "給定無重複元素的排序整數陣列 nums，回傳覆蓋所有數字的最小有序區間列表。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "summary_ranges",
                        ProblemParameters = [new() { Type = "List[int]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "ranges", ReturnType = "List[str]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "SummaryRanges",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "ranges", ReturnType = "List<string>" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 1, 2, 4, 5, 7]}",
                        Expected = "[\"0->2\", \"4->5\", \"7\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 2, 3, 4, 6, 8, 9]}",
                        Expected = "[\"0\", \"2->4\", \"6\", \"8->9\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": []}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1]}",
                        Expected = "[\"1\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4, 5]}",
                        Expected = "[\"1->5\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-2, -1, 0, 2, 3]}",
                        Expected = "[\"-2->0\", \"2->3\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 3, 5, 7]}",
                        Expected = "[\"1\", \"3\", \"5\", \"7\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]}",
                        Expected = "[\"0->9\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5]}",
                        Expected = "[\"5\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-5, -4, -3, -1, 0, 1]}",
                        Expected = "[\"-5->-3\", \"-1->1\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 1, 2, 4, 5, 7]}",
                        Expected = "[\"0->2\", \"4->5\", \"7\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 2, 3, 4, 6, 8, 9]}",
                        Expected = "[\"0\", \"2->4\", \"6\", \"8->9\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": []}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1]}",
                        Expected = "[\"1\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4, 5]}",
                        Expected = "[\"1->5\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-2, -1, 0, 2, 3]}",
                        Expected = "[\"-2->0\", \"2->3\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 3, 5, 7]}",
                        Expected = "[\"1\", \"3\", \"5\", \"7\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]}",
                        Expected = "[\"0->9\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5]}",
                        Expected = "[\"5\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-5, -4, -3, -1, 0, 1]}",
                        Expected = "[\"-5->-3\", \"-1->1\"]",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }],
            };

            var mergeIntervals = new Problem
            {
                ProblemName = "合併區間",
                Description = "給定區間陣列 intervals，合併所有重疊區間，回傳不重疊的區間陣列。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "merge_intervals",
                        ProblemParameters =
                        [
                            new() { Type = "List[List[int]]", ParameterName = "intervals" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "merged", ReturnType = "List[List[int]]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "MergeIntervals",
                        ProblemParameters =
                        [
                            new() { Type = "int[][]", ParameterName = "intervals" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "merged", ReturnType = "int[][]" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"intervals\": [[1, 3], [2, 6], [8, 10], [15, 18]]}",
                        Expected = "[[1, 6], [8, 10], [15, 18]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"intervals\": [[1, 4], [4, 5]]}",
                        Expected = "[[1, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"intervals\": [[1, 4], [0, 4]]}",
                        Expected = "[[0, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"intervals\": [[1, 4], [2, 3]]}",
                        Expected = "[[1, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"intervals\": [[1, 4]]}",
                        Expected = "[[1, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"intervals\": [[1, 4], [5, 6]]}",
                        Expected = "[[1, 4], [5, 6]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"intervals\": [[1, 10], [2, 3], [4, 5], [6, 7]]}",
                        Expected = "[[1, 10]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"intervals\": [[2, 3], [4, 5], [6, 7], [8, 9], [1, 10]]}",
                        Expected = "[[1, 10]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"intervals\": [[1, 4], [0, 2], [3, 5]]}",
                        Expected = "[[0, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"intervals\": [[0, 0], [1, 1], [2, 2]]}",
                        Expected = "[[0, 0], [1, 1], [2, 2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"intervals\": [[1, 3], [2, 6], [8, 10], [15, 18]]}",
                        Expected = "[[1, 6], [8, 10], [15, 18]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"intervals\": [[1, 4], [4, 5]]}",
                        Expected = "[[1, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"intervals\": [[1, 4], [0, 4]]}",
                        Expected = "[[0, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"intervals\": [[1, 4], [2, 3]]}",
                        Expected = "[[1, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"intervals\": [[1, 4]]}",
                        Expected = "[[1, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"intervals\": [[1, 4], [5, 6]]}",
                        Expected = "[[1, 4], [5, 6]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"intervals\": [[1, 10], [2, 3], [4, 5], [6, 7]]}",
                        Expected = "[[1, 10]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"intervals\": [[2, 3], [4, 5], [6, 7], [8, 9], [1, 10]]}",
                        Expected = "[[1, 10]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"intervals\": [[1, 4], [0, 2], [3, 5]]}",
                        Expected = "[[0, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"intervals\": [[0, 0], [1, 1], [2, 2]]}",
                        Expected = "[[0, 0], [1, 1], [2, 2]]",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Sorting" }],
            };

            var insertInterval = new Problem
            {
                ProblemName = "插入區間",
                Description =
                    "給定不重疊且排序的區間陣列 intervals 與新區間 newInterval，插入並合併必要區間。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "insert_interval",
                        ProblemParameters =
                        [
                            new() { Type = "List[List[int]]", ParameterName = "intervals" },
                            new() { Type = "List[int]", ParameterName = "newInterval" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "result", ReturnType = "List[List[int]]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "InsertInterval",
                        ProblemParameters =
                        [
                            new() { Type = "int[][]", ParameterName = "intervals" },
                            new() { Type = "int[]", ParameterName = "newInterval" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "result", ReturnType = "int[][]" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"intervals\": [[1, 3], [6, 9]], \"newInterval\": [2, 5]}",
                        Expected = "[[1, 5], [6, 9]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"intervals\": [[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]], \"newInterval\": [4, 8]}",
                        Expected = "[[1, 2], [3, 10], [12, 16]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"intervals\": [], \"newInterval\": [5, 7]}",
                        Expected = "[[5, 7]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"intervals\": [[1, 5]], \"newInterval\": [2, 3]}",
                        Expected = "[[1, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"intervals\": [[1, 5]], \"newInterval\": [6, 8]}",
                        Expected = "[[1, 5], [6, 8]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"intervals\": [[1, 5]], \"newInterval\": [0, 0]}",
                        Expected = "[[0, 0], [1, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"intervals\": [[3, 5], [12, 15]], \"newInterval\": [6, 6]}",
                        Expected = "[[3, 5], [6, 6], [12, 15]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"intervals\": [[1, 2], [3, 4], [5, 6]], \"newInterval\": [0, 10]}",
                        Expected = "[[0, 10]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"intervals\": [[1, 3]], \"newInterval\": [4, 7]}",
                        Expected = "[[1, 3], [4, 7]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"intervals\": [[2, 3], [5, 7]], \"newInterval\": [0, 1]}",
                        Expected = "[[0, 1], [2, 3], [5, 7]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"intervals\": [[1, 3], [6, 9]], \"newInterval\": [2, 5]}",
                        Expected = "[[1, 5], [6, 9]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"intervals\": [[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]], \"newInterval\": [4, 8]}",
                        Expected = "[[1, 2], [3, 10], [12, 16]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"intervals\": [], \"newInterval\": [5, 7]}",
                        Expected = "[[5, 7]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"intervals\": [[1, 5]], \"newInterval\": [2, 3]}",
                        Expected = "[[1, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"intervals\": [[1, 5]], \"newInterval\": [6, 8]}",
                        Expected = "[[1, 5], [6, 8]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"intervals\": [[1, 5]], \"newInterval\": [0, 0]}",
                        Expected = "[[0, 0], [1, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"intervals\": [[3, 5], [12, 15]], \"newInterval\": [6, 6]}",
                        Expected = "[[3, 5], [6, 6], [12, 15]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"intervals\": [[1, 2], [3, 4], [5, 6]], \"newInterval\": [0, 10]}",
                        Expected = "[[0, 10]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"intervals\": [[1, 3]], \"newInterval\": [4, 7]}",
                        Expected = "[[1, 3], [4, 7]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"intervals\": [[2, 3], [5, 7]], \"newInterval\": [0, 1]}",
                        Expected = "[[0, 1], [2, 3], [5, 7]]",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }],
            };

            var minArrowsBurstBalloons = new Problem
            {
                ProblemName = "用最少數量的箭引爆氣球",
                Description =
                    "氣球以水平直徑區間陣列 points 表示，求引爆所有氣球所需的最少箭矢數量。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "find_min_arrow_shots",
                        ProblemParameters =
                        [
                            new() { Type = "List[List[int]]", ParameterName = "points" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "minArrows", ReturnType = "int" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "FindMinArrowShots",
                        ProblemParameters = [new() { Type = "int[][]", ParameterName = "points" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "minArrows", ReturnType = "int" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"points\": [[10, 16], [2, 8], [1, 6], [7, 12]]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"points\": [[1, 2], [3, 4], [5, 6], [7, 8]]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"points\": [[1, 2], [2, 3], [3, 4], [4, 5]]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"points\": [[1, 10]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"points\": []}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"points\": [[1, 2]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"points\": [[1, 5], [2, 3], [4, 6]]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"points\": [[3, 9], [7, 12], [3, 8], [6, 8], [9, 10], [2, 9], [0, 9], [3, 9], [0, 6], [2, 8]]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"points\": [[1, 4], [2, 3], [2, 4]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"points\": [[-2147483648, 2147483647]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"points\": [[10, 16], [2, 8], [1, 6], [7, 12]]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"points\": [[1, 2], [3, 4], [5, 6], [7, 8]]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"points\": [[1, 2], [2, 3], [3, 4], [4, 5]]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"points\": [[1, 10]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"points\": []}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"points\": [[1, 2]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"points\": [[1, 5], [2, 3], [4, 6]]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"points\": [[3, 9], [7, 12], [3, 8], [6, 8], [9, 10], [2, 9], [0, 9], [3, 9], [0, 6], [2, 8]]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"points\": [[1, 4], [2, 3], [2, 4]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"points\": [[-2147483648, 2147483647]]}",
                        Expected = "1",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Greedy" },
                    new() { Name = "Sorting" },
                ],
            };

            var validParentheses = new Problem
            {
                ProblemName = "有效的括號",
                Description = "給定僅含括號字元的字串 s，判斷括號是否以正確順序閉合。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "is_valid_parens",
                        ProblemParameters = [new() { Type = "str", ParameterName = "s" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "isValid", ReturnType = "bool" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "IsValid",
                        ProblemParameters = [new() { Type = "string", ParameterName = "s" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "isValid", ReturnType = "bool" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"()\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"()[]{}\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"(]\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"([)]\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"{[]}\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"(\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \")\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"((()))\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"(((\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"()\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"()[]{}\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"(]\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"([)]\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"{[]}\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"(\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \")\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"((()))\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"(((\"}",
                        Expected = "false",
                    },
                ],
                ProblemTags = [new() { Name = "String" }, new() { Name = "Stack" }],
            };

            var simplifyPath = new Problem
            {
                ProblemName = "簡化路徑",
                Description = "給定 Unix 風格絕對路徑字串 path，簡化為規範路徑。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "simplify_path",
                        ProblemParameters = [new() { Type = "str", ParameterName = "path" }],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "str" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "SimplifyPath",
                        ProblemParameters = [new() { Type = "string", ParameterName = "path" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "result", ReturnType = "string" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"path\": \"/home/\"}",
                        Expected = "\"/home\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"path\": \"/../\"}",
                        Expected = "\"/\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"path\": \"/home//foo/\"}",
                        Expected = "\"/home/foo\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"path\": \"/a/./b/../../c/\"}",
                        Expected = "\"/c\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"path\": \"/a/../../b/../c//.//\"}",
                        Expected = "\"/c\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"path\": \"/a//b////c/d//././/..\"}",
                        Expected = "\"/a/b/c\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"path\": \"/\"}",
                        Expected = "\"/\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"path\": \"/...\"}",
                        Expected = "\"/...\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"path\": \"/a/b/c\"}",
                        Expected = "\"/a/b/c\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"path\": \"/../../../\"}",
                        Expected = "\"/\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"path\": \"/home/\"}",
                        Expected = "\"/home\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"path\": \"/../\"}",
                        Expected = "\"/\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"path\": \"/home//foo/\"}",
                        Expected = "\"/home/foo\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"path\": \"/a/./b/../../c/\"}",
                        Expected = "\"/c\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"path\": \"/a/../../b/../c//.//\"}",
                        Expected = "\"/c\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"path\": \"/a//b////c/d//././/..\"}",
                        Expected = "\"/a/b/c\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"path\": \"/\"}",
                        Expected = "\"/\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"path\": \"/...\"}",
                        Expected = "\"/...\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"path\": \"/a/b/c\"}",
                        Expected = "\"/a/b/c\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"path\": \"/../../../\"}",
                        Expected = "\"/\"",
                    },
                ],
                ProblemTags = [new() { Name = "String" }, new() { Name = "Stack" }],
            };

            var evaluateReversePolishNotation = new Problem
            {
                ProblemName = "逆波蘭表達式求值",
                Description = "給定逆波蘭表示法的算術表達式 tokens，計算並回傳結果。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "eval_rpn",
                        ProblemParameters =
                        [
                            new() { Type = "List[str]", ParameterName = "tokens" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "EvalRPN",
                        ProblemParameters = [new() { Type = "string[]", ParameterName = "tokens" }],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"tokens\": [\"2\", \"1\", \"+\", \"3\", \"*\"]}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"tokens\": [\"4\", \"13\", \"5\", \"/\", \"+\"]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"tokens\": [\"10\", \"6\", \"9\", \"3\", \"+\", \"-11\", \"*\", \"/\", \"*\", \"17\", \"+\", \"5\", \"+\"]}",
                        Expected = "22",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"tokens\": [\"1\"]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"tokens\": [\"3\", \"4\", \"+\"]}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"tokens\": [\"18\", \"4\", \"/\"]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"tokens\": [\"-5\", \"4\", \"+\"]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"tokens\": [\"5\", \"-3\", \"-\"]}",
                        Expected = "8",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"tokens\": [\"2\", \"3\", \"*\", \"4\", \"+\"]}",
                        Expected = "10",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"tokens\": [\"15\", \"7\", \"1\", \"1\", \"+\", \"-\", \"/\", \"3\", \"*\", \"2\", \"1\", \"1\", \"+\", \"+\", \"-\"]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"tokens\": [\"2\", \"1\", \"+\", \"3\", \"*\"]}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"tokens\": [\"4\", \"13\", \"5\", \"/\", \"+\"]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"tokens\": [\"10\", \"6\", \"9\", \"3\", \"+\", \"-11\", \"*\", \"/\", \"*\", \"17\", \"+\", \"5\", \"+\"]}",
                        Expected = "22",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"tokens\": [\"1\"]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"tokens\": [\"3\", \"4\", \"+\"]}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"tokens\": [\"18\", \"4\", \"/\"]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"tokens\": [\"-5\", \"4\", \"+\"]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"tokens\": [\"5\", \"-3\", \"-\"]}",
                        Expected = "8",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"tokens\": [\"2\", \"3\", \"*\", \"4\", \"+\"]}",
                        Expected = "10",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"tokens\": [\"15\", \"7\", \"1\", \"1\", \"+\", \"-\", \"/\", \"3\", \"*\", \"2\", \"1\", \"1\", \"+\", \"+\", \"-\"]}",
                        Expected = "5",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Math" },
                    new() { Name = "Stack" },
                ],
            };

            var basicCalculator = new Problem
            {
                ProblemName = "基本計算器",
                Description = "給定包含非負整數、加減運算符與括號的字串表達式 s，計算並回傳結果。",
                Difficulty = ProblemDifficultyEnums.Hard,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "calculate",
                        ProblemParameters = [new() { Type = "str", ParameterName = "s" }],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "Calculate",
                        ProblemParameters = [new() { Type = "string", ParameterName = "s" }],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"1 + 1\"}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \" 2-1 + 2 \"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"(1+(4+5+2)-3)+(6+8)\"}",
                        Expected = "23",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"1-(     -2)\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"2-(5-6)\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"-(2+3)\"}",
                        Expected = "-5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"0\"}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"(1)\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"1-1-1\"}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"(7)-(0)+(4)\"}",
                        Expected = "11",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"1 + 1\"}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \" 2-1 + 2 \"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"(1+(4+5+2)-3)+(6+8)\"}",
                        Expected = "23",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"1-(     -2)\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"2-(5-6)\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"-(2+3)\"}",
                        Expected = "-5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"0\"}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"(1)\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"1-1-1\"}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"(7)-(0)+(4)\"}",
                        Expected = "11",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Math" },
                    new() { Name = "String" },
                    new() { Name = "Stack" },
                ],
            };

            var numberOfIslands = new Problem
            {
                ProblemName = "島嶼數量",
                Description = "給定由 '1' 和 '0' 組成的二維網格 grid，回傳島嶼的數量。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "num_islands",
                        ProblemParameters =
                        [
                            new() { Type = "List[List[str]]", ParameterName = "grid" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "count", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "NumIslands",
                        ProblemParameters = [new() { Type = "char[][]", ParameterName = "grid" }],
                        ProblemReturnTypes = [new() { ReturnName = "count", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"grid\": [[\"1\", \"1\", \"1\", \"1\", \"0\"], [\"1\", \"1\", \"0\", \"1\", \"0\"], [\"1\", \"1\", \"0\", \"0\", \"0\"], [\"0\", \"0\", \"0\", \"0\", \"0\"]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"grid\": [[\"1\", \"1\", \"0\", \"0\", \"0\"], [\"1\", \"1\", \"0\", \"0\", \"0\"], [\"0\", \"0\", \"1\", \"0\", \"0\"], [\"0\", \"0\", \"0\", \"1\", \"1\"]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"grid\": [[\"0\"]]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"grid\": [[\"1\"]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"grid\": [[\"1\", \"0\", \"1\", \"0\", \"1\"]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"grid\": [[\"0\", \"0\", \"0\"], [\"0\", \"0\", \"0\"]]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"grid\": [[\"1\", \"1\"], [\"1\", \"1\"]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"grid\": [[\"1\", \"0\"], [\"0\", \"1\"]]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"grid\": [[\"1\", \"1\", \"1\"], [\"0\", \"1\", \"0\"], [\"1\", \"1\", \"1\"]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"grid\": [[\"0\", \"1\", \"0\"], [\"1\", \"0\", \"1\"], [\"0\", \"1\", \"0\"]]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"grid\": [[\"1\", \"1\", \"1\", \"1\", \"0\"], [\"1\", \"1\", \"0\", \"1\", \"0\"], [\"1\", \"1\", \"0\", \"0\", \"0\"], [\"0\", \"0\", \"0\", \"0\", \"0\"]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"grid\": [[\"1\", \"1\", \"0\", \"0\", \"0\"], [\"1\", \"1\", \"0\", \"0\", \"0\"], [\"0\", \"0\", \"1\", \"0\", \"0\"], [\"0\", \"0\", \"0\", \"1\", \"1\"]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"grid\": [[\"0\"]]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"grid\": [[\"1\"]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"grid\": [[\"1\", \"0\", \"1\", \"0\", \"1\"]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"grid\": [[\"0\", \"0\", \"0\"], [\"0\", \"0\", \"0\"]]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"grid\": [[\"1\", \"1\"], [\"1\", \"1\"]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"grid\": [[\"1\", \"0\"], [\"0\", \"1\"]]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"grid\": [[\"1\", \"1\", \"1\"], [\"0\", \"1\", \"0\"], [\"1\", \"1\", \"1\"]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"grid\": [[\"0\", \"1\", \"0\"], [\"1\", \"0\", \"1\"], [\"0\", \"1\", \"0\"]]}",
                        Expected = "4",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Depth-First Search" },
                    new() { Name = "Breadth-First Search" },
                    new() { Name = "Union Find" },
                    new() { Name = "Matrix" },
                ],
            };

            var surroundedRegions = new Problem
            {
                ProblemName = "被圍繞的區域",
                Description =
                    "給定由 'X' 和 'O' 組成的矩陣 board，找出被 'X' 完全圍繞的 'O' 區域並翻轉為 'X'。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "solve_regions",
                        ProblemParameters =
                        [
                            new() { Type = "List[List[str]]", ParameterName = "board" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "board", ReturnType = "List[List[str]]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "Solve",
                        ProblemParameters = [new() { Type = "char[][]", ParameterName = "board" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "board", ReturnType = "char[][]" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"X\", \"X\", \"X\", \"X\"], [\"X\", \"O\", \"O\", \"X\"], [\"X\", \"X\", \"O\", \"X\"], [\"X\", \"O\", \"X\", \"X\"]]}",
                        Expected =
                            "[[\"X\", \"X\", \"X\", \"X\"], [\"X\", \"X\", \"X\", \"X\"], [\"X\", \"X\", \"X\", \"X\"], [\"X\", \"O\", \"X\", \"X\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[\"X\"]]}",
                        Expected = "[[\"X\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[\"O\"]]}",
                        Expected = "[[\"O\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[\"O\", \"O\"], [\"O\", \"O\"]]}",
                        Expected = "[[\"O\", \"O\"], [\"O\", \"O\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"X\", \"O\", \"X\"], [\"O\", \"X\", \"O\"], [\"X\", \"O\", \"X\"]]}",
                        Expected =
                            "[[\"X\", \"O\", \"X\"], [\"O\", \"X\", \"O\"], [\"X\", \"O\", \"X\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[\"O\", \"X\"], [\"X\", \"O\"]]}",
                        Expected = "[[\"O\", \"X\"], [\"X\", \"O\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"X\", \"X\", \"X\"], [\"X\", \"O\", \"X\"], [\"X\", \"X\", \"X\"]]}",
                        Expected =
                            "[[\"X\", \"X\", \"X\"], [\"X\", \"X\", \"X\"], [\"X\", \"X\", \"X\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"O\", \"O\", \"O\"], [\"O\", \"O\", \"O\"], [\"O\", \"O\", \"O\"]]}",
                        Expected =
                            "[[\"O\", \"O\", \"O\"], [\"O\", \"O\", \"O\"], [\"O\", \"O\", \"O\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[\"X\", \"O\", \"X\", \"O\", \"X\"]]}",
                        Expected = "[[\"X\", \"O\", \"X\", \"O\", \"X\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[\"O\"], [\"X\"], [\"O\"]]}",
                        Expected = "[[\"O\"], [\"X\"], [\"O\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"X\", \"X\", \"X\", \"X\"], [\"X\", \"O\", \"O\", \"X\"], [\"X\", \"X\", \"O\", \"X\"], [\"X\", \"O\", \"X\", \"X\"]]}",
                        Expected =
                            "[[\"X\", \"X\", \"X\", \"X\"], [\"X\", \"X\", \"X\", \"X\"], [\"X\", \"X\", \"X\", \"X\"], [\"X\", \"O\", \"X\", \"X\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[\"X\"]]}",
                        Expected = "[[\"X\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[\"O\"]]}",
                        Expected = "[[\"O\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[\"O\", \"O\"], [\"O\", \"O\"]]}",
                        Expected = "[[\"O\", \"O\"], [\"O\", \"O\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"X\", \"O\", \"X\"], [\"O\", \"X\", \"O\"], [\"X\", \"O\", \"X\"]]}",
                        Expected =
                            "[[\"X\", \"O\", \"X\"], [\"O\", \"X\", \"O\"], [\"X\", \"O\", \"X\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[\"O\", \"X\"], [\"X\", \"O\"]]}",
                        Expected = "[[\"O\", \"X\"], [\"X\", \"O\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"X\", \"X\", \"X\"], [\"X\", \"O\", \"X\"], [\"X\", \"X\", \"X\"]]}",
                        Expected =
                            "[[\"X\", \"X\", \"X\"], [\"X\", \"X\", \"X\"], [\"X\", \"X\", \"X\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"O\", \"O\", \"O\"], [\"O\", \"O\", \"O\"], [\"O\", \"O\", \"O\"]]}",
                        Expected =
                            "[[\"O\", \"O\", \"O\"], [\"O\", \"O\", \"O\"], [\"O\", \"O\", \"O\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[\"X\", \"O\", \"X\", \"O\", \"X\"]]}",
                        Expected = "[[\"X\", \"O\", \"X\", \"O\", \"X\"]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[\"O\"], [\"X\"], [\"O\"]]}",
                        Expected = "[[\"O\"], [\"X\"], [\"O\"]]",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Depth-First Search" },
                    new() { Name = "Breadth-First Search" },
                    new() { Name = "Union Find" },
                    new() { Name = "Matrix" },
                ],
            };

            var evaluateDivision = new Problem
            {
                ProblemName = "除法求值",
                Description =
                    "給定變數等式關係 equations 與對應值 values，計算每個查詢 queries 的結果；無法確定則回傳 -1.0。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "calc_equation",
                        ProblemParameters =
                        [
                            new() { Type = "List[List[str]]", ParameterName = "equations" },
                            new() { Type = "List[float]", ParameterName = "values" },
                            new() { Type = "List[List[str]]", ParameterName = "queries" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "results", ReturnType = "List[float]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "CalcEquation",
                        ProblemParameters =
                        [
                            new() { Type = "string[][]", ParameterName = "equations" },
                            new() { Type = "double[]", ParameterName = "values" },
                            new() { Type = "string[][]", ParameterName = "queries" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "results", ReturnType = "double[]" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"equations\": [[\"a\", \"b\"], [\"b\", \"c\"]], \"values\": [2.0, 3.0], \"queries\": [[\"a\", \"c\"], [\"b\", \"a\"], [\"a\", \"e\"], [\"a\", \"a\"], [\"x\", \"x\"]]}",
                        Expected = "[6.0, 0.5, -1.0, 1.0, -1.0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"equations\": [[\"a\", \"b\"], [\"b\", \"c\"], [\"bc\", \"cd\"]], \"values\": [1.5, 2.5, 5.0], \"queries\": [[\"a\", \"c\"], [\"c\", \"b\"], [\"bc\", \"cd\"], [\"cd\", \"bc\"]]}",
                        Expected = "[3.75, 0.4, 5.0, 0.2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"equations\": [[\"a\", \"b\"]], \"values\": [0.5], \"queries\": [[\"a\", \"b\"], [\"b\", \"a\"], [\"a\", \"c\"], [\"x\", \"y\"]]}",
                        Expected = "[0.5, 2.0, -1.0, -1.0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"equations\": [[\"x1\", \"x2\"], [\"x2\", \"x3\"], [\"x3\", \"x4\"], [\"x4\", \"x5\"]], \"values\": [3.0, 4.0, 5.0, 6.0], \"queries\": [[\"x1\", \"x5\"], [\"x5\", \"x2\"], [\"x2\", \"x4\"], [\"x1\", \"x1\"], [\"x6\", \"x6\"]]}",
                        Expected = "[360.0, 0.00833, 20.0, 1.0, -1.0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"equations\": [[\"a\", \"b\"], [\"c\", \"d\"]], \"values\": [2.0, 3.0], \"queries\": [[\"a\", \"c\"]]}",
                        Expected = "[-1.0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"equations\": [[\"a\", \"a\"]], \"values\": [1.0], \"queries\": [[\"a\", \"a\"]]}",
                        Expected = "[1.0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"equations\": [[\"a\", \"b\"], [\"b\", \"a\"]], \"values\": [2.0, 0.5], \"queries\": [[\"a\", \"b\"], [\"b\", \"a\"]]}",
                        Expected = "[2.0, 0.5]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"equations\": [[\"a\", \"b\"], [\"b\", \"c\"], [\"c\", \"d\"]], \"values\": [2.0, 2.0, 2.0], \"queries\": [[\"a\", \"d\"], [\"d\", \"a\"]]}",
                        Expected = "[8.0, 0.125]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"equations\": [[\"a\", \"b\"]], \"values\": [2.0], \"queries\": [[\"b\", \"a\"]]}",
                        Expected = "[0.5]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"equations\": [[\"a\", \"b\"], [\"b\", \"c\"]], \"values\": [1.0, 1.0], \"queries\": [[\"a\", \"c\"]]}",
                        Expected = "[1.0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"equations\": [[\"a\", \"b\"], [\"b\", \"c\"]], \"values\": [2.0, 3.0], \"queries\": [[\"a\", \"c\"], [\"b\", \"a\"], [\"a\", \"e\"], [\"a\", \"a\"], [\"x\", \"x\"]]}",
                        Expected = "[6.0, 0.5, -1.0, 1.0, -1.0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"equations\": [[\"a\", \"b\"], [\"b\", \"c\"], [\"bc\", \"cd\"]], \"values\": [1.5, 2.5, 5.0], \"queries\": [[\"a\", \"c\"], [\"c\", \"b\"], [\"bc\", \"cd\"], [\"cd\", \"bc\"]]}",
                        Expected = "[3.75, 0.4, 5.0, 0.2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"equations\": [[\"a\", \"b\"]], \"values\": [0.5], \"queries\": [[\"a\", \"b\"], [\"b\", \"a\"], [\"a\", \"c\"], [\"x\", \"y\"]]}",
                        Expected = "[0.5, 2.0, -1.0, -1.0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"equations\": [[\"x1\", \"x2\"], [\"x2\", \"x3\"], [\"x3\", \"x4\"], [\"x4\", \"x5\"]], \"values\": [3.0, 4.0, 5.0, 6.0], \"queries\": [[\"x1\", \"x5\"], [\"x5\", \"x2\"], [\"x2\", \"x4\"], [\"x1\", \"x1\"], [\"x6\", \"x6\"]]}",
                        Expected = "[360.0, 0.00833, 20.0, 1.0, -1.0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"equations\": [[\"a\", \"b\"], [\"c\", \"d\"]], \"values\": [2.0, 3.0], \"queries\": [[\"a\", \"c\"]]}",
                        Expected = "[-1.0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"equations\": [[\"a\", \"a\"]], \"values\": [1.0], \"queries\": [[\"a\", \"a\"]]}",
                        Expected = "[1.0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"equations\": [[\"a\", \"b\"], [\"b\", \"a\"]], \"values\": [2.0, 0.5], \"queries\": [[\"a\", \"b\"], [\"b\", \"a\"]]}",
                        Expected = "[2.0, 0.5]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"equations\": [[\"a\", \"b\"], [\"b\", \"c\"], [\"c\", \"d\"]], \"values\": [2.0, 2.0, 2.0], \"queries\": [[\"a\", \"d\"], [\"d\", \"a\"]]}",
                        Expected = "[8.0, 0.125]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"equations\": [[\"a\", \"b\"]], \"values\": [2.0], \"queries\": [[\"b\", \"a\"]]}",
                        Expected = "[0.5]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"equations\": [[\"a\", \"b\"], [\"b\", \"c\"]], \"values\": [1.0, 1.0], \"queries\": [[\"a\", \"c\"]]}",
                        Expected = "[1.0]",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Graph" },
                    new() { Name = "Union Find" },
                    new() { Name = "Shortest Path" },
                ],
            };

            var courseSchedule = new Problem
            {
                ProblemName = "課程表",
                Description =
                    "給定課程數 numCourses 與先修關係 prerequisites，判斷是否能完成所有課程。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "can_finish",
                        ProblemParameters =
                        [
                            new() { Type = "int", ParameterName = "numCourses" },
                            new() { Type = "List[List[int]]", ParameterName = "prerequisites" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "canFinish", ReturnType = "bool" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "CanFinish",
                        ProblemParameters =
                        [
                            new() { Type = "int", ParameterName = "numCourses" },
                            new() { Type = "int[][]", ParameterName = "prerequisites" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "canFinish", ReturnType = "bool" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numCourses\": 2, \"prerequisites\": [[1, 0]]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numCourses\": 2, \"prerequisites\": [[1, 0], [0, 1]]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numCourses\": 1, \"prerequisites\": []}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numCourses\": 3, \"prerequisites\": [[1, 0], [2, 1]]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numCourses\": 3, \"prerequisites\": [[0, 1], [1, 2], [2, 0]]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"numCourses\": 4, \"prerequisites\": [[1, 0], [2, 0], [3, 1], [3, 2]]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"numCourses\": 5, \"prerequisites\": [[0, 1], [0, 2], [1, 3], [1, 4], [3, 4]]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numCourses\": 2, \"prerequisites\": []}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numCourses\": 3, \"prerequisites\": [[0, 1], [0, 2]]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"numCourses\": 4, \"prerequisites\": [[1, 0], [2, 1], [3, 2], [1, 3]]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numCourses\": 2, \"prerequisites\": [[1, 0]]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numCourses\": 2, \"prerequisites\": [[1, 0], [0, 1]]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numCourses\": 1, \"prerequisites\": []}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numCourses\": 3, \"prerequisites\": [[1, 0], [2, 1]]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numCourses\": 3, \"prerequisites\": [[0, 1], [1, 2], [2, 0]]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"numCourses\": 4, \"prerequisites\": [[1, 0], [2, 0], [3, 1], [3, 2]]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"numCourses\": 5, \"prerequisites\": [[0, 1], [0, 2], [1, 3], [1, 4], [3, 4]]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numCourses\": 2, \"prerequisites\": []}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numCourses\": 3, \"prerequisites\": [[0, 1], [0, 2]]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"numCourses\": 4, \"prerequisites\": [[1, 0], [2, 1], [3, 2], [1, 3]]}",
                        Expected = "false",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Depth-First Search" },
                    new() { Name = "Breadth-First Search" },
                    new() { Name = "Graph" },
                    new() { Name = "Topological Sort" },
                ],
            };

            var courseScheduleIi = new Problem
            {
                ProblemName = "課程表 II",
                Description =
                    "給定課程數 numCourses 與先修關係 prerequisites，回傳完成所有課程的有效學習順序；不可能則回傳空陣列。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "find_order",
                        ProblemParameters =
                        [
                            new() { Type = "int", ParameterName = "numCourses" },
                            new() { Type = "List[List[int]]", ParameterName = "prerequisites" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "order", ReturnType = "List[int]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "FindOrder",
                        ProblemParameters =
                        [
                            new() { Type = "int", ParameterName = "numCourses" },
                            new() { Type = "int[][]", ParameterName = "prerequisites" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "order", ReturnType = "int[]" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numCourses\": 2, \"prerequisites\": [[1, 0]]}",
                        Expected = "[0, 1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"numCourses\": 4, \"prerequisites\": [[1, 0], [2, 0], [3, 1], [3, 2]]}",
                        Expected = "[0, 1, 2, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numCourses\": 1, \"prerequisites\": []}",
                        Expected = "[0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numCourses\": 2, \"prerequisites\": [[1, 0], [0, 1]]}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numCourses\": 3, \"prerequisites\": [[0, 1], [1, 2], [2, 0]]}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numCourses\": 3, \"prerequisites\": []}",
                        Expected = "[0, 1, 2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"numCourses\": 5, \"prerequisites\": [[1, 0], [2, 0], [3, 1], [4, 2]]}",
                        Expected = "[0, 1, 2, 3, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numCourses\": 2, \"prerequisites\": []}",
                        Expected = "[0, 1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"numCourses\": 6, \"prerequisites\": [[1, 0], [2, 1], [3, 2], [4, 3], [5, 4]]}",
                        Expected = "[0, 1, 2, 3, 4, 5]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"numCourses\": 3, \"prerequisites\": [[0, 1], [0, 2]]}",
                        Expected = "[1, 2, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numCourses\": 2, \"prerequisites\": [[1, 0]]}",
                        Expected = "[0, 1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"numCourses\": 4, \"prerequisites\": [[1, 0], [2, 0], [3, 1], [3, 2]]}",
                        Expected = "[0, 1, 2, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numCourses\": 1, \"prerequisites\": []}",
                        Expected = "[0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numCourses\": 2, \"prerequisites\": [[1, 0], [0, 1]]}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numCourses\": 3, \"prerequisites\": [[0, 1], [1, 2], [2, 0]]}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numCourses\": 3, \"prerequisites\": []}",
                        Expected = "[0, 1, 2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"numCourses\": 5, \"prerequisites\": [[1, 0], [2, 0], [3, 1], [4, 2]]}",
                        Expected = "[0, 1, 2, 3, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numCourses\": 2, \"prerequisites\": []}",
                        Expected = "[0, 1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"numCourses\": 6, \"prerequisites\": [[1, 0], [2, 1], [3, 2], [4, 3], [5, 4]]}",
                        Expected = "[0, 1, 2, 3, 4, 5]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"numCourses\": 3, \"prerequisites\": [[0, 1], [0, 2]]}",
                        Expected = "[1, 2, 0]",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Depth-First Search" },
                    new() { Name = "Breadth-First Search" },
                    new() { Name = "Graph" },
                    new() { Name = "Topological Sort" },
                ],
            };

            var snakesAndLadders = new Problem
            {
                ProblemName = "蛇梯棋",
                Description =
                    "給定 n x n 蛇梯棋盤 board，從格子 1 出發每次最多移動 6 格，回傳到達終點所需最少移動次數；不可能則回傳 -1。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "snakes_and_ladders",
                        ProblemParameters =
                        [
                            new() { Type = "List[List[int]]", ParameterName = "board" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "minMoves", ReturnType = "int" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "SnakesAndLadders",
                        ProblemParameters = [new() { Type = "int[][]", ParameterName = "board" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "minMoves", ReturnType = "int" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[-1, -1, -1, -1, -1, -1], [-1, -1, -1, -1, -1, -1], [-1, -1, -1, -1, -1, -1], [-1, 35, -1, -1, 13, -1], [-1, -1, -1, -1, -1, -1], [-1, 15, -1, -1, -1, -1]]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[-1, -1], [-1, 3]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[-1, -1, -1], [-1, 9, 8], [-1, 8, 9]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[-1, -1, -1, -1, -1, -1], [-1, -1, -1, -1, -1, -1], [-1, -1, -1, -1, -1, -1], [-1, -1, -1, -1, -1, -1], [-1, -1, -1, -1, -1, -1], [-1, -1, -1, -1, -1, -1]]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[-1, 4], [-1, -1]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[-1, -1, -1], [-1, -1, -1], [-1, -1, -1]]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[-1, -1, -1, -1], [-1, -1, -1, -1], [-1, -1, -1, -1], [-1, -1, -1, -1]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[-1, -1], [2, -1]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[-1, -1, -1, -1], [-1, 2, -1, -1], [-1, -1, -1, -1], [-1, -1, -1, 15]]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[-1, -1], [-1, -1]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[-1, -1, -1, -1, -1, -1], [-1, -1, -1, -1, -1, -1], [-1, -1, -1, -1, -1, -1], [-1, 35, -1, -1, 13, -1], [-1, -1, -1, -1, -1, -1], [-1, 15, -1, -1, -1, -1]]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[-1, -1], [-1, 3]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[-1, -1, -1], [-1, 9, 8], [-1, 8, 9]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[-1, -1, -1, -1, -1, -1], [-1, -1, -1, -1, -1, -1], [-1, -1, -1, -1, -1, -1], [-1, -1, -1, -1, -1, -1], [-1, -1, -1, -1, -1, -1], [-1, -1, -1, -1, -1, -1]]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[-1, 4], [-1, -1]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[-1, -1, -1], [-1, -1, -1], [-1, -1, -1]]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[-1, -1, -1, -1], [-1, -1, -1, -1], [-1, -1, -1, -1], [-1, -1, -1, -1]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[-1, -1], [2, -1]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[-1, -1, -1, -1], [-1, 2, -1, -1], [-1, -1, -1, -1], [-1, -1, -1, 15]]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[-1, -1], [-1, -1]]}",
                        Expected = "1",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Breadth-First Search" },
                    new() { Name = "Matrix" },
                ],
            };

            var minimumGeneticMutation = new Problem
            {
                ProblemName = "最小基因變化",
                Description =
                    "給定起始基因 startGene、目標基因 endGene 與基因庫 bank，求達到目標所需最少變化次數；不可能則回傳 -1。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "min_mutation",
                        ProblemParameters =
                        [
                            new() { Type = "str", ParameterName = "startGene" },
                            new() { Type = "str", ParameterName = "endGene" },
                            new() { Type = "List[str]", ParameterName = "bank" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "minMutations", ReturnType = "int" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "MinMutation",
                        ProblemParameters =
                        [
                            new() { Type = "string", ParameterName = "startGene" },
                            new() { Type = "string", ParameterName = "endGene" },
                            new() { Type = "string[]", ParameterName = "bank" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "minMutations", ReturnType = "int" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"startGene\": \"AACCGGTT\", \"endGene\": \"AACCGGTA\", \"bank\": [\"AACCGGTA\"]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"startGene\": \"AACCGGTT\", \"endGene\": \"AAACGGTA\", \"bank\": [\"AACCGGTA\", \"AACCGCTA\", \"AAACGGTA\"]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"startGene\": \"AAAAACCC\", \"endGene\": \"AACCCCCC\", \"bank\": [\"AAAACCCC\", \"AAACCCCC\", \"AACCCCCC\"]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"startGene\": \"AAAAAAAA\", \"endGene\": \"AAAAAAAA\", \"bank\": [\"AAAAAAAA\"]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"startGene\": \"AAAAAAAA\", \"endGene\": \"CCCCCCCC\", \"bank\": [\"AAAAAAAA\"]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"startGene\": \"AACCGGTT\", \"endGene\": \"AACCGGTT\", \"bank\": []}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"startGene\": \"ACGT\", \"endGene\": \"ACGT\", \"bank\": [\"AAAA\"]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"startGene\": \"AAAAAAAA\", \"endGene\": \"AAAAAAAT\", \"bank\": [\"AAAAAAAT\"]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"startGene\": \"AAAAAAAA\", \"endGene\": \"AAAAAACC\", \"bank\": [\"AAAAAAAC\", \"AAAAAACC\"]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"startGene\": \"AAAAAAAA\", \"endGene\": \"AAAAACCC\", \"bank\": [\"AAAAAAAC\", \"AAAAAACC\", \"AAAAACCC\", \"AAAACCCC\"]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"startGene\": \"AACCGGTT\", \"endGene\": \"AACCGGTA\", \"bank\": [\"AACCGGTA\"]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"startGene\": \"AACCGGTT\", \"endGene\": \"AAACGGTA\", \"bank\": [\"AACCGGTA\", \"AACCGCTA\", \"AAACGGTA\"]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"startGene\": \"AAAAACCC\", \"endGene\": \"AACCCCCC\", \"bank\": [\"AAAACCCC\", \"AAACCCCC\", \"AACCCCCC\"]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"startGene\": \"AAAAAAAA\", \"endGene\": \"AAAAAAAA\", \"bank\": [\"AAAAAAAA\"]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"startGene\": \"AAAAAAAA\", \"endGene\": \"CCCCCCCC\", \"bank\": [\"AAAAAAAA\"]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"startGene\": \"AACCGGTT\", \"endGene\": \"AACCGGTT\", \"bank\": []}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"startGene\": \"ACGT\", \"endGene\": \"ACGT\", \"bank\": [\"AAAA\"]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"startGene\": \"AAAAAAAA\", \"endGene\": \"AAAAAAAT\", \"bank\": [\"AAAAAAAT\"]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"startGene\": \"AAAAAAAA\", \"endGene\": \"AAAAAACC\", \"bank\": [\"AAAAAAAC\", \"AAAAAACC\"]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"startGene\": \"AAAAAAAA\", \"endGene\": \"AAAAACCC\", \"bank\": [\"AAAAAAAC\", \"AAAAAACC\", \"AAAAACCC\", \"AAAACCCC\"]}",
                        Expected = "3",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Hash Table" },
                    new() { Name = "String" },
                    new() { Name = "Breadth-First Search" },
                ],
            };

            var wordLadder = new Problem
            {
                ProblemName = "單字接龍",
                Description =
                    "給定起始單字 beginWord、目標單字 endWord 與單字列表 wordList，求最短轉換序列長度；不存在則回傳 0。",
                Difficulty = ProblemDifficultyEnums.Hard,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "ladder_length",
                        ProblemParameters =
                        [
                            new() { Type = "str", ParameterName = "beginWord" },
                            new() { Type = "str", ParameterName = "endWord" },
                            new() { Type = "List[str]", ParameterName = "wordList" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "length", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "LadderLength",
                        ProblemParameters =
                        [
                            new() { Type = "string", ParameterName = "beginWord" },
                            new() { Type = "string", ParameterName = "endWord" },
                            new() { Type = "string[]", ParameterName = "wordList" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "length", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"beginWord\": \"hit\", \"endWord\": \"cog\", \"wordList\": [\"hot\", \"dot\", \"dog\", \"lot\", \"log\", \"cog\"]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"beginWord\": \"hit\", \"endWord\": \"cog\", \"wordList\": [\"hot\", \"dot\", \"dog\", \"lot\", \"log\"]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"beginWord\": \"a\", \"endWord\": \"c\", \"wordList\": [\"a\", \"b\", \"c\"]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"beginWord\": \"hot\", \"endWord\": \"dog\", \"wordList\": [\"hot\", \"dog\"]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"beginWord\": \"hot\", \"endWord\": \"dog\", \"wordList\": [\"hot\", \"dot\", \"dog\"]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"beginWord\": \"cat\", \"endWord\": \"cat\", \"wordList\": [\"cat\"]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"beginWord\": \"hot\", \"endWord\": \"hit\", \"wordList\": [\"hit\"]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"beginWord\": \"hot\", \"endWord\": \"hot\", \"wordList\": [\"hot\"]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"beginWord\": \"game\", \"endWord\": \"thee\", \"wordList\": [\"frye\", \"drew\", \"daze\", \"earl\", \"harp\", \"tace\", \"boon\", \"base\", \"soak\", \"scow\", \"wane\", \"sown\", \"cods\", \"tobe\", \"tots\", \"tutu\", \"tods\", \"poke\", \"tile\", \"mast\", \"mist\", \"kant\", \"gnaw\", \"stay\", \"gnat\", \"tree\", \"race\", \"care\", \"made\", \"mace\", \"tape\", \"gave\", \"mode\", \"name\", \"cove\", \"take\", \"cane\", \"mine\", \"gain\", \"mint\"]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"beginWord\": \"leet\", \"endWord\": \"code\", \"wordList\": [\"lest\", \"leet\", \"lose\", \"code\", \"lode\", \"robe\", \"lost\"]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"beginWord\": \"hit\", \"endWord\": \"cog\", \"wordList\": [\"hot\", \"dot\", \"dog\", \"lot\", \"log\", \"cog\"]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"beginWord\": \"hit\", \"endWord\": \"cog\", \"wordList\": [\"hot\", \"dot\", \"dog\", \"lot\", \"log\"]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"beginWord\": \"a\", \"endWord\": \"c\", \"wordList\": [\"a\", \"b\", \"c\"]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"beginWord\": \"hot\", \"endWord\": \"dog\", \"wordList\": [\"hot\", \"dog\"]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"beginWord\": \"hot\", \"endWord\": \"dog\", \"wordList\": [\"hot\", \"dot\", \"dog\"]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"beginWord\": \"cat\", \"endWord\": \"cat\", \"wordList\": [\"cat\"]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"beginWord\": \"hot\", \"endWord\": \"hit\", \"wordList\": [\"hit\"]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"beginWord\": \"hot\", \"endWord\": \"hot\", \"wordList\": [\"hot\"]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"beginWord\": \"game\", \"endWord\": \"thee\", \"wordList\": [\"frye\", \"drew\", \"daze\", \"earl\", \"harp\", \"tace\", \"boon\", \"base\", \"soak\", \"scow\", \"wane\", \"sown\", \"cods\", \"tobe\", \"tots\", \"tutu\", \"tods\", \"poke\", \"tile\", \"mast\", \"mist\", \"kant\", \"gnaw\", \"stay\", \"gnat\", \"tree\", \"race\", \"care\", \"made\", \"mace\", \"tape\", \"gave\", \"mode\", \"name\", \"cove\", \"take\", \"cane\", \"mine\", \"gain\", \"mint\"]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"beginWord\": \"leet\", \"endWord\": \"code\", \"wordList\": [\"lest\", \"leet\", \"lose\", \"code\", \"lode\", \"robe\", \"lost\"]}",
                        Expected = "6",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Hash Table" },
                    new() { Name = "String" },
                    new() { Name = "Breadth-First Search" },
                ],
            };

            var wordSearchIi = new Problem
            {
                ProblemName = "單字搜尋 II",
                Description =
                    "給定 m x n 字元網格 board 與單字列表 words，找出網格中可連接構成的所有單字。",
                Difficulty = ProblemDifficultyEnums.Hard,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "find_words",
                        ProblemParameters =
                        [
                            new() { Type = "List[List[str]]", ParameterName = "board" },
                            new() { Type = "List[str]", ParameterName = "words" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "found", ReturnType = "List[str]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "FindWords",
                        ProblemParameters =
                        [
                            new() { Type = "char[][]", ParameterName = "board" },
                            new() { Type = "string[]", ParameterName = "words" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "found", ReturnType = "List<string>" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"o\", \"a\", \"a\", \"n\"], [\"e\", \"t\", \"a\", \"e\"], [\"i\", \"h\", \"k\", \"r\"], [\"i\", \"f\", \"l\", \"v\"]], \"words\": [\"oath\", \"pea\", \"eat\", \"rain\"]}",
                        Expected = "[\"eat\", \"oath\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"a\", \"b\"], [\"c\", \"d\"]], \"words\": [\"abcb\"]}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[\"a\"]], \"words\": [\"a\"]}",
                        Expected = "[\"a\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[\"a\"]], \"words\": [\"b\"]}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"a\", \"b\"], [\"a\", \"a\"]], \"words\": [\"aaa\", \"aab\"]}",
                        Expected = "[\"aaa\", \"aab\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"b\", \"a\", \"b\"], [\"b\", \"a\", \"b\"], [\"b\", \"a\", \"b\"]], \"words\": [\"baa\", \"bba\"]}",
                        Expected = "[\"baa\", \"bba\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"o\", \"a\"], [\"b\", \"b\"]], \"words\": [\"oa\", \"oaa\"]}",
                        Expected = "[\"oa\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"a\", \"b\", \"c\"], [\"a\", \"e\", \"d\"], [\"a\", \"f\", \"g\"]], \"words\": [\"abcdefg\", \"gfedcbaaa\", \"eaabcdgfa\", \"befa\", \"dgc\", \"ade\"]}",
                        Expected = "[\"abcdefg\", \"befa\", \"eaabcdgfa\", \"gfedcbaaa\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[\"a\", \"a\"]], \"words\": [\"aa\"]}",
                        Expected = "[\"aa\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"c\", \"a\", \"a\"], [\"a\", \"a\", \"a\"], [\"b\", \"c\", \"d\"]], \"words\": [\"aaa\", \"aab\", \"baa\", \"bcd\", \"abcd\", \"ab\"]}",
                        Expected = "[\"aaa\", \"aab\", \"ab\", \"abcd\", \"baa\", \"bcd\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"o\", \"a\", \"a\", \"n\"], [\"e\", \"t\", \"a\", \"e\"], [\"i\", \"h\", \"k\", \"r\"], [\"i\", \"f\", \"l\", \"v\"]], \"words\": [\"oath\", \"pea\", \"eat\", \"rain\"]}",
                        Expected = "[\"eat\", \"oath\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"a\", \"b\"], [\"c\", \"d\"]], \"words\": [\"abcb\"]}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[\"a\"]], \"words\": [\"a\"]}",
                        Expected = "[\"a\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[\"a\"]], \"words\": [\"b\"]}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"a\", \"b\"], [\"a\", \"a\"]], \"words\": [\"aaa\", \"aab\"]}",
                        Expected = "[\"aaa\", \"aab\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"b\", \"a\", \"b\"], [\"b\", \"a\", \"b\"], [\"b\", \"a\", \"b\"]], \"words\": [\"baa\", \"bba\"]}",
                        Expected = "[\"baa\", \"bba\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"o\", \"a\"], [\"b\", \"b\"]], \"words\": [\"oa\", \"oaa\"]}",
                        Expected = "[\"oa\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"a\", \"b\", \"c\"], [\"a\", \"e\", \"d\"], [\"a\", \"f\", \"g\"]], \"words\": [\"abcdefg\", \"gfedcbaaa\", \"eaabcdgfa\", \"befa\", \"dgc\", \"ade\"]}",
                        Expected = "[\"abcdefg\", \"befa\", \"eaabcdgfa\", \"gfedcbaaa\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[\"a\", \"a\"]], \"words\": [\"aa\"]}",
                        Expected = "[\"aa\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"c\", \"a\", \"a\"], [\"a\", \"a\", \"a\"], [\"b\", \"c\", \"d\"]], \"words\": [\"aaa\", \"aab\", \"baa\", \"bcd\", \"abcd\", \"ab\"]}",
                        Expected = "[\"aaa\", \"aab\", \"ab\", \"abcd\", \"baa\", \"bcd\"]",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "String" },
                    new() { Name = "Backtracking" },
                    new() { Name = "Trie" },
                    new() { Name = "Matrix" },
                ],
            };

            var letterCombinationsPhone = new Problem
            {
                ProblemName = "電話號碼的字母組合",
                Description = "給定只含數字 2-9 的字串 digits，回傳該數字能表示的所有字母組合。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "letter_combinations",
                        ProblemParameters = [new() { Type = "str", ParameterName = "digits" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "combinations", ReturnType = "List[str]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "LetterCombinations",
                        ProblemParameters = [new() { Type = "string", ParameterName = "digits" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "combinations", ReturnType = "List<string>" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"digits\": \"23\"}",
                        Expected =
                            "[\"ad\", \"ae\", \"af\", \"bd\", \"be\", \"bf\", \"cd\", \"ce\", \"cf\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"digits\": \"2\"}",
                        Expected = "[\"a\", \"b\", \"c\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"digits\": \"\"}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"digits\": \"9\"}",
                        Expected = "[\"w\", \"x\", \"y\", \"z\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"digits\": \"79\"}",
                        Expected =
                            "[\"pw\", \"px\", \"py\", \"pz\", \"qw\", \"qx\", \"qy\", \"qz\", \"rw\", \"rx\", \"ry\", \"rz\", \"sw\", \"sx\", \"sy\", \"sz\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"digits\": \"234\"}",
                        Expected =
                            "[\"adg\", \"adh\", \"adi\", \"aeg\", \"aeh\", \"aei\", \"afg\", \"afh\", \"afi\", \"bdg\", \"bdh\", \"bdi\", \"beg\", \"beh\", \"bei\", \"bfg\", \"bfh\", \"bfi\", \"cdg\", \"cdh\", \"cdi\", \"ceg\", \"ceh\", \"cei\", \"cfg\", \"cfh\", \"cfi\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"digits\": \"56\"}",
                        Expected =
                            "[\"jm\", \"jn\", \"jo\", \"km\", \"kn\", \"ko\", \"lm\", \"ln\", \"lo\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"digits\": \"8\"}",
                        Expected = "[\"t\", \"u\", \"v\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"digits\": \"22\"}",
                        Expected =
                            "[\"aa\", \"ab\", \"ac\", \"ba\", \"bb\", \"bc\", \"ca\", \"cb\", \"cc\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"digits\": \"99\"}",
                        Expected =
                            "[\"ww\", \"wx\", \"wy\", \"wz\", \"xw\", \"xx\", \"xy\", \"xz\", \"yw\", \"yx\", \"yy\", \"yz\", \"zw\", \"zx\", \"zy\", \"zz\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"digits\": \"23\"}",
                        Expected =
                            "[\"ad\", \"ae\", \"af\", \"bd\", \"be\", \"bf\", \"cd\", \"ce\", \"cf\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"digits\": \"2\"}",
                        Expected = "[\"a\", \"b\", \"c\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"digits\": \"\"}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"digits\": \"9\"}",
                        Expected = "[\"w\", \"x\", \"y\", \"z\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"digits\": \"79\"}",
                        Expected =
                            "[\"pw\", \"px\", \"py\", \"pz\", \"qw\", \"qx\", \"qy\", \"qz\", \"rw\", \"rx\", \"ry\", \"rz\", \"sw\", \"sx\", \"sy\", \"sz\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"digits\": \"234\"}",
                        Expected =
                            "[\"adg\", \"adh\", \"adi\", \"aeg\", \"aeh\", \"aei\", \"afg\", \"afh\", \"afi\", \"bdg\", \"bdh\", \"bdi\", \"beg\", \"beh\", \"bei\", \"bfg\", \"bfh\", \"bfi\", \"cdg\", \"cdh\", \"cdi\", \"ceg\", \"ceh\", \"cei\", \"cfg\", \"cfh\", \"cfi\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"digits\": \"56\"}",
                        Expected =
                            "[\"jm\", \"jn\", \"jo\", \"km\", \"kn\", \"ko\", \"lm\", \"ln\", \"lo\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"digits\": \"8\"}",
                        Expected = "[\"t\", \"u\", \"v\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"digits\": \"22\"}",
                        Expected =
                            "[\"aa\", \"ab\", \"ac\", \"ba\", \"bb\", \"bc\", \"ca\", \"cb\", \"cc\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"digits\": \"99\"}",
                        Expected =
                            "[\"ww\", \"wx\", \"wy\", \"wz\", \"xw\", \"xx\", \"xy\", \"xz\", \"yw\", \"yx\", \"yy\", \"yz\", \"zw\", \"zx\", \"zy\", \"zz\"]",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Hash Table" },
                    new() { Name = "String" },
                    new() { Name = "Backtracking" },
                ],
            };

            var combinations = new Problem
            {
                ProblemName = "組合",
                Description = "給定整數 n 和 k，回傳範圍 [1, n] 中所有 k 個數的組合。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "combine",
                        ProblemParameters =
                        [
                            new() { Type = "int", ParameterName = "n" },
                            new() { Type = "int", ParameterName = "k" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "combinations", ReturnType = "List[List[int]]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "Combine",
                        ProblemParameters =
                        [
                            new() { Type = "int", ParameterName = "n" },
                            new() { Type = "int", ParameterName = "k" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "combinations", ReturnType = "List<List<int>>" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 4, \"k\": 2}",
                        Expected = "[[1, 2], [1, 3], [1, 4], [2, 3], [2, 4], [3, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 1, \"k\": 1}",
                        Expected = "[[1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 5, \"k\": 1}",
                        Expected = "[[1], [2], [3], [4], [5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 4, \"k\": 4}",
                        Expected = "[[1, 2, 3, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 3, \"k\": 2}",
                        Expected = "[[1, 2], [1, 3], [2, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 5, \"k\": 3}",
                        Expected =
                            "[[1, 2, 3], [1, 2, 4], [1, 2, 5], [1, 3, 4], [1, 3, 5], [1, 4, 5], [2, 3, 4], [2, 3, 5], [2, 4, 5], [3, 4, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 2, \"k\": 2}",
                        Expected = "[[1, 2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 6, \"k\": 1}",
                        Expected = "[[1], [2], [3], [4], [5], [6]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 4, \"k\": 1}",
                        Expected = "[[1], [2], [3], [4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 5, \"k\": 5}",
                        Expected = "[[1, 2, 3, 4, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 4, \"k\": 2}",
                        Expected = "[[1, 2], [1, 3], [1, 4], [2, 3], [2, 4], [3, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 1, \"k\": 1}",
                        Expected = "[[1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 5, \"k\": 1}",
                        Expected = "[[1], [2], [3], [4], [5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 4, \"k\": 4}",
                        Expected = "[[1, 2, 3, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 3, \"k\": 2}",
                        Expected = "[[1, 2], [1, 3], [2, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 5, \"k\": 3}",
                        Expected =
                            "[[1, 2, 3], [1, 2, 4], [1, 2, 5], [1, 3, 4], [1, 3, 5], [1, 4, 5], [2, 3, 4], [2, 3, 5], [2, 4, 5], [3, 4, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 2, \"k\": 2}",
                        Expected = "[[1, 2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 6, \"k\": 1}",
                        Expected = "[[1], [2], [3], [4], [5], [6]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 4, \"k\": 1}",
                        Expected = "[[1], [2], [3], [4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 5, \"k\": 5}",
                        Expected = "[[1, 2, 3, 4, 5]]",
                    },
                ],
                ProblemTags = [new() { Name = "Backtracking" }],
            };

            var permutations = new Problem
            {
                ProblemName = "全排列",
                Description = "給定不含重複數字的整數陣列 nums，回傳其所有可能的全排列。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "permute",
                        ProblemParameters = [new() { Type = "List[int]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "permutations", ReturnType = "List[List[int]]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "Permute",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "permutations", ReturnType = "List<List<int>>" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3]}",
                        Expected =
                            "[[1, 2, 3], [1, 3, 2], [2, 1, 3], [2, 3, 1], [3, 1, 2], [3, 2, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 1]}",
                        Expected = "[[0, 1], [1, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1]}",
                        Expected = "[[1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2]}",
                        Expected = "[[1, 2], [2, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4]}",
                        Expected =
                            "[[1, 2, 3, 4], [1, 2, 4, 3], [1, 3, 2, 4], [1, 3, 4, 2], [1, 4, 2, 3], [1, 4, 3, 2], [2, 1, 3, 4], [2, 1, 4, 3], [2, 3, 1, 4], [2, 3, 4, 1], [2, 4, 1, 3], [2, 4, 3, 1], [3, 1, 2, 4], [3, 1, 4, 2], [3, 2, 1, 4], [3, 2, 4, 1], [3, 4, 1, 2], [3, 4, 2, 1], [4, 1, 2, 3], [4, 1, 3, 2], [4, 2, 1, 3], [4, 2, 3, 1], [4, 3, 1, 2], [4, 3, 2, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-1, 0, 1]}",
                        Expected =
                            "[[-1, 0, 1], [-1, 1, 0], [0, -1, 1], [0, 1, -1], [1, -1, 0], [1, 0, -1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, 6]}",
                        Expected = "[[5, 6], [6, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 1]}",
                        Expected = "[[1, 2], [2, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [3, 2, 1]}",
                        Expected =
                            "[[1, 2, 3], [1, 3, 2], [2, 1, 3], [2, 3, 1], [3, 1, 2], [3, 2, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [9]}",
                        Expected = "[[9]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3]}",
                        Expected =
                            "[[1, 2, 3], [1, 3, 2], [2, 1, 3], [2, 3, 1], [3, 1, 2], [3, 2, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 1]}",
                        Expected = "[[0, 1], [1, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1]}",
                        Expected = "[[1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2]}",
                        Expected = "[[1, 2], [2, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4]}",
                        Expected =
                            "[[1, 2, 3, 4], [1, 2, 4, 3], [1, 3, 2, 4], [1, 3, 4, 2], [1, 4, 2, 3], [1, 4, 3, 2], [2, 1, 3, 4], [2, 1, 4, 3], [2, 3, 1, 4], [2, 3, 4, 1], [2, 4, 1, 3], [2, 4, 3, 1], [3, 1, 2, 4], [3, 1, 4, 2], [3, 2, 1, 4], [3, 2, 4, 1], [3, 4, 1, 2], [3, 4, 2, 1], [4, 1, 2, 3], [4, 1, 3, 2], [4, 2, 1, 3], [4, 2, 3, 1], [4, 3, 1, 2], [4, 3, 2, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-1, 0, 1]}",
                        Expected =
                            "[[-1, 0, 1], [-1, 1, 0], [0, -1, 1], [0, 1, -1], [1, -1, 0], [1, 0, -1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, 6]}",
                        Expected = "[[5, 6], [6, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 1]}",
                        Expected = "[[1, 2], [2, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [3, 2, 1]}",
                        Expected =
                            "[[1, 2, 3], [1, 3, 2], [2, 1, 3], [2, 3, 1], [3, 1, 2], [3, 2, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [9]}",
                        Expected = "[[9]]",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Backtracking" }],
            };

            var combinationSum = new Problem
            {
                ProblemName = "組合總和",
                Description =
                    "給定無重複元素的整數陣列 candidates 和目標數 target，找出所有可使數字和為 target 的組合（可重複選取）。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "combination_sum",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "candidates" },
                            new() { Type = "int", ParameterName = "target" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "combinations", ReturnType = "List[List[int]]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "CombinationSum",
                        ProblemParameters =
                        [
                            new() { Type = "int[]", ParameterName = "candidates" },
                            new() { Type = "int", ParameterName = "target" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "combinations", ReturnType = "List<List<int>>" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"candidates\": [2, 3, 6, 7], \"target\": 7}",
                        Expected = "[[2, 2, 3], [7]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"candidates\": [2, 3, 5], \"target\": 8}",
                        Expected = "[[2, 2, 2, 2], [2, 3, 3], [3, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"candidates\": [2], \"target\": 1}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"candidates\": [1], \"target\": 2}",
                        Expected = "[[1, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"candidates\": [3, 5, 7], \"target\": 7}",
                        Expected = "[[7]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"candidates\": [2, 4, 6], \"target\": 8}",
                        Expected = "[[2, 2, 2, 2], [2, 2, 4], [2, 6], [4, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"candidates\": [1, 2, 3], \"target\": 4}",
                        Expected = "[[1, 1, 1, 1], [1, 1, 2], [1, 3], [2, 2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"candidates\": [5], \"target\": 5}",
                        Expected = "[[5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"candidates\": [2, 3], \"target\": 5}",
                        Expected = "[[2, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"candidates\": [1, 2], \"target\": 4}",
                        Expected = "[[1, 1, 1, 1], [1, 1, 2], [2, 2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"candidates\": [2, 3, 6, 7], \"target\": 7}",
                        Expected = "[[2, 2, 3], [7]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"candidates\": [2, 3, 5], \"target\": 8}",
                        Expected = "[[2, 2, 2, 2], [2, 3, 3], [3, 5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"candidates\": [2], \"target\": 1}",
                        Expected = "[]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"candidates\": [1], \"target\": 2}",
                        Expected = "[[1, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"candidates\": [3, 5, 7], \"target\": 7}",
                        Expected = "[[7]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"candidates\": [2, 4, 6], \"target\": 8}",
                        Expected = "[[2, 2, 2, 2], [2, 2, 4], [2, 6], [4, 4]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"candidates\": [1, 2, 3], \"target\": 4}",
                        Expected = "[[1, 1, 1, 1], [1, 1, 2], [1, 3], [2, 2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"candidates\": [5], \"target\": 5}",
                        Expected = "[[5]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"candidates\": [2, 3], \"target\": 5}",
                        Expected = "[[2, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"candidates\": [1, 2], \"target\": 4}",
                        Expected = "[[1, 1, 1, 1], [1, 1, 2], [2, 2]]",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Backtracking" }],
            };

            var nQueensIi = new Problem
            {
                ProblemName = "N 皇后 II",
                Description = "給定整數 n，回傳 n 皇后問題所有不同解法的數量。",
                Difficulty = ProblemDifficultyEnums.Hard,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "total_n_queens",
                        ProblemParameters = [new() { Type = "int", ParameterName = "n" }],
                        ProblemReturnTypes = [new() { ReturnName = "count", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "TotalNQueens",
                        ProblemParameters = [new() { Type = "int", ParameterName = "n" }],
                        ProblemReturnTypes = [new() { ReturnName = "count", ReturnType = "int" }],
                    },
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
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 3}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 4}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 5}",
                        Expected = "10",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 6}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 7}",
                        Expected = "40",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 8}",
                        Expected = "92",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 9}",
                        Expected = "352",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 0}",
                        Expected = "1",
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
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 3}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 4}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 5}",
                        Expected = "10",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 6}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 7}",
                        Expected = "40",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 8}",
                        Expected = "92",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 9}",
                        Expected = "352",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 0}",
                        Expected = "1",
                    },
                ],
                ProblemTags = [new() { Name = "Backtracking" }],
            };

            var generateParentheses = new Problem
            {
                ProblemName = "括號生成",
                Description = "給定整數 n，生成所有由 n 對括號組成的有效括號組合。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "generate_parenthesis",
                        ProblemParameters = [new() { Type = "int", ParameterName = "n" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "combinations", ReturnType = "List[str]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "GenerateParenthesis",
                        ProblemParameters = [new() { Type = "int", ParameterName = "n" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "combinations", ReturnType = "List<string>" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 1}",
                        Expected = "[\"()\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 2}",
                        Expected = "[\"(())\", \"()()\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 3}",
                        Expected = "[\"((()))\", \"(()())\", \"(())()\", \"()(())\", \"()()()\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 4}",
                        Expected =
                            "[\"(((())))\", \"((()()))\", \"((())())\", \"((()))()\", \"(()(()))\", \"(()()())\", \"(()())()\", \"(())(())\", \"(())()()\", \"()((()))\", \"()(()())\", \"()(())()\", \"()()(())\", \"()()()()\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 0}",
                        Expected = "[\"\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 5}",
                        Expected =
                            "[\"((((()))))\", \"(((()())))\", \"(((())()))\", \"(((()))())\", \"(((())))()\", \"((()(())))\", \"((()()()))\", \"((()())())\", \"((()()))()\", \"((())(()))\", \"((())()())\", \"((())())()\", \"((()))(())\", \"((()))()()\", \"(()((())))\", \"(()(()()))\", \"(()(())())\", \"(()(()))()\", \"(()()(()))\", \"(()()()())\", \"(()()())()\", \"(()())(())\", \"(()())()()\", \"(())((()))\", \"(())(()())\", \"(())(())()\", \"(())()(())\", \"(())()()()\", \"()(((())))\", \"()((()()))\", \"()((())())\", \"()((()))()\", \"()(()(()))\", \"()(()()())\", \"()(()())()\", \"()(())(())\", \"()(())()()\", \"()()((()))\", \"()()(()())\", \"()()(())()\", \"()()()(())\", \"()()()()()\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 1}",
                        Expected = "[\"()\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 2}",
                        Expected = "[\"(())\", \"()()\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 3}",
                        Expected = "[\"((()))\", \"(()())\", \"(())()\", \"()(())\", \"()()()\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 4}",
                        Expected =
                            "[\"(((())))\", \"((()()))\", \"((())())\", \"((()))()\", \"(()(()))\", \"(()()())\", \"(()())()\", \"(())(())\", \"(())()()\", \"()((()))\", \"()(()())\", \"()(())()\", \"()()(())\", \"()()()()\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 1}",
                        Expected = "[\"()\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 2}",
                        Expected = "[\"(())\", \"()()\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 3}",
                        Expected = "[\"((()))\", \"(()())\", \"(())()\", \"()(())\", \"()()()\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 4}",
                        Expected =
                            "[\"(((())))\", \"((()()))\", \"((())())\", \"((()))()\", \"(()(()))\", \"(()()())\", \"(()())()\", \"(())(())\", \"(())()()\", \"()((()))\", \"()(()())\", \"()(())()\", \"()()(())\", \"()()()()\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 0}",
                        Expected = "[\"\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 5}",
                        Expected =
                            "[\"((((()))))\", \"(((()())))\", \"(((())()))\", \"(((()))())\", \"(((())))()\", \"((()(())))\", \"((()()()))\", \"((()())())\", \"((()()))()\", \"((())(()))\", \"((())()())\", \"((())())()\", \"((()))(())\", \"((()))()()\", \"(()((())))\", \"(()(()()))\", \"(()(())())\", \"(()(()))()\", \"(()()(()))\", \"(()()()())\", \"(()()())()\", \"(()())(())\", \"(()())()()\", \"(())((()))\", \"(())(()())\", \"(())(())()\", \"(())()(())\", \"(())()()()\", \"()(((())))\", \"()((()()))\", \"()((())())\", \"()((()))()\", \"()(()(()))\", \"()(()()())\", \"()(()())()\", \"()(())(())\", \"()(())()()\", \"()()((()))\", \"()()(()())\", \"()()(())()\", \"()()()(())\", \"()()()()()\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 1}",
                        Expected = "[\"()\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 2}",
                        Expected = "[\"(())\", \"()()\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 3}",
                        Expected = "[\"((()))\", \"(()())\", \"(())()\", \"()(())\", \"()()()\"]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 4}",
                        Expected =
                            "[\"(((())))\", \"((()()))\", \"((())())\", \"((()))()\", \"(()(()))\", \"(()()())\", \"(()())()\", \"(())(())\", \"(())()()\", \"()((()))\", \"()(()())\", \"()(())()\", \"()()(())\", \"()()()()\"]",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "String" },
                    new() { Name = "Dynamic Programming" },
                    new() { Name = "Backtracking" },
                ],
            };

            var wordSearch = new Problem
            {
                ProblemName = "單字搜尋",
                Description = "給定 m x n 字元網格 board 與字串 word，判斷 word 是否存在於網格中。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "exist_word",
                        ProblemParameters =
                        [
                            new() { Type = "List[List[str]]", ParameterName = "board" },
                            new() { Type = "str", ParameterName = "word" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "exists", ReturnType = "bool" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "Exist",
                        ProblemParameters =
                        [
                            new() { Type = "char[][]", ParameterName = "board" },
                            new() { Type = "string", ParameterName = "word" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "exists", ReturnType = "bool" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"A\", \"B\", \"C\", \"E\"], [\"S\", \"F\", \"C\", \"S\"], [\"A\", \"D\", \"E\", \"E\"]], \"word\": \"ABCCED\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"A\", \"B\", \"C\", \"E\"], [\"S\", \"F\", \"C\", \"S\"], [\"A\", \"D\", \"E\", \"E\"]], \"word\": \"SEE\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"A\", \"B\", \"C\", \"E\"], [\"S\", \"F\", \"C\", \"S\"], [\"A\", \"D\", \"E\", \"E\"]], \"word\": \"ABCB\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[\"a\"]], \"word\": \"a\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[\"a\"]], \"word\": \"b\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[\"a\", \"a\"]], \"word\": \"aa\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[\"a\", \"a\"]], \"word\": \"aaa\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"board\": [[\"C\", \"A\", \"A\"], [\"A\", \"A\", \"A\"], [\"B\", \"C\", \"D\"]], \"word\": \"AAB\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[\"A\", \"B\"], [\"C\", \"D\"]], \"word\": \"ABDC\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"board\": [[\"A\", \"B\"], [\"C\", \"D\"]], \"word\": \"ABCD\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"A\", \"B\", \"C\", \"E\"], [\"S\", \"F\", \"C\", \"S\"], [\"A\", \"D\", \"E\", \"E\"]], \"word\": \"ABCCED\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"A\", \"B\", \"C\", \"E\"], [\"S\", \"F\", \"C\", \"S\"], [\"A\", \"D\", \"E\", \"E\"]], \"word\": \"SEE\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"A\", \"B\", \"C\", \"E\"], [\"S\", \"F\", \"C\", \"S\"], [\"A\", \"D\", \"E\", \"E\"]], \"word\": \"ABCB\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[\"a\"]], \"word\": \"a\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[\"a\"]], \"word\": \"b\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[\"a\", \"a\"]], \"word\": \"aa\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[\"a\", \"a\"]], \"word\": \"aaa\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"board\": [[\"C\", \"A\", \"A\"], [\"A\", \"A\", \"A\"], [\"B\", \"C\", \"D\"]], \"word\": \"AAB\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[\"A\", \"B\"], [\"C\", \"D\"]], \"word\": \"ABDC\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"board\": [[\"A\", \"B\"], [\"C\", \"D\"]], \"word\": \"ABCD\"}",
                        Expected = "false",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "String" },
                    new() { Name = "Backtracking" },
                    new() { Name = "Matrix" },
                ],
            };

            var maximumSubarray = new Problem
            {
                ProblemName = "最大子陣列和",
                Description = "給定整數陣列 nums，找出具有最大和的連續子陣列，回傳其最大和。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "max_sub_array",
                        ProblemParameters = [new() { Type = "List[int]", ParameterName = "nums" }],
                        ProblemReturnTypes = [new() { ReturnName = "maxSum", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "MaxSubArray",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "nums" }],
                        ProblemReturnTypes = [new() { ReturnName = "maxSum", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-2, 1, -3, 4, -1, 2, 1, -5, 4]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, 4, -1, 7, 8]}",
                        Expected = "23",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-1]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-2, -1]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-1, -2, -3, -4]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 0, 0]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4, 5]}",
                        Expected = "15",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-5, 1, -5, 1, -5]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [3, -2, 5, -1]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-2, 1, -3, 4, -1, 2, 1, -5, 4]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, 4, -1, 7, 8]}",
                        Expected = "23",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-1]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-2, -1]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-1, -2, -3, -4]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 0, 0]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4, 5]}",
                        Expected = "15",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-5, 1, -5, 1, -5]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [3, -2, 5, -1]}",
                        Expected = "6",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Divide and Conquer" },
                    new() { Name = "Dynamic Programming" },
                ],
            };

            var maxSumCircularSubarray = new Problem
            {
                ProblemName = "環形子陣列的最大和",
                Description = "給定環形整數陣列 nums，回傳非空子陣列的最大可能和。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "max_subarray_sum_circular",
                        ProblemParameters = [new() { Type = "List[int]", ParameterName = "nums" }],
                        ProblemReturnTypes = [new() { ReturnName = "maxSum", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "MaxSubarraySumCircular",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "nums" }],
                        ProblemReturnTypes = [new() { ReturnName = "maxSum", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, -2, 3, -2]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, -3, 5]}",
                        Expected = "10",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [3, -1, 2, -1]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [3, -2, 2, -3]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-2, -3, -1]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-5]}",
                        Expected = "-5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1, 1, 1]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-1, -2, -3, -4]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, -1, 2, -1, 2]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, -2, 3, -2]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, -3, 5]}",
                        Expected = "10",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [3, -1, 2, -1]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [3, -2, 2, -3]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-2, -3, -1]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-5]}",
                        Expected = "-5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1, 1, 1]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-1, -2, -3, -4]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, -1, 2, -1, 2]}",
                        Expected = "5",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Queue" },
                    new() { Name = "Dynamic Programming" },
                    new() { Name = "Monotonic Queue" },
                ],
            };

            var searchInsertPosition = new Problem
            {
                ProblemName = "搜尋插入位置",
                Description = "給定排序整數陣列 nums 與目標值 target，回傳其索引或應插入的位置。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "search_insert",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "nums" },
                            new() { Type = "int", ParameterName = "target" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "index", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "SearchInsert",
                        ProblemParameters =
                        [
                            new() { Type = "int[]", ParameterName = "nums" },
                            new() { Type = "int", ParameterName = "target" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "index", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 3, 5, 6], \"target\": 5}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 3, 5, 6], \"target\": 2}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 3, 5, 6], \"target\": 7}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 3, 5, 6], \"target\": 0}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [], \"target\": 5}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1], \"target\": 1}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1], \"target\": 0}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1], \"target\": 2}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 3, 5, 5, 5, 6], \"target\": 5}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-5, -3, 0, 4, 8], \"target\": -1}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 3, 5, 6], \"target\": 5}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 3, 5, 6], \"target\": 2}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 3, 5, 6], \"target\": 7}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 3, 5, 6], \"target\": 0}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [], \"target\": 5}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1], \"target\": 1}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1], \"target\": 0}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1], \"target\": 2}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 3, 5, 5, 5, 6], \"target\": 5}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-5, -3, 0, 4, 8], \"target\": -1}",
                        Expected = "2",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Binary Search" }],
            };

            var search2dMatrix = new Problem
            {
                ProblemName = "搜尋二維矩陣",
                Description = "給定每行遞增且行間遞增的矩陣 matrix，判斷目標值 target 是否存在。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "search_matrix",
                        ProblemParameters =
                        [
                            new() { Type = "List[List[int]]", ParameterName = "matrix" },
                            new() { Type = "int", ParameterName = "target" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "found", ReturnType = "bool" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "SearchMatrix",
                        ProblemParameters =
                        [
                            new() { Type = "int[][]", ParameterName = "matrix" },
                            new() { Type = "int", ParameterName = "target" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "found", ReturnType = "bool" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"matrix\": [[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]], \"target\": 3}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"matrix\": [[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]], \"target\": 13}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1]], \"target\": 1}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1]], \"target\": 2}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1, 3]], \"target\": 3}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[1], [3]], \"target\": 3}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[-5, -3, -1], [0, 2, 4]], \"target\": -3}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"matrix\": [[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]], \"target\": 60}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"matrix\": [[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]], \"target\": 1}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"matrix\": [[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]], \"target\": 61}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"matrix\": [[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]], \"target\": 3}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"matrix\": [[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]], \"target\": 13}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1]], \"target\": 1}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1]], \"target\": 2}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1, 3]], \"target\": 3}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[1], [3]], \"target\": 3}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[-5, -3, -1], [0, 2, 4]], \"target\": -3}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"matrix\": [[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]], \"target\": 60}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"matrix\": [[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]], \"target\": 1}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"matrix\": [[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]], \"target\": 61}",
                        Expected = "false",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Binary Search" },
                    new() { Name = "Matrix" },
                ],
            };

            var findPeakElement = new Problem
            {
                ProblemName = "尋找峰值",
                Description = "給定整數陣列 nums，找出任意一個值大於左右相鄰元素的峰值索引。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "find_peak_element",
                        ProblemParameters = [new() { Type = "List[int]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "peakIndex", ReturnType = "int" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "FindPeakElement",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "peakIndex", ReturnType = "int" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 1]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 1, 3, 5, 6, 4]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4, 5]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, 4, 3, 2, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 3, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 10, 5, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 1, 2, 1]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 1]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 1, 3, 5, 6, 4]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4, 5]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, 4, 3, 2, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 3, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 10, 5, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 1, 2, 1]}",
                        Expected = "3",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Binary Search" }],
            };

            var searchInRotatedSortedArray = new Problem
            {
                ProblemName = "搜尋旋轉排序陣列",
                Description =
                    "給定旋轉過的升序整數陣列 nums 與目標值 target，搜尋其索引；不存在則回傳 -1。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "search_rotated",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "nums" },
                            new() { Type = "int", ParameterName = "target" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "index", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "Search",
                        ProblemParameters =
                        [
                            new() { Type = "int[]", ParameterName = "nums" },
                            new() { Type = "int", ParameterName = "target" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "index", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [4, 5, 6, 7, 0, 1, 2], \"target\": 0}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [4, 5, 6, 7, 0, 1, 2], \"target\": 3}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1], \"target\": 0}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1], \"target\": 1}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, 1, 3], \"target\": 5}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [3, 1], \"target\": 1}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4, 5], \"target\": 3}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [4, 5, 6, 7, 8, 1, 2, 3], \"target\": 8}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [6, 7, 8, 1, 2, 3, 4, 5], \"target\": 1}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 3], \"target\": 0}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [4, 5, 6, 7, 0, 1, 2], \"target\": 0}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [4, 5, 6, 7, 0, 1, 2], \"target\": 3}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1], \"target\": 0}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1], \"target\": 1}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, 1, 3], \"target\": 5}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [3, 1], \"target\": 1}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4, 5], \"target\": 3}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [4, 5, 6, 7, 8, 1, 2, 3], \"target\": 8}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [6, 7, 8, 1, 2, 3, 4, 5], \"target\": 1}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 3], \"target\": 0}",
                        Expected = "-1",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Binary Search" }],
            };

            var findFirstLastPosition = new Problem
            {
                ProblemName = "在排序陣列中找元素的第一個和最後一個位置",
                Description =
                    "給定升序整數陣列 nums 與目標值 target，找出其起始與結束索引；不存在則回傳 [-1, -1]。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "search_range",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "nums" },
                            new() { Type = "int", ParameterName = "target" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "range", ReturnType = "List[int]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "SearchRange",
                        ProblemParameters =
                        [
                            new() { Type = "int[]", ParameterName = "nums" },
                            new() { Type = "int", ParameterName = "target" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "range", ReturnType = "int[]" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, 7, 7, 8, 8, 10], \"target\": 8}",
                        Expected = "[3, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, 7, 7, 8, 8, 10], \"target\": 6}",
                        Expected = "[-1, -1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [], \"target\": 0}",
                        Expected = "[-1, -1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1], \"target\": 1}",
                        Expected = "[0, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1], \"target\": 0}",
                        Expected = "[-1, -1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 2, 2, 2, 2], \"target\": 2}",
                        Expected = "[0, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4, 5], \"target\": 1}",
                        Expected = "[0, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4, 5], \"target\": 5}",
                        Expected = "[4, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1, 2, 2, 2, 3], \"target\": 2}",
                        Expected = "[2, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 3, 3, 3, 5], \"target\": 3}",
                        Expected = "[1, 3]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, 7, 7, 8, 8, 10], \"target\": 8}",
                        Expected = "[3, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, 7, 7, 8, 8, 10], \"target\": 6}",
                        Expected = "[-1, -1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [], \"target\": 0}",
                        Expected = "[-1, -1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1], \"target\": 1}",
                        Expected = "[0, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1], \"target\": 0}",
                        Expected = "[-1, -1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 2, 2, 2, 2], \"target\": 2}",
                        Expected = "[0, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4, 5], \"target\": 1}",
                        Expected = "[0, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4, 5], \"target\": 5}",
                        Expected = "[4, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1, 2, 2, 2, 3], \"target\": 2}",
                        Expected = "[2, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 3, 3, 3, 5], \"target\": 3}",
                        Expected = "[1, 3]",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Binary Search" }],
            };

            var findMinimumRotatedSortedArray = new Problem
            {
                ProblemName = "尋找旋轉排序陣列中的最小值",
                Description = "給定旋轉過且不含重複元素的升序整數陣列 nums，找出陣列中的最小元素。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "find_min",
                        ProblemParameters = [new() { Type = "List[int]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "minValue", ReturnType = "int" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "FindMin",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "minValue", ReturnType = "int" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [3, 4, 5, 1, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [4, 5, 6, 7, 0, 1, 2]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [11, 13, 15, 17]}",
                        Expected = "11",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [3, 1, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, 1, 2, 3, 4]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 3, 4, 5, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4, 5]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [3, 4, 5, 1, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [4, 5, 6, 7, 0, 1, 2]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [11, 13, 15, 17]}",
                        Expected = "11",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [3, 1, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, 1, 2, 3, 4]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 3, 4, 5, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4, 5]}",
                        Expected = "1",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Binary Search" }],
            };

            var medianOfTwoSortedArrays = new Problem
            {
                ProblemName = "尋找兩個正序陣列的中位數",
                Description = "給定兩個升序陣列 nums1 和 nums2，回傳合併後的中位數。",
                Difficulty = ProblemDifficultyEnums.Hard,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "find_median_sorted_arrays",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "nums1" },
                            new() { Type = "List[int]", ParameterName = "nums2" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "median", ReturnType = "float" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "FindMedianSortedArrays",
                        ProblemParameters =
                        [
                            new() { Type = "int[]", ParameterName = "nums1" },
                            new() { Type = "int[]", ParameterName = "nums2" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "median", ReturnType = "double" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [1, 3], \"nums2\": [2]}",
                        Expected = "2.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [1, 2], \"nums2\": [3, 4]}",
                        Expected = "2.5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [], \"nums2\": [1]}",
                        Expected = "1.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [1], \"nums2\": []}",
                        Expected = "1.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [0, 0], \"nums2\": [0, 0]}",
                        Expected = "0.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [1, 2, 3], \"nums2\": [4, 5, 6, 7]}",
                        Expected = "4.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [1, 3, 5], \"nums2\": [2, 4, 6]}",
                        Expected = "3.5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [2], \"nums2\": [1, 3, 4]}",
                        Expected = "2.5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [1, 5, 9], \"nums2\": [2, 3, 4, 6, 7, 8]}",
                        Expected = "5.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [-5, -3, -1], \"nums2\": [-4, -2, 0]}",
                        Expected = "-2.5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [1, 3], \"nums2\": [2]}",
                        Expected = "2.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [1, 2], \"nums2\": [3, 4]}",
                        Expected = "2.5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [], \"nums2\": [1]}",
                        Expected = "1.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [1], \"nums2\": []}",
                        Expected = "1.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [0, 0], \"nums2\": [0, 0]}",
                        Expected = "0.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [1, 2, 3], \"nums2\": [4, 5, 6, 7]}",
                        Expected = "4.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [1, 3, 5], \"nums2\": [2, 4, 6]}",
                        Expected = "3.5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [2], \"nums2\": [1, 3, 4]}",
                        Expected = "2.5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [1, 5, 9], \"nums2\": [2, 3, 4, 6, 7, 8]}",
                        Expected = "5.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [-5, -3, -1], \"nums2\": [-4, -2, 0]}",
                        Expected = "-2.5",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Binary Search" },
                    new() { Name = "Divide and Conquer" },
                ],
            };

            var kthLargestElement = new Problem
            {
                ProblemName = "陣列中的第 K 個最大元素",
                Description = "給定未排序整數陣列 nums 和整數 k，回傳陣列中第 k 大的元素。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "find_kth_largest",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "nums" },
                            new() { Type = "int", ParameterName = "k" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "kthLargest", ReturnType = "int" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "FindKthLargest",
                        ProblemParameters =
                        [
                            new() { Type = "int[]", ParameterName = "nums" },
                            new() { Type = "int", ParameterName = "k" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "kthLargest", ReturnType = "int" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [3, 2, 1, 5, 6, 4], \"k\": 2}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [3, 2, 3, 1, 2, 4, 5, 5, 6], \"k\": 4}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1], \"k\": 1}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 1], \"k\": 2}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [7, 6, 5, 4, 3, 2, 1], \"k\": 1}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [7, 6, 5, 4, 3, 2, 1], \"k\": 7}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, 5, 5, 5], \"k\": 1}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, 5, 5, 5], \"k\": 4}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-1, -2, -3, -4], \"k\": 1}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10], \"k\": 5}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [3, 2, 1, 5, 6, 4], \"k\": 2}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [3, 2, 3, 1, 2, 4, 5, 5, 6], \"k\": 4}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1], \"k\": 1}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 1], \"k\": 2}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [7, 6, 5, 4, 3, 2, 1], \"k\": 1}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [7, 6, 5, 4, 3, 2, 1], \"k\": 7}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, 5, 5, 5], \"k\": 1}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, 5, 5, 5], \"k\": 4}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-1, -2, -3, -4], \"k\": 1}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10], \"k\": 5}",
                        Expected = "6",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Divide and Conquer" },
                    new() { Name = "Sorting" },
                    new() { Name = "Heap (Priority Queue)" },
                ],
            };

            var ipo = new Problem
            {
                ProblemName = "IPO",
                Description =
                    "給定初始資本 w、最多可選 k 個專案，每個專案有所需資金 capital[i] 與利潤 profits[i]，求最終可獲得的最大資本。",
                Difficulty = ProblemDifficultyEnums.Hard,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "find_maximized_capital",
                        ProblemParameters =
                        [
                            new() { Type = "int", ParameterName = "k" },
                            new() { Type = "int", ParameterName = "w" },
                            new() { Type = "List[int]", ParameterName = "profits" },
                            new() { Type = "List[int]", ParameterName = "capital" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "maxCapital", ReturnType = "int" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "FindMaximizedCapital",
                        ProblemParameters =
                        [
                            new() { Type = "int", ParameterName = "k" },
                            new() { Type = "int", ParameterName = "w" },
                            new() { Type = "int[]", ParameterName = "profits" },
                            new() { Type = "int[]", ParameterName = "capital" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "maxCapital", ReturnType = "int" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"k\": 2, \"w\": 0, \"profits\": [1, 2, 3], \"capital\": [0, 1, 1]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"k\": 3, \"w\": 0, \"profits\": [1, 2, 3], \"capital\": [0, 1, 2]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"k\": 1, \"w\": 0, \"profits\": [1, 2, 3], \"capital\": [0, 1, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"k\": 0, \"w\": 0, \"profits\": [1, 2, 3], \"capital\": [0, 1, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"k\": 1, \"w\": 0, \"profits\": [5], \"capital\": [0]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"k\": 2, \"w\": 0, \"profits\": [5], \"capital\": [0]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"k\": 3, \"w\": 0, \"profits\": [1, 2, 3, 4], \"capital\": [0, 0, 0, 0]}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"k\": 1, \"w\": 10, \"profits\": [1, 2, 3], \"capital\": [0, 1, 1]}",
                        Expected = "13",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"k\": 2, \"w\": 0, \"profits\": [3, 2, 1], \"capital\": [0, 0, 0]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"k\": 4, \"w\": 0, \"profits\": [2, 3, 5], \"capital\": [0, 1, 2]}",
                        Expected = "10",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"k\": 2, \"w\": 0, \"profits\": [1, 2, 3], \"capital\": [0, 1, 1]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"k\": 3, \"w\": 0, \"profits\": [1, 2, 3], \"capital\": [0, 1, 2]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"k\": 1, \"w\": 0, \"profits\": [1, 2, 3], \"capital\": [0, 1, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"k\": 0, \"w\": 0, \"profits\": [1, 2, 3], \"capital\": [0, 1, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"k\": 1, \"w\": 0, \"profits\": [5], \"capital\": [0]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"k\": 2, \"w\": 0, \"profits\": [5], \"capital\": [0]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"k\": 3, \"w\": 0, \"profits\": [1, 2, 3, 4], \"capital\": [0, 0, 0, 0]}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"k\": 1, \"w\": 10, \"profits\": [1, 2, 3], \"capital\": [0, 1, 1]}",
                        Expected = "13",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"k\": 2, \"w\": 0, \"profits\": [3, 2, 1], \"capital\": [0, 0, 0]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"k\": 4, \"w\": 0, \"profits\": [2, 3, 5], \"capital\": [0, 1, 2]}",
                        Expected = "10",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Greedy" },
                    new() { Name = "Sorting" },
                    new() { Name = "Heap (Priority Queue)" },
                ],
            };

            var findKPairsSmallestSums = new Problem
            {
                ProblemName = "查找和最小的 K 對數字",
                Description = "給定兩個升序整數陣列 nums1、nums2 與整數 k，回傳和最小的 k 個數對。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "k_smallest_pairs",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "nums1" },
                            new() { Type = "List[int]", ParameterName = "nums2" },
                            new() { Type = "int", ParameterName = "k" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "pairs", ReturnType = "List[List[int]]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "KSmallestPairs",
                        ProblemParameters =
                        [
                            new() { Type = "int[]", ParameterName = "nums1" },
                            new() { Type = "int[]", ParameterName = "nums2" },
                            new() { Type = "int", ParameterName = "k" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "pairs", ReturnType = "List<List<int>>" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [1, 7, 11], \"nums2\": [2, 4, 6], \"k\": 3}",
                        Expected = "[[1, 2], [1, 4], [1, 6]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [1, 1, 2], \"nums2\": [1, 2, 3], \"k\": 2}",
                        Expected = "[[1, 1], [1, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [1, 2], \"nums2\": [3], \"k\": 3}",
                        Expected = "[[1, 3], [2, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [1], \"nums2\": [1], \"k\": 1}",
                        Expected = "[[1, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [1, 2, 3], \"nums2\": [1, 2, 3], \"k\": 9}",
                        Expected =
                            "[[1, 1], [1, 2], [2, 1], [1, 3], [2, 2], [3, 1], [2, 3], [3, 2], [3, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [1, 1, 1], \"nums2\": [1, 1, 1], \"k\": 3}",
                        Expected = "[[1, 1], [1, 1], [1, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [5, 8, 9], \"nums2\": [1, 2, 3], \"k\": 2}",
                        Expected = "[[5, 1], [5, 2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [0], \"nums2\": [0], \"k\": 1}",
                        Expected = "[[0, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [-1, 1], \"nums2\": [-2, 2], \"k\": 2}",
                        Expected = "[[-1, -2], [1, -2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums1\": [1, 2, 3], \"nums2\": [1, 2, 3], \"k\": 1}",
                        Expected = "[[1, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [1, 7, 11], \"nums2\": [2, 4, 6], \"k\": 3}",
                        Expected = "[[1, 2], [1, 4], [1, 6]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [1, 1, 2], \"nums2\": [1, 2, 3], \"k\": 2}",
                        Expected = "[[1, 1], [1, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [1, 2], \"nums2\": [3], \"k\": 3}",
                        Expected = "[[1, 3], [2, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [1], \"nums2\": [1], \"k\": 1}",
                        Expected = "[[1, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [1, 2, 3], \"nums2\": [1, 2, 3], \"k\": 9}",
                        Expected =
                            "[[1, 1], [1, 2], [2, 1], [1, 3], [2, 2], [3, 1], [2, 3], [3, 2], [3, 3]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [1, 1, 1], \"nums2\": [1, 1, 1], \"k\": 3}",
                        Expected = "[[1, 1], [1, 1], [1, 1]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [5, 8, 9], \"nums2\": [1, 2, 3], \"k\": 2}",
                        Expected = "[[5, 1], [5, 2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [0], \"nums2\": [0], \"k\": 1}",
                        Expected = "[[0, 0]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [-1, 1], \"nums2\": [-2, 2], \"k\": 2}",
                        Expected = "[[-1, -2], [1, -2]]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums1\": [1, 2, 3], \"nums2\": [1, 2, 3], \"k\": 1}",
                        Expected = "[[1, 1]]",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Heap (Priority Queue)" }],
            };

            var addBinary = new Problem
            {
                ProblemName = "二進位求和",
                Description = "給定兩個二進位字串 a 和 b，回傳它們的和（以二進位字串表示）。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "add_binary",
                        ProblemParameters =
                        [
                            new() { Type = "str", ParameterName = "a" },
                            new() { Type = "str", ParameterName = "b" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "sum", ReturnType = "str" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "AddBinary",
                        ProblemParameters =
                        [
                            new() { Type = "string", ParameterName = "a" },
                            new() { Type = "string", ParameterName = "b" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "sum", ReturnType = "string" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"a\": \"11\", \"b\": \"1\"}",
                        Expected = "\"100\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"a\": \"1010\", \"b\": \"1011\"}",
                        Expected = "\"10101\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"a\": \"0\", \"b\": \"0\"}",
                        Expected = "\"0\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"a\": \"1\", \"b\": \"1\"}",
                        Expected = "\"10\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"a\": \"1111\", \"b\": \"1111\"}",
                        Expected = "\"11110\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"a\": \"100\", \"b\": \"110010\"}",
                        Expected = "\"110110\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"a\": \"0\", \"b\": \"1\"}",
                        Expected = "\"1\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"a\": \"110\", \"b\": \"1\"}",
                        Expected = "\"111\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"a\": \"1\", \"b\": \"0\"}",
                        Expected = "\"1\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"a\": \"11111\", \"b\": \"11111\"}",
                        Expected = "\"111110\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"a\": \"11\", \"b\": \"1\"}",
                        Expected = "\"100\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"a\": \"1010\", \"b\": \"1011\"}",
                        Expected = "\"10101\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"a\": \"0\", \"b\": \"0\"}",
                        Expected = "\"0\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"a\": \"1\", \"b\": \"1\"}",
                        Expected = "\"10\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"a\": \"1111\", \"b\": \"1111\"}",
                        Expected = "\"11110\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"a\": \"100\", \"b\": \"110010\"}",
                        Expected = "\"110110\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"a\": \"0\", \"b\": \"1\"}",
                        Expected = "\"1\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"a\": \"110\", \"b\": \"1\"}",
                        Expected = "\"111\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"a\": \"1\", \"b\": \"0\"}",
                        Expected = "\"1\"",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"a\": \"11111\", \"b\": \"11111\"}",
                        Expected = "\"111110\"",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Math" },
                    new() { Name = "String" },
                    new() { Name = "Bit Manipulation" },
                    new() { Name = "Simulation" },
                ],
            };

            var reverseBits = new Problem
            {
                ProblemName = "顛倒二進位位元",
                Description = "給定 32 位元無符號整數，顛倒其二進位位元順序並回傳結果。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "reverse_bits",
                        ProblemParameters = [new() { Type = "int", ParameterName = "n" }],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "ReverseBits",
                        ProblemParameters = [new() { Type = "uint", ParameterName = "n" }],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "uint" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 43261596}",
                        Expected = "964176192",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 4294967293}",
                        Expected = "3221225471",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 1}",
                        Expected = "2147483648",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 0}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 2147483648}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 4294967295}",
                        Expected = "4294967295",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 2}",
                        Expected = "1073741824",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 3}",
                        Expected = "3221225472",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 1024}",
                        Expected = "2097152",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 12345}",
                        Expected = "2618032128",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 43261596}",
                        Expected = "964176192",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 4294967293}",
                        Expected = "3221225471",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 1}",
                        Expected = "2147483648",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 0}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 2147483648}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 4294967295}",
                        Expected = "4294967295",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 2}",
                        Expected = "1073741824",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 3}",
                        Expected = "3221225472",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 1024}",
                        Expected = "2097152",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 12345}",
                        Expected = "2618032128",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Divide and Conquer" },
                    new() { Name = "Bit Manipulation" },
                ],
            };

            var numberOf1Bits = new Problem
            {
                ProblemName = "位元 1 的個數",
                Description = "給定整數，回傳其二進位表示中數字 1 的個數。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "hamming_weight",
                        ProblemParameters = [new() { Type = "int", ParameterName = "n" }],
                        ProblemReturnTypes = [new() { ReturnName = "count", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "HammingWeight",
                        ProblemParameters = [new() { Type = "int", ParameterName = "n" }],
                        ProblemReturnTypes = [new() { ReturnName = "count", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 11}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 128}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 4294967293}",
                        Expected = "31",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 0}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 1}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 2147483648}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 4294967295}",
                        Expected = "32",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 3}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 255}",
                        Expected = "8",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 1024}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 11}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 128}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 4294967293}",
                        Expected = "31",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 0}",
                        Expected = "0",
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
                        Input = "{\"n\": 2147483648}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 4294967295}",
                        Expected = "32",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 3}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 255}",
                        Expected = "8",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 1024}",
                        Expected = "1",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Divide and Conquer" },
                    new() { Name = "Bit Manipulation" },
                ],
            };

            var singleNumber = new Problem
            {
                ProblemName = "只出現一次的數字",
                Description =
                    "給定非空整數陣列 nums，除某元素只出現一次外其餘皆出現兩次，找出該元素。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "single_number",
                        ProblemParameters = [new() { Type = "List[int]", ParameterName = "nums" }],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "SingleNumber",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "nums" }],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 2, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [4, 1, 2, 1, 2]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 1, 0]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-1, -1, -2]}",
                        Expected = "-2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, 3, 5]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [7, 7, 8]}",
                        Expected = "8",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1, 2, 2, 3]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [100]}",
                        Expected = "100",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-3, -3, 7]}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 2, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [4, 1, 2, 1, 2]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 1, 0]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-1, -1, -2]}",
                        Expected = "-2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, 3, 5]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [7, 7, 8]}",
                        Expected = "8",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1, 2, 2, 3]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [100]}",
                        Expected = "100",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-3, -3, 7]}",
                        Expected = "7",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Bit Manipulation" }],
            };

            var singleNumberIi = new Problem
            {
                ProblemName = "只出現一次的數字 II",
                Description = "給定整數陣列 nums，除某元素只出現一次外其餘皆出現三次，找出該元素。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "single_number_ii",
                        ProblemParameters = [new() { Type = "List[int]", ParameterName = "nums" }],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "SingleNumberII",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "nums" }],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 2, 3, 2]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 1, 0, 1, 0, 1, 99]}",
                        Expected = "99",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-2, -2, 1, 1, -3, 1, -3, -3, -4]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, 5, 5, 9]}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 0, 0, 5]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [-1, -1, -1, -7]}",
                        Expected = "-7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [3, 3, 3, 4, 4, 4, 5]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1, 1, 2]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [10, 10, 10, 20]}",
                        Expected = "20",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 2, 3, 2]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 1, 0, 1, 0, 1, 99]}",
                        Expected = "99",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-2, -2, 1, 1, -3, 1, -3, -3, -4]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, 5, 5, 9]}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 0, 0, 5]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [-1, -1, -1, -7]}",
                        Expected = "-7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [3, 3, 3, 4, 4, 4, 5]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1, 1, 2]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [10, 10, 10, 20]}",
                        Expected = "20",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Bit Manipulation" }],
            };

            var bitwiseAndNumbersRange = new Problem
            {
                ProblemName = "數字範圍按位與",
                Description =
                    "給定整數 left 和 right，回傳區間 [left, right] 內所有數字按位與的結果。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "range_bitwise_and",
                        ProblemParameters =
                        [
                            new() { Type = "int", ParameterName = "left" },
                            new() { Type = "int", ParameterName = "right" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "RangeBitwiseAnd",
                        ProblemParameters =
                        [
                            new() { Type = "int", ParameterName = "left" },
                            new() { Type = "int", ParameterName = "right" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"left\": 5, \"right\": 7}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"left\": 0, \"right\": 0}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"left\": 1, \"right\": 2147483647}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"left\": 1, \"right\": 1}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"left\": 5, \"right\": 5}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"left\": 2, \"right\": 4}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"left\": 8, \"right\": 10}",
                        Expected = "8",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"left\": 0, \"right\": 1}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"left\": 3, \"right\": 7}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"left\": 123, \"right\": 234}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"left\": 5, \"right\": 7}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"left\": 0, \"right\": 0}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"left\": 1, \"right\": 2147483647}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"left\": 1, \"right\": 1}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"left\": 5, \"right\": 5}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"left\": 2, \"right\": 4}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"left\": 8, \"right\": 10}",
                        Expected = "8",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"left\": 0, \"right\": 1}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"left\": 3, \"right\": 7}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"left\": 123, \"right\": 234}",
                        Expected = "0",
                    },
                ],
                ProblemTags = [new() { Name = "Bit Manipulation" }],
            };

            var palindromeNumber = new Problem
            {
                ProblemName = "回文數",
                Description = "給定整數 x，判斷其是否為回文數。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "is_palindrome_number",
                        ProblemParameters = [new() { Type = "int", ParameterName = "x" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "isPalindrome", ReturnType = "bool" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "IsPalindrome",
                        ProblemParameters = [new() { Type = "int", ParameterName = "x" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "isPalindrome", ReturnType = "bool" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 121}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": -121}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 10}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 0}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 1}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 12321}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 12320}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 1000021}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 11}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 1221}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 121}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": -121}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 10}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 0}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 1}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 12321}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 12320}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 1000021}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 11}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 1221}",
                        Expected = "true",
                    },
                ],
                ProblemTags = [new() { Name = "Math" }],
            };

            var plusOne = new Problem
            {
                ProblemName = "加一",
                Description = "給定表示大整數每一位數字的陣列 digits，將該整數加一後回傳結果陣列。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "plus_one",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "digits" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "result", ReturnType = "List[int]" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "PlusOne",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "digits" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "result", ReturnType = "int[]" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"digits\": [1, 2, 3]}",
                        Expected = "[1, 2, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"digits\": [4, 3, 2, 1]}",
                        Expected = "[4, 3, 2, 2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"digits\": [9]}",
                        Expected = "[1, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"digits\": [9, 9]}",
                        Expected = "[1, 0, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"digits\": [9, 9, 9]}",
                        Expected = "[1, 0, 0, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"digits\": [0]}",
                        Expected = "[1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"digits\": [1, 9]}",
                        Expected = "[2, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"digits\": [8, 9, 9, 9]}",
                        Expected = "[9, 0, 0, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"digits\": [1, 0, 0]}",
                        Expected = "[1, 0, 1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"digits\": [2, 9, 9]}",
                        Expected = "[3, 0, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"digits\": [1, 2, 3]}",
                        Expected = "[1, 2, 4]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"digits\": [4, 3, 2, 1]}",
                        Expected = "[4, 3, 2, 2]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"digits\": [9]}",
                        Expected = "[1, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"digits\": [9, 9]}",
                        Expected = "[1, 0, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"digits\": [9, 9, 9]}",
                        Expected = "[1, 0, 0, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"digits\": [0]}",
                        Expected = "[1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"digits\": [1, 9]}",
                        Expected = "[2, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"digits\": [8, 9, 9, 9]}",
                        Expected = "[9, 0, 0, 0]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"digits\": [1, 0, 0]}",
                        Expected = "[1, 0, 1]",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"digits\": [2, 9, 9]}",
                        Expected = "[3, 0, 0]",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Math" }],
            };

            var factorialTrailingZeroes = new Problem
            {
                ProblemName = "階乘後的零",
                Description = "給定整數 n，回傳 n! 結果末尾零的數量。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "trailing_zeroes",
                        ProblemParameters = [new() { Type = "int", ParameterName = "n" }],
                        ProblemReturnTypes = [new() { ReturnName = "count", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "TrailingZeroes",
                        ProblemParameters = [new() { Type = "int", ParameterName = "n" }],
                        ProblemReturnTypes = [new() { ReturnName = "count", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 3}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 5}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 0}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 10}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 25}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 100}",
                        Expected = "24",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 1}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 4}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 30}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"n\": 1000}",
                        Expected = "249",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 3}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 5}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 0}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 10}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 25}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 100}",
                        Expected = "24",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 1}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 4}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 30}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"n\": 1000}",
                        Expected = "249",
                    },
                ],
                ProblemTags = [new() { Name = "Math" }],
            };

            var sqrtX = new Problem
            {
                ProblemName = "x 的平方根",
                Description = "給定非負整數 x，回傳其平方根的整數部分。",
                Difficulty = ProblemDifficultyEnums.Easy,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "my_sqrt",
                        ProblemParameters = [new() { Type = "int", ParameterName = "x" }],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "MySqrt",
                        ProblemParameters = [new() { Type = "int", ParameterName = "x" }],
                        ProblemReturnTypes = [new() { ReturnName = "result", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 4}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 8}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 0}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 1}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 2147395599}",
                        Expected = "46339",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 9}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 15}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 16}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 2}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 100}",
                        Expected = "10",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 4}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 8}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 0}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 1}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 2147395599}",
                        Expected = "46339",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 9}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 15}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 16}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 2}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 100}",
                        Expected = "10",
                    },
                ],
                ProblemTags = [new() { Name = "Math" }, new() { Name = "Binary Search" }],
            };

            var powXN = new Problem
            {
                ProblemName = "Pow(x, n)",
                Description = "計算 x 的 n 次方（n 可為負整數）。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "my_pow",
                        ProblemParameters =
                        [
                            new() { Type = "float", ParameterName = "x" },
                            new() { Type = "int", ParameterName = "n" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "result", ReturnType = "float" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "MyPow",
                        ProblemParameters =
                        [
                            new() { Type = "double", ParameterName = "x" },
                            new() { Type = "int", ParameterName = "n" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "result", ReturnType = "double" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 2.0, \"n\": 10}",
                        Expected = "1024.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 2.1, \"n\": 3}",
                        Expected = "9.261",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 2.0, \"n\": -2}",
                        Expected = "0.25",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 1.0, \"n\": 2147483647}",
                        Expected = "1.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 2.0, \"n\": 0}",
                        Expected = "1.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 0.5, \"n\": 2}",
                        Expected = "0.25",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": -2.0, \"n\": 3}",
                        Expected = "-8.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": -2.0, \"n\": 2}",
                        Expected = "4.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 1.5, \"n\": 4}",
                        Expected = "5.0625",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"x\": 3.0, \"n\": -3}",
                        Expected = "0.03704",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 2.0, \"n\": 10}",
                        Expected = "1024.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 2.1, \"n\": 3}",
                        Expected = "9.261",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 2.0, \"n\": -2}",
                        Expected = "0.25",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 1.0, \"n\": 2147483647}",
                        Expected = "1.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 2.0, \"n\": 0}",
                        Expected = "1.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 0.5, \"n\": 2}",
                        Expected = "0.25",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": -2.0, \"n\": 3}",
                        Expected = "-8.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": -2.0, \"n\": 2}",
                        Expected = "4.0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 1.5, \"n\": 4}",
                        Expected = "5.0625",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"x\": 3.0, \"n\": -3}",
                        Expected = "0.03704",
                    },
                ],
                ProblemTags = [new() { Name = "Math" }, new() { Name = "Recursion" }],
            };

            var maxPointsOnLine = new Problem
            {
                ProblemName = "直線上最多的點數",
                Description = "給定二維平面上的點集合 points，找出位於同一條直線上的最多點數。",
                Difficulty = ProblemDifficultyEnums.Hard,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "max_points_on_line",
                        ProblemParameters =
                        [
                            new() { Type = "List[List[int]]", ParameterName = "points" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "maxPoints", ReturnType = "int" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "MaxPoints",
                        ProblemParameters = [new() { Type = "int[][]", ParameterName = "points" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "maxPoints", ReturnType = "int" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"points\": [[1, 1], [2, 2], [3, 3]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"points\": [[1, 1], [3, 2], [5, 3], [4, 1], [2, 3], [1, 4]]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"points\": [[0, 0]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"points\": [[0, 0], [1, 1]]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"points\": [[1, 1], [1, 1], [1, 1]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"points\": [[0, 1], [1, 1], [2, 1]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"points\": [[1, 0], [1, 1], [1, -1]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"points\": [[0, 0], [1, 1], [2, 2], [0, 1]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"points\": [[2, 3], [3, 3], [-5, 3]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"points\": [[1, 1], [2, 3], [3, 5], [4, 7]]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"points\": [[1, 1], [2, 2], [3, 3]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"points\": [[1, 1], [3, 2], [5, 3], [4, 1], [2, 3], [1, 4]]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"points\": [[0, 0]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"points\": [[0, 0], [1, 1]]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"points\": [[1, 1], [1, 1], [1, 1]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"points\": [[0, 1], [1, 1], [2, 1]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"points\": [[1, 0], [1, 1], [1, -1]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"points\": [[0, 0], [1, 1], [2, 2], [0, 1]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"points\": [[2, 3], [3, 3], [-5, 3]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"points\": [[1, 1], [2, 3], [3, 5], [4, 7]]}",
                        Expected = "4",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Hash Table" },
                    new() { Name = "Math" },
                    new() { Name = "Geometry" },
                ],
            };

            var houseRobber = new Problem
            {
                ProblemName = "打家劫舍",
                Description =
                    "給定代表每間房屋金額的陣列 nums，不偷竊相鄰兩間房屋，計算可偷竊的最高總金額。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "rob",
                        ProblemParameters = [new() { Type = "List[int]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "maxAmount", ReturnType = "int" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "Rob",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "nums" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "maxAmount", ReturnType = "int" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 1]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 7, 9, 3, 1]}",
                        Expected = "12",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": []}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 1]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, 5, 10, 100, 10, 5]}",
                        Expected = "110",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 1, 1, 1, 1]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 0, 0]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [4, 1, 2, 7, 5, 3, 1]}",
                        Expected = "14",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 1]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 7, 9, 3, 1]}",
                        Expected = "12",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": []}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 1]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, 5, 10, 100, 10, 5]}",
                        Expected = "110",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 1, 1, 1, 1]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 0, 0]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [4, 1, 2, 7, 5, 3, 1]}",
                        Expected = "14",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Dynamic Programming" }],
            };

            var wordBreak = new Problem
            {
                ProblemName = "單字拆分",
                Description = "給定字串 s 和單字字典 wordDict，判斷是否可用字典單字拼接組成 s。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "word_break",
                        ProblemParameters =
                        [
                            new() { Type = "str", ParameterName = "s" },
                            new() { Type = "List[str]", ParameterName = "wordDict" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "canBreak", ReturnType = "bool" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "WordBreak",
                        ProblemParameters =
                        [
                            new() { Type = "string", ParameterName = "s" },
                            new() { Type = "string[]", ParameterName = "wordDict" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "canBreak", ReturnType = "bool" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"leetcode\", \"wordDict\": [\"leet\", \"code\"]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"applepenapple\", \"wordDict\": [\"apple\", \"pen\"]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"s\": \"catsandog\", \"wordDict\": [\"cats\", \"dog\", \"sand\", \"and\", \"cat\"]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"\", \"wordDict\": [\"a\"]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"a\", \"wordDict\": [\"a\"]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"a\", \"wordDict\": [\"b\"]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"aaaaaaa\", \"wordDict\": [\"aaaa\", \"aaa\"]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"cars\", \"wordDict\": [\"car\", \"ca\", \"rs\"]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"abcd\", \"wordDict\": [\"a\", \"abc\", \"b\", \"cd\"]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"ab\", \"wordDict\": [\"a\", \"b\"]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"leetcode\", \"wordDict\": [\"leet\", \"code\"]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"applepenapple\", \"wordDict\": [\"apple\", \"pen\"]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"s\": \"catsandog\", \"wordDict\": [\"cats\", \"dog\", \"sand\", \"and\", \"cat\"]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"\", \"wordDict\": [\"a\"]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"a\", \"wordDict\": [\"a\"]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"a\", \"wordDict\": [\"b\"]}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"aaaaaaa\", \"wordDict\": [\"aaaa\", \"aaa\"]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"cars\", \"wordDict\": [\"car\", \"ca\", \"rs\"]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"abcd\", \"wordDict\": [\"a\", \"abc\", \"b\", \"cd\"]}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"ab\", \"wordDict\": [\"a\", \"b\"]}",
                        Expected = "true",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Hash Table" },
                    new() { Name = "String" },
                    new() { Name = "Dynamic Programming" },
                    new() { Name = "Trie" },
                    new() { Name = "Memoization" },
                ],
            };

            var coinChange = new Problem
            {
                ProblemName = "零錢兌換",
                Description =
                    "給定硬幣面額陣列 coins 與總金額 amount，計算湊成總金額所需最少硬幣數量；無法湊成則回傳 -1。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "coin_change",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "coins" },
                            new() { Type = "int", ParameterName = "amount" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "minCoins", ReturnType = "int" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "CoinChange",
                        ProblemParameters =
                        [
                            new() { Type = "int[]", ParameterName = "coins" },
                            new() { Type = "int", ParameterName = "amount" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "minCoins", ReturnType = "int" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"coins\": [1, 2, 5], \"amount\": 11}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"coins\": [2], \"amount\": 3}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"coins\": [1], \"amount\": 0}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"coins\": [1], \"amount\": 1}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"coins\": [1], \"amount\": 2}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"coins\": [2, 5, 10, 1], \"amount\": 27}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"coins\": [186, 419, 83, 408], \"amount\": 6249}",
                        Expected = "20",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"coins\": [1, 2, 5], \"amount\": 100}",
                        Expected = "20",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"coins\": [5], \"amount\": 5}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"coins\": [3, 7], \"amount\": 11}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"coins\": [1, 2, 5], \"amount\": 11}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"coins\": [2], \"amount\": 3}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"coins\": [1], \"amount\": 0}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"coins\": [1], \"amount\": 1}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"coins\": [1], \"amount\": 2}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"coins\": [2, 5, 10, 1], \"amount\": 27}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"coins\": [186, 419, 83, 408], \"amount\": 6249}",
                        Expected = "20",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"coins\": [1, 2, 5], \"amount\": 100}",
                        Expected = "20",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"coins\": [5], \"amount\": 5}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"coins\": [3, 7], \"amount\": 11}",
                        Expected = "-1",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Dynamic Programming" },
                    new() { Name = "Breadth-First Search" },
                ],
            };

            var longestIncreasingSubsequence = new Problem
            {
                ProblemName = "最長遞增子序列",
                Description = "給定整數陣列 nums，找出最長嚴格遞增子序列的長度。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "length_of_lis",
                        ProblemParameters = [new() { Type = "List[int]", ParameterName = "nums" }],
                        ProblemReturnTypes = [new() { ReturnName = "length", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "LengthOfLIS",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "nums" }],
                        ProblemReturnTypes = [new() { ReturnName = "length", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [10, 9, 2, 5, 3, 7, 101, 18]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [0, 1, 0, 3, 2, 3]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [7, 7, 7, 7, 7, 7, 7]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": []}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 2, 3, 4, 5]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [5, 4, 3, 2, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [4, 10, 4, 3, 8, 9]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [1, 3, 6, 7, 9, 4, 10, 5, 6]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"nums\": [2, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [10, 9, 2, 5, 3, 7, 101, 18]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [0, 1, 0, 3, 2, 3]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [7, 7, 7, 7, 7, 7, 7]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": []}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 2, 3, 4, 5]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [5, 4, 3, 2, 1]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [4, 10, 4, 3, 8, 9]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [1, 3, 6, 7, 9, 4, 10, 5, 6]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"nums\": [2, 2]}",
                        Expected = "1",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Binary Search" },
                    new() { Name = "Dynamic Programming" },
                ],
            };

            var triangle = new Problem
            {
                ProblemName = "三角形最小路徑和",
                Description =
                    "給定三角形陣列 triangle，從頂部到底部每步移動到下一行相鄰節點，求最小路徑和。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "minimum_total",
                        ProblemParameters =
                        [
                            new() { Type = "List[List[int]]", ParameterName = "triangle" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "minSum", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "MinimumTotal",
                        ProblemParameters =
                        [
                            new() { Type = "List<List<int>>", ParameterName = "triangle" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "minSum", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"triangle\": [[2], [3, 4], [6, 5, 7], [4, 1, 8, 3]]}",
                        Expected = "11",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"triangle\": [[-10]]}",
                        Expected = "-10",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"triangle\": [[1], [2, 3]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"triangle\": [[1], [-2, -3]]}",
                        Expected = "-2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"triangle\": [[0], [0, 0], [0, 0, 0]]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"triangle\": [[5], [1, 2], [3, 4, 5]]}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"triangle\": [[2], [3, 4]]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"triangle\": [[-1], [2, 3], [1, -1, -3]]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"triangle\": [[1], [1, 1], [1, 1, 1], [1, 1, 1, 1]]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"triangle\": [[7], [3, 8], [8, 1, 0], [2, 7, 4, 4], [4, 5, 2, 6, 5]]}",
                        Expected = "17",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"triangle\": [[2], [3, 4], [6, 5, 7], [4, 1, 8, 3]]}",
                        Expected = "11",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"triangle\": [[-10]]}",
                        Expected = "-10",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"triangle\": [[1], [2, 3]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"triangle\": [[1], [-2, -3]]}",
                        Expected = "-2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"triangle\": [[0], [0, 0], [0, 0, 0]]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"triangle\": [[5], [1, 2], [3, 4, 5]]}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"triangle\": [[2], [3, 4]]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"triangle\": [[-1], [2, 3], [1, -1, -3]]}",
                        Expected = "-1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"triangle\": [[1], [1, 1], [1, 1, 1], [1, 1, 1, 1]]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"triangle\": [[7], [3, 8], [8, 1, 0], [2, 7, 4, 4], [4, 5, 2, 6, 5]]}",
                        Expected = "17",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Dynamic Programming" }],
            };

            var minimumPathSum = new Problem
            {
                ProblemName = "最小路徑和",
                Description =
                    "給定非負整數網格 grid，從左上到右下每次只能向右或向下移動，求路徑數字總和最小值。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "min_path_sum",
                        ProblemParameters =
                        [
                            new() { Type = "List[List[int]]", ParameterName = "grid" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "minSum", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "MinPathSum",
                        ProblemParameters = [new() { Type = "int[][]", ParameterName = "grid" }],
                        ProblemReturnTypes = [new() { ReturnName = "minSum", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"grid\": [[1, 3, 1], [1, 5, 1], [4, 2, 1]]}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"grid\": [[1, 2, 3], [4, 5, 6]]}",
                        Expected = "12",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"grid\": [[1]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"grid\": [[1, 2]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"grid\": [[1], [2]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"grid\": [[5, 5], [5, 5]]}",
                        Expected = "15",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"grid\": [[1, 2, 5], [3, 2, 1]]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"grid\": [[0, 0, 0], [0, 0, 0]]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"grid\": [[9, 1, 4, 8], [4, 7, 9, 2], [6, 2, 3, 5]]}",
                        Expected = "27",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"grid\": [[1, 1, 1], [1, 1, 1], [1, 1, 1]]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"grid\": [[1, 3, 1], [1, 5, 1], [4, 2, 1]]}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"grid\": [[1, 2, 3], [4, 5, 6]]}",
                        Expected = "12",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"grid\": [[1]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"grid\": [[1, 2]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"grid\": [[1], [2]]}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"grid\": [[5, 5], [5, 5]]}",
                        Expected = "15",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"grid\": [[1, 2, 5], [3, 2, 1]]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"grid\": [[0, 0, 0], [0, 0, 0]]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"grid\": [[9, 1, 4, 8], [4, 7, 9, 2], [6, 2, 3, 5]]}",
                        Expected = "27",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"grid\": [[1, 1, 1], [1, 1, 1], [1, 1, 1]]}",
                        Expected = "5",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Dynamic Programming" },
                    new() { Name = "Matrix" },
                ],
            };

            var uniquePathsIi = new Problem
            {
                ProblemName = "不同路徑 II",
                Description = "給定含障礙物的網格 obstacleGrid，從左上到右下求不同路徑的數量。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "unique_paths_with_obstacles",
                        ProblemParameters =
                        [
                            new() { Type = "List[List[int]]", ParameterName = "obstacleGrid" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "pathCount", ReturnType = "int" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "UniquePathsWithObstacles",
                        ProblemParameters =
                        [
                            new() { Type = "int[][]", ParameterName = "obstacleGrid" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "pathCount", ReturnType = "int" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"obstacleGrid\": [[0, 0, 0], [0, 1, 0], [0, 0, 0]]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"obstacleGrid\": [[0, 1], [0, 0]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"obstacleGrid\": [[0]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"obstacleGrid\": [[1]]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"obstacleGrid\": [[0, 0]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"obstacleGrid\": [[0], [0]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"obstacleGrid\": [[1, 0]]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"obstacleGrid\": [[0, 0, 0, 0]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"obstacleGrid\": [[0, 0], [1, 1], [0, 0]]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"obstacleGrid\": [[0, 0, 0], [0, 0, 0], [0, 0, 0]]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"obstacleGrid\": [[0, 0, 0], [0, 1, 0], [0, 0, 0]]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"obstacleGrid\": [[0, 1], [0, 0]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"obstacleGrid\": [[0]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"obstacleGrid\": [[1]]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"obstacleGrid\": [[0, 0]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"obstacleGrid\": [[0], [0]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"obstacleGrid\": [[1, 0]]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"obstacleGrid\": [[0, 0, 0, 0]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"obstacleGrid\": [[0, 0], [1, 1], [0, 0]]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"obstacleGrid\": [[0, 0, 0], [0, 0, 0], [0, 0, 0]]}",
                        Expected = "6",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Dynamic Programming" },
                    new() { Name = "Matrix" },
                ],
            };

            var longestPalindromicSubstringLength = new Problem
            {
                ProblemName = "最長回文子字串長度",
                Description = "給定字串 s，回傳其中最長回文子字串的長度。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "longest_palindrome_length",
                        ProblemParameters = [new() { Type = "str", ParameterName = "s" }],
                        ProblemReturnTypes = [new() { ReturnName = "length", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "LongestPalindromeLength",
                        ProblemParameters = [new() { Type = "string", ParameterName = "s" }],
                        ProblemReturnTypes = [new() { ReturnName = "length", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"babad\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"cbbd\"}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"a\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"\"}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"ac\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"racecar\"}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"abcdefg\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"aaaa\"}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"abacdfgdcaba\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s\": \"aabcdcb\"}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"babad\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"cbbd\"}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"a\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"\"}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"ac\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"racecar\"}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"abcdefg\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"aaaa\"}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"abacdfgdcaba\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s\": \"aabcdcb\"}",
                        Expected = "5",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Two Pointers" },
                    new() { Name = "String" },
                    new() { Name = "Dynamic Programming" },
                ],
            };

            var interleavingString = new Problem
            {
                ProblemName = "交錯字串",
                Description = "給定字串 s1、s2、s3，判斷 s3 是否由 s1 和 s2 交錯組成。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "is_interleave",
                        ProblemParameters =
                        [
                            new() { Type = "str", ParameterName = "s1" },
                            new() { Type = "str", ParameterName = "s2" },
                            new() { Type = "str", ParameterName = "s3" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "isInterleave", ReturnType = "bool" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "IsInterleave",
                        ProblemParameters =
                        [
                            new() { Type = "string", ParameterName = "s1" },
                            new() { Type = "string", ParameterName = "s2" },
                            new() { Type = "string", ParameterName = "s3" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "isInterleave", ReturnType = "bool" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s1\": \"aabcc\", \"s2\": \"dbbca\", \"s3\": \"aadbbcbcac\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s1\": \"aabcc\", \"s2\": \"dbbca\", \"s3\": \"aadbbbaccc\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s1\": \"\", \"s2\": \"\", \"s3\": \"\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s1\": \"a\", \"s2\": \"\", \"s3\": \"a\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s1\": \"\", \"s2\": \"b\", \"s3\": \"b\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s1\": \"a\", \"s2\": \"b\", \"s3\": \"ab\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s1\": \"a\", \"s2\": \"b\", \"s3\": \"ba\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s1\": \"abc\", \"s2\": \"def\", \"s3\": \"abdcef\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s1\": \"aa\", \"s2\": \"ab\", \"s3\": \"aaba\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"s1\": \"ab\", \"s2\": \"cd\", \"s3\": \"acbd\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s1\": \"aabcc\", \"s2\": \"dbbca\", \"s3\": \"aadbbcbcac\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s1\": \"aabcc\", \"s2\": \"dbbca\", \"s3\": \"aadbbbaccc\"}",
                        Expected = "false",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s1\": \"\", \"s2\": \"\", \"s3\": \"\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s1\": \"a\", \"s2\": \"\", \"s3\": \"a\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s1\": \"\", \"s2\": \"b\", \"s3\": \"b\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s1\": \"a\", \"s2\": \"b\", \"s3\": \"ab\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s1\": \"a\", \"s2\": \"b\", \"s3\": \"ba\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s1\": \"abc\", \"s2\": \"def\", \"s3\": \"abdcef\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s1\": \"aa\", \"s2\": \"ab\", \"s3\": \"aaba\"}",
                        Expected = "true",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"s1\": \"ab\", \"s2\": \"cd\", \"s3\": \"acbd\"}",
                        Expected = "true",
                    },
                ],
                ProblemTags = [new() { Name = "String" }, new() { Name = "Dynamic Programming" }],
            };

            var editDistance = new Problem
            {
                ProblemName = "編輯距離",
                Description =
                    "給定字串 word1 和 word2，計算將 word1 轉換成 word2 所需的最少操作次數。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "min_distance",
                        ProblemParameters =
                        [
                            new() { Type = "str", ParameterName = "word1" },
                            new() { Type = "str", ParameterName = "word2" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "distance", ReturnType = "int" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "MinDistance",
                        ProblemParameters =
                        [
                            new() { Type = "string", ParameterName = "word1" },
                            new() { Type = "string", ParameterName = "word2" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "distance", ReturnType = "int" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"word1\": \"horse\", \"word2\": \"ros\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"word1\": \"intention\", \"word2\": \"execution\"}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"word1\": \"\", \"word2\": \"\"}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"word1\": \"a\", \"word2\": \"\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"word1\": \"\", \"word2\": \"a\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"word1\": \"abc\", \"word2\": \"abc\"}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"word1\": \"a\", \"word2\": \"b\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"word1\": \"kitten\", \"word2\": \"sitting\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"word1\": \"abcdef\", \"word2\": \"azced\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"word1\": \"same\", \"word2\": \"same\"}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"word1\": \"horse\", \"word2\": \"ros\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"word1\": \"intention\", \"word2\": \"execution\"}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"word1\": \"\", \"word2\": \"\"}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"word1\": \"a\", \"word2\": \"\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"word1\": \"\", \"word2\": \"a\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"word1\": \"abc\", \"word2\": \"abc\"}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"word1\": \"a\", \"word2\": \"b\"}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"word1\": \"kitten\", \"word2\": \"sitting\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"word1\": \"abcdef\", \"word2\": \"azced\"}",
                        Expected = "3",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"word1\": \"same\", \"word2\": \"same\"}",
                        Expected = "0",
                    },
                ],
                ProblemTags = [new() { Name = "String" }, new() { Name = "Dynamic Programming" }],
            };

            var bestTimeBuySellStockIii = new Problem
            {
                ProblemName = "買賣股票的最佳時機 III",
                Description = "給定股價陣列 prices，最多可完成兩次交易，回傳能獲得的最大利潤。",
                Difficulty = ProblemDifficultyEnums.Hard,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "max_profit3",
                        ProblemParameters =
                        [
                            new() { Type = "List[int]", ParameterName = "prices" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "maxProfit", ReturnType = "int" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "MaxProfitIII",
                        ProblemParameters = [new() { Type = "int[]", ParameterName = "prices" }],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "maxProfit", ReturnType = "int" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [3, 3, 5, 0, 0, 3, 1, 4]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [1, 2, 3, 4, 5]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [7, 6, 4, 3, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": []}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [1, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [2, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [3, 2, 6, 5, 0, 3]}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [1, 2, 4, 2, 5, 7, 2, 4, 9, 0]}",
                        Expected = "13",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"prices\": [6, 1, 3, 2, 4, 7]}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [3, 3, 5, 0, 0, 3, 1, 4]}",
                        Expected = "6",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [1, 2, 3, 4, 5]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [7, 6, 4, 3, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": []}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [1, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [2, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [3, 2, 6, 5, 0, 3]}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [1, 2, 4, 2, 5, 7, 2, 4, 9, 0]}",
                        Expected = "13",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"prices\": [6, 1, 3, 2, 4, 7]}",
                        Expected = "7",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Dynamic Programming" }],
            };

            var bestTimeBuySellStockIv = new Problem
            {
                ProblemName = "買賣股票的最佳時機 IV",
                Description =
                    "給定股價陣列 prices 與整數 k，最多可完成 k 次交易，回傳能獲得的最大利潤。",
                Difficulty = ProblemDifficultyEnums.Hard,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "max_profit4",
                        ProblemParameters =
                        [
                            new() { Type = "int", ParameterName = "k" },
                            new() { Type = "List[int]", ParameterName = "prices" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "maxProfit", ReturnType = "int" },
                        ],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "MaxProfitIV",
                        ProblemParameters =
                        [
                            new() { Type = "int", ParameterName = "k" },
                            new() { Type = "int[]", ParameterName = "prices" },
                        ],
                        ProblemReturnTypes =
                        [
                            new() { ReturnName = "maxProfit", ReturnType = "int" },
                        ],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"k\": 2, \"prices\": [2, 4, 1]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"k\": 2, \"prices\": [3, 2, 6, 5, 0, 3]}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"k\": 0, \"prices\": [1, 2, 3]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"k\": 1, \"prices\": [1, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"k\": 1, \"prices\": [2, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"k\": 2, \"prices\": []}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"k\": 2, \"prices\": [1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"k\": 3, \"prices\": [1, 2, 4, 2, 5, 7, 2, 4, 9, 0]}",
                        Expected = "15",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"k\": 1, \"prices\": [7, 1, 5, 3, 6, 4]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"k\": 100, \"prices\": [1, 2, 3, 4, 5]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"k\": 2, \"prices\": [2, 4, 1]}",
                        Expected = "2",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"k\": 2, \"prices\": [3, 2, 6, 5, 0, 3]}",
                        Expected = "7",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"k\": 0, \"prices\": [1, 2, 3]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"k\": 1, \"prices\": [1, 2]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"k\": 1, \"prices\": [2, 1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"k\": 2, \"prices\": []}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"k\": 2, \"prices\": [1]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"k\": 3, \"prices\": [1, 2, 4, 2, 5, 7, 2, 4, 9, 0]}",
                        Expected = "15",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"k\": 1, \"prices\": [7, 1, 5, 3, 6, 4]}",
                        Expected = "5",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"k\": 100, \"prices\": [1, 2, 3, 4, 5]}",
                        Expected = "4",
                    },
                ],
                ProblemTags = [new() { Name = "Array" }, new() { Name = "Dynamic Programming" }],
            };

            var maximalSquare = new Problem
            {
                ProblemName = "最大正方形",
                Description =
                    "給定由 '0' 和 '1' 組成的二維矩陣 matrix，找出只含 '1' 的最大正方形並回傳其面積。",
                Difficulty = ProblemDifficultyEnums.Medium,
                CreateDate = now,
                UpdateDate = now,
                ProblemSignatures =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        FunctionName = "maximal_square",
                        ProblemParameters =
                        [
                            new() { Type = "List[List[str]]", ParameterName = "matrix" },
                        ],
                        ProblemReturnTypes = [new() { ReturnName = "area", ReturnType = "int" }],
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        FunctionName = "MaximalSquare",
                        ProblemParameters = [new() { Type = "char[][]", ParameterName = "matrix" }],
                        ProblemReturnTypes = [new() { ReturnName = "area", ReturnType = "int" }],
                    },
                ],
                Functions =
                [
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"matrix\": [[\"1\", \"0\", \"1\", \"0\", \"0\"], [\"1\", \"0\", \"1\", \"1\", \"1\"], [\"1\", \"1\", \"1\", \"1\", \"1\"], [\"1\", \"0\", \"0\", \"1\", \"0\"]]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[\"0\", \"1\"], [\"1\", \"0\"]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[\"0\"]]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[\"1\"]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[\"1\", \"1\"], [\"1\", \"1\"]]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input = "{\"matrix\": [[\"0\", \"0\"], [\"0\", \"0\"]]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"matrix\": [[\"1\", \"1\", \"1\"], [\"1\", \"1\", \"1\"], [\"1\", \"1\", \"1\"]]}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"matrix\": [[\"1\", \"0\", \"1\"], [\"1\", \"0\", \"1\"], [\"1\", \"1\", \"1\"]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"matrix\": [[\"1\", \"1\", \"1\", \"1\", \"1\"], [\"1\", \"1\", \"1\", \"1\", \"1\"], [\"1\", \"1\", \"1\", \"1\", \"1\"], [\"1\", \"1\", \"1\", \"1\", \"1\"], [\"1\", \"1\", \"1\", \"1\", \"1\"]]}",
                        Expected = "25",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.python,
                        Input =
                            "{\"matrix\": [[\"0\", \"1\", \"1\"], [\"1\", \"1\", \"1\"], [\"0\", \"1\", \"1\"]]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"matrix\": [[\"1\", \"0\", \"1\", \"0\", \"0\"], [\"1\", \"0\", \"1\", \"1\", \"1\"], [\"1\", \"1\", \"1\", \"1\", \"1\"], [\"1\", \"0\", \"0\", \"1\", \"0\"]]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[\"0\", \"1\"], [\"1\", \"0\"]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[\"0\"]]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[\"1\"]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[\"1\", \"1\"], [\"1\", \"1\"]]}",
                        Expected = "4",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input = "{\"matrix\": [[\"0\", \"0\"], [\"0\", \"0\"]]}",
                        Expected = "0",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"matrix\": [[\"1\", \"1\", \"1\"], [\"1\", \"1\", \"1\"], [\"1\", \"1\", \"1\"]]}",
                        Expected = "9",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"matrix\": [[\"1\", \"0\", \"1\"], [\"1\", \"0\", \"1\"], [\"1\", \"1\", \"1\"]]}",
                        Expected = "1",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"matrix\": [[\"1\", \"1\", \"1\", \"1\", \"1\"], [\"1\", \"1\", \"1\", \"1\", \"1\"], [\"1\", \"1\", \"1\", \"1\", \"1\"], [\"1\", \"1\", \"1\", \"1\", \"1\"], [\"1\", \"1\", \"1\", \"1\", \"1\"]]}",
                        Expected = "25",
                    },
                    new()
                    {
                        Language = JudgeLanguageEnum.csharp,
                        Input =
                            "{\"matrix\": [[\"0\", \"1\", \"1\"], [\"1\", \"1\", \"1\"], [\"0\", \"1\", \"1\"]]}",
                        Expected = "4",
                    },
                ],
                ProblemTags =
                [
                    new() { Name = "Array" },
                    new() { Name = "Dynamic Programming" },
                    new() { Name = "Matrix" },
                ],
            };

            context.Problems.AddRange(
                mergeSortedArray,
                removeElement,
                removeDuplicatesSortedArray,
                removeDuplicatesSortedArrayIi,
                majorityElement,
                rotateArray,
                bestTimeBuySellStock,
                bestTimeBuySellStockIi,
                jumpGame,
                jumpGameIi,
                hIndex,
                productOfArrayExceptSelf,
                gasStation,
                candy,
                trappingRainWater,
                romanToInteger,
                integerToRoman,
                lengthOfLastWord,
                longestCommonPrefix,
                reverseWordsInString,
                zigzagConversion,
                findFirstOccurrenceInString,
                textJustification,
                validPalindrome,
                isSubsequence,
                containerWithMostWater,
                twoSumIiSorted,
                threeSum,
                happyNumber,
                longestSubstringWithoutRepeat,
                minimumWindowSubstring,
                substringConcatAllWords,
                minimumSizeSubarraySum,
                validSudoku,
                spiralMatrix,
                rotateImage,
                setMatrixZeroes,
                gameOfLife,
                ransomNote,
                isomorphicStrings,
                wordPattern,
                validAnagram,
                groupAnagrams,
                containsDuplicate,
                containsDuplicateIi,
                longestConsecutiveSequence,
                summaryRanges,
                mergeIntervals,
                insertInterval,
                minArrowsBurstBalloons,
                validParentheses,
                simplifyPath,
                evaluateReversePolishNotation,
                basicCalculator,
                numberOfIslands,
                surroundedRegions,
                evaluateDivision,
                courseSchedule,
                courseScheduleIi,
                snakesAndLadders,
                minimumGeneticMutation,
                wordLadder,
                wordSearchIi,
                letterCombinationsPhone,
                combinations,
                permutations,
                combinationSum,
                nQueensIi,
                generateParentheses,
                wordSearch,
                maximumSubarray,
                maxSumCircularSubarray,
                searchInsertPosition,
                search2dMatrix,
                findPeakElement,
                searchInRotatedSortedArray,
                findFirstLastPosition,
                findMinimumRotatedSortedArray,
                medianOfTwoSortedArrays,
                kthLargestElement,
                ipo,
                findKPairsSmallestSums,
                addBinary,
                reverseBits,
                numberOf1Bits,
                singleNumber,
                singleNumberIi,
                bitwiseAndNumbersRange,
                palindromeNumber,
                plusOne,
                factorialTrailingZeroes,
                sqrtX,
                powXN,
                maxPointsOnLine,
                houseRobber,
                wordBreak,
                coinChange,
                longestIncreasingSubsequence,
                triangle,
                minimumPathSum,
                uniquePathsIi,
                longestPalindromicSubstringLength,
                interleavingString,
                editDistance,
                bestTimeBuySellStockIii,
                bestTimeBuySellStockIv,
                maximalSquare
            );
            await context.SaveChangesAsync();
        }
    }
}
