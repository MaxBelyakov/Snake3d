using UnityEngine;

public class ItemController : MonoBehaviour {

	//Listening for getting item
	void OnTriggerEnter(Collider collision) {
		if (collision.tag == "SnakeHead") {
			collision.GetComponent<SnakeMovement>().AddTail();
			Destroy(gameObject);
		}
	}
}
