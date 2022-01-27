using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Vector2 startingPoint;
    [SerializeField] private bool grounded;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = startingPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && grounded)
            {
            Jump();
            }
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
