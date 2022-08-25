using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public int curHealth = 0;
    public int maxHealth = 100;
    // Start is called before the first frame update public int curHealth = 0;
   

    public HealthBar healthBar;

    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        Debug.Log(curHealth);
    //    if(Input.GetKeyDown(KeyCode.Space))
    //    {
    //     DamagePlayer(10);
    //    }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.transform.tag == "Player")
        {
            DamagePlayer(5);
        }
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;

        healthBar.SetHealth(curHealth);
    }
}
