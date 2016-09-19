using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character : MonoBehaviour {
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public float rotationX;
	public float rotationY;
	public Text itemsCollected,totalItems;
	public int counter = 0;

	private Vector3 moveDirection = Vector3.zero;
	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) { // Se o objeto estiver no chao...
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection); // Essa linha faz o objeto andar em si... ate entao movedirection era soh um vetor.
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;

		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
		OnMouseMoved ();
//		OnMouseMovedX ();
//		OnMouseMovedY ();
	}

	private void OnMouseMoved(){
		rotationX -= Input.GetAxis ("Mouse Y") * 5f;
		rotationY += Input.GetAxis ("Mouse X") * 5f;

		transform.rotation = Quaternion.Euler (rotationX, rotationY,0);
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("collectable")) {
			Destroy (other.gameObject);
			counter++;
			itemsCollected.text = "Items Collected: " + counter;
		}
		if (counter.ToString().Equals (totalItems.text))
			Application.LoadLevel("Winner");
	}
}



/* Essa bosta toda pra representar a mesma coisa que os cara fizeram em 3 linhas......    Quaternion eh o poder, usado para representar rotacoes...
	public void OnMouseMovedX(){
		if (oldMousePosition != Input.mousePosition) {
			if (oldMousePosition.x < Input.mousePosition.x)
				Camera.main.transform.Rotate (new Vector3 (0F, Input.mousePosition.x, 0F) * Time.deltaTime);
			else if (oldMousePosition.x > Input.mousePosition.x)
				Camera.main.transform.Rotate (new Vector3 (0F, -Input.mousePosition.x, 0F) * Time.deltaTime);
		}
	}
	//Preciso ajustar o problema que acontece quando faço os dois ao mesmo tempo...
	public void OnMouseMovedY(){
		if (oldMousePosition != Input.mousePosition) {
			if (oldMousePosition.y < Input.mousePosition.y)
				Camera.main.transform.Rotate (new Vector3 (-Input.mousePosition.y, 0F, 0F) * Time.deltaTime);
			else if (oldMousePosition.y > Input.mousePosition.y)
				Camera.main.transform.Rotate (new Vector3 (Input.mousePosition.y, 0F, 0F) * Time.deltaTime);
		}
	}*/