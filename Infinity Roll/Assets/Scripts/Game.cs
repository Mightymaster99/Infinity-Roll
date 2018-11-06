using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    public bool playing = false;
    public float score = 0;
    public float replayTimer = 0;

    private GameObject introCanvas;
    private GameObject scoreCanvas;
    private GameObject gameOverCanvas;
    public GameObject brickPrefab;
#if ()
    public KeyCode actionCode;

    private void Start() {
        if (SystemInfo.deviceType == DeviceType.Desktop) {
            actionCode = KeyCode.Space;
        }
        if (SystemInfo.deviceType == DeviceType.Handheld) {
            actionCode = KeyCode.;
        }
        FloorSetup();
        score = 0;
        introCanvas = GameObject.Find("IntroCanvas");
        scoreCanvas = GameObject.Find("ScoreCanvas");
        gameOverCanvas = GameObject.Find("GameOverCanvas");
        scoreCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
    }

    private void Update() {
        if (!playing && Input.GetKeyDown(KeyCode.Space) && replayTimer == 0) {
            playing = true;
            score = 0;
            FloorSetup();
            StartCoroutine(this.gameObject.GetComponent<TerrainGen>().WorldGeneration());
            StartCoroutine(this.gameObject.GetComponent<TerrainGen>().RowOneGeneration());
            StartCoroutine(this.gameObject.GetComponent<TerrainGen>().RowTwoGeneration());
            StartCoroutine(this.gameObject.GetComponent<TerrainGen>().RowThreeGeneration());
            StartCoroutine(this.gameObject.GetComponent<TerrainGen>().DecorationGeneration());
            StartCoroutine(this.gameObject.GetComponent<TerrainGen>().CoinGeneration());
            StartCoroutine(ScoreCount());
            GameObject.Find("Player").transform.position = new Vector3(-6, -2, 0);
            GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            introCanvas.SetActive(false);
            scoreCanvas.SetActive(true);
            gameOverCanvas.SetActive(false);
        }
    }

    public void KillAll() {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
            Destroy(enemy);
        }
        gameOverCanvas.SetActive(true);
        GameObject.Find("YouScoredText").GetComponent<Text>().text = "Your score was: " + Mathf.Floor(score).ToString();
        GameObject.Find("InterestingFactText").GetComponent<InterestingFact>().ChangeName();
        StopAllCoroutines();
        GameObject.Find("Player").transform.position = new Vector3(-6, -20, 0);
        GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        // Testing High Scores
        if (score > PlayerPrefs.GetFloat("Highscore")) {
            PlayerPrefs.SetFloat("Fifth", PlayerPrefs.GetFloat("Fourth"));
            PlayerPrefs.SetFloat("Fourth", PlayerPrefs.GetFloat("Third"));
            PlayerPrefs.SetFloat("Third", PlayerPrefs.GetFloat("Second"));
            PlayerPrefs.SetFloat("Second", PlayerPrefs.GetFloat("Highscore"));
            PlayerPrefs.SetFloat("Highscore", score);
        } else if (score > PlayerPrefs.GetFloat("Second")) {
            PlayerPrefs.SetFloat("Fifth", PlayerPrefs.GetFloat("Fourth"));
            PlayerPrefs.SetFloat("Fourth", PlayerPrefs.GetFloat("Third"));
            PlayerPrefs.SetFloat("Third", PlayerPrefs.GetFloat("Second"));
            PlayerPrefs.SetFloat("Second", score);
        } else if (score > PlayerPrefs.GetFloat("Third")) {
            PlayerPrefs.SetFloat("Fifth", PlayerPrefs.GetFloat("Fourth"));
            PlayerPrefs.SetFloat("Fourth", PlayerPrefs.GetFloat("Third"));
            PlayerPrefs.SetFloat("Third", score);
        } else if (score > PlayerPrefs.GetFloat("Fourth")) {
            PlayerPrefs.SetFloat("Fifth", PlayerPrefs.GetFloat("Fourth"));
            PlayerPrefs.SetFloat("Fourth", score);
        } else if (score > PlayerPrefs.GetFloat("Fifth")) {
            PlayerPrefs.SetFloat("Fifth", score);
        }

        GameObject.Find("First").GetComponent<Text>().text = PlayerPrefs.GetFloat("Highscore").ToString();
        GameObject.Find("Second").GetComponent<Text>().text = PlayerPrefs.GetFloat("Second").ToString();
        GameObject.Find("Third").GetComponent<Text>().text = PlayerPrefs.GetFloat("Third").ToString();
        GameObject.Find("Fourth").GetComponent<Text>().text = PlayerPrefs.GetFloat("Fourth").ToString();
        GameObject.Find("Fifth").GetComponent<Text>().text = PlayerPrefs.GetFloat("Fifth").ToString();

    }

    private void FloorSetup() {
        for (float i = 0; i <= 17; i++) {
            GameObject baseTile = (GameObject)Instantiate(brickPrefab, new Vector3(i - 8.3f, -4.5f, 0), Quaternion.identity, this.gameObject.transform);
            GameObject ceilingTile = (GameObject)Instantiate(brickPrefab, new Vector3(i - 8.3f, 4.5f, 0), Quaternion.identity, this.gameObject.transform);
        }
    }

    public IEnumerator ScoreCount() {
        while (playing) {
            score += 1;
            yield return new WaitForSeconds(0.2f);
            if (GameObject.Find("EventSystem").GetComponent<Game>().score % 1 == 0) {
                GameObject.Find("ScoreText").GetComponent<Text>().text = "Score: " + GameObject.Find("EventSystem").GetComponent<Game>().score;
            }
        }
    }

}
