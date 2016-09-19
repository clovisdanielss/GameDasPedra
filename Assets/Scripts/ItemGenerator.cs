using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemGenerator : MonoBehaviour {

	public GameObject prefab;
	public int maxCol;
	private int counter;
	private float timer;
	public Text totalItems;

	// Use this for initialization
	void Start () {
		timer = 0F;
		counter = 0;
		totalItems.text = maxCol.ToString();
	}

	// Update is called once per frame
	void Update () {
		float x = (float)Random.Range (-40, 40);
		float z = (float)Random.Range (-40, 40);
		if (timer == 0F && counter < maxCol) {
			GameObject obj = Instantiate (prefab, new Vector3 (x, 1F, z), Quaternion.identity) as GameObject;
		}
		timer+= Time.deltaTime;

		if(counter < maxCol && timer > 4F){
			timer = 0F;
			counter++;
		}

	}
}
