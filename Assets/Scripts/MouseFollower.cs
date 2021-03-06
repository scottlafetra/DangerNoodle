using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour {

    [SerializeField]
    public float limit = 0f;

    public bool fired = false;

    public float timerStart = 0f;
    public float timerEnd = 0f;
    float timerResult = 0f;

    public EmitterSpawner emitterSpawner;

    void Update()
    {
        GunRot();
        //Timer(Input.GetButton("Fire"));
        Timer(Input.GetMouseButton(0));
    }

    void GunRot()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90 );
    }

    //void OtherRot()
    //{
    //    Vector3 difference = new Vector3(Input.GetAxis("RightJoystickX"), Input.GetAxis("RightJoystickY"));
    //    difference.Normalize();
    //    float rotY = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
    //    transform.rotation = Quaternion.Euler(0f, rotY - 90, 0f);
    //}


    void Timer(bool b)
    {
        if (b)
        {
            fireDown();
        }
        else if (!b)
        {
            fireUp();
        }
    }

    void fireDown()
    {
        if (!fired)
        {
            timerStart = Time.time;
            fired = true;
        }
    }

    void fireUp()
    {
        if (fired)
        {
            timerEnd = Time.time;
            timerResult = timerEnd - timerStart;
            if (timerResult >= limit)
            {
                timerResult = limit;
            }

            // Emit a noodle
            float noodliness = Mathf.Max(0.05f, timerResult / limit);
            emitterSpawner.Spawn( noodliness, noodliness );

            fired = false;
        }
        
            
    }

}
