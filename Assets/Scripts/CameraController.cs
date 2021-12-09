using UnityEngine;

public class CameraController : MonoBehaviour {

	private Vector3 targetPosition;
    public GameObject cameraTarget;
    public float cameraMoveSpeed;

	void Update () {
        /* Move camera follow the player */
        targetPosition = new Vector3(cameraTarget.transform.position.x - 4f, cameraTarget.transform.position.y + 7f, cameraTarget.transform.position.z - 5.5f);
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraMoveSpeed * Time.deltaTime);
	
	}
}