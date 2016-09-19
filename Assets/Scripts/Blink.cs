using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {

	private float timer = 0;
	public Texture tex1,tex2;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Material> ().SetTexture(tex1.name,tex1);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 1F) {
			gameObject.GetComponent<Material> ().SetTexture(tex2.name,tex2);
			if (timer > 1.5F) {
				timer = 0;
				gameObject.GetComponent<Material> ().SetTexture(tex1.name,tex1);
			}
		}
			
	}
}
