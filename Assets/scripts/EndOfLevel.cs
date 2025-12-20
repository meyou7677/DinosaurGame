using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "fred")
        {
            SceneManager.LoadScene("WorldMap");
        }
    }
}
