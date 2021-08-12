 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayCast : MonoBehaviour
{
    class collider          //collider represents the structure(class) for the Collider and the float. NOT to be confused with Collider which is the component of the object!!
    {
        public Collider col;
        public float remainingTime;

        public collider(Collider col, float remainingTime)
        {
            this.col = col;
            this.remainingTime = remainingTime;
        }
    }

    public float floatingTime = 5f;       //how many seconds should the object float
    public bool firingMode;                    //float <-> explode/implode

    public float x=0, y=0, z=0;
    public float liftForce;
    public GameObject camera, light;
    public GameObject ball;

    GameObject bomb;
    Collider[] collidersHit;    //array of Collider where i put the result from overlap sphere
    List<collider> colList = new List<collider>();

    bool OnFire;
    PlayerControlls controlls;
    private void Awake()
    {
        controlls = new PlayerControlls();

        controlls.controlls.fire.started += ctx => Fire();
    }
    void Fire()
    {
        OnFire = true;
    }
    private void OnEnable()
    {
        controlls.controlls.fire.Enable();
    }
    private void OnDisable()
    {
        controlls.controlls.fire.Disable();
    }

    void Update()
    {
        RaycastHit hit;

        transform.position = camera.transform.position;     //update position of the ray each fram

        Vector3 myRay = (camera.transform.forward) * 10f;
        Debug.DrawRay(camera.transform.position, myRay, Color.green);

        for (int i = 0;i<colList.Count;i++)                   //update time for each object and if the time expired turn gravity back on
        {
            colList[i].remainingTime -= Time.deltaTime;
            if (colList[i].remainingTime <= 0f)
            {
                colList[i].col.GetComponent<Rigidbody>().useGravity = true;
                colList.Remove(colList[i]);

                Destroy(bomb);
            }
        }

        if (Physics.Raycast(camera.transform.position, myRay, out hit, 100f) && OnFire && !firingMode)
        {
            bomb = Instantiate(light, hit.point + new Vector3(0f,.1f,0f), Quaternion.Euler(0f, 0f, 0f));       //instantiate the light with a .1 vertical offset
            print("Found an object - distance: " + hit.distance);

            collidersHit = Physics.OverlapSphere(hit.point, 5f);
            makeList(collidersHit);       //put colliders with a RigidBody component in a list

            foreach(collider col in colList)                            // sets the gravity to 0, lifts and rotates the object
            {
                if (col.col.GetComponent<Rigidbody>().useGravity)             // if is not floating (according to its useGravity) the add a force and set its gravity to false!!!
                {
                    liftCollider(col.col, hit.point, liftForce);
                    col.col.GetComponent<Rigidbody>().useGravity = false;
                }
            }

            firingMode = true;
            OnFire = false;         //only fire for this frame!!!
        }
        else if (OnFire && firingMode)
        {
            for (int i = 0; i < colList.Count; i++)                   //update time for each object and if the time expired turn gravity back on
            {
                if (!colList[i].col.GetComponent<Rigidbody>().useGravity)             // if is not floating (according to its useGravity) the add a force and set its gravity to false!!!
                {
                    explode(colList[i].col, bomb.transform.position);
                    colList[i].col.GetComponent<Rigidbody>().useGravity = true;
                    colList[i].remainingTime = 0f;
                }
            }
            Destroy(bomb);
            firingMode = false;
            OnFire = false;
        }

    }

    void makeList(Collider[] cols)        //puts all game objects that have a rigidbody component into a list and puts it in !! colList !!
    {
        foreach (var col in cols)
            if (col.gameObject.GetComponent<Rigidbody>() != null)
            {
                collider aux = new collider(col, floatingTime);
                if(!colList.Contains(aux))
                    colList.Add(aux);
            }
    }

    void liftCollider(Collider collider, Vector3 PointHit,float force)
    {
        Vector3 dir = collider.gameObject.transform.position - PointHit;
        dir.Normalize();
        collider.gameObject.GetComponent<Rigidbody>().AddForce(dir * force + new Vector3(0f,2*force,0f)); //lift objects into the air
        collider.GetComponent<Rigidbody>().AddTorque(Random.insideUnitCircle.normalized * 2);            //rotate it in random direction
    }

    void explode (Collider collider, Vector3 PointHit)   //applys force on an object opposite to the point of impact
    {
        Vector3 dir = collider.gameObject.transform.position - PointHit;
        dir.Normalize();
        collider.gameObject.GetComponent<Rigidbody>().AddForce(dir * 200f);
    }
}
