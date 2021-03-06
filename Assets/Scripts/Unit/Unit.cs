using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    //[SerializeField, Header("基本ステータス")]
    //protected UnitStatus m_basisStatus = default;
    protected int m_currentHp = default;
    protected int m_currentMp = default;
    //[Header("装備品の合計値")]
    //protected UnitStatus m_equipment = default;

    public virtual BaseStatus Status { get; set; }
    public int m_time = 100;


    protected virtual void Start()
    {
        m_currentHp = Status.HP;
        m_currentMp = Status.MP;
    }
    public abstract void Attack();
    protected abstract void Defence();
    protected abstract void Skill();

    public virtual void Damege(int atk)
    {
        int damege = atk - (Status.DEF / 2);
        if (damege <= 0)
        {
            damege = 1;
        }
        m_currentHp -= damege;

        Debug.Log(name + "は" + damege + "のダメージを受けた");
        if (m_currentHp <= 0)
        {
            Debug.Log(name + "は倒れた");
        }
    }
}
