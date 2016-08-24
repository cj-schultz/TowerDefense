using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color hoverColor = Color.green;
	public Vector3 positionOffset;

	private Renderer rend;
	private Color defaultColor;

	private GameObject turret;

	void Start(){
		rend = GetComponent<Renderer> ();
		defaultColor = rend.material.color;
	}

	void OnMouseDown(){
		if (EventSystem.current.IsPointerOverGameObject ())
			return;
		
		if (BuildManager.instance.GetTurretToBuild () == null) {
			Debug.Log ("There is no turret to build");
			return;
		}

		if (turret != null) {
			Debug.Log ("Can't build here - TODO: Display on screen.");
			return;
		}

		GameObject turretToBuild = BuildManager.instance.GetTurretToBuild ();
		turret = (GameObject)Instantiate (turretToBuild, transform.position + positionOffset, transform.rotation);
	}

	void OnMouseEnter(){
		if (EventSystem.current.IsPointerOverGameObject ())
			return;

		if (BuildManager.instance.GetTurretToBuild () == null)
			return;
		
		rend.material.color = hoverColor;
	}

	void OnMouseExit(){
		rend.material.color = defaultColor;
	}

}
