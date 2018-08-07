using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastPlayer : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.up * -1, out hit, 10f)){
			Debug.Log("Colidiu");
			Debug.DrawLine(transform.position, hit.point, Color.green);
		} else {
			Debug.Log("Não Colidiu");
			Debug.DrawLine(transform.position, hit.point, Color.yellow);
			Invoke("EndGame", 1f);
		}		
	}
	void EndGame(){
		Time.timeScale = 0f;
		Debug.Log("Perdeu");
	}
}
