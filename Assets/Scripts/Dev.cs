using UnityEngine;
using UnityEngine.UI;

public class Dev : MonoBehaviour {
    Toggle neon;
    private void Start() {
        neon = GetComponent<Toggle>();
    }
    private void Update() {
        if(neon.isOn){
            CarControllerEndless.neon = true;
        }
        else
        {
            CarControllerEndless.neon = false;
        }
    }
}