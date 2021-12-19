using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    [SerializeField]
    BaseStatus m_status = default;

    SkillBase[] m_skill = new SkillBase[4];

    protected override void Start()
    {
        Status = m_status;
        if (PlayerInfo.Instance)
        {
            Status = PlayerInfo.Instance.Status;
        }

        base.Start();
    }

    public override void Attack()
    {
        int atk = Status.ATK;
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
        if (m_currentHp <= 0)
        {
            BattleManager.Instance.PlayerDown(this);
            gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }
}
