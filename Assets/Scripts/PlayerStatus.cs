using System.Collections;
using System.Collections.Generic;


public enum AbnormalState
{
    毒 = 0b1000, 火傷 = 0b0100, 眠り = 0b0010, 麻痺 = 0b0001
}

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
