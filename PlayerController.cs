using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//void Update () {//This function is for the frame of the game
	//}

	public float speed;
	public Text countText;
	public Text WinText;

	private Rigidbody rb;//Putting teh type of rigidbody on rb
	private int count;

	void Start () {//This function is the first frame of the game

		rb = GetComponent<Rigidbody>();//rb get de variable os RigidBody
		count = 0;
		SetCountText ();
		WinText.text = "";
	}

	void FixedUpdate () {//This function is for the physics of the  game

		float moveHorizontal = Input.GetAxis ("Horizontal");//Get de Movement of the player in the game in the Horizontal part

		float moveVertical = Input.GetAxis("Vertical");//Get de Movement of the player in the game in the Vertical part

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);//create a vector of 3 variables x = Horizontal y = Vertical z = Side  

		rb.AddForce(movement * speed);//Call the function AddForce in the object rb and deliver as parameter movement = Vector3	
			
	}

	void OnTriggerEnter(Collider other) {
		
		if(other.gameObject.CompareTag("Pick Up")){

			other.gameObject.SetActive (false);

			count++;

			SetCountText ();

		}
	}

	void SetCountText () {

		countText.text = "Nro de Pontos: " + count.ToString ();

		if (count >= 23) {
			
			WinText.text = "You Win!!!!";
				
		}
	}

}



