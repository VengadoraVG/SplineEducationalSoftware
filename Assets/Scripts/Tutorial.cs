using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class Tutorial : MonoBehaviour {
    public List<string> TutorialText;
    public int CurrentText;

    private Text _text;

    void Start () {
        _text = GetComponent<Text>();
        _text.text = TutorialText[CurrentText];
    }
	
    void Update () {

    }

    public void Next () {
        CurrentText++;
	if (CurrentText < TutorialText.Count) {
            _text.text = TutorialText[CurrentText];
        } else {
            CurrentText--;
            _text.text = "";
        }
    }
}
