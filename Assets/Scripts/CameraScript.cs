using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed;
    public Vector3 offset;
    
    //public static bool pov = false;
    public void LateUpdate()
    {
        Vector3 cameraPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, cameraPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
    /*
	private void FixedUpdate() {
        smoothSpeed = (Mathf.Clamp(Time.deltaTime, 1f, -15f));
		if (pov == true)
        {
            for (int i = 0; i < (int)smoothSpeed; i++)
            {
                smoothSpeed--;
            }
            //smoothSpeed = -0.125f;
        }
        else
        {
            //smoothSpeed = 1;
        }
	}
    */
}
