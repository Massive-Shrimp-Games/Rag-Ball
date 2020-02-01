public static class GameLevel
{
    public enum Level
    {
        Court1,
        Court2
    }

    public static int Count
    {
        get { return EnumHelper.GetCount<Level>(); }
    }
}
