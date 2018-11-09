using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPlayer : MonoBehaviour {

    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float starDashTime;
    private int direction;
    private Vector2 current;
    private Gamekit2D.Damageable dm;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        dm = GetComponentInParent<Gamekit2D.Damageable>();
        dashTime = starDashTime;
        current = rb.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (direction == 0 && Input.GetKeyDown(KeyCode.LeftShift))
        {

            if (Input.GetKey(KeyCode.A))
            {
                direction = 1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                direction = 2;
            }
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
        else
        {
            if(dashTime <= 0)
            {
                direction = 0;
                dashTime = starDashTime;
                rb.velocity = Vector2.zero;
                dm.DisableInvulnerability();
            }
            else
            {
                dm.EnableInvulnerability();
                dashTime -= Time.deltaTime;
                if (direction == 1)
                {
                    rb.AddForce(Vector3.left * dashSpeed);
                    //rb.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 2)
                {
                    rb.AddForce(Vector3.right * dashSpeed);
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
