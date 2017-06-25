using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour {
	[SerializeField]
	private GameObject _enemy;
	// Use this for initialization
	void Start () {
		StartCoroutine(spawn());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private IEnumerator spawn()
	{
		while (true)
		{
			Instantiate(_enemy, transform.position, Quaternion.identity);
			yield return new WaitForSeconds(Random.Range(5,7));
		}
	}
}
