using UnityEngine;

public class CameraController : MonoBehaviour {

	private bool doMovement = true;
	private Vector3 initPosition;
	private Quaternion initRotation;

	[SerializeField]
	private float panSpeed = 40f;
	[SerializeField]
	private float panBorderThickness = 10f; // in pixels
	[SerializeField]
	private float zoomSpeed = 1000f;
	[SerializeField]
	private float minY = 8f;
	[SerializeField]
	private float maxY = 70f;
	[SerializeField]
	private bool invertScrolling = true;

	void Start(){
		initPosition = transform.position;
		initRotation = transform.rotation;
	}

	void Update(){

		if (Input.GetKeyDown (KeyCode.Escape))
			doMovement = !doMovement;

		if (!doMovement) {
			return;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			transform.position = initPosition;
		}

		if (Input.GetKey ("w") || Input.mousePosition.y > Screen.height - panBorderThickness) {
			transform.Translate (-Vector3.forward * Time.deltaTime * panSpeed, Space.World);
		}

		if (Input.GetKey ("s") || Input.mousePosition.y < panBorderThickness) {
			transform.Translate (-Vector3.back * Time.deltaTime * panSpeed, Space.World);
		}

		if (Input.GetKey ("a") || Input.mousePosition.x < panBorderThickness) {
			transform.Translate (-Vector3.left * Time.deltaTime * panSpeed, Space.World);
		}

		if (Input.GetKey ("d") || Input.mousePosition.x > Screen.width - panBorderThickness) {
			transform.Translate (-Vector3.right * Time.deltaTime * panSpeed, Space.World);
		}
			
		float zoom;
		if(invertScrolling)
			zoom = -Input.GetAxis ("Mouse ScrollWheel");
		else
			zoom = Input.GetAxis ("Mouse ScrollWheel");

		Vector3 pos = transform.position;

		pos.y -= zoom * Time.deltaTime * zoomSpeed;
		pos.y = Mathf.Clamp (pos.y, minY, maxY);

		transform.position = pos;
	}

}
