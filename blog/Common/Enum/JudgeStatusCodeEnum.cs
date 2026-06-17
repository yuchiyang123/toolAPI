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
        AC,
        WA,
        TLE,
        RE,
    }

    public enum TestResultSymbolEnum
    {
        RESULT,
        ERROR,
    }
}
