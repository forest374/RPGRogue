using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater : MonoBehaviour
{
    [SerializeField]
    int m_enemyNum = 1;
    [SerializeField]
    GameObject m_enemy = default;

    Unit[] m_enemeis =  default;
    void Start()
    {
        m_enemeis = new Unit[m_enemyNum];
        for (int i = 0; i < m_enemyNum; i++)
        {
            m_enemeis[i] = Instantiate(m_enemy, this.transform).GetComponent<Unit>();
        }
        BattleManager.Instance.EnemiesSet(m_enemeis);
    }

}
