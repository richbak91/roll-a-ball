using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {

	public float speed;
	public GUIText counterTxt;
	public GUIText winTxt;
	private int counter;
	
	void Start (){
		counter = 0;
		SetCounterTxt ();
		winTxt.text = "";
	}

	// Update is called once per frame
	void Update () {	
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0 , moveVertical);

		rigidbody.AddForce(movement*speed*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Item") {
			other.gameObject.SetActive(false);
			counter = counter + 1;
			SetCounterTxt();
		}
	}

	void SetCounterTxt(){
		counterTxt.text = "Count = " + counter.ToString ();
		if (counter >= 12) {
			winTxt.text = "YOU WIN!!!";
			counterTxt.text = "";
		}
	}
}
