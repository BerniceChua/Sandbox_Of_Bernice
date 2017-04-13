using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObjects : MonoBehaviour {
    public int m_HP;

	// Use this for initialization
	void Start () {
        FloatingTextController.Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void TakeDamage(int damageAmount) {
        FloatingTextController.CreateFloatingText(damageAmount.ToString(), transform);
        Debug.LogFormat("{0} was dealt {1} damage", gameObject.name, damageAmount);

        if ((m_HP -= damageAmount) <= 0)
            Die();
    }

    public virtual void Die() {
        Debug.Log(gameObject.name + "has died.");
    }

}