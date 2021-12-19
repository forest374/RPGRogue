using UnityEngine;

public abstract class IDBase
{
    public abstract LineAge lineAge { get; }

    public abstract int SpeciesNum { get; }
    public abstract string Species(int id);
}
