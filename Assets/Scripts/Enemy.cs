using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    public int MyNum { get; set; } = default;
    public override void Attack()
    {
        int atk = m_basisStatus.ATK + m_equipment.ATK;
        BattleManager.Instance.EnemyAttack(atk);
    }
    protected override void Defence()
    {

    }
    protected override void Skill()
    {

    }
    public override void Damege(int damege)
    {
        base.Damege(damege);
        if (m_currentHp <= 0)
        {
            BattleManager.Instance.EnemyDead(this);
            Destroy(this.gameObject);
        }
    }
}
