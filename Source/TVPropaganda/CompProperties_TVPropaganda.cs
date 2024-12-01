using Verse;

namespace TVPropaganda;

public class CompProperties_TVPropaganda : CompProperties
{
    public float TVeffectFactor;

    public int TVeffectRadius;

    public CompProperties_TVPropaganda()
    {
        compClass = typeof(CompTVPropaganda);
    }
}