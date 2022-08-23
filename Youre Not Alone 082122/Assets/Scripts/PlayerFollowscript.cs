using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowscript : MonoBehaviour
{
    
    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 10f;
    public float timer;
    public bool thrown;


    // Update is called once per frame
    void Update()
    {

        if (timer >= 1 && thrown == true)
        {

        
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation


        //move towards the player
        if (Vector3.Distance(transform.position, target.position) > 1f)
        {//move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        }

        if (thrown == true)
        {
            timer = timer + Time.deltaTime;
        }
        Vector3 pos = transform.position;
        if (Input.GetKey("t"))
        {
            pos.x += speed * Time.deltaTime;
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKeyDown("g"))
        {
            
            thrown = true;
            if (timer <= 1f)
            {
        
                pos.x -= speed * Time.deltaTime;
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
