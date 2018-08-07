using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody body;

    private Transform filho;

    [SerializeField]
    private float speed = 15.0f;

    [SerializeField]
    private Joystick joystick;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        filho = GetComponentInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        /* float h = Input.GetAxisRaw("Horizontal");
         float v = Input.GetAxisRaw("Vertical");

         h = h * speed * Time.deltaTime;
         v = v * speed * Time.deltaTime;

         body.AddForce(h, 0.0f, v); 
         */
        transform.Translate(joystick.inputDirection*Time.deltaTime);

        //filho.Rotate(Vector3.up  * joystick.inputDirection.);

        //Vector3 direction = new Vector3(joystick.inputDirection.x, joystick.inputDirection.y,0);
        //Quaternion rotation = Quaternion.LookRotation(direction, Vector3.right);
        //filho.rotation = rotation;





    }

    public void Jump() {
        body.AddForce(0.0f, 500.0f, 0.0f);
    }
}
