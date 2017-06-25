using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {
	public int Health;
	private PlayerScore _playerScore;

	public void SetHealth(int value)
	{
		Health = value;
	}
	public void DegreeHealth(int value)
	{
		Health -= value;

		if (_playerScore == null)
			_playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();

		_playerScore.IncreaseScore(10);
		if (Health <= 0)
		{
			_playerScore.IncreaseScore(100);
			Destroy(gameObject);
		}
	}
}
