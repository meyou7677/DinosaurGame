using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    private Slider m_slider;
    private GameObject m_dieMenu;

    
    // Start is called before the first frame update
    void Start()
    {
        m_slider = GetComponentInChildren<Slider>();
        m_dieMenu = GameObject.Find("Diemenu");
        m_dieMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerHealth(float health)
    {
        m_slider.value = health;
    }

    public void EnableDieMenu()
    {
        m_dieMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Restart"));
    }
}
