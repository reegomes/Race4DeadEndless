using UnityEngine;

public class CameraScript : MonoBehaviour {
	public Transform target;
	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	public void LateUpdate() {
		Vector3 cameraPosition = target.position + offset;	
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, cameraPosition, smoothSpeed);
		transform.position = smoothedPosition;
		
		transform.LookAt(target);
	}
	public void PointOfView(){
		offset = new Vector3(5f, 3f, -2);
	}
}
