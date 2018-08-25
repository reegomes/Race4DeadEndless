using UnityEngine;

public class Lights : MonoBehaviour
{

    Light lights;
    float timer;
    void Start()
    {
        lights = GetComponent<Light>();
        timer = 2f;
    }
    void Update()
    {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            lights.enabled = true;
            timer = 2f;
        }
        else
        {
            lights.enabled = false;
        }
    }
}
