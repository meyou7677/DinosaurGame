using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float health;
    public float damage;
    public GameObject SmokeEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ApplyDamage(Player.fire_damage);
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;
        if (health < 1)
        {
            GameObject smoke = GameObject.Instantiate(SmokeEffect);
            smoke.transform.position = transform.position;
            GameObject.Destroy(gameObject);
        }
    }
}
