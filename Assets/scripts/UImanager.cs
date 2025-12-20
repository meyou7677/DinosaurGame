using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    private Slider m_slider;

    
    // Start is called before the first frame update
    void Start()
    {
        m_slider = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerHealth(float health)
    {
        m_slider.value = health;
    }
}
