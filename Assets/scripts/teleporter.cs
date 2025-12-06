using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class teleporter : MonoBehaviour
{

    private GameObject m_cube;
    // Start is called before the first frame update
    void Start()
    {
        m_cube = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = m_cube.transform.position;
        }
    }
}
