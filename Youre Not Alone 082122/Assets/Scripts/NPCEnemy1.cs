using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEnemy1 : MonoBehaviour
{
    public float Espeed = 10.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos.z -= Espeed * Time.deltaTime;

        transform.position = pos;
    }
}
