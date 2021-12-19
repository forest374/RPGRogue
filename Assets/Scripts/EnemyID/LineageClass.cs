using System;
using UnityEngine;

public class Bug : IDBase
{
    public SpeciesID m_id = default;
    public override LineAge lineAge => LineAge.Bug;
    public override int SpeciesNum => Enum.GetNames(typeof(SpeciesID)).Length;

    //
    public override string Species(int id)
    {
        if (Enum.IsDefined(typeof(SpeciesID), id))
            m_id = (SpeciesID)id;
        return m_id.ToString();
    }
    public enum SpeciesID
    {
        げじげじ,
    }

}
public class Slime : IDBase
{
    public SpeciesID m_id = default;
    public override LineAge lineAge => LineAge.Slime;
    public override int SpeciesNum => Enum.GetNames(typeof(SpeciesID)).Length;

    //
    public override string Species(int id)
    {
        if (Enum.IsDefined(typeof(SpeciesID), id))
            m_id = (SpeciesID)id;
        return m_id.ToString();
    }

    public enum SpeciesID
    {
        スライム,
    }
}
public class Ogre : IDBase
{
    public SpeciesID m_id = default;
    public override LineAge lineAge => LineAge.Ogre;
    public override int SpeciesNum => Enum.GetNames(typeof(SpeciesID)).Length;

    //
    public override string Species(int id)
    {
        if (Enum.IsDefined(typeof(SpeciesID), id))
            m_id = (SpeciesID)id;
        return m_id.ToString();
    }
    public enum SpeciesID
    {
        ゴブリン,
    }
}

public class Beast : IDBase
{
    public SpeciesID m_id = default;

    public override LineAge lineAge => LineAge.Beast;
    public override int SpeciesNum => Enum.GetNames(typeof(SpeciesID)).Length;

    //
    public override string Species(int id)
    {
        if (Enum.IsDefined(typeof(SpeciesID), id))
            m_id = (SpeciesID)id;
        return m_id.ToString();
    }
    public enum SpeciesID
    {
        ねこ,
    }
}
public class Bird : IDBase
{
    public SpeciesID m_id = default;
    public override LineAge lineAge => LineAge.Bird;
    public override int SpeciesNum => Enum.GetNames(typeof(SpeciesID)).Length;

    //
    public override string Species(int id)
    {
        if (Enum.IsDefined(typeof(SpeciesID), id))
            m_id = (SpeciesID)id;
        return m_id.ToString();
    }
    public enum SpeciesID
    {
        からす,
    }
}
public class Devil : IDBase
{
    public SpeciesID m_id = default;
    public override LineAge lineAge => LineAge.Devil;
    public override int SpeciesNum => Enum.GetNames(typeof(SpeciesID)).Length;

    //
    public override string Species(int id)
    {
        if (Enum.IsDefined(typeof(SpeciesID), id))
            m_id = (SpeciesID)id;
        return m_id.ToString();
    }
    public enum SpeciesID
    {
        レッサーデーモン,
    }

}
public class Fish : IDBase
{
    public SpeciesID m_id = default;
    public override LineAge lineAge => LineAge.Fish;
    public override int SpeciesNum => Enum.GetNames(typeof(SpeciesID)).Length;

    //
    public override string Species(int id)
    {
        if (Enum.IsDefined(typeof(SpeciesID), id))
            m_id = (SpeciesID)id;
        return m_id.ToString();
    }
    public enum SpeciesID
    {
        サーモン,
    }

}
public class Machine : IDBase
{
    public SpeciesID m_id = default;
    public override LineAge lineAge => LineAge.Machine;
    public override int SpeciesNum => Enum.GetNames(typeof(SpeciesID)).Length;

    //
    public override string Species(int id)
    {
        if (Enum.IsDefined(typeof(SpeciesID), id))
            m_id = (SpeciesID)id;
        return m_id.ToString();
    }
    public enum SpeciesID
    {
        ゴーレム,
    }

}

