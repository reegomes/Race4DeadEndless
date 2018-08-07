using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScenario : MonoBehaviour {

	AudioSource audio1;
	// Use this for initialization
	void Start () {
		audio1 = GetComponent<AudioSource>();
	}
	void OnCollisionEnter(Collision other) {
		if(other.gameObject.CompareTag("Player")){
			audio1.Play();
		}	
	}
}
