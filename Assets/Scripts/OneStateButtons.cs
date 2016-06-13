using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class OneStateButtons : MonoBehaviour {
    public Image Evaluate;
    public Image Demostrate;
    public GameObject Calificar;

    public Color ActiveColor;
    public Color InactiveColor;

    private GameController _gameController;
    
    void Start () {
        _gameController = GameObject.FindGameObjectWithTag(Tags.GameController)
            .GetComponent<GameController>();
        DemostrateClick();
    }
	
    void Update () {
        
    }

    public void EvaluateClick () {
        Evaluate.color = ActiveColor;
        Demostrate.color = InactiveColor;
        _gameController.SwitchToEvaluating();
        Calificar.SetActive(true);
    }

    public void DemostrateClick () {
        Evaluate.color = InactiveColor;
        Demostrate.color = ActiveColor;
        _gameController.SwitchToDemostration();
        Calificar.SetActive(false);
    }
}
