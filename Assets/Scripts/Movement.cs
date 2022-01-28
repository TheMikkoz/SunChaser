using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Vector2 startingPoint;
    [SerializeField] private bool grounded;
    [SerializeField] private float gravity, speed;
    private Vector2 movement;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startingPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && grounded)
            {
            Jump();
            }
        if (!grounded)
        {
            movement.y -= gravity * Time.deltaTime;
        }
        transform.Translate(movement * speed * Time.deltaTime);
    }
    void Jump()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
