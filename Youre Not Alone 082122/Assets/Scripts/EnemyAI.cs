﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed ;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShoot;
    public float startTimeBtwShoot;

    public GameObject projectile;

    public Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShoot = startTimeBtwShoot;
    }

    private void Update() {
        
        if(Vector3.Distance(transform.position,player.position)> stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position,player.position,speed * Time.deltaTime);

        }
        else if(Vector3.Distance(transform.position,player.position)< stoppingDistance && Vector3.Distance(transform.position,player.position)> retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector3.Distance(transform.position,player.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
        }

        if(timeBtwShoot <=0)
        {
            Instantiate(projectile,transform.position,Quaternion.identity);
            timeBtwShoot = startTimeBtwShoot;
        }else{
            timeBtwShoot -= Time.deltaTime;
        }
    }
}
