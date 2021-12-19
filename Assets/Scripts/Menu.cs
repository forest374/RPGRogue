using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject m_menu = default;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            if (m_menu.activeSelf)
                m_menu.SetActive(false);
            else
                m_menu.SetActive(true);
        }
    }
}
