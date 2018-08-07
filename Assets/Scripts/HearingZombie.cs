using UnityEngine;
using UnityEngine.AI;

public class HearingZombie : MonoBehaviour {

	bool atkActive;
	bool enableAtk;
	NavMeshAgent nav;

	void Awake() {
		nav = GetComponent<NavMeshAgent>();
	}
	void OnTriggerStay(Collider other) {
		if(other.gameObject.CompareTag("SceneCars")){
			enableAtk = true;
		}
	}
	void Update() {
		if(enableAtk == true){

		}
	}
}
