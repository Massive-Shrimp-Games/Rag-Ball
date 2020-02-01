public static class EnumHelper
{
    public static int GetCount<T>()
    {
        return System.Enum.GetNames(typeof(T)).Length;
    }
}
