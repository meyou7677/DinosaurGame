using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump_enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody m_rb;
    private float jumptimer;
    public float minJumpTime;
    public float maxjumptime;
    public Vector3 minjumpforce;
    public Vector3 maxjumpforce;
    private float enemy_health = 20;
    public GameObject SmokeEffect;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        jumptimer += Time.deltaTime;
        if(jumptimer > Random.Range(minJumpTime,maxjumptime))
        {
            jumptimer = 0;
            Vector3 jumpforce = new Vector3(0, Random.Range(minjumpforce.y, maxjumpforce.y), Random.Range(minjumpforce.z, maxjumpforce.z));
            int R = Random.Range(0, 2);
            if(R == 0)
            {
                jumpforce.z *= -1;
            }
            m_rb.AddForce(jumpforce, ForceMode.Impulse);
        }
        
    

    }

    private void OnParticleCollision(GameObject other)
    {
        enemy_health -= Player.fire_damage;
        Debug.Log(enemy_health);
        if(enemy_health < 1)
        {
            GameObject smoke = GameObject.Instantiate(SmokeEffect);
            smoke.transform.position = transform.position;
            GameObject.Destroy(gameObject);
        }
    }
}
