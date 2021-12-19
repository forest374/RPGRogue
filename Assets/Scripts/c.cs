using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c : MonoBehaviour
{

    List<Item> _inventory = new List<Item>();
    Item item = new Item();
    SkillItem s = new SkillItem();

    List<SkillItem> _skillItem = new List<SkillItem>();
    void Start()
    {
        _inventory.Add(item);
        _inventory.Add(item);
        _inventory.Add(s);

        foreach (var item in _inventory)
        {
            Debug.Log((typeof(SkillItem) == item.GetType()));
        }
    }

}
