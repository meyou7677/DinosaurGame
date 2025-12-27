using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorway : MonoBehaviour
{
    public int LevelNumber;
    private Player m_playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        m_playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "fred" && m_playerScript.IsEnter)
        {

            SceneManager.LoadScene(LevelNumber);
        }
    }
   
}
