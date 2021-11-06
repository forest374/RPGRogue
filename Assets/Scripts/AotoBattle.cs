using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BattleSystem;

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

                m_eTime[i]++;

            m_eTime = m_bM.AttackCheck(i, m_eTime);
        }
    }

}
