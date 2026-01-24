using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bomb;
    private float timer = 0;
    public float min_time;
    public float max_time;
    private float time;
    public float min_throw;
    public float max_throw;
    void Start()
    {
        time = Random.Range(min_time, max_time);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= time)
        {
            timer = 0;
            time = Random.Range(min_time, max_time);
            GameObject tempBomb = GameObject.Instantiate(bomb);
            tempBomb.transform.position = transform.position + Vector3.up * 5;
            tempBomb.GetComponent<Rigidbody>().AddForce(new Vector3(0, 5, Random.Range(min_throw, max_throw)), ForceMode.Impulse);
        }
    }
}
