using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff : MonoBehaviour {
	public DebuffType DebuffType;
	public string Name;
	public string Tooltip;
	public int Damage;
	public int Duration;

	void Start () {
		
	}

	void Update () {
		
	}
}

public enum DebuffType
{
	Poison,
	Slow
}
