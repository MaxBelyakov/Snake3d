using UnityEngine;

public class TailMovement : MonoBehaviour {

	public GameObject target;
	public SnakeMovement snake;
	private float speed;
	public int index; //Need to ignore first tail items when head rotating

	//Find the previous snake element
	void Start () {
		snake = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<SnakeMovement>();
		target = snake.snakeTail[snake.snakeTail.Count - 2];
		speed = snake.speed + 1.5f;
		index = snake.snakeTail.IndexOf(gameObject);
	}
	
	//Move to target
	void Update () {
		transform.LookAt(target.transform.position);
		transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
	}
}