using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject coinPrefab;
    public int coinCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(random_coins());
    }

    IEnumerator random_coins()
    {
        while (coinCount <=20)
        {
            // Generate random position
            float xpos = Random.Range(-10f, 10f);
            float zpos = Random.Range(-10f, 10f);
            // Instantiate the coin
            GameObject newCoin = Instantiate(coinPrefab, new Vector3(xpos, 0, zpos), Quaternion.identity);

            yield return new WaitForSeconds(1f);
            coinCount += 1;
        }
    }
}
