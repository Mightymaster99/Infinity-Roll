using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickScript : MonoBehaviour {

    private float speed;

    private void Start() {
        if (this.gameObject.name == "Brick(Clone)") {
            speed = -0.147f;
            float color = Random.Range(200, 255);
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(color / 255, color / 255, color / 255);
        } else {
            speed = -1 * Random.Range(50, 300) / 2000f;
        }
    }

    void Update() {
        if (GameObject.Find("EventSystem").GetComponent<Game>().playing) {
            this.gameObject.transform.Translate(speed, 0, 0);
            if (this.gameObject.transform.position.x < -8.5f) {
                Destroy(this.gameObject);
            }
        }
    }
}
