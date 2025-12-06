using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private GameObject m_player;
    private Canvas m_canvas;
    public float DistanceFromPlayer;
    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_canvas = GetComponentInChildren<Canvas>(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 distanceVector = m_player.transform.position - transform.position;
        //float distance = distanceVector.magnitude;
        //if(distance < DistanceFromPlayer)
        {
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_canvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_canvas.gameObject.SetActive(false);
        }
    }
}
