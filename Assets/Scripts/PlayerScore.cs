using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

	public int playerScore = 0;
	Text instruction;
	// Update is called once per frame
	void Update () {
		playerScore = PlayerPrefs.GetInt("Player Score");
		instruction = GetComponent<Text>();
		instruction.text = "Scores: " + playerScore * 1;
	}
}
