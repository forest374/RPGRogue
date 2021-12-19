using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo Instance = default;

    public BaseStatus Status { get; set; }
    public Stomach Stomach { get; set; }
    public int CurrentHP { get; set; }
    public int CurrentMP { get; set; }


    private void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
}
