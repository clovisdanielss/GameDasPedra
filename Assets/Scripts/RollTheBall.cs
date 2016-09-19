using UnityEngine;
using System.Collections;

public class RollTheBall : MonoBehaviour {

	private Rigidbody rb;
	private float timer;
	private float direction;
	private Vector3 move;
	private string goingTo;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		timer = 0F;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer == 0) {
			direction = (float)Random.Range (-1, 1);
			if(GoingTo(direction,Random.Range(0,100)) < 50)
				move = new Vector3 (0F, 0F, direction * 30F);
			else
				move = new Vector3 (direction * 30F, 0F, 0F);
		}
		rb.AddForce (move);
		timer += Time.deltaTime;

		if (timer > 3F) {
			timer = 0F;
		}
	}

	private int GoingTo(float dir, int chance){
		switch ((int)dir) {
		case -1:
			if (chance < 50)
				goingTo = "down";
			else
				goingTo = "left";
			break;
		case 1:
			if (chance < 50)
				goingTo = "top";
			else
				goingTo = "right";
			break;
		}

		return chance;
	}
		
	private void RollBack(){
		switch (goingTo) {
		case "top":
			goingTo = "down";
			move = new Vector3 (0F, 0F, -30F);
			rb.AddForce (move);
			break;
		case "down":
			goingTo = "top";
			move = new Vector3 (0F, 0F, 30F);
			rb.AddForce (move);
			break;
		case "left":
			goingTo = "right";
			move = new Vector3 (30F, 0F, 0F);
			rb.AddForce (move);
			break;
		case "right":
			goingTo = "left";
			move = new Vector3 (-30F, 0F, 0F);
			rb.AddForce (move);
			break;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("wall")) {
			RollBack ();
		}
		if (other.CompareTag ("MainCamera")) {
			Debug.Log ("Testing Collider");
			Application.LoadLevel ("Loser");
		}
	}
}
