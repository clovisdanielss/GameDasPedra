using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	public void Reset(){
		Application.LoadLevel ("Scene_1");
	}
}
