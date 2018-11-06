using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

	void Update () {
        this.gameObject.transform.Translate(-0.147f, 0, 0);
        this.gameObject.transform.GetChild(0).transform.localEulerAngles = new Vector3(90, 3 * Time.frameCount, 0);
        if (this.gameObject.transform.position.x < -8.5f) {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Impacted with " + collision.collider.name.ToString());
        if (collision.collider.name == "Player") {
            GameObject.Find("EventSystem").GetComponent<Game>().score += 5f;
            StartCoroutine(GameObject.Find("Player").GetComponent<Player>().Boost());
            Destroy(this.gameObject);
        }
    }
}
