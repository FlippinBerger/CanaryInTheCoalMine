using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	public float speed = 6.0f;
	public CharacterController controller;

    private TextBoxManager textBox;

    public string[] dialog;

	// Use this for initialization
	void Start() {
		controller = GetComponent<CharacterController>();
        textBox = TextBoxManager.S;
	}

	// Update is called once per frame
	void Update() {
		Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;

		controller.Move(moveDirection * Time.deltaTime);
	}

    //Using this to test the dialog box
    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "wall"){
            textBox.ShowTextBox(dialog);
        }
    }
}
