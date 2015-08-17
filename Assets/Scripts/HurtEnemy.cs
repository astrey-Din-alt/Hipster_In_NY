using UnityEngine;
using System.Collections;

public class HurtEnemy : MonoBehaviour {

	private GameObject enemy;

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			enemy = GameObject.FindGameObjectWithTag("Enemy");
			enemy.GetComponent<Enemy>().Hurt();
		}
	}
}