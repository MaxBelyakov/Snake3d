using UnityEngine;

public class ItemGenerator : MonoBehaviour {

	public GameObject ItemPrefab;
	private GameObject item;

	//Create item at the beggining
	void Start() {
		AddNewItem();
	}

	//Checking item in the game
	void Update() {
		if (!item) {
			AddNewItem();
		}
	}
	
	//Create item
	void AddNewItem() {
		var item_position = new Vector3(Random.Range(-4.5f, 4.5f), 0.25f, Random.Range(-4.5f, 4.5f));
		item = Instantiate(ItemPrefab, item_position, Quaternion.identity);
	}
}