using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class displays a simple text box on screen that will:
// 1. Show the text that you give it in the text portion of the box
// 2. Show a flashing indicator that will alert the player to their 
//    ability to press a button to speed up the process
// 3. Show 1 letter at a time based on the set speed
// 4. Allow the user to complete the current section of text instantly.
public class TextBoxManager : MonoBehaviour {

    static public TextBoxManager S;

    // UI pieces
    public GameObject textBox;
    public Text text;
    public Text indicator;
    bool active = false;

    public float speed = 0.01f;

	// Passed in by the object that is using this manager
    // Each string is 2 lines of text or less 
	string[] completeText;
    string displayText;

    // Current reading position you are at in the current text
    int textLine = 0;

    // Flag saying if you're at the end of the current block of text
    bool lineComplete = false;

    bool isTyping = false;
    bool cancelTyping = false;

    void Awake(){
        S = this;
    }

	// Update is called once per frame
	void Update(){
        UserInput();
    }


    // Called to show the text box on screen
    public void ShowTextBox(string[] dialog){
        completeText = dialog;
        displayText = completeText[textLine];
        textBox.SetActive(true);
        active = true;
        StartCoroutine(ScrollText(displayText));
    }

    // Handles the "ghost writing" of the text in the dialog box
    private IEnumerator ScrollText(string displayText){
        int pos = 0;
        text.text = "";
        isTyping = true;
        cancelTyping = false;

        while(isTyping && !cancelTyping && pos < displayText.Length) {
            text.text += displayText[pos++];
            yield return new WaitForSeconds(speed);
        }
        text.text = displayText;
        lineComplete = true;
        isTyping = false;
        cancelTyping = false;
    }
        
    // Exits the text box
    private void HideTextBox(){
        textBox.SetActive(false);
        active = false;
        textLine = 0;
    }

    private void ShowNextLine(){
        HideIndicator();
        ++textLine;
        lineComplete = false;
        text.text = "";
        if(textLine < completeText.Length){
            displayText = completeText[textLine];
            StartCoroutine(ScrollText(displayText)); 
        } else {
            HideTextBox(); 
        }
    }

    private void UserInput() {
        if (active && Input.GetKeyDown(KeyCode.Space)){
            if (lineComplete)
                ShowNextLine();
            else if (isTyping && !cancelTyping){
                cancelTyping = true;
            }
        }
    }
   
    // UI functions for the indicator to tell the player they can continue
    private void ShowIndicator(){   
        
    }

    private void HideIndicator(){
        indicator.text = "";
    }
}
