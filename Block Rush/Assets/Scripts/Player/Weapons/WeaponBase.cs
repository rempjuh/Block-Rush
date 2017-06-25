using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase {
public virtual void Shoot(GameObject bullet, Vector3 shootPoint, int damage,Transform transform)
	{
		Rigidbody rigi = GameObject.Instantiate(bullet,shootPoint,Quaternion.Euler(transform.forward)).GetComponent<Rigidbody>();
		rigi.AddRelativeForce(transform.forward * 1000);
		rigi.GetComponent<BulletScript>().Shooter = "Player";
		rigi.GetComponent<BulletScript>().Target = "Enemy";
		rigi.GetComponent<BulletScript>().Damage = damage;
	}
}
