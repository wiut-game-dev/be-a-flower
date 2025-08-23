using System;

public class VisualState : IEquatable<VisualState>
{
	public int LeafCount;
	public int FlowerCount;
	public int LeafPrimaryPhase;
	public int LeafSecondaryPhase;
	public int StemPrimaryPhase;
	public int StemSecondaryPhase;
	public int RootPrimaryPhase;
	public int RootSecondaryPhase;

	public static explicit operator VisualState(GeneralState state)
	{
		return new(state.LeafCount, state.FlowerCount, state.LeafPrimaryPhase, state.LeafSecondaryPhase, state.StemPrimaryPhase, state.StemSecondaryPhase, state.RootPrimaryPhase, state.RootSecondaryPhase);
	}

	public VisualState(int leafCount, int flowerCount, int leafPrimaryPhase, int leafSecondaryPhase, int stemPrimaryPhase, int stemSecondaryPhase, int rootPrimaryPhase, int rootSecondaryPhase)
	{
		LeafCount = leafCount;
		FlowerCount = flowerCount;
		LeafPrimaryPhase = leafPrimaryPhase;
		LeafSecondaryPhase = leafSecondaryPhase;
		StemPrimaryPhase = stemPrimaryPhase;
		StemSecondaryPhase = stemSecondaryPhase;
		RootPrimaryPhase = rootPrimaryPhase;
		RootSecondaryPhase = rootSecondaryPhase;
	}

	public bool Equals(VisualState other)
	{
		if(other is null)
			return false;
		return LeafCount == other.LeafCount && FlowerCount == other.FlowerCount && LeafPrimaryPhase == other.LeafPrimaryPhase && LeafSecondaryPhase == other.LeafSecondaryPhase && StemPrimaryPhase == other.StemPrimaryPhase && StemSecondaryPhase == other.StemSecondaryPhase && RootPrimaryPhase == other.RootPrimaryPhase && RootSecondaryPhase == other.RootSecondaryPhase;
	}

	public override bool Equals(object obj)
	{
		return base.Equals(obj);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static bool operator ==(VisualState a, VisualState b) => a.Equals(b);
	public static bool operator !=(VisualState a, VisualState b) => !a.Equals(b);
}