using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerController : MonoBehaviour {

    public float speed;

    [SerializeField]
    public float limit = 0f;

    public bool fired = false;

    public float timerStart = 0f;
    public float timerEnd = 0f;
    float timerResult = 0f;

    private InputDevice controller;
    private Rigidbody2D myRigidbody;
    public EmitterSpawner emitterSpawner;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        controller = InputManager.Devices[ GetComponent<PlayerTag>().playerNum ];
	}
	
	// Update is called once per frame
	void Update () {
        int activeIndex = InputManager.Devices.IndexOf( InputManager.ActiveDevice );
        myRigidbody.velocity = new Vector2(
            controller.LeftStick.X * speed,
            controller.LeftStick.Y * speed
            );

        if( controller.RightStick.Vector.magnitude != 0 )
        {
            if( controller.RightStick.Vector.x > 0 )
            {
                transform.rotation = Quaternion.Euler( 0, 0, -Vector2.Angle( controller.RightStick.Vector, Vector2.up ) );
            }
            else
            {
                transform.rotation = Quaternion.Euler( 0, 0, Vector2.Angle( controller.RightStick.Vector, Vector2.up ) - 360 );
            }

        }
        

        Timer( controller.RightTrigger.IsPressed );

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
        if( b )
        {
            fireDown();
        }
        else if( !b )
        {
            fireUp();
        }
    }

    void fireDown()
    {
        if( !fired )
        {
            timerStart = Time.time;
            fired = true;
        }
    }

    void fireUp()
    {
        if( fired )
        {
            timerEnd = Time.time;
            timerResult = timerEnd - timerStart;
            if( timerResult >= limit )
            {
                timerResult = limit;
            }

            // Emit a noodle
            float noodliness = Mathf.Max( 0.1f, timerResult / limit );
            emitterSpawner.Spawn( noodliness, noodliness );

            fired = false;
        }


    }
}