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

    float m_MaxDistance;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();     
        m_Collider = GetComponent<Collider>();   
        m_MaxDistance = .2f;
    }

    public void MoveTowards(Vector2 input)
    {

        Vector3 moveDirection = new Vector3(input.x, 0, input.y);
        moveDirection.Normalize();
        if (moveDirection != Vector3.zero) transform.forward = moveDirection;
        if (!m_HitDetect) transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);


    }

    void FixedUpdate()
    {
        m_HitDetect = Physics.BoxCast(m_Collider.bounds.center, Vector3.one / 2f, transform.forward, out m_Hit, transform.rotation, m_MaxDistance);

    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        if (m_HitDetect)
        {
            Gizmos.DrawRay(transform.position, transform.forward * m_Hit.distance);
            Gizmos.DrawWireCube(transform.position + transform.forward * m_Hit.distance, transform.localScale);
        }
        else
        {
            Gizmos.DrawRay(transform.position, transform.forward * m_MaxDistance);
            Gizmos.DrawWireCube(transform.position + transform.forward * m_MaxDistance, transform.localScale);
        }
    }
}
