using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPlayer : MonoBehaviour
{
    public GameObject afterimage;
    private bool telActive;
    private Vector3 location;
    private GameObject img;
// private Gamekit2D.PlayerCharacter pc;

    // Use this for initialization
    void Start()
    {
        //pc = GetComponentInParent<Gamekit2D.PlayerCharacter>();
        
        telActive = false;
        location = this.gameObject.transform.position;
// location = pc.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (telActive == true)
            {
                // pc.transform.position = location;
                this.gameObject.transform.position = location;
                telActive = false;
                Destroy(img);
            }

            else if (telActive == false)
            {
                // location = pc.transform.position;
                location = this.gameObject.transform.position;
                telActive = true;
                img = Instantiate(afterimage, location, Quaternion.identity);
            }
        }
    }
}