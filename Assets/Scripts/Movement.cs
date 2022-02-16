using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Vector2 startingPoint;
    [SerializeField] private float gravity, speed;
    public bool grounded;
    [SerializeField]private Vector2 movement;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startingPoint;
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs
        inputs();

        //Gravity
        if (!grounded) movement.y -= gravity * Time.deltaTime; else movement.y = 0;

        //Move
        transform.Translate(movement * speed * Time.deltaTime);
        grounded = false;
    }
    void Jump()
    {
    }

    void inputs()
    {
        if (Input.GetAxisRaw("Vertical") > 0 && grounded)
        {
            movement.y = speed * 1.5f;
            grounded = false;
        }
        movement.x = Input.GetAxisRaw("Horizontal") * speed;
    }

}
