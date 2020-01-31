public class CharacterInfoWrapper
{
    public TeamColor color;
    public RagdollType type;

    public TeamColor GetTeamColor()
    {
        return color;
    }

    public void SetTeamColor(TeamColor teamColor)
    {
        color = teamColor;
    }

    public RagdollType GetRagdollType()
    {
        return type;
    }

    public void SetRagdollType(RagdollType ragdollType)
    {
        type = ragdollType;
    }
}
