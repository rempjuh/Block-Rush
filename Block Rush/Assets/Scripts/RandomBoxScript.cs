using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoxScript : Interactible{
	private Dictionary<GameObject, WeaponType> _weapons = new Dictionary<GameObject, WeaponType>();
	[SerializeField]
	private GameObject[] showWeapons;
	private bool _inrandom;
	private Animator _amin;
	// Use this for initialization
	new void Start () {
		base.Start();
		_amin = GetComponent<Animator>();
	}
	public override void Interact()
	{
		if (!_inrandom)
			StartCoroutine(StartRandom());
	}
	private IEnumerator StartRandom()
	{
		_inrandom = true;
		Usible = false;
		_amin.SetBool("Open", true);
		GameObject a = new GameObject();
		a.transform.position = transform.position + new Vector3(0.8f,0.5f,1);
		yield return new WaitForSeconds(0.5f);
		for (int i = 0; i < 10; i++)
		{
			GameObject w = Instantiate(showWeapons[Random.Range(0,showWeapons.Length)], a.transform.position, 
				Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y+90, transform.eulerAngles.z));
			for (int g = 0; g < 5; g++)
			{
				yield return new WaitForSeconds(0.1f);
				w.transform.position += new Vector3(0, 0.05f, 0);
			}
			a.transform.position = w.transform.position;
			if (i != 9)
			Destroy(w);
		}
	}
}
