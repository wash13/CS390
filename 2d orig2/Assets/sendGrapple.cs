using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendGrapple : MonoBehaviour {

    public GameObject hook;
    GameObject curhook;
    private Gamekit2D.PlayerCharacter pc;
    private Gamekit2D.CharacterController2D cc;
    public float waitTime = (float) .5;
    private float currentTime;
    public float newgrav = 1;
    private float prevgrav;
    //public float test;
    // Use this for initialization
    void Start () {
        pc = GetComponentInParent<Gamekit2D.PlayerCharacter>();
        cc = GetComponentInParent<Gamekit2D.CharacterController2D>();
        currentTime = Time.time;
        prevgrav = pc.gravity;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E) && (Time.time >= currentTime + waitTime))
        {
            if (curhook == null)
            {
                currentTime = Time.time;
                Vector2 origin = transform.position;
                Vector2 dest = origin;
                float test = pc.GetFacing();
                //ContactFilter2D layer;
                dest.Set((origin.x + 1000) * test, (origin.y + 1000));
                RaycastHit2D cast = Physics2D.Raycast(origin, dest, 100);
                if (cast.collider != null)
                {
                    dest = cast.point;
                    curhook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);
                    curhook.GetComponent<ropeGrapple>().dest = dest;
                    pc.gravity = newgrav;
                    cc.setGrounded(true);
                }
            }
            else
            {
                currentTime = Time.time;
                Destroy(curhook);
                pc.gravity = prevgrav;
            }
        }
	}
}
