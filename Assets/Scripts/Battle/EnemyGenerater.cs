using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerater : MonoBehaviour
{
    [SerializeField, Tooltip("出現させる敵の数")]
    int m_enemyNum = 1;
    [SerializeField, Tooltip("出現させる敵のレベル")]
    int m_level = default;
    [Tooltip("敵の系統数")]
    int m_maxLineage = default;
    [SerializeField, Tooltip("")]
    GameObject m_enemy = default;
    [SerializeField, Tooltip("")]
    Vector3 m_pad = new Vector3(3f, 0);
    EnemyID m_enemyID = new EnemyID();

    Unit[] m_enemeis =  default;
    public void OnGenerater()
    {
        m_enemeis = new Enemy[m_enemyNum];
        m_maxLineage = Enum.GetNames(typeof(LineAge)).Length;
        CreateEnemies();
        BattleManager.Instance.EnemiesSet(m_enemeis);
    }

    /// <summary>
    /// enemyを生成する
    /// </summary>
    private void CreateEnemies()
    {
        int id;
        string path;
        LineAge lineAge;
        IDBase enemy;
        //Status status;
        //UnityEngine.Object stat;

        for (int i = 0; i < m_enemyNum; i++)
        {
            id = UnityEngine.Random.Range(0, m_maxLineage);
            lineAge = (LineAge)id;
            enemy = m_enemyID.Create(lineAge);
            id = UnityEngine.Random.Range(0, enemy.SpeciesNum);
            path = "Enemy/" + lineAge.ToString() + "/" + enemy.Species(id);

            //status = (Status)Resources.Load(path);

            m_enemeis[i] = Instantiate(m_enemy, this.transform).GetComponent<Enemy>();
            m_enemeis[i].Status = (BaseStatus)Resources.Load(path);
            m_enemeis[i].transform.position = m_pad * i;
            m_enemeis[i].name = m_enemeis[i].Status.UnitName;
        }
    }
    // ステータスを固定するならスクリプタルオブジェクト固定じゃない場合は普通のオブジェクト
    // とりあえずHPとかはint型で持たせる
    // ビットは　モンスターの系統が上2桁、種類が下2桁みたいな感じでやる
}
