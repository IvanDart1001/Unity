using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;


public class PlayerController2 : MonoBehaviour {


	public float speed;
	public Text CountText;


	private Rigidbody rb;
	private int Count ;
	public Text winText;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		Count = 0;
		SetCountText ();
		winText.text = "";
	}

	/*
	 * physics code will go
	 * 
	 */

	void FixedUpdate(){

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);

	}

	void OnTriggerEnter (Collider ohter){
		if( ohter.gameObject.CompareTag("PickUp")){
			
			ohter.gameObject.SetActive (false);

			Count = Count + 1;
			SetCountText ();

		}
	}

	void SetCountText(){
		CountText.text = "Count: " + Count.ToString ();
		if(Count>=10){
			winText.text = "You Win";
		}

	}


}
