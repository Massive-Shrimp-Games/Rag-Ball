public static class MenuActions
{
    public delegate void MenuAction();
    public static event MenuAction _ToGameMode;
    public static event MenuAction _ToLevelSelect;
    public static event MenuAction _ToCharacterSelect;

    public static void ToGameMode()
    {
        _ToGameMode();
    }

    public static void ToLevelSelect()
    {
        _ToLevelSelect();
    }

    public static void ToCharacterSelect()
    {
        _ToCharacterSelect();
    }
}
