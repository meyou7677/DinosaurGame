using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody m_rb;
    public float Speed;
    public float JumpForce;
    public float MaxSpeed;
    private bool m_isGrounded;
    private GameObject[] m_raycastpoints;
    public float RaycastDistance;
    private ParticleSystem m_fire;
    public KeyCode JumpButton;
    public KeyCode FlameButton;
    public KeyCode SpinButton;
    public KeyCode EnterButton;
    public static float fire_damage = 1f;
    public float Health;
    private UImanager m_uimanager;
    public bool IsEnter = false;


    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_raycastpoints = GameObject.FindGameObjectsWithTag("raycast");
        m_fire = GetComponentInChildren<ParticleSystem>();
        var emission = m_fire.emission;
        emission.enabled = false;
        m_uimanager = GameObject.FindObjectOfType<UImanager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float MovementX = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        m_rb.AddForce(0, 0, MovementX, ForceMode.Acceleration);

        m_isGrounded = false;
        for (int i = 0; i < m_raycastpoints.Length; i++)
        {
            GameObject obj = m_raycastpoints[i];
            Vector3 origin = obj.transform.position;
            Vector3 direction = Vector3.down;
            Debug.DrawRay(origin, direction);
            if (Physics.Raycast(origin, direction, out RaycastHit hitInfo, RaycastDistance))
            {
                m_isGrounded = true;

                break;
            }

        }
        if (Input.GetKeyDown(JumpButton) && m_isGrounded)
        {
            Vector3 velocity = m_rb.velocity;
            velocity.y = 0;
            m_rb.velocity = velocity;
            m_rb.AddForce(0, JumpForce, 0, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(SpinButton))
        {
            transform.Rotate(0, 180, 0);
        }
        if (Input.GetKey(FlameButton))
        {
            var emission = m_fire.emission;
            emission.enabled = true;
        }
        if (Input.GetKeyUp(FlameButton))
        {
            var emission = m_fire.emission;
            emission.enabled = false;
        }
        if (Input.GetKey(EnterButton))
        {
            IsEnter = true;
        }
        if (Input.GetKeyUp(EnterButton))
        {
            IsEnter = false;
        }

    }
    private void FixedUpdate()
    {
        if(m_rb.velocity.magnitude > MaxSpeed)
        {
            Vector3 newvelocity = m_rb.velocity.normalized * MaxSpeed;
            m_rb.velocity = new Vector3 (newvelocity.x,m_rb.velocity.y,newvelocity.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy" || collision.gameObject.tag == "enemybombresist")
        {
            var enemyScript = collision.gameObject.GetComponent<enemy>();
            ApplyDamage(enemyScript.damage);
            
        }
    }
    public void ApplyDamage(float damage)
    {
        Health -= damage;
        m_uimanager.SetPlayerHealth(Health);
        if (Health <= 0)
        {
            m_uimanager.EnableDieMenu();
            gameObject.SetActive(false);
        }
    }
}
