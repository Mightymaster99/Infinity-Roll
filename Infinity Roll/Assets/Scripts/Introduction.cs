using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Introduction : MonoBehaviour {

	void Update () {
        this.gameObject.GetComponent<Text>().fontSize = (int)(50f + 10 * Mathf.Sin(Time.frameCount / 20f));
	}
}
