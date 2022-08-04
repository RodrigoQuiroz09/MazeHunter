using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Velocidad del Movimiento del personaje en N/s")]
    [Range(0, 100)]
    public float speed;
    private Rigidbody _rb;
    bool m_HitDetect;

    Collider m_Collider;
    RaycastHit m_Hit;

    private Vector2 input;

    float m_MaxDistance;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();     
        m_Collider = GetComponent<Collider>();   
        m_MaxDistance = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if(input != Vector2.zero)
        {
            if (input.x != 0) input.y = 0;

            float space = speed * Time.deltaTime;
            transform.Translate(new Vector3(input.x*space, 0, input.y*space));
        }


        // if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
        // {
        //     this.transform.Rotate(0f, 0f, 0f,Space.World);
        // }
        // if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) 
        // {
        //     this.transform.Rotate(0f, 180f, 0,Space.World);
        // }
        // if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) 
        // {
        //     this.transform.Rotate(0f, 90f, 0,Space.World);
        // }
        // if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) 
        // {
        //     this.transform.Rotate(0f, 270f, 0,Space.World);
        // }

    }

    void FixedUpdate()
    {
        //Test to see if there is a hit using a BoxCast
        //Calculate using the center of the GameObject's Collider(could also just use the GameObject's position), half the GameObject's size, the direction, the GameObject's rotation, and the maximum distance as variables.
        //Also fetch the hit data
        m_HitDetect = Physics.BoxCast(m_Collider.bounds.center, transform.localScale, transform.forward, out m_Hit, transform.rotation, m_MaxDistance);
        if (m_HitDetect)
        {
            //Output the name of the Collider your Box hit
            Debug.Log("Hit : " + m_Hit.collider.name);
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (m_HitDetect)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, transform.forward * m_Hit.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(transform.position + transform.forward * m_Hit.distance, transform.localScale);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, transform.forward * m_MaxDistance);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.position + transform.forward * m_MaxDistance, transform.localScale);
        }
    }
}
