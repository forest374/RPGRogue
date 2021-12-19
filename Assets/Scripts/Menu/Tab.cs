using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tab : MonoBehaviour
{
    [SerializeField]
    protected GameObject _panel = default;

    protected TabManager _tabManager = default;

    public int TabNum { get; set; }

    protected virtual void Start()
    {
        _tabManager = GetComponentInParent<TabManager>();
    }

    public virtual Vector3 GetPanelPos()
    {
        return _panel.transform.position;
    }

    public virtual void SetPanelPos(float space)
    {
        RectTransform r = GetComponent<RectTransform>();
        float x = _panel.transform.position.x - (r.rect.width + space) * TabNum;
        _panel.transform.position = new Vector3(x, _panel.transform.position.y, _panel.transform.position.z);
    }

    public virtual void TabSelect()
    {
        _tabManager.TabSelect(TabNum);
    }

    public virtual void TabSetActive(bool active)
    {
        _panel.SetActive(active);
    }
}
