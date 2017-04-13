using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextUpdate : MonoBehaviour {
    [SerializeField] Animator m_anim;

    private Text m_damageText;

    private void Awake() {
        m_damageText = m_anim.GetComponent<Text>();
    }

    // Use this for initialization
    void OnEnable () {
        AnimatorClipInfo[] clipInfo = m_anim.GetCurrentAnimatorClipInfo(0);
        Debug.Log(clipInfo.Length);
        Destroy(gameObject, clipInfo[0].clip.length);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetText(string text) {
        m_damageText.text = text;
    }

}
