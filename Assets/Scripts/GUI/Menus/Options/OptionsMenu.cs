public static class OptionsMenu
{
    public static float dashSpeed = 8000f;
    public static float jumpHeight = 12000f;
    public static int staggerDuration = 4;
    public static float staminaRegenRate = 1.5f;
    public delegate void OptionsChange();
    public static OptionsChange OptionsChangeEvent;
}
