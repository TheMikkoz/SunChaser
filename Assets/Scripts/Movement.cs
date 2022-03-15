using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] private Vector2 startingPoint;
    [SerializeField] private float gravity, speed;
    public bool grounded;
    private Vector2 movement;
    [SerializeField] LayerMask groundlayer;
    [SerializeField, Header("Manager")] GameObject Manager;

    // Start is called before the first frame update
    void Awake()
    {
        transform.position = startingPoint;
    }
    

    //To another lvl??
    void Door()
    {
        Manager.GetComponent<Manager>().Door();
        //SceneManager.LoadSceneAsync("empty");
    }

    //Raycast check collision
    bool Check(RaycastHit2D hit2D)
    {
        
        if (hit2D.collider != null)
        {
            if (hit2D.collider.tag == "Door")
            {
                Door();
            }
            if (hit2D.collider.tag == "Ground")
            {
                return false;
            }
            if (hit2D.collider.tag == "Platform")
            {
                transform.parent = hit2D.transform;
                return false;
            }
        }
        return true;
    }


    void Inputs()
    {
        //Raycast Rays
        RaycastHit2D Down1 = Physics2D.Raycast(new Vector2(transform.position.x - transform.localScale.x / 2 + 0.1f, transform.position.y), Vector2.down, transform.localScale.y / 2, groundlayer);
        RaycastHit2D Down2 = Physics2D.Raycast(new Vector2(transform.position.x + transform.localScale.x / 2 - 0.1f, transform.position.y), Vector2.down, transform.localScale.y / 2, groundlayer);
        RaycastHit2D Right1 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2 + 0.1f), Vector2.right, transform.localScale.x / 2, groundlayer);
        RaycastHit2D Right2 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + transform.localScale.y / 2 - 0.1f), Vector2.right, transform.localScale.x / 2, groundlayer);
        RaycastHit2D Left1 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2 + 0.1f), Vector2.left, transform.localScale.x / 2, groundlayer);
        RaycastHit2D Left2 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + transform.localScale.y / 2 - 0.1f), Vector2.left, transform.localScale.x / 2, groundlayer);

        
        //Horizontal movement reset
        movement.x = 0;

        //Ground Check
        if(!Check(Down1) || !Check(Down2)) 
        {
            grounded = true;
            movement.y = 0;
        }
        else
        {
            transform.parent = null;
            grounded = false;
            movement.y -= gravity * Time.deltaTime;
        }

        //Right side Check
        if (Check(Right1) && Check(Right2))
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                movement.x = speed;
            }
        }
        
        //Left side Check
        if (Check(Left1) && Check(Left2))
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                movement.x = -speed;
            }
        }

        //Jump
        if (Input.GetAxisRaw("Vertical") > 0 && grounded)
        {
            movement.y = speed * 1.5f;
            grounded = false;
        }
    }

    void Defeat()
    {
        if (movement.y < -10)
        {
            movement.y = 0;
            transform.position = startingPoint;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs
        Inputs();

        Defeat();

        //Move
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
