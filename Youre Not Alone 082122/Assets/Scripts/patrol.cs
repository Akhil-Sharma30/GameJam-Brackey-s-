using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startingTime;

    public Transform[] moveSpots;
    private int randomSpot;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startingTime;
        randomSpot = Random.Range(0,moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,moveSpots[randomSpot].position,speed*Time.deltaTime);
        
        if(Vector3.Distance(transform.position,moveSpots[randomSpot].position) < 0.2f)
        {
            if(waitTime <=0){
                randomSpot = Random.Range(0,moveSpots.Length);
                waitTime = startingTime;
            }
            else{
                waitTime -= Time.deltaTime;
            }
        }
    }
}
