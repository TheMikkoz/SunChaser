using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] private Vector2 startingPoint;
=======
    private Animator plr;
    public Vector2 startingPoint;
>>>>>>> Stashed changes
    [SerializeField] private float gravity, speed;
    public bool grounded;
    [SerializeField]private Vector2 movement;
    [SerializeField]
    LayerMask groundlayer;

    // Start is called before the first frame update
    void Start()
    {
        plr = GetComponent<Animator>();
        transform.position = startingPoint;
    }

    bool Check(RaycastHit2D hit2D)
    {
        if (hit2D.collider != null)
        {
            if (hit2D.collider.tag == "Ground")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return true;
        }

    }


    void Inputs()
    {

        //raycast
        RaycastHit2D Down1 = Physics2D.Raycast(new Vector2(transform.position.x - transform.localScale.x / 2, transform.position.y), Vector2.down, transform.localScale.y / 2, groundlayer);
        RaycastHit2D Down2 = Physics2D.Raycast(new Vector2(transform.position.x + transform.localScale.x / 2, transform.position.y), Vector2.down, transform.localScale.y / 2, groundlayer);
        RaycastHit2D Right1 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2 + 0.1f), Vector2.right, transform.localScale.x / 2, groundlayer);
        RaycastHit2D Right2 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + transform.localScale.y / 2 - 0.1f), Vector2.right, transform.localScale.x / 2, groundlayer);
        RaycastHit2D Left1 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2 + 0.1f), Vector2.left, transform.localScale.x / 2, groundlayer);
        RaycastHit2D Left2 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + transform.localScale.y / 2 - 0.1f), Vector2.left, transform.localScale.x / 2, groundlayer);

<<<<<<< Updated upstream
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + transform.localScale.y / 2), Vector2.left, Color.red);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2), Vector2.left, Color.red);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + transform.localScale.y / 2), Vector2.right, Color.blue);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2), Vector2.right, Color.blue);

        print(Down1.collider + " - " + Down2.collider + " - " + Right1.collider + " - " + Right2.collider + " - " + Left1.collider + " - " + Left2.collider);
=======
        
        //Horizontal movement reset
        movement.x = 0;
        plr.SetBool("Run", false);
        
>>>>>>> Stashed changes

        //Ground Check
        if (!Check(Down1) || !Check(Down2)) 
        {
            plr.SetBool("Jump", false);
            plr.SetBool("Idle", true);
            grounded = true;
            movement.y = 0;
        }
        else
        {
<<<<<<< Updated upstream
=======
            plr.SetBool("Jump",true);
            plr.SetBool("Idle", false);
            transform.parent = null;
            grounded = false;
>>>>>>> Stashed changes
            movement.y -= gravity * Time.deltaTime;
        }

        movement.x = 0;

        if (Check(Right1) && Check(Right2))
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                movement.x = speed;
                plr.SetBool("Run", true);
                GetComponent<SpriteRenderer>().flipX = false;
                plr.SetBool("Idle", false);
                plr.SetBool("Jump", false);
            }
        }

        if (Check(Left1) && Check(Left2))
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                movement.x = -speed;
                plr.SetBool("Run", true);
                GetComponent<SpriteRenderer>().flipX=true;
                plr.SetBool("Idle", false);
                plr.SetBool("Jump", false);
            }
        }

        if (Input.GetAxisRaw("Vertical") > 0 && grounded)
        {
            movement.y = speed * 1.5f;
            grounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs
        Inputs();

        

        //Old Gravity
        //if (!grounded) movement.y -= gravity * Time.deltaTime; else movement.y = 0;

        //Move
        transform.Translate(movement * speed * Time.deltaTime);

    }
}
