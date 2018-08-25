using UnityEngine;

public class RayCastPlayer : MonoBehaviour {

	void Update () {
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.up * -1, out hit, 40f)){
			//Debug.Log("Colidiu");
			Debug.DrawLine(transform.position, hit.point, Color.green);
		} else {
			//Debug.Log("Não Colidiu");
			Debug.DrawLine(transform.position, hit.point, Color.yellow);
			Invoke("EndGame", 1f);
		}
	}
	private void OnCollisionExit(Collision other) {
		if(other.gameObject.CompareTag("Zombie")){
				ShopStats.points++;
				//Debug.Log(ShopStats.points);
			}
	}
	void EndGame(){
		Time.timeScale = 0f;
		Debug.Log("Perdeu");
	}

}
