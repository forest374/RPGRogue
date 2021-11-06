using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScelect : MonoBehaviour
{
    [SerializeField]
    GameObject m_circle = default;
    int m_selectNum = 0;

    public int SelectNum { get => m_selectNum; }

    private void Start()
    {
    }

    private void Update()
    {
        Calculation();
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

    public void ResetSelectNum()
    {
        m_selectNum = 0;
        m_circle.transform.position = BattleManager.Instance.Enemies[m_selectNum].transform.position;
    }

    void AddSelectNum()
    {
        if (m_selectNum + 1 >= BattleManager.Instance.Enemies.Count)
        {
            return;
        }
        m_selectNum++;
        m_circle.transform.position = BattleManager.Instance.Enemies[m_selectNum].transform.position;
    }

    void SubSelectNum()
    {
        if (m_selectNum - 1 < 0)
        {
            return;
        }
        m_selectNum--;
        m_circle.transform.position = BattleManager.Instance.Enemies[m_selectNum].transform.position;
    }

    public void CircleOn()
    {
        m_circle.SetActive(true);
    }
    public void CircleOff()
    {
        m_circle.SetActive(false);
    }
}
