﻿using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake(){
		if (instance != null) {
			Debug.LogError ("More than one BuildManager in the scene!");
			return;
		}

		instance = this;
	}

	public GameObject standardTurretPrefab;
	public GameObject anotherTurretPrefab;

	private GameObject turretToBuild;

	public GameObject GetTurretToBuild(){
		return turretToBuild;
	}

	public void SetTurretToBuild(GameObject turret){
		turretToBuild = turret;
	}
}