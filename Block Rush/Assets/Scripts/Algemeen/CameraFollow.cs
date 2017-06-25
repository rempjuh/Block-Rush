using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	[SerializeField]
	private Transform _player;
	private Vector3 _pos;
	// Use this for initialization
	void Start () {
		_pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(_pos.x + _player.position.x, _pos.y, _pos.z + _player.position.z);
	}
}
