using UnityEngine;

public class Shop : MonoBehaviour {

	public void PurchaseStandardTurret(){
		Debug.Log ("Standard turret selected");
		BuildManager.instance.SetTurretToBuild (BuildManager.instance.standardTurretPrefab);
	}

	public void PurchaseAnotherTurret(){
		Debug.Log ("Another turret selected");
		BuildManager.instance.SetTurretToBuild (BuildManager.instance.anotherTurretPrefab);
	}

}
