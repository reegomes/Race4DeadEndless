using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

    private int count_buttons;

    private Touch touch_mode;

    [SerializeField]
    private GameObject panel_Credits, Panel_Achieve, Panel_options_menu;

    private void Awake()
    {
        count_buttons = 0;
    }

    void Check_Buttons()
    {
        Debug.Log(count_buttons);
        switch (count_buttons)
        {
            case 0:
                Panel_options_menu.SetActive(false);
                panel_Credits.SetActive(false);
                Panel_Achieve.SetActive(false);
                break;
            case 1:
                SceneManager.LoadScene("Game_scene1");
                break;
            case 2:
                panel_Credits.SetActive(true);
                break;
            case 3:
                Panel_options_menu.SetActive(true);
                break;
            case 4:
                Application.Quit();
                break;
            case 5:
                Panel_Achieve.SetActive(true);
                break;

        }
    }

    //On Click Mode// Receive a Value
    /// <summary>
    /// Claim a Value into Unity inspector!!!
    /// </summary>
    /// <param name="ButtonValue"></param>
    public void ClickButton(int ButtonValue)
    {
        count_buttons = ButtonValue;
        Check_Buttons();
        //For security
        if (count_buttons != 3) { Panel_options_menu.SetActive(false); }
        if (count_buttons != 2) { panel_Credits.SetActive(false); }
    }

}
