using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpFruit : MonoBehaviour {
    [SerializeField] GameObject m_inventoryPanel;
    [SerializeField] GameObject[] m_inventoryIcons;

    private void OnCollisionEnter(Collision collision) {
        foreach (Transform child in m_inventoryPanel.transform) {
            if (child.gameObject.tag == collision.gameObject.tag) {
                string childObj = child.Find("Text").GetComponent<Text>().text;
                int totalCount = System.Int32.Parse(childObj) + 1;
                child.Find("Text").GetComponent<Text>().text = "" + totalCount;
                return;
            }
        }

        GameObject i;
        if (collision.gameObject.tag == "Lemon") {
            i = Instantiate(m_inventoryIcons[0]);
            i.transform.SetParent(m_inventoryPanel.transform);

            Debug.Log("if tag is 'Lemon', m_inventoryIcons.Length is:");
            Debug.Log(m_inventoryIcons.Length);
            Debug.Log("m_inventoryIcons[0] is:");
            Debug.Log(m_inventoryIcons[0].ToString());
        } else if (collision.gameObject.tag == "Apple") {
            i = Instantiate(m_inventoryIcons[1]);
            i.transform.SetParent(m_inventoryPanel.transform);

            Debug.Log("if tag is 'Apple', m_inventoryIcons.Length is:");
            Debug.Log(m_inventoryIcons.Length);
            Debug.Log("m_inventoryIcons[1] is:");
            Debug.Log(m_inventoryIcons[1].ToString());
        } else if (collision.gameObject.tag == "Strawberry") {
            i = Instantiate(m_inventoryIcons[2]);
            i.transform.SetParent(m_inventoryPanel.transform);

            Debug.Log("if tag is 'Strawberry', m_inventoryIcons.Length is:");
            Debug.Log(m_inventoryIcons.Length);
            Debug.Log("m_inventoryIcons[2] is:");
            Debug.Log(m_inventoryIcons[2].ToString());
        }
    }

}