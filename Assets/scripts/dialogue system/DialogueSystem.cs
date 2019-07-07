using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {
    private float speed = 0.01f;
    public string currentText; //придумать, как заполнить массивы
    public string[] text = new string[3];


	public void Typing(int NumberOfText){
		StartCoroutine (ShowText (NumberOfText));
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Return)) {
			this.GetComponent<Text> ().text = "";
		}
	}
	
	IEnumerator ShowText(int NumberOfText)
    {
		for(int i = 0; i <= text[NumberOfText].Length; i++)
        {
			currentText = text[NumberOfText].Substring(0, i);
          	this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(speed);
        }

    }
}
