using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
    public List<GameObject> Pins;
    public Tutorial UiTutorial;

    private SelectPin _selectController;

    void Start () {
        _selectController = GetComponent<SelectPin>();
    }
    
    void Update () {
        if (Pins.Count == 2 && UiTutorial.CurrentText == 0) {
            UiTutorial.Next();
        }

        if (Input.GetKeyDown(KeyCode.Space) && UiTutorial.CurrentText == 1) {
            UiTutorial.Next();
        }

        if (_selectController.Selection != null && UiTutorial.CurrentText == 2) {
            UiTutorial.Next();
        }

        if (Input.GetKeyDown(KeyCode.Delete) && UiTutorial.CurrentText == 3) {
            UiTutorial.Next();
        }
    }
}
