using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    Rigidbody myBody;

    public float speed = 1f, reverse = 2f;

    public GameObject Camera;
    public float maxspeed = 17f, breakPower = 10f;

    PlayerControlls Pctrl;      
    public Vector2 move;

    public bool brk;
    void Awake()
    {
        Pctrl = new PlayerControlls();

        Pctrl.controlls.movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        Pctrl.controlls.movement.canceled += ctx => move = Vector2.zero;

        Pctrl.controlls.jump.performed += ctx => brk = true;
        Pctrl.controlls.jump.canceled += ctx => brk = false;
    }
    private void OnEnable()
    {
        Pctrl.controlls.Enable();
    }
    private void OnDisable()
    {
        Pctrl.controlls.Disable();
    }


    void Start()
    {
        myBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if (Input.GetButtonDown("R"))
            this.gameObject.transform.position = new Vector3(0, 1, -10);*/


        var forward = Camera.transform.forward;
        var right = Camera.transform.right;
        float velocity = myBody.velocity.magnitude;

        forward.Normalize();
        right.Normalize();
        forward.y = 0;
        right.y = 0;

        Quaternion rotation = Camera.transform.rotation;
        Vector3 dir = new Vector3(move.x, 0f, move.y);
        Vector3 transformedDir = Camera.transform.TransformDirection(dir);
        if(velocity <= maxspeed)
            myBody.AddForce(transformedDir * speed);

        //add force to move object in the desired direction

        /*if (Input.GetButton("W") && velocity <= maxspeed)
            myBody.AddForce(forward * speed);
        if (Input.GetButton("S") && velocity <= maxspeed)
            myBody.AddForce(forward * -speed * reverse);
        if (Input.GetButton("A") && velocity <= maxspeed)
            myBody.AddForce(right * -speed);
        if (Input.GetButton("D") && velocity <= maxspeed)
            myBody.AddForce(right * speed); */

        //break
        if (brk)
            myBody.AddForce(-myBody.velocity * breakPower); 

    }
}
