using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField]
    protected UnitStatus m_status = default;
    protected UnitStatus m_changedValue = default;


    protected virtual void Start()
    {
    }
    protected abstract void Attack();
    protected abstract void Defence();
    protected abstract void Skill();

    public virtual void Damege(int damege)
    {
        m_status.HP -= m_status.DEF - damege;
    }
}
