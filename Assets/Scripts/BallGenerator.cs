using UnityEngine;
using System.Collections;

public class BallGenerator : MonoBehaviour {

	public GameObject prefab;
	public int maxBalls;
	private int counter;
	private float timer;

	// Use this for initialization
	void Start () {
		timer = 0F;
		maxBalls -=1;
		counter = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		float x = (float)Random.Range (-20, 20);
		float z = (float)Random.Range (-20, 20);
		if (timer == 0F && counter < maxBalls) {
			GameObject obj = Instantiate (prefab, new Vector3 (x, 3F, z), Quaternion.identity) as GameObject;
		}
		timer+= Time.deltaTime;

		if(counter < maxBalls && timer > 10F){
			timer = 0F;
			counter++;
		}
		
	}
}
