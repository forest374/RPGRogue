using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    public int MyNum { get; set; } = default;
    public override void Attack()
    {
        int atk = Status.ATK;
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
            BattleManager.Instance.EnemyDown(this);
            gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }
}
