using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public override void Attack()
    {
        int atk = m_basisStatus.ATK + m_equipment.ATK;
        BattleManager.Instance.PlayerAttack(atk);
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
    }
}
