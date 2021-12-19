using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance = default;
    
    [SerializeField, Tooltip("プレイスピード")]
    PlaySpeed m_playSpeed = default;

    [SerializeField]
    EnemyGenerater m_enemyGenerater = default;
    [SerializeField]
    Unit m_player = default;
    [SerializeField]
    ScelectCursor m_scelectCursor = default;

    AotoBattle m_aotoBattle = default;
    //List<Enemy> m_enemies = new List<Enemy>();
    Unit[] m_enemies = default;
    bool[] m_down = default;


    public bool Battle = true;
    public bool[] Down => m_down;
    public Unit[] Enemies => m_enemies;


    private void Awake()
    {
        Instance = this;
        m_aotoBattle = gameObject.AddComponent<AotoBattle>();
        m_scelectCursor = Instantiate(m_scelectCursor);
        m_enemyGenerater.OnGenerater();
    }

    private void Update()
    {
        m_scelectCursor.Calculation();
    }

    private void FixedUpdate()
    {
        if (!Battle) return;

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
            //Debug.Log(m_player.name);
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
            //Debug.Log(m_enemies[i].name);
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
        if (m_enemies.Length <= m_scelectCursor.SelectNum)
        {
            return;
        }

        m_enemies[m_scelectCursor.SelectNum].Damege(atk);
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
    public void EnemiesSet(Unit[] enemeis)
    {
        m_enemies = enemeis;
        m_down = new bool[m_enemies.Length];
        m_aotoBattle.DataSet(m_enemies.Length, m_playSpeed, Instance);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="enemy"></param>
    public void EnemyDown(Unit enemy)
    {
        for (int i = 0; i < m_enemies.Length; i++)
        {
            if (m_enemies[i] == enemy)
            {
                m_down[i] = true;
            }
        }
        EnemiesConfirmationOfSurvival();
        m_scelectCursor.EnemyDown();
    }
    public void PlayerDown(Unit player)
    {
        Battle = false;
    }

    /// <summary>
    /// 敵の生存確認
    /// </summary>
    void EnemiesConfirmationOfSurvival()
    {
        Battle = false;
        foreach (var b in m_down)
        {
            if (b == false)
            {
                Battle = true;
                break;
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


    /// <summary>
    /// スピードを変更する
    /// </summary>
    public void SpeedChange()
    {
        PlaySpeed s = PlaySpeed.x1;
        switch (m_playSpeed)
        {
            case PlaySpeed.x1:
                s = PlaySpeed.x2;
                break;
            case PlaySpeed.x2:
                s = PlaySpeed.x3;
                break;
            case PlaySpeed.x3:
                s = PlaySpeed.x4;
                break;
            case PlaySpeed.x4:
                s = PlaySpeed.x10;
                break;
            case PlaySpeed.x10:
                s = PlaySpeed.x1;
                break;
            default:
                break;
        }
        m_playSpeed = s;
        m_aotoBattle.DataSet(m_playSpeed);
    }
}
