using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PutPin : MonoBehaviour {
    public List<GameObject> Pins;
    public GameObject PinPrototype;
    public GameObject Pizarra;

    private Camera _camera;
    private RaycastHit _hit;
    private Spline _splineSet;

    void Start () {
        _camera = GameObject.FindGameObjectWithTag(Tags.MainCamera).GetComponent<Camera>();
        _splineSet = PinPrototype.GetComponent<Pin>().
            SplineSet.GetComponent<Spline>();
        Pins = GetComponent<GameController>().Pins;
    }

    void Update () {

        if (Input.GetMouseButtonDown(0) &&
            Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out _hit)) {

            PutIt();

        }


        if (Input.GetKeyDown(KeyCode.Space)) {
            _splineSet.RepaintAll();
        }
    }

    void PutIt () {
        GameObject placedPin = Instantiate(PinPrototype);
        placedPin.SetActive(true);
        Pins.Add(placedPin);
        placedPin.transform.position = _hit.point - new Vector3(0,0,0.09f);
        placedPin.transform.parent = Pizarra.transform;
    }
}
