using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Matrix : MonoBehaviour {
    public int CellCount;
    public int Offset;
    public GameObject Cell;
    public GameObject Content;
    public float[] DataSource;

    private List<GameObject> _cells;
    private UiController _uiController;

    void Start () {
        _cells = new List<GameObject>();
    }

    void Update () {
        UpdateData();
        UpdateCellCount();
    }

    private void _removeExtraCells () {
        for (int i=_cells.Count-1; i>=CellCount; i--) {
            GameObject cell;
            cell = _cells[i];
            _cells.RemoveAt(i);
            Destroy(cell);
        }
    }

    private void _addMissingCells () {
        for (int i=_cells.Count; i<CellCount; i++) {
            GameObject cell;
            cell = Instantiate(Cell);
            cell.transform.parent = Content.transform;
            cell.transform.position = Cell.transform.position;
            cell.transform.localScale = Cell.transform.localScale;
            cell.transform.GetComponent<RectTransform>().anchoredPosition =
                cell.transform.GetComponent<RectTransform>().anchoredPosition +
                new Vector2(0, Offset * i);
            cell.SetActive(true);
            _cells.Add(cell);
        }
    }

    public void UpdateCellCount () {
        _removeExtraCells();
        _addMissingCells();
    }

    public void UpdateData () {
        CellCount = DataSource.Length;
        UpdateCellCount();

        for (int i=0; i<DataSource.Length; i++) {
            _cells[i].GetComponent<Cell>().SetText(Math.Round(DataSource[i],3) + "");
        }
    }

    public bool Calificar () {
        for (int i=0; i<CellCount; i++) {
            if (false == _cells[i].GetComponent<Cell>().Calificar()) {
                return false;
            }
        }

        return true;
    }

}
