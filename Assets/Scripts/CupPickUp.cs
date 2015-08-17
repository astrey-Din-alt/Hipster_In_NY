using UnityEngine;
using System.Collections;

public class CupPickUp : MonoBehaviour
{
    private Animator anim;					// Reference to the animator component.
    public GameObject player;
	private Score score;
	public AudioClip collect;
	public GameObject hundredPointsUI;

    void Awake()
    {
		score = GameObject.Find("Score").GetComponent<Score>();
    }
	void OnTriggerEnter2D(Collider2D col)
	{			
		if (col.gameObject.tag == "Player") {
			// Create a vector that is just above the enemy.
			Vector3 scorePos;
			scorePos = transform.position;
			scorePos.y += 1.5f;

			Instantiate(hundredPointsUI, scorePos, Quaternion.identity);
			AudioSource.PlayClipAtPoint(collect,transform.position);
			Destroy(this.gameObject);
		}
	}

	void OnDestroy() {
		score.score += 100;
	}  
}
