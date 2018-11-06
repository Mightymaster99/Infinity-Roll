using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGen : MonoBehaviour {

    public GameObject brickPrefab;
    public GameObject cloudPrefab;
    public GameObject coinPrefab;

    public int rowOneCount = 0;
    public int rowOneOffset = 0;
    public int rowTwoCount = 0;
    public int rowTwoOffset = 0;
    public int rowThreeCount = 0;
    public int rowThreeOffset = 0;
    public int ceilingBlocked = 0;
    public int floorBlocked = 0;


    public IEnumerator WorldGeneration() {
        while (GameObject.Find("EventSystem").GetComponent<Game>().playing) {
            yield return new WaitForSeconds(0.1f);
            GameObject baseTile = (GameObject)Instantiate(brickPrefab, new Vector3(8.5f, -4.5f, 0), Quaternion.identity, this.gameObject.transform);
            GameObject ceilingTile = (GameObject)Instantiate(brickPrefab, new Vector3(8.5f, 4.5f, 0), Quaternion.identity, this.gameObject.transform);
        }
    }

    public IEnumerator RowOneGeneration() {
        while (GameObject.Find("EventSystem").GetComponent<Game>().playing) {
            if (rowOneCount == 0) {
                rowOneCount = Random.Range(3, 8);
                rowOneOffset = Random.Range(5, 9);
                floorBlocked = Random.Range(0, 2);
            } else {
                yield return new WaitForSeconds(0.1f * rowOneOffset);
                while (rowOneCount > 0) {
                    GameObject baseTile = (GameObject)Instantiate(brickPrefab, new Vector3(8.5f, -2.5f, 0), Quaternion.identity, this.gameObject.transform);
                    yield return new WaitForSeconds(0.1f);
                    rowOneCount--;
                    if (rowOneCount == 1 && floorBlocked == 1) {
                        GameObject wallTile = (GameObject)Instantiate(brickPrefab, new Vector3(8.5f, -3.5f, 0), Quaternion.identity, this.gameObject.transform);
                    }
                }
            }
        }
    }

    public IEnumerator RowTwoGeneration() {
        while (GameObject.Find("EventSystem").GetComponent<Game>().playing) {
            if (rowTwoCount == 0) {
                rowTwoCount = Random.Range(3, 8);
                rowTwoOffset = Random.Range(5, 9);
            } else {
                yield return new WaitForSeconds(0.1f * rowTwoOffset);
                while (rowTwoCount > 0) {
                    GameObject baseTile = (GameObject)Instantiate(brickPrefab, new Vector3(8.5f, 0f, 0), Quaternion.identity, this.gameObject.transform);
                    yield return new WaitForSeconds(0.1f);
                    rowTwoCount--;
                }
            }
        }
    }

    public IEnumerator RowThreeGeneration() {
        while (GameObject.Find("EventSystem").GetComponent<Game>().playing) {
            if (rowThreeCount == 0) {
                rowThreeCount = Random.Range(3, 8);
                rowThreeOffset = Random.Range(5, 9);
                ceilingBlocked = Random.Range(0, 2);
            } else {
                yield return new WaitForSeconds(0.1f * rowThreeOffset);
                while (rowThreeCount > 0) {
                    GameObject baseTile = (GameObject)Instantiate(brickPrefab, new Vector3(8.5f, 2.5f, 0f), Quaternion.identity, this.gameObject.transform);
                    yield return new WaitForSeconds(0.1f);
                    if (ceilingBlocked == 1 && rowThreeCount == 2) {
                        GameObject wallTile = (GameObject)Instantiate(brickPrefab, new Vector3(8.5f, 3.5f, 0f), Quaternion.identity, this.gameObject.transform);
                    }
                    rowThreeCount--;
                }
            }
        }
    }

    public IEnumerator DecorationGeneration() {
        while (GameObject.Find("EventSystem").GetComponent<Game>().playing) {
            int cloudOffset = Random.Range(0, 12);
            yield return new WaitForSeconds(cloudOffset * 0.1f);
            GameObject cloud = (GameObject)Instantiate(cloudPrefab, new Vector3(10f , Random.Range(-1, 4), 5f), Quaternion.identity, this.gameObject.transform);
        }
    }

    public IEnumerator CoinGeneration() {
        float[] options = new float[] { -3.5f, 1f, 3.5f };
        while (GameObject.Find("EventSystem").GetComponent<Game>().playing) {
            int coinOffset = Random.Range(10, 20);
            yield return new WaitForSeconds(coinOffset * 0.1f);
            GameObject coin = (GameObject)Instantiate(coinPrefab, new Vector3(8.5f, options[Random.Range(0, options.Length)], 0f), Quaternion.identity, this.gameObject.transform);
        }
    }
 

    public void StopGeneration() {
        rowOneCount = 0;
        rowOneOffset = 0;
        rowTwoCount = 0;
        rowTwoOffset = 0;
        rowThreeCount = 0;
        rowThreeOffset = 0;
        ceilingBlocked = 0;
    }
}
