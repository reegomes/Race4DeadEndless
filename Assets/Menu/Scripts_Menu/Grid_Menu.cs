using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class Grid_Menu : MonoBehaviour {


    //Panel
    [SerializeField]
    private TextMesh trophy_desc_panel_name, trophy_desc_panel_Description;
    [SerializeField]
    private GameObject Panel_Desc_trophy;
    private Sprite actual_image_button_pressed;
    [SerializeField]
    private Button actual_button_pressed;

    private int Count_Value;


    // Use this for initialization
    void Awake () {

        Count_Value = 0;
        actual_button_pressed = GetComponent<Button>();
        actual_button_pressed.image.sprite = actual_image_button_pressed;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		if(Count_Value != 0)
        {
            Panel_Transition();
        }
	}

    public void Invoke_Button_Trophy(int value_Button, string name_button, Sprite button_image, string desc_button)
    {
        Count_Value = value_Button;
        trophy_desc_panel_name.text = name_button;
        actual_image_button_pressed = button_image;
        trophy_desc_panel_Description.text = desc_button;

    }

    public void Panel_Transition()
    {
        Panel_Desc_trophy.SetActive(true);
    }

}
