using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour {
	[SerializeField]
	private SimpleTouchController _rightJoyStick;
	private WeaponType _holdedWeaponOne;
	private WeaponType _holdedWeaponTwo;
	private WeaponInfo _selectedWeapon;
	[SerializeField]
	private GameObject _bullet;
	[SerializeField]
	private GameObject[] _weapons;
	private Dictionary<WeaponType, WeaponInfo> _weapon = new Dictionary<WeaponType, WeaponInfo>();
	private bool _isShooting;
	// Use this for initialization
	void Start () {
		_weapon.Add(WeaponType.Pistol, new WeaponInfo("Pistol", 1, 1,_weapons[0]));
		_weapon.Add(WeaponType.Mac, new WeaponInfo("Mac-10", 0.1f, 1, _weapons[1]));
		_weapon.Add(WeaponType.ShotGun, new WeaponInfo("Shotgun", 1, 5, _weapons[2]));
		_holdedWeaponOne = WeaponType.Pistol;
		_holdedWeaponTwo = WeaponType.Mac;
		_selectedWeapon = _weapon[_holdedWeaponOne];
		SetWeapon(_holdedWeaponOne);
	}

	// Update is called once per frame
	void Update () {
		if (!_isShooting && _rightJoyStick.GetTouchPosition.x != 0)
			StartCoroutine(ShootGun());

		if (Input.GetKeyDown(KeyCode.A))
			SetWeapon(WeaponType.Pistol);
		if (Input.GetKeyDown(KeyCode.S))
			SetWeapon(WeaponType.Mac);
		if (Input.GetKeyDown(KeyCode.D))
			SetWeapon(WeaponType.ShotGun);
	}


	IEnumerator ShootGun()
	{
		_isShooting = true;
		Rigidbody rigi = Instantiate(_bullet,
			transform.Find(_selectedWeapon.Name).Find("ShootPoint").position,
			Quaternion.Euler(transform.forward)).GetComponent<Rigidbody>();

		rigi.AddRelativeForce(transform.forward*1000);
		Destroy(rigi.gameObject, 3);
		yield return new WaitForSeconds(_selectedWeapon.ShootTime);
		_isShooting = false;
	}

	private void SetWeapon(WeaponType weapon)
	{
		if (transform.Find(_selectedWeapon.Name))
			Destroy(transform.Find(_selectedWeapon.Name).gameObject);
		WeaponInfo weaponinfo = _weapon[weapon];
		GameObject newGun = Instantiate(weaponinfo.GunObject, transform.position,Quaternion.Euler(transform.localEulerAngles)) as GameObject;
		newGun.transform.SetParent(transform);
		newGun.transform.localPosition += new Vector3(0.7f, 0, 0);
		newGun.name = weaponinfo.Name;
	//	if (_selectedWeapon == _weapon[_holdedWeaponOne])
	//		_holdedWeaponOne = weapon;
	//	else if (_selectedWeapon == _weapon[_holdedWeaponTwo])
	//		_holdedWeaponTwo = weapon;
		_selectedWeapon = weaponinfo;
	}
}

public class WeaponInfo
{
	public string Name;
	public float ShootTime;
	public float Damage;
	public GameObject GunObject;
	public WeaponInfo(string name, float shootTime,float damage, GameObject gunObject)
	{
		Name = name;
		ShootTime = shootTime;
		Damage = damage;
		GunObject = gunObject;
	}
}
public enum WeaponType
{
	Pistol,
	Mac,
	ShotGun,
	None
}
