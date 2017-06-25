using UnityEngine;

public class BulletScript : MonoBehaviour {
	public string Shooter;
	public string Target;
	public int Damage;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, 2);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag != Shooter && other.tag !=tag)
		{
			if (other.tag == Target)
				other.GetComponent<HealthScript>().DegreeHealth(Damage);
			Destroy(gameObject);
		}
	}
}
