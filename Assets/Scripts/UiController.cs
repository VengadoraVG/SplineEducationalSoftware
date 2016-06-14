using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UiController : MonoBehaviour {
    private SelectPin _selectionController;

    public InputField txtX;
    public InputField txtY;

    void Start () {
        _selectionController = GetComponent<SelectPin>();
    }

    void Update () {
    }

    public void UpdateSelection () {
        if (_selectionController.Selection != null) {
            txtX.readOnly = txtX.readOnly = false;
            txtX.text = _selectionController.Selection.transform.localPosition.x + "";
            txtY.text = _selectionController.Selection.transform.localPosition.y + "";
        } else {
            txtX.readOnly = txtX.readOnly = true;
            txtX.text = "0";
            txtY.text = "0";
        }
    }
    
    public void SetSelectionPosition () {
        GameObject s = _selectionController.Selection;
        try {
            s.transform.localPosition =
                new Vector3(float.Parse(txtX.text), float.Parse(txtY.text),
                            s.transform.localPosition.z);
        } catch {
            txtX.text = "0";
            txtY.text = "0";
            SetSelectionPosition();
        }
    }
}
