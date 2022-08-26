using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour



{

    public float speed = 3f;
    public GameObject Alien;

    public float timer;
    public bool thrown;
    public float sideStepSpeed = 2;
    private bool wentUp;
    private bool wentDown;
    private bool wentLeft;
    private bool wentRight;
    public float jumpSpeed = 3;
    public bool jumped;
    public float jumpTimer;
    private Rigidbody selfRigidbody;
    private bool canJump;
    public int forceConst = 10;
    public bool grounded;

    //new
    [SerializeField]
    private Transform cylinderPrefab;

    public GameObject leftSphere;
    public GameObject rightSphere;
    private GameObject cylinder;

    

    private void Start()
    {
        selfRigidbody = GetComponent<Rigidbody>();
        wentRight = true;
        //new
        //leftSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //rightSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //leftSphere.transform.position = new Vector3(-1, 0, 0);
        //rightSphere.transform.position = new Vector3(1, 0, 0);

        InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        //new
       // leftSphere.transform.position = new Vector3(-1, -2f * Mathf.Sin(Time.time), 0);
        //rightSphere.transform.position = new Vector3(1, 2f * Mathf.Sin(Time.time), 0);

        UpdateCylinderPosition(cylinder, leftSphere.transform.position, rightSphere.transform.position);

        if (thrown == true)
        {
            timer = timer + Time.deltaTime;
        }
        if ( jumped == true)
        {
            jumpTimer = jumpTimer + Time.deltaTime;
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

        // for directional side step
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
        if (Input.GetKey("g"))
        {
            thrown = true;
            if (timer > .5f && timer <= 1f)
            {
                //pos.x += sideStepSpeed * Time.deltaTime;
                if (wentUp == true)
                {
                    pos.z += speed * Time.deltaTime;
                    
                }
                if (wentDown == true)
                {
                    pos.z -= speed * Time.deltaTime;
                    
                }
                if (wentRight == true)
                {
                    pos.x += speed * Time.deltaTime;
                    
                }
                if (wentLeft == true)
                {
                    pos.x -= speed * Time.deltaTime;
                    
                }
            }
        }
        if (Input.GetKeyUp("g"))
        {
            timer = 0;
            thrown = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            canJump = true;
        }

        transform.position = pos;
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        
        if (canJump && grounded)
        {
            canJump = false;
            selfRigidbody.AddForce(0, forceConst, 0, ForceMode.Impulse);
        }
        

        transform.position = pos;
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            canJump = false;
            grounded = false;
            selfRigidbody.AddForce(0, forceConst, 0, ForceMode.Impulse);
            Debug.Log("Not grounded");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            grounded = true;
            Debug.Log("grounded");
        }
    }

    //new
    private void InstantiateCylinder(Transform cylinderPrefab, Vector3 beginPoint, Vector3 endPoint)
    {
        cylinder = Instantiate<GameObject>(cylinderPrefab.gameObject, Vector3.zero, Quaternion.identity);
        UpdateCylinderPosition(cylinder, beginPoint, endPoint);
    }

    private void UpdateCylinderPosition(GameObject cylinder, Vector3 beginPoint, Vector3 endPoint)
    {
        Vector3 offset = endPoint - beginPoint;
        Vector3 position = beginPoint + (offset / 2.0f);

        cylinder.transform.position = position;
        cylinder.transform.LookAt(beginPoint);
        Vector3 localScale = cylinder.transform.localScale;
        localScale.z = (endPoint - beginPoint).magnitude;
        cylinder.transform.localScale = localScale;
    }



}




