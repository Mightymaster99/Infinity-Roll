using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    bool isGrounded;
    public float speedBoost = 0;

	void Update () {
	    if (GameObject.Find("EventSystem").GetComponent<Game>().playing) {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
                isGrounded = false;
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 7.5f);
            }
            this.gameObject.transform.localEulerAngles = new Vector3(0, 0, -5 * Time.frameCount);
        }
        if (this.gameObject.transform.position.x < -8f) {
            GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.position.y < this.gameObject.transform.position.y) {
            isGrounded = true;
        }
    }
    
    public void GameOver() {
        GameObject.Find("EventSystem").GetComponent<Game>().playing = false;
        GameObject.Find("EventSystem").GetComponent<Game>().KillAll();
        GameObject.Find("EventSystem").GetComponent<TerrainGen>().StopGeneration();
    }

    public IEnumerator Boost() {
        int initialFrame = Time.frameCount;
        while (Time.frameCount - initialFrame > 0) {
            speedBoost = (Time.frameCount - initialFrame) * 10;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speedBoost, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            yield return new WaitForEndOfFrame();
        }
    }

}
