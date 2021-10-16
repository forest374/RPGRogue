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
    public int SelectEnemy { get; set; } = 0;
    private void Start()
    {
        Instance = this;
    }

    /// <summary>
    /// 選択した敵を記録する
    /// </summary>
    /// <param name="enemy">敵</param>
    public void EnemySelect(Unit enemy)
    {
        for (int i = 0; i < m_enemies.Length; i++)
        {
            if (m_enemies[i] == enemy)
            {
                SelectEnemy = i;
                return;
            }
        }

        Debug.Log("選択した敵がいません");
    }
    /// <summary>
    /// プレイヤーの攻撃
    /// </summary>
    /// <param name="atk">攻撃力</param>
    public void PlayerAttack(int atk)
    {
        m_enemies[SelectEnemy].Damege(atk);
    }
    /// <summary>
    /// 敵の攻撃(必ずプレイヤーに攻撃)
    /// </summary>
    /// <param name="atk">攻撃力</param>
    public void EnemyAttack(int atk)
    {
        m_player.Damege(atk);
    }
}
