using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
    private const int SHOWING = 0;
    private const int EVALUATING = 1;

    private const int UNKOWN = 0;
    private const int GOOD = 1;
    private const int BAD = 2;

    public int GameModeStatus = 0;
    public int CalificationStatus = 0;
    
    public List<GameObject> Pins;
    public Tutorial UiTutorial;
    public MatrixController MyMatrixController;

    public Confeti confeti;
    public WrongLight wrongLight;

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

    public bool IsEvaluating () {
        return GameModeStatus == EVALUATING;
    }

    public void SwitchToEvaluating () {
        GameModeStatus = EVALUATING;
    }

    public void SwitchToDemostration () {
        GameModeStatus = SHOWING;
    }

    public void Calificar () {
        if (MyMatrixController.Calificar()) {
            CalificationStatus = GOOD;
            confeti.Activate();
        } else {
            wrongLight.Activate();
            CalificationStatus = BAD;
        }
    }

    public void openvideo () {
        Application.OpenURL((Application.dataPath) + "/test.mp4");
    }

}
