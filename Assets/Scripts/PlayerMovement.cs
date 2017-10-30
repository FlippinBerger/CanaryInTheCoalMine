using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float distance = 1.0f;
	public float speed = 1.0f;
	public float jumpHeight = 3.0f;

	private Rigidbody2D _rigidbody;

	// Use this for initialization
	void Start () {
		// Should get the rigid body attached to the GO
		_rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Fixed Update because this is for a rigidbody player
	void FixedUpdate () {		
		Vector3 moveHorizontal = new Vector3(distance, transform.position.y, transform.position.z);
		if(Input.GetKeyDown(KeyCode.A)) {
			//_rigidbody.position = new Vector2(_rigidbody.position.x + speed * moveHorizontal, _rigidbody.position.y);
			moveHorizontal.x *= -1;
			_rigidbody.MovePosition(transform.position + moveHorizontal * Time.deltaTime);
		} else if(Input.GetKeyDown(KeyCode.D)) {
			_rigidbody.MovePosition(transform.position + moveHorizontal * Time.deltaTime);
		}

		if(Input.GetKeyDown(KeyCode.W)) {
			Jump();
		}

	} 

	void Jump() {
		Debug.Log("Jumping");
		Vector2 v2 = new Vector2(0, jumpHeight);
		//_rigidbody.MovePosition(_rigidbody.position + new Vector2(0, jumpHeight));
		_rigidbody.position += v2;
		//_rigidbody.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
	}
}
