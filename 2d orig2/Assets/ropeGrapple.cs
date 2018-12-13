using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeGrapple : MonoBehaviour {

    public Vector2 dest;
    public float speed = 1;
    public float spacing = 2;
    public GameObject node;
    private GameObject pc;
    //public Vector3 lastVec;
    public GameObject lastNode;
    bool done = false;

	// Use this for initialization
	void Start () {
        pc = GameObject.FindGameObjectWithTag("Player");
        lastNode = transform.gameObject;
        //lastVec = pc.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, dest, speed);
      
        if((Vector2) transform.position != dest)
        {
            if(Vector2.Distance(pc.transform.position, lastNode.transform.position) > spacing)
            {
                createNode();
            }
        }
        else if(done == false)
        {
            done = true;
            lastNode.GetComponent<HingeJoint2D>().connectedBody = pc.GetComponent<Rigidbody2D>();
        }
	}

    void createNode()
    {
        Vector2 position = pc.transform.position - lastNode.transform.position;
        position.Normalize();
        position *= spacing;
        position += (Vector2) lastNode.transform.position;
        GameObject nextNode = (GameObject) Instantiate(node, position, Quaternion.identity);
        nextNode.transform.SetParent(transform);

        lastNode.GetComponent<HingeJoint2D>().connectedBody = nextNode.GetComponent<Rigidbody2D>();
        //lastVec = curNode.transform.position;
        lastNode = nextNode;
    }
}
