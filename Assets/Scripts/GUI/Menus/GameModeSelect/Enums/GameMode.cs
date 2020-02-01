public static class GameMode
{
    public enum Mode
    {
        RagBall,
        RagOfTheHill,
        LazerRag
    }

    public static int Count
    {
        get { return EnumHelper.GetCount<Mode>(); }
    }
}
