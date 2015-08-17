using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public float timer;
	public float allTime;
	private GameObject player;

	// Update is called once per frame
	void Update () {
		timer += Time.fixedDeltaTime; //Time.deltaTime;
		ReloadGameAfterTimeEnd ();		
		float UiAllTime = allTime - timer;
		GetComponent<GUIText>().text = "Time: " + UiAllTime.ToString("0");
	}
	void ReloadGameAfterTimeEnd(){
		if (timer > 120) {
			player = GameObject.FindGameObjectWithTag("Player");
			Destroy (player);
			StartCoroutine("ReloadGame");
		}
	}
	IEnumerator ReloadGame()
	{			
		// ... pause briefly
		yield return new WaitForSeconds(2);
		// ... and then reload the level.
		Application.LoadLevel(Application.loadedLevel);
	}
}