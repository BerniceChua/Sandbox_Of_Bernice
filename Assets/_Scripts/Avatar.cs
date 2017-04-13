using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour, IDamageable<float>, IKillable {
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    // NOTE: the body of the functions from the interface 
    // is independent of the interfaces, and can be implemented however you like.
    // These kinds of interfaces might be useful if there was a situation in 
    // your game where want to do damage or kill everything.
    // simply by finding everything that implements IKillable or IDamageable, 
    // you could be sure they have the kill or damage functions.

    public void Damage(float damage) {
        // Do something fun
    }

    public void Kill() {
        // Do something fun
    }

}