using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s : MonoBehaviour
{
    int m_iD = 0x00ff;

    char[] aa = new char[4];
    void Start()
    {
        string strID = m_iD.ToString("x4");
        int i = int.Parse(strID.Substring(0, 2));

        UnitIDCheck(i);

        i = int.Parse(strID.Substring(2, 1), System.Globalization.NumberStyles.HexNumber);
        LevelIDCheck(i);
    }

    /// <summary>
    /// ユニットIDチェック　16進数　4桁の前2桁
    /// </summary>
    /// <param name="id"></param>
    void UnitIDCheck(int id)
    {
        if(System.Enum.IsDefined(typeof(EnemyUnit), id))
        {
            EnemyUnit e = (EnemyUnit)id;
            Debug.Log(e.ToString());
            Debug.Log((int)e);
        }
        else
        {
            Debug.Log(id);
            Debug.Log("ユニットIDが違います");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    void LevelIDCheck(int id)
    {
        Debug.Log("Level: " + id);
    }


    enum EnemyUnit
    {
        いもむし, スライム, ゴブリン, コボルト,
        コカトリス, ミノタウロス
    }
}
