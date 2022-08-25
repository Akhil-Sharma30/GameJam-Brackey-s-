using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowscript : MonoBehaviour
{
    
    public Transform target;//set target from inspector instead of looking in Update
    public float speed;
    public float timer;
    public bool thrown;
    private bool wentUp;
    private bool wentDown;
    private bool wentLeft;
    private bool wentRight;


    // Update is called once per frame
    void Update()
    {
        
        if (timer <= .5f && thrown == true)
        {

        
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation


        //move towards the player
        if (Vector3.Distance(transform.position, target.position) > .1f)
        {//move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        }
        

        if (thrown == true)
        {
            timer = timer + Time.deltaTime;
        }
        if (Input.GetKeyDown("w"))
        {
            wentUp = true;
            wentDown = false;
            wentLeft = false;
            wentRight = false;
        }
        if (Input.GetKeyDown("s"))
        {
            wentUp = false;
            wentDown = true;
            wentLeft = false;
            wentRight = false;
        }
        if (Input.GetKeyDown("d"))
        {
            wentUp = false;
            wentDown = false;
            wentLeft = false;
            wentRight = true;
        }
        if (Input.GetKeyDown("a"))
        {
            wentUp = false;
            wentDown = false;
            wentLeft = true;
            wentRight = false;
        }
        Vector3 pos = transform.position;
        if (Input.GetKey("t"))
        {
           
            if ( wentUp == true )
            {
                pos.z += speed * Time.deltaTime;
                pos.y += speed * Time.deltaTime;
            }
            if (wentDown == true )
            {
                pos.z -= speed * Time.deltaTime;
                pos.y += speed * Time.deltaTime;
            }
            if (wentRight == true)
            {
                pos.x += speed * Time.deltaTime;
                pos.y += speed * Time.deltaTime;
            }
            if (wentLeft == true)
            {
                pos.x -= speed * Time.deltaTime;
                pos.y += speed * Time.deltaTime;
            }
        }
        if (Input.GetKey("g"))
        {
            
            thrown = true;
            if (timer > .5f && timer <= 1f)
            {
        
                //pos.x -= speed * Time.deltaTime;
                if (wentUp == true)
                {
                    pos.z -= speed * Time.deltaTime;

                }
                if (wentDown == true)
                {
                    pos.z += speed * Time.deltaTime;

                }
                if (wentRight == true)
                {
                    pos.x -= speed * Time.deltaTime;

                }
                if (wentLeft == true)
                {
                    pos.x += speed * Time.deltaTime;

                }
            }


            
        }
        if (Input.GetKeyUp("g"))
        {
            timer = 0;
            thrown = false;
            
        }
       
        
        transform.position = pos;
    }
}
