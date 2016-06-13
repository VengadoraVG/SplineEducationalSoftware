using UnityEngine;
using System.Collections;

public class WrongLight : MonoBehaviour {
    private Light _light;
    private float time = 100;

    void Start () {
        _light = GetComponent<Light>();
    }
    
    void Update () {
        time += Time.deltaTime;
        _light.intensity = Mathf.Lerp(5, 0, time/1.0f);
    }

    public void Activate () {
        time = 0;
    }
}
