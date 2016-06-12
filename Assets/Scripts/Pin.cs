using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {
    public GameObject SplineSet;

    void Start () {
        Spline s = SplineSet.GetComponent<Spline>();
        s.Pins.Add(this.gameObject);
        s.Unordered = true;
    }

    void Update () {

    }
}
