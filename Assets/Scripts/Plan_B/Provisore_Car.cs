using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Provisore_Car : MonoBehaviour {

  
    float move_h;


	// Use this for initialization
	void Awake () {
        StartCoroutine("Update_metod");
        
    }

    IEnumerator Update_metod()
    {
        Debug.Log("Corroutine_Proccess");
        Input_Axis_h();
        yield return new WaitForSeconds(0.05f);
        StartCoroutine("Update_metod");
    }


    void Input_Axis_h()
    {
        move_h = Input.GetAxis("Horizontal");
        //transform.Translate(0, 0, move_v * Time.deltaTime);
        transform.Rotate(0, move_h * 10, 0);

    }
    
}
