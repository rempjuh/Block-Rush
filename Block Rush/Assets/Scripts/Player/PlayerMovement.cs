using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField]
	private SimpleTouchController _leftJoyStick;
	[SerializeField]
	private SimpleTouchController _rightJoyStick;
	private Rigidbody _rigidBody;
	private const float _movementSpeed = 5;
	// Use this for initialization
	void Start () {
		_rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		_rigidBody.MovePosition(transform.position + (Vector3.forward * _leftJoyStick.GetTouchPosition.y * Time.deltaTime * _movementSpeed) +
		(Vector3.right * _leftJoyStick.GetTouchPosition.x * Time.deltaTime * _movementSpeed));

		transform.LookAt(transform.position + new Vector3(_rightJoyStick.GetTouchPosition.x, 0, _rightJoyStick.GetTouchPosition.y));
	}
}
