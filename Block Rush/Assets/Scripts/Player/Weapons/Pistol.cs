using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponBase {
	public override void Shoot(GameObject bullet, Vector3 shootPoint, int damage, Transform transform)
	{
		base.Shoot(bullet, shootPoint, damage, transform);
	}
}
