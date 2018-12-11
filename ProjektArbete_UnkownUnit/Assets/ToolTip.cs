using System.Collections;
using System.Collections.Generic;
using Assets.Entities;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    [SerializeField]
    private Text toolTiptText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    toolTiptText.text = "Name: " + Tower.Instance.Name+"\n"+
	        "Damage: " + Tower.Instance.Damage + "\n"+
	        "Description: " + Tower.Instance.Description;
	}
}
