using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPadMover : MonoBehaviour {

    public float speed;
    private Rigidbody ballRigidbody;
    SteamVR_TrackedObject controller;

	// Use this for initialization
	void Start () {
		
	}

    private void Awake()
    {
        this.controller = GetComponent<SteamVR_TrackedObject>();
        this.ballRigidbody = GameObject.Find("Ball").GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var device = SteamVR_Controller.Input((int)controller.index);

        // if touching the touchpad, we'll move the ball
        if ( device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad) )
        {
            var model = this.transform.Find("Model");
            Transform trackpad = model.Find("trackpad").Find("attach");
            Transform touch = model.Find("trackpad_touch").Find("attach");

            Vector3 movement = (touch.position) - (trackpad.position);
            movement = new Vector3(movement.x, 0, movement.z);
            movement.Normalize();

            this.ballRigidbody.AddForce(movement * speed);
        }
    }
}
