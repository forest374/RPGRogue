using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    protected override void Attack()
    {

    }
    protected override void Defence()
    {
        throw new System.NotImplementedException();
    }
    protected override void Skill()
    {
        throw new System.NotImplementedException();
    }
    public override void Damege(int damege)
    {
        base.Damege(damege);
    }
}
