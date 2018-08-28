using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopStats : MonoBehaviour
{
    public static int velocity, gas, angle, mass, nitro;
    public static int points = 100;
}

public class Shop : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI velocity;
    [SerializeField]
    TextMeshProUGUI gas;
    [SerializeField]
    TextMeshProUGUI angle;
    [SerializeField]
    TextMeshProUGUI points;
    [SerializeField]
    TextMeshProUGUI mass;
    private void Start()
    {
        ShopStats.velocity = PlayerPrefs.GetInt("Velocity", ShopStats.velocity);
        ShopStats.gas = PlayerPrefs.GetInt("Gas", ShopStats.gas);
        ShopStats.mass = PlayerPrefs.GetInt("Mass", ShopStats.mass);
    }

    private void Update()
    {
        gas.text = ShopStats.gas.ToString();
        velocity.text = ShopStats.velocity.ToString();
        angle.text = ShopStats.angle.ToString();
        mass.text = ShopStats.mass.ToString();
        points.text = "Pontuação: " + ShopStats.points.ToString();
    }
    public void OnClickGas()
    {
        if (ShopStats.gas <= ShopStats.points)
        {
            ShopStats.gas++;
            ShopStats.points--;
            PlayerPrefs.SetInt("Gas", ShopStats.gas);
            
            //Debug.Log(ShopStats.gas);
        }
    }
    public void OnClickVelocity()
    {
        if (ShopStats.velocity <= ShopStats.points)
        {
            ShopStats.velocity++;
            ShopStats.points--;
            PlayerPrefs.SetInt("Velocity", ShopStats.velocity);
            Archievements.VSFasterAsFuck = true;
            //Debug.Log(ShopStats.velocity);
        }
    }
    public void OnClickMass()
    {
        if (ShopStats.mass <= ShopStats.points)
        {
            ShopStats.mass++;
            ShopStats.points--;
            PlayerPrefs.SetInt("Mass", ShopStats.mass);
            
        }
    }
    public void OnClickAngle()
    {
        if (ShopStats.angle <= ShopStats.points)
        {
            ShopStats.angle++;
            ShopStats.points--;
            PlayerPrefs.SetInt("Angle", ShopStats.angle);
        }
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}