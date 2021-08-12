using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    public float maxSpeed = 16f;
    public float offset = -0.3f;
    public GameObject Ball;
    Rigidbody BallRB;

    void Start()
    {
        BallRB = Ball.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.position = Ball.transform.position + new Vector3(0f,offset,0f);
        Vector3 pointTowards = BallRB.velocity;
        pointTowards.y = -1f;
        transform.LookAt((-1) * pointTowards * 200f, Vector3.up);


        if (BallRB.velocity.magnitude >= maxSpeed-1)           //play when at top speed
            this.gameObject.GetComponent<ParticleSystem>().Play();
        if (BallRB.velocity.magnitude < maxSpeed-1)
            this.gameObject.GetComponent<ParticleSystem>().Stop();
    }
}
