using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakScript_Particles : MonoBehaviour
{
    public Vector3 offset, direction = new Vector3(0f,3f,0f);
    public GameObject Ball;
    Rigidbody BallRB;

    void Start()
    {
        BallRB = Ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Ball.transform.position + offset;
        Vector3 pointTowards = BallRB.velocity + direction;
        //pointTowards.y = -30f;
        transform.LookAt(pointTowards * 50f, Vector3.up);

        if (Ball.GetComponent<Movement>().brk && BallRB.velocity.magnitude >= 15f)
            this.gameObject.GetComponent<ParticleSystem>().Play();
        if(!Ball.GetComponent<Movement>().brk || BallRB.velocity.magnitude < 9f)
            this.gameObject.GetComponent<ParticleSystem>().Stop(); 

    }
}
