using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeMovement : MonoBehaviour {

	public float speed;
	public float rotation_speed;

	public List<GameObject> snakeTail = new List<GameObject>();
	public GameObject talePrefab;
	public Text textPrefab;
	public int score = 0;

	//Add Head to List as 1 element
	void Start() {
		snakeTail.Add(gameObject);
	}

	//Moving forward and listenint for rotation
	void Update() {
		transform.Translate(Vector3.forward * speed * Time.deltaTime);

		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Rotate(Vector3.up * -1 * rotation_speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Rotate(Vector3.up * rotation_speed * Time.deltaTime);
		}

		//Update score text
		textPrefab.text = score.ToString();

	}

	//Add new tail to the end of the snake
	public void AddTail() {
		var newTailPosition = snakeTail[snakeTail.Count - 1].transform.position;

		//fix: correct tail position to avoid collision with head
		if (snakeTail.Count == 2)
			newTailPosition.x = newTailPosition.x - 0.5f;

		snakeTail.Add(Instantiate(talePrefab, newTailPosition, Quaternion.identity) as GameObject);
		score++;
	}

	//GameOver scenario
	void OnTriggerEnter (Collider collision) {
		if (collision.tag == "Tail") {
			if (collision.GetComponent<TailMovement>().index > 3) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
		if (collision.tag == "Boarder") {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}