using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float timer = 0;
    public float time;
    private bool BlowUpTime = false;
    private HashSet<GameObject> BlowUpObjects;
    public float pushForce;
    public GameObject ExplosionEffect;
    
    
    // Start is called before the first frame update
    void Start()
    {
        BlowUpObjects = new HashSet<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= time && !BlowUpTime)
        {
            BlowUpTime=true;
            foreach(GameObject obj in BlowUpObjects)
            {
                if(obj.tag == "Player")
                {
                    obj.GetComponent<Player>().ApplyDamage(20);

                }
                if(obj.tag == "enemy")
                {
                    
                    obj.GetComponent<enemy>().ApplyDamage(20);
                }
                Vector3 pushDirection = obj.transform.position - transform.position;
                obj.GetComponent<Rigidbody>().AddForce(pushDirection.normalized * pushForce, ForceMode.Impulse);

            }
            GameObject smoke = GameObject.Instantiate(ExplosionEffect);
            smoke.transform.position = transform.position;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "enemy")
        {
            BlowUpObjects.Add(other.gameObject);
        }
        
        
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        BlowUpObjects.Remove(other.gameObject);
        
    }
}
