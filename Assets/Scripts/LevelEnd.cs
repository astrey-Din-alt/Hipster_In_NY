using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player hits the trigger...
		if (col.gameObject.tag == "Player") {
				// ... destroy the player.
				Destroy (col.gameObject);
				// ... reload the level.
				StartCoroutine ("LoadNextLevel");
				Debug.LogError ("LoadNextLevel!");
	
		}
	}
	IEnumerator LoadNextLevel()
	{	
		float fadeTime = GameObject.Find("_GM").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel (Application.loadedLevel + 1);
	}		
}

