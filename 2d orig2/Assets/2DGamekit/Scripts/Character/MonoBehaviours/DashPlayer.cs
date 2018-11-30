using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPlayer : MonoBehaviour {

    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float starDashTime;
    private int direction;
    //private Vector2 current;
    private Gamekit2D.Damageable dm;
    private float prevGrav;
    private Gamekit2D.PlayerCharacter pc;
    bool dashing;

    private float speed;
    // Use this for initialization

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        dm = GetComponentInParent<Gamekit2D.Damageable>();
        pc = GetComponentInParent<Gamekit2D.PlayerCharacter>();
        dashTime = starDashTime;
        //current = rb.position;
        //prevGrav = pc.gravity;

        speed = pc.maxSpeed;
        dashing = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = 1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dashing = true;
            //speed = pc.maxSpeed;
            //pc.gravity = 0;
            /*
            if (Input.GetKey(KeyCode.A))
            {
                direction = 1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                direction = 2;
            }
            */
            /*
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = 3;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = 4;
            }
            */
        }
        else if (dashing == true)
        {
            if(dashTime <= 0)
            {
                //direction = 0;
                dashTime = starDashTime;
                rb.velocity = Vector2.zero;
                dm.DisableInvulnerability();

                dashing = false;
                pc.maxSpeed = speed;
                //pc.gravity = prevGrav;
            }
            else
            {
                dm.EnableInvulnerability(true);
                dashTime -= Time.deltaTime;
                if (direction == 1)
                {
                    rb.AddForce(Vector3.left * dashSpeed);
                    //pc.maxSpeed = speed * dashSpeed;
                    //rb.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 2)
                {
                    rb.AddForce(Vector3.right * dashSpeed);
                    //pc.maxSpeed = speed * dashSpeed;
                    //rb.velocity = Vector2.right * dashSpeed;
                }
                /*
                else if (direction == 3)
                {
                    rb.velocity = Vector2.up * dashSpeed;
                }
                else if (direction == 4)
                {
                    rb.velocity = Vector2.down * dashSpeed;
                }
                */
            }
        }
	}
}
