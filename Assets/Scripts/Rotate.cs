using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
    public const int ENLARGING = 0;
    public const int REDUCING = 1;

    public float AngularSpeed = 10;
    public float PumpTime = 1;
    public Vector3 MaximumPump;
    public Vector3 MinimumPump;

    private int _currentState = 0;
    private float _timeOnState = 0;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (_currentState == ENLARGING) {
            transform.localScale = Vector3.Lerp(MinimumPump, MaximumPump,
                                                _timeOnState/PumpTime);
        } else {
            transform.localScale = Vector3.Lerp(MaximumPump, MinimumPump,
                                                _timeOnState/PumpTime);
        }

        if (_timeOnState > PumpTime) {
            _timeOnState = 0;
            _currentState = (_currentState + 1) % 2; // the next state
        }

        _timeOnState += Time.deltaTime;
        transform.Rotate(0, 0, AngularSpeed);
    }
}
