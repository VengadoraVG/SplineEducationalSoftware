using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MatrixController : MonoBehaviour {
    public List<Matrix> M;
    public Spline SplineSet;

    void Start () {

    }

    void Update () {        
        UpdateDataSources();
    }

    public void UpdateDataSources () {
        M[0].DataSource = SplineSet.A;
        M[1].DataSource = SplineSet.B;
        M[2].DataSource = SplineSet.C;
        M[3].DataSource = SplineSet.D;        
    }

    public bool Calificar () {
        for (int i=0; i<4; i++) {
            if (false == M[i].Calificar()) {
                return false;
            }
        }
        return true;
    }
}
