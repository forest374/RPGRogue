using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public struct PlayerStatus
{
    public int HP;
    public int MP;
    public int ATK;
    public int DEF;
    public int AGI;

    /// <summary>
    /// 状態異常 　毒,火傷,眠り,麻痺
    /// </summary>
    [System.NonSerialized]
    public byte AbnormalState;
}
