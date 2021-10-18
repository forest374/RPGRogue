using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance = default;

    [SerializeField]
    Unit m_player = default;
    [SerializeField]
    Unit[] m_enemies = default;
    [SerializeField]
    PlayerScelect m_select = default;

    public Unit[] Enemies { get => m_enemies; }

    public int EnemyNum { get; private set; } = 0;
    private void Awake()
    {
        Instance = this;
        EnemyNum = m_enemies.Length;
    }

    public void EnemiesSet(Unit[] enemeis)
    {
        m_enemies = new Unit[enemeis.Length];
        for (int i = 0; i < enemeis.Length; i++)
        {
            m_enemies[i] = enemeis[i];
        }
    }

    /// <summary>
    /// プレイヤーの攻撃
    /// </summary>
    /// <param name="atk">攻撃力</param>
    public void PlayerAttack(int atk)
    {
        if (m_enemies.Length <= m_select.SelectNum)
        {
            return;
        }
        m_enemies[m_select.SelectNum].Damege(atk);
    }
    /// <summary>
    /// 敵の攻撃(必ずプレイヤーに攻撃)
    /// </summary>
    /// <param name="atk">攻撃力</param>
    public void EnemyAttack(int atk)
    {
        m_player.Damege(atk);
    }

    ///// <summary>
    ///// 選択した敵を記録する
    ///// </summary>
    ///// <param name="enemy">敵</param>
    //public void EnemySelect(Unit enemy)
    //{
    //    for (int i = 0; i < m_enemies.Length; i++)
    //    {
    //        if (m_enemies[i] == enemy)
    //        {
    //            SelectEnemy = i;
    //            return;
    //        }
    //    }

    //    Debug.Log("選択した敵がいません");
    //}
}
