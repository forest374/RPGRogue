using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScelectCursor : MonoBehaviour
{
    int m_selectNum = 0;
    int m_maxNum = default;

    public int SelectNum => m_selectNum;

    public void Start()
    {
        m_maxNum = BattleManager.Instance.Enemies.Length;
    }
    
    public void Calculation()
    {
        if (Input.GetKeyDown("a"))
        {
            SubSelectNum();
        }
        if (Input.GetKeyDown("d"))
        {
            AddSelectNum();
        }
    }

    /// <summary>
    /// カーソルの位置をひとつ後ろの敵に合わせる
    /// </summary>
    void AddSelectNum()
    {
        if (!BattleManager.Instance.Battle)
        {
            CircleOff();
        }

        m_selectNum++;
        if (m_selectNum >= m_maxNum)
        {
            ResetSelectNum();
            return;
        }

        if (BattleManager.Instance.Down[m_selectNum])
        {
            AddSelectNum();
            return;
        }

        transform.position = BattleManager.Instance.Enemies[m_selectNum].transform.position;
    }

    /// <summary>
    /// カーソルの位置をひとつ前の敵に合わせる
    /// </summary>
    void SubSelectNum()
    {
        if (!BattleManager.Instance.Battle)
        {
            CircleOff();
        }

        m_selectNum--;
        if (m_selectNum < 0)
        {
            MaxSelectNum();
            return;
        }
        if (BattleManager.Instance.Down[m_selectNum])
        {
            SubSelectNum();
            return;
        }
        transform.position = BattleManager.Instance.Enemies[m_selectNum].transform.position;
    }

    /// <summary>
    /// 敵が死んだらカーソルを移動させる
    /// </summary>
    public void EnemyDown()
    {
        AddSelectNum();
    }

    /// <summary>
    /// カーソルの位置を先頭の敵に合わせる
    /// </summary>
    public void ResetSelectNum()
    {
        m_selectNum = 0;
        transform.position = BattleManager.Instance.Enemies[m_selectNum].transform.position;
    }
    /// <summary>
    /// カーソルの位置を最後尾の敵に合わせる
    /// </summary>
    public void MaxSelectNum()
    {
        m_selectNum = m_maxNum - 1;
        transform.position = BattleManager.Instance.Enemies[m_selectNum].transform.position;
    }

    public void CircleOn()
    {
        gameObject.SetActive(true);
    }
    public void CircleOff()
    {
        gameObject.SetActive(false);
    }
}
