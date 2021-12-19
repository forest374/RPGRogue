using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance = default;

    SkillBase skill;
    List<Item> _inventory = new List<Item>();
    public List<Item> Inventory { get => _inventory; set {_inventory = value; } }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

}
