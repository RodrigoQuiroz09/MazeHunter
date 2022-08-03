using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Velocidad del Movimiento del personaje en N/s")]
    [Range(0, 1000)]
    public float speed;
    private Rigidbody _rb;

    void Start()
    {
    _rb = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
                float space = speed * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
              Vector3 dir = new Vector3(horizontal, 0, vertical);
        //this.transform.Translate(dir.normalized * space); - Sin físicas
        //_rb.AddRelativeForce(dir.normalized * space);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) this.transform.Translate(0, 0, space);
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) this.transform.Translate(0, 0, -space);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) this.transform.Translate(-space, 0, 0);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) this.transform.Translate(space, 0, 0);
    }
}
