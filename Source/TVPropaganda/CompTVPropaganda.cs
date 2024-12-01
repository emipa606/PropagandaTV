using System;
using System.Linq;
using RimWorld;
using Verse;

namespace TVPropaganda;

public class CompTVPropaganda : ThingComp
{
    public CompProperties_TVPropaganda Props => (CompProperties_TVPropaganda)props;

    public Building TVP => parent as Building;

    public override void CompTick()
    {
        base.CompTick();
        if (Find.TickManager.TicksGame % 1000 != 0 || !IsFunctional(TVP))
        {
            return;
        }

        var list = GenRadial.RadialCellsAround(TVP.Position, Math.Min(20, Props.TVeffectRadius), true).ToList();
        if (list.Count <= 0)
        {
            return;
        }

        foreach (var item in list)
        {
            try
            {
                if (!IsValidCell(item, TVP))
                {
                    continue;
                }
            }
            catch (Exception)
            {
                // ignored
            }

            var thingList = item.GetThingList(TVP.Map);
            if (thingList.Count <= 0)
            {
                continue;
            }

            foreach (var thing in thingList)
            {
                if (thing is not Pawn pawn || !IsValidPawn(pawn) || !HasCertainty(pawn))
                {
                    continue;
                }

                var certainty = pawn.ideo.Certainty;
                var zero = 0f;
                if (!(certainty > zero) || certainty.Equals(null))
                {
                    continue;
                }

                var effectiveness = 1f;
                if (pawn.needs?.mood != null)
                {
                    effectiveness *= pawn.needs.mood.CurLevel * Math.Min(1f, Props.TVeffectFactor);
                }

                effectiveness *= pawn.health.capacities.GetLevel(PawnCapacityDefOf.Sight);
                effectiveness *= pawn.health.capacities.GetLevel(PawnCapacityDefOf.Hearing);
                var techLevel = TechLevel.Industrial;
                if (pawn.Faction != null)
                {
                    techLevel = pawn.Faction.def.techLevel;
                }

                switch (techLevel)
                {
                    case TechLevel.Animal:
                        effectiveness *= 0.7f;
                        break;
                    case TechLevel.Neolithic:
                        effectiveness *= 0.8f;
                        break;
                    case TechLevel.Medieval:
                        effectiveness *= 0.9f;
                        break;
                    case TechLevel.Spacer:
                        effectiveness *= 0.9f;
                        break;
                    case TechLevel.Ultra:
                        effectiveness *= 0.8f;
                        break;
                    case TechLevel.Archotech:
                        effectiveness *= 0.7f;
                        break;
                }

                if (!(Math.Min(1f, effectiveness) > 0f))
                {
                    continue;
                }

                var primaryIdeo = Faction.OfPlayer.ideos.PrimaryIdeo;
                var ideo = pawn.Ideo;
                if (primaryIdeo != ideo)
                {
                    var reduceBy = Math.Min(0.25f, certainty / 10f * effectiveness);
                    pawn.ideo.Debug_ReduceCertainty(reduceBy);
                    if (certainty - reduceBy < 0.025f)
                    {
                        Messages.Message("TVPropaganda.willbroken".Translate(pawn.LabelShort),
                            MessageTypeDefOf.NeutralEvent);
                        var playerIdeology = GetPlayerIdeology();
                        pawn.ideo.SetIdeo(playerIdeology);
                    }
                    else
                    {
                        certainty -= reduceBy;
                    }
                }

                var increaseBy = Math.Min(0.25f, certainty / 10f * effectiveness);
                if (ideo == primaryIdeo && pawn.ideo.Certainty != 1f)
                {
                    if (certainty + increaseBy > 1f)
                    {
                        increaseBy = 1f - certainty;
                    }

                    pawn.ideo.Debug_ReduceCertainty(-increaseBy);
                }

                if (TVP.def.description.Contains("radio"))
                {
                    GiveRadioThought(pawn);
                }
                else
                {
                    GiveTVThought(pawn);
                }
            }
        }
    }

    public void GiveTVThought(Pawn pawn)
    {
        try
        {
            if (pawn == null || pawn.needs?.mood == null)
            {
                return;
            }

            var named = DefDatabase<ThoughtDef>.GetNamed("TVPropaganda", false);
            if (named != null)
            {
                pawn.needs.mood.thoughts.memories.TryGainMemory(named);
            }
        }
        catch (Exception exception)
        {
            Log.Message($"TVPropaganda: Exception Thrown in GiveTVThought {exception}");
        }
    }

    public void GiveRadioThought(Pawn pawn)
    {
        try
        {
            if (pawn == null || pawn.needs?.mood == null)
            {
                return;
            }

            var named = DefDatabase<ThoughtDef>.GetNamed("RadioPropaganda", false);
            if (named != null)
            {
                pawn.needs.mood.thoughts.memories.TryGainMemory(named);
            }
        }
        catch (Exception exception)
        {
            Log.Message($"TVPropaganda: Exception Thrown in Give Radio Thought {exception}");
        }
    }

    public bool HasCertainty(Pawn pawn)
    {
        try
        {
            var certainty = pawn.ideo.Certainty;
            certainty = (float)Math.Round(certainty, 2);
            return 0.0 <= certainty && certainty <= 0.99 && !pawn.IsPrisoner && !certainty.Equals(null);
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool IsFunctional(Building building)
    {
        try
        {
            return !building.DestroyedOrNull() && building.Map != null && building.Spawned &&
                   building.TryGetComp<CompPowerTrader>().PowerOn &&
                   !building.IsBrokenDown();
        }
        catch (Exception exception)
        {
            Log.Message($"Building Functional but we got a dangol Exeption {exception}");
            return false;
        }
    }

    public bool IsValidCell(IntVec3 cell, Building building)
    {
        return cell.InBounds(building.Map);
    }

    public bool IsValidPawn(Pawn pawn)
    {
        try
        {
            return !pawn.Dead && pawn.Awake() && !pawn.IsBurning() && !pawn.InMentalState &&
                   (pawn.IsColonist || pawn.IsSlaveOfColony || pawn.IsPrisonerOfColony);
        }
        catch (Exception exception)
        {
            Log.Message($"{pawn.LabelShortCap} Threw an Exception in IsValidPawn: {exception}");
            return false;
        }
    }

    public static Ideo GetPlayerIdeology()
    {
        Faction.OfPlayer.ideos.AllIdeos.Where(ideo => Faction.OfPlayer.ideos.PrimaryIdeo.id == ideo.id)
            .TryRandomElement(out var result);
        return result;
    }
}