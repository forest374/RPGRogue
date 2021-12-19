using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTab : Tab
{
    SkillBase[] _skill;
    List<Item> _inventory = default;
    List<SkillItem> _skillItem = new List<SkillItem>();

    [SerializeField]
    HorizontalLayoutGroup _layoutGroup = default;

    int _maxNum = 0;
    int _iNum = 0;

    protected override void Start()
    {
        base.Start();

        _inventory = PlayerManager.Instance.Inventory;

        foreach (var item in _inventory)
        {
            if (typeof(SkillItem) == item.GetType())
            {
                _skillItem.Add((SkillItem)item);
            }
        }
        _maxNum = _skillItem.Count;

        for (int i = 0; i < _skillItem.Count; i++)
        {
            var o = Instantiate(_skillItem[i].gameObject, _layoutGroup.transform);
        }
    }

    public void TabOperation()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            if (_iNum < _maxNum - 1)
            {
                _iNum++;
            }
        }
    }
}
