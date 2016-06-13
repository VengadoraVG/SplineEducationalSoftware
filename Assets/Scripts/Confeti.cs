using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Confeti : MonoBehaviour {
    public List<ParticleSystem> Confetis;

    void Start () {
	
    }
	
    void Update () {
	
    }

    public void Activate () {
        for (int i=0; i<Confetis.Count; i++) {
            Confetis[i].Clear();
            Confetis[i].Play();
        }
    }
}
