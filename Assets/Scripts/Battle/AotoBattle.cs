using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// プレイスピード
/// </summary>
public enum PlaySpeed
{
    x1 = 1, x2, x3, x4,
    x10 = 10
}

public class AotoBattle : MonoBehaviour
{
    public PlaySpeed m_playSpeed = default;

    BattleManager m_bM = default;
    int m_pTime = default;
    int[] m_eTime = default;

    public void DataSet(int enemyNum, PlaySpeed speed, BattleManager battleManager)
    {
        m_eTime = new int[enemyNum];
        m_playSpeed = speed;
        m_bM = battleManager;
    }
    public void DataSet(PlaySpeed speed)
    {
        m_playSpeed = speed;
    }

    public void Aoto()
    {
        for (int i = 0; i < (int)m_playSpeed; i++)
        {
            Cycle();
        }
    }

    private void Cycle()
    {
        m_pTime++;
        m_pTime = m_bM.AttackCheck(m_pTime);

        for (int i = 0; i < m_eTime.Length; i++)
        {
            if (m_bM.Down[i] == true) continue;

            m_eTime[i]++;
            m_eTime = m_bM.AttackCheck(i, m_eTime);
        }
    }
}
