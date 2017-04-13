using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour {
    private static FloatingTextUpdate m_popupText;
    private static GameObject m_canvas;

    public static void Initialize() {
        m_canvas = GameObject.Find("Canvas");

        if (!m_popupText)
            m_popupText = Resources.Load<FloatingTextUpdate>("Prefabs/PopupTextParent");
    }


    public static void CreateFloatingText(string text, Transform location) {
        FloatingTextUpdate instance = Instantiate(m_popupText);
        float xRandom = location.position.x + Random.Range(-0.5f, 0.5f);
        float yRandom = location.position.y + Random.Range(-0.5f, 0.5f);

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2(xRandom, yRandom));

        instance.transform.SetParent(m_canvas.transform, false);
        instance.transform.position = screenPosition;
        instance.SetText(text);
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
