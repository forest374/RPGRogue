using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerater : MonoBehaviour
{
    [SerializeField]
    AotoBattle m_rTBM = default;

    [SerializeField]
    int m_enemyNum = 1;
    [SerializeField]
    GameObject m_enemy = default;
    [SerializeField]
    Vector3 pad = new Vector3(3f, 0);

    Enemy[] m_enemeis =  default;
    void Start()
    {
        m_enemeis = new Enemy[m_enemyNum];
        for (int i = 0; i < m_enemyNum; i++)
        {
            m_enemeis[i] = Instantiate(m_enemy,this.transform).GetComponent<Enemy>();
            m_enemeis[i].transform.position = pad * i;
            m_enemeis[i].name = m_enemeis[i].name + " " + i;
        }
        BattleManager.Instance.EnemiesSet(m_enemeis);
        //m_rTBM.SetEnemies(m_enemeis);

    }

    // ステータスを固定するならスクリプタルオブジェクト固定じゃない場合は普通のオブジェクト
    // とりあえずHPとかはint型で持たせる
    // ビットは　モンスターの系統が上2桁、種類が下2桁みたいな感じでやる
}
