using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
	public TowerType TowerType;
	public string Name;
	public int Damage;
	public int HP;
	public int Level;
	public string Description;
	public int BaseCost;
	public int UpgradeCost;
	public int TotalCost;
	public int AttackCooldown;

	public List<Projectile> projectiles;

	void Start () {
		
	}
	
	void Update () {

	}
}

public enum TowerType
{
	Damage,
	Poison,
	Slow,
	AreaOfEffect
}
