using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : WeaponBase {
	public override void Shoot(GameObject bullet, Vector3 shootPoint, int damage, Transform transform)
	{
		for (int i = 0; i < 3; i++)
		{
			Rigidbody rigi = GameObject.Instantiate(bullet, shootPoint, Quaternion.Euler(transform.forward)).GetComponent<Rigidbody>();
			rigi.AddRelativeForce(transform.forward * 1000 + (transform.right*(50 + (50*i))));
			rigi.GetComponent<BulletScript>().Shooter = "Player";
			rigi.GetComponent<BulletScript>().Target = "Enemy";
			rigi.GetComponent<BulletScript>().Damage = damage;
		}

	}
}
