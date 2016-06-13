using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectPin : MonoBehaviour {
    public List<GameObject> Pins;
    public GameObject Selection;
    public GameObject SelectionGizmos;

    private Camera _camera;
    private UiController _uiController;

    void Start () {
        Pins = GetComponent<GameController>().Pins;
        _camera = GameObject.FindGameObjectWithTag(Tags.MainCamera)
            .GetComponent<Camera>();
        _uiController = GameObject.FindGameObjectWithTag(Tags.GameController)
            .GetComponent<UiController>();
    }
    
    void Update () {
        if (Input.GetMouseButtonDown(1)) {
            _SelectAt(Input.mousePosition);
        }

        _UpdateSelectionGizmos();

        if (Input.GetKeyDown(KeyCode.Delete)) {
            DeleteSelection();
        }
    }

    public void DeleteSelection () {
        _uiController.UpdateSelection();
        if (Selection != null) {
            Selection.GetComponent<Pin>()
                .SplineSet.GetComponent<Spline>().Remove(Selection);
            Destroy(Selection);
            Selection = null;
        }
    }

    private void _UpdateSelectionGizmos () {
        if (Selection != null) {
            SelectionGizmos.SetActive(true);
            SelectionGizmos.transform.position = Selection.transform.position +
                new Vector3(0,0,-0.1f);
        } else {
            SelectionGizmos.SetActive(false);
        }
    }

    private void _SelectAt (Vector3 coords) {
        List<RaycastHit> hits = new List<RaycastHit>();
        hits.AddRange(Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition)));

        bool foundAHit = false;

        for (int i=0; i<hits.Count; i++) {
            Debug.Log("zomg! " + hits[i].collider.gameObject);
            if (hits[i].collider.gameObject.CompareTag(Tags.Pin)) {
                Selection = hits[i].collider.gameObject.transform.parent.gameObject;
                foundAHit = true;
            }
        }

        if (!foundAHit) {
            Selection = null;
        } else {
            _uiController.UpdateSelection();
        }
    }        
}
