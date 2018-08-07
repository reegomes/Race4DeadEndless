using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankZombie : MonoBehaviour {
	public Transform carPlayer;
	float distance;
	Rigidbody tankRB;
	float Move = 8f;
	public bool canJump;
	NavMeshAgent agent;
	void Start() {
		tankRB = GetComponent<Rigidbody>();
		agent = GetComponent<NavMeshAgent>();
	}
	void Update() {
			transform.LookAt(carPlayer);
			distance = Vector3.Distance(this.transform.position, carPlayer.transform.position);
			if (distance >= 10f && distance <= 15f && canJump == true){
				Jump();
				// Não está funcionando tão bem quanto eu imaginei, vou mudar depois
				canJump = false;
			} if (distance <= 13f){
				//Follow();
				//agent.destination = carPlayer.position;
				//Os dois funcionam bem, mas vou desativar para não atrapalhar o teste de outras funcionalidades.
			} 
	}
	void Jump(){
		tankRB.AddForce(0f,100f,0f);
	}
	void Follow(){
		transform.position = Vector3.MoveTowards(transform.position, carPlayer.position, Move * Time.deltaTime);
	}
	void OnCollisionStay(Collision other) {
		if(other.gameObject.CompareTag("Buildings")){
			canJump = true;
		} else {
			canJump = false;
		}
	}
}