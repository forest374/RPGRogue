using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    Tab[] _tabs = default;
    HorizontalLayoutGroup h = default;

    int _maxTab = 0;
    int _tabNum = 0;
    private void Start()
    {
        h = GetComponent<HorizontalLayoutGroup>();
        float spacing = h.spacing;

        _maxTab = transform.childCount;

        _tabs = new Tab[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            _tabs[i] = transform.GetChild(i).GetComponent<Tab>();
            _tabs[i].TabNum = i;

            if (i == 0)
            {
                _tabs[i].TabSetActive(true);
            }
            else
            {
                _tabs[i].SetPanelPos(spacing);
                _tabs[i].TabSetActive(false);
            }
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("E") && _tabNum < _maxTab - 1)
        {
            _tabNum++;
            TabSelect(_tabNum);
        }
        else if(Input.GetButtonDown("Q") && _tabNum > 0)
        {
            _tabNum--;
            TabSelect(_tabNum);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="num"></param>
    public void TabSelect(int num)
    {
        for (int i = 0; i < _tabs.Length; i++)
        {
            if (i == num) _tabs[i].TabSetActive(true);
            else _tabs[i].TabSetActive(false);
        }
    }
}
