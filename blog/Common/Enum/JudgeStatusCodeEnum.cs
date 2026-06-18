namespace blog.Common.Enum
{
    public enum JudgeLanguageEnum
    {
        python = 1,
        csharp = 2,
    }

    public enum JudgeStatusCodeEnum
    {
        Timeout = 124,
    }

    public enum JudgeErrorMsg
    {
        Time_Limit_Exceeded,
        Unsupported_language,
    }

    public enum SubmissionStatus
    {
        /// <summary>
        /// Accepted：所有測試案例皆通過
        /// </summary>
        AC,

        /// <summary>
        /// Wrong Answer：輸出結果與預期不符
        /// </summary>
        WA,

        /// <summary>
        /// Time Limit Exceeded：執行時間超過限制
        /// </summary>
        TLE,

        /// <summary>
        /// Runtime Error：執行過程中發生例外或崩潰
        /// </summary>
        RE,
    }

    public enum TestResultSymbolEnum
    {
        RESULT,
        ERROR,
    }

    public enum ProblemDifficultyEnums
    {
        Easy,
        Medium,
        Hard,
    }
}
