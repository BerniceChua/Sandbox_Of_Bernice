using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : DamageableObjects {

	void OnMouseDown() {
        this.TakeDamage(Random.Range(0, 100));
    }
}
