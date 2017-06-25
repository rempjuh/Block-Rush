using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeScript : Interactible{

	[SerializeField]
	private GameObject[] _spawners;

	new void Start()
	{
		base.Start();
	}


	public override void Interact()
	{
		foreach (GameObject item in _spawners)
		{
			item.SetActive(true);
		}
		Destroy(gameObject);
	}
}
