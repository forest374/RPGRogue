using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : MonoBehaviour
{
    public abstract Skills Skill { get; }

    public abstract void UseSkill();
}
