using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceTowardsPoint : MonoBehaviour
{
    public Transform model;
    public float x = 0, y = 0, z = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction_to_model = model.transform.position - transform.position + new Vector3(x,y,z);
        Quaternion rotation = Quaternion.LookRotation(direction_to_model, Vector3.up);
        transform.rotation = rotation;
    }
}
