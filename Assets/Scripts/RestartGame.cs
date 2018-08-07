using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour {
	public Vector3 initialPosition;
	[SerializeField]
	public Button btnRestart;
	[SerializeField]
	public Button btnQuit;
	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag("EndGame")){
		this.transform.position = initialPosition;
		this.transform.Rotate(180f, 0, 0);
		}
		//SceneManager.LoadScene("SampleScene");
		//Não da bake na cena
	}

	private void Start() {
		btnRestart.onClick.AddListener(ClickRestart);
		btnQuit.onClick.AddListener(ClickQuit);
	}
	void ClickRestart(){
		this.transform.Rotate(180f, 0, 0);
	}
	void ClickQuit(){
		Application.Quit();
	}
}
