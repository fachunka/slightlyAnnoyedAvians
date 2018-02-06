using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Rigidbody2D rb;

	private bool isPressed = false;

	public float releaseTime = .15f;

	private int count;
	public Text countText;
	void Start ()
	{
		count = 0;
		countText.text = "Swine Killed: " + count.ToString ();

	}
		
	void Update () {

		if (isPressed) {
			rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
		Debug.Log (count);

	}

	void OnMouseDown () {
		isPressed = true;
		rb.isKinematic = true;
	}

	void OnMouseUp () {
		
		isPressed = false;
		rb.isKinematic = false;

		StartCoroutine (Release ());
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.CompareTag ("enemy")) {
			other.gameObject.SetActive(false);
			count = count + 1;
			countText.text = "Swine Killed: " + count.ToString ();
		}
	}

	IEnumerator Release () {

		yield return new WaitForSeconds (releaseTime);

		GetComponent<SpringJoint2D> ().enabled = false;
	}


}
