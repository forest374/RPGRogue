using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BattleSystem;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance = default;

    [SerializeField]
    Unit m_player = default;

    [SerializeField]
    PlayerScelect m_playerScelect = default;

    List<Enemy> m_enemies = new List<Enemy>();
    public List<Enemy> Enemies { get => m_enemies; }

    AotoBattle m_aotoBattle = default;
    [SerializeField]
    PlaySpeed m_playSpeed = default;

    private void Awake()
    {
        Instance = this;
        m_aotoBattle = gameObject.AddComponent<AotoBattle>();
    }

    private void FixedUpdate()
    {
        if (m_enemies.Count == 0) return;

        m_aotoBattle.Aoto();
    }


    /// <summary>
    /// playerの攻撃確認
    /// </summary>
    /// <param name="count"></param>
    public int AttackCheck(int count)
    {
        if (count == m_player.m_time)
        {
            count = 0;
            //　こうげき 
            Debug.Log(m_player.name);
            m_player.Attack();
        }
        return count;
    }
    /// <summary>
    /// 敵の攻撃確認
    /// </summary>
    /// <param name="i"></param>
    /// <param name="count"></param>
    public int[] AttackCheck(int i, int[] count)
    {
        if (count[i] == m_enemies[i].m_time)
        {
            count[i] = 0;
            //　こうげき 
            Debug.Log(m_enemies[i].name);
            m_enemies[i].Attack();
        }
        return count;
    }

    /// <summary>
    /// プレイヤーの攻撃
    /// </summary>
    /// <param name="atk">攻撃力</param>
    public void PlayerAttack(int atk)
    {
        if (m_enemies.Count <= m_playerScelect.SelectNum)
        {
            return;
        }

        m_enemies[m_playerScelect.SelectNum].Damege(atk);
    }


    /// <summary>
    /// 敵の攻撃(必ずプレイヤーに攻撃)
    /// </summary>
    /// <param name="atk">攻撃力</param>
    public void EnemyAttack(int atk)
    {
        m_player.Damege(atk);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="enemeis"></param>
    public void EnemiesSet(Enemy[] enemeis)
    {
        for (int i = 0; i < enemeis.Length; i++)
        {
            m_enemies.Add(enemeis[i]);
        }
        m_aotoBattle.DataSet(Enemies.Count, m_playSpeed, Instance);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="enemy"></param>
    public void EnemyDead(Enemy enemy)
    {
        for (int i = 0; i < m_enemies.Count; i++)
        {
            if (m_enemies[i] == enemy)
            {
                m_enemies.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// damegeログ
    /// </summary>
    /// <param name="name"></param>
    /// <param name="damege"></param>
    public void DamegeLog(string name, int damege)
    {
        Debug.Log(name + "は" + damege + "のダメージを受けた");
    }

    /// <summary>
    /// ダウンログ
    /// </summary>
    /// <param name="name"></param>
    public void DownLog(string name)
    {
        Debug.Log(name + "は倒れた");
    }
}
