using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum Skills
{
    BodyBlow, Slash,
}

public class SkillList
{
    SkillBase[] m_skillBases =
    {
        new BodyBlow(),
        new Slash(),
    };


    public SkillBase Create(Skills skill)
    {
        return m_skillBases.SingleOrDefault(iD => iD.Skill == skill);
    }
}
