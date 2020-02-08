public static class GameMode
{
    public enum Mode
    {
        RagBall,
        RagOfTheHill,
        CaptureTheRag
    }

    public static int Count
    {
        get { return EnumHelper.GetCount<Mode>(); }
    }
}
