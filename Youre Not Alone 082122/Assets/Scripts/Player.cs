using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour



{

    public float speed = 10.5f;
    public GameObject Alien;

    public float timer;
    public bool thrown;

    // Update is called once per frame
    void Update()
    {
        if (thrown == true)
        {
            timer = timer + Time.deltaTime;
        }

        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.z += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.z -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }

        if (Input.GetKeyDown("x"))
        {
            thrown = true;
            if (timer <= .5f)
            {
                pos.x += speed * Time.deltaTime;
            }
        }
        if (Input.GetKeyUp("g"))
        {
            timer = 0;
            thrown = false;
        }

        transform.position = pos;
    }

    private void FixedUpdate()
    {
        //jumping need to be here
    }

}




