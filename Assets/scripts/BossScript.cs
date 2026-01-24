using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private float jumptimer;
    public float minJumpTime;
    public float maxjumptime;
    public Vector3 minjumpforce;
    public Vector3 maxjumpforce;
    private Rigidbody m_rb;
    private LineRenderer m_LR;
    private float laser_timer;
    public float LaserTime;
    private AudioSource m_AS;
    private float beeptimer;
    private float BehaviorTime;
    
    
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_LR = GetComponent<LineRenderer>();
        m_LR.enabled = false;
        m_AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        BehaviorTime += Time.deltaTime;
        if(BehaviorTime < 10)
        {
            JumpAround();
        }
        else
        {
            Laser();
        }
            


    }

    void JumpAround()
    {
        jumptimer += Time.deltaTime;
        if (jumptimer > Random.Range(minJumpTime, maxjumptime))
        {
            jumptimer = 0;
            Vector3 jumpforce = new Vector3(0, Random.Range(minjumpforce.y, maxjumpforce.y), Random.Range(minjumpforce.z, maxjumpforce.z));
            int R = Random.Range(0, 2);
            if (R == 0)
            {
                jumpforce.z *= -1;
            }
            m_rb.AddForce(jumpforce, ForceMode.Impulse);
        }
    }

    IEnumerator ActivateLaser()
    {
        m_LR.enabled = true;
        yield return new WaitForSeconds(0.5f);
        m_LR.enabled = false;
        BehaviorTime = 0;
    }
    void Laser()
    {
        laser_timer += Time.deltaTime;
        beeptimer += Time.deltaTime;
        if(beeptimer >= 1)
        {
            m_AS.Play();
            beeptimer = 0;
        }
        if(laser_timer >= LaserTime)
        {
            StartCoroutine(ActivateLaser());
            laser_timer = 0;

        }
    }
}
