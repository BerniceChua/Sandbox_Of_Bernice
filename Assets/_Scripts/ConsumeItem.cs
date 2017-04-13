using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsumeItem : MonoBehaviour {

    // original
    //public void Consume() {
    //    if (System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) > 1) {
    //        int totalCount = System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) - 1;
    //        this.transform.Find("Text").GetComponent<Text>().text = "" + totalCount;
    //    }
    //    else {
    //        Destroy(this.gameObject);
    //    }
    //}

    // 1st refactor == I found out this won't work if you assign the text and the int as variables...
    //public void Consume() {
    //    string itemName = this.transform.Find("Text").GetComponent<Text>().text;
    //    int itemCount = System.Int32.Parse(itemName);

    //    if (itemCount > 1) {
    //        int totalCount = itemCount - 1;
    //        itemName = "" + totalCount;
    //    } else {
    //        Destroy(this.gameObject);
    //    }
    //}

    // 2nd refactor == I found out this won't work if you assign the text and the int as variables...
    //public void Consume() {
    //    string itemName = this.transform.Find("Text").GetComponent<Text>().text;
    //    int itemCount = System.Int32.Parse(itemName);

    //    if (itemCount < 1)
    //        Destroy(this.gameObject);

    //    int totalCount = itemCount - 1;
    //    itemName = "" + totalCount;
    //}

    // 3rd refactor
    public void Consume() {
        if (System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) <= 1) {
            Destroy(this.gameObject);
        }

        int totalCount = System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) - 1;
        this.transform.Find("Text").GetComponent<Text>().text = "" + totalCount;
    }

    // 4th refactor ==  this one gives an error message:
    /*
     * ArgumentException: The Object you want to instantiate is null.
        UnityEngine.Object.CheckNullArgument (System.Object arg, System.String message) (at C:/buildslave/unity/build/Runtime/Export/UnityEngineObject.cs:239)
        UnityEngine.Object.Instantiate[GameObject] (UnityEngine.GameObject original) (at C:/buildslave/unity/build/Runtime/Export/UnityEngineObject.cs:201)
        PickUpFruit.OnCollisionEnter (UnityEngine.Collision collision) (at Assets/_Scripts/PickUpFruit.cs:22)
     */
    //public void Consume() {
    //    if (System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) < 1) {
    //        //Destroy(this.gameObject);
    //        DestroyImmediate(this.gameObject, true);
    //    } else {
    //        int totalCount = System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) - 1;
    //        this.transform.Find("Text").GetComponent<Text>().text = "" + totalCount;
    //    }
    //}

}