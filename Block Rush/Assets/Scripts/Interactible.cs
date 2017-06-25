using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour {
	protected TextMesh _text;
	[SerializeField]
	protected int _value;
	private bool _inBound;
	protected bool Usible;
	// Use this for initialization
	protected void Start () {
		_text = transform.Find("Text").GetComponent<TextMesh>();
		Usible = true;
	}

	public bool IsInBound()
	{
		return _inBound;
	}
	public bool IsUseble()
	{
		return Usible;
	}

	public int GetValue()
	{
		return _value;
	}

	public virtual void Interact()
	{ }

	protected virtual void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			_inBound = true;
			_text.text = "Cost: " + _value;
		}
	}

	protected virtual void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			_inBound = false;
			_text.text = "";
		}
	}
}
