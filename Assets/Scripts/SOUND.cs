using System.Collections;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public AudioClip coinCollectSound;
    public AudioSource backgroundMusic;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            // Play the coin collection sound
            AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);

            // Lower the background music volume
            if (backgroundMusic != null)
            {
                StartCoroutine(LowerMusicVolumeOverTime(2f)); // Adjust the duration as needed
            }

            // Destroy the collected coin
            Destroy(other.gameObject);
        }
    }

    IEnumerator LowerMusicVolumeOverTime(float duration)
    {
        float startVolume = backgroundMusic.volume;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            backgroundMusic.volume = Mathf.Lerp(startVolume, 0f, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        backgroundMusic.volume = 0f;
    }
}
