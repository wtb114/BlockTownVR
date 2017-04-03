using UnityEngine;
using System.Collections;

public class GyroScriptWalk : MonoBehaviour {

	public GameObject diveCamera;
	public float moveSpeed  = 10.0f;
	public float moveSpeed2 = 30.0f;
	public float moveSpeed3 = -10.0f;
	public float moveAngleX = 10.0f;
	public float moveAngleXX = 20.0f;
	public float moveAngleXXX = 350.0f;
	public float moveAngleXXXX = 340.0f;

//	private Vector3 Acceleration;
//	private Vector3 preAcceleration;
//	float DotProduct;
//	public static float ShakeCount;

	float yOffset;

	Quaternion currentGyro;

	void Start(){
		Input.gyro.enabled = true;
		yOffset = gameObject.transform.position.y;
//		ShakeCount = 2;
	}

	void Update () {
		currentGyro = Input.gyro.attitude;
		this.transform.localRotation = 
			Quaternion.Euler (90, 90, 0) * (new Quaternion (-currentGyro.x, -currentGyro.y, currentGyro.z, currentGyro.w)); 
		
		// 1.カメラの傾きを取得
		float angle = diveCamera.transform.eulerAngles.x;
//		float angle = Input.gyro.attitude.x;
//		float angle = transform.localRotation.x;
		Debug.Log (angle);		

		// 2.ある角度以内であれば前進させる
		if (moveAngleX < angle && angle < moveAngleXX) {
			moveForward ();
		} else if (moveAngleXX < angle && angle < 45.0f) {
			runForward ();
		} else if (moveAngleXXX > angle && angle > moveAngleXXXX) {
			moveBackward ();
//		} else {
//		  preAcceleration = Acceleration;
//		  Acceleration = Input.acceleration;
//		  DotProduct = Vector3.Dot(Acceleration, preAcceleration);
//		  ShakeCount += 1 * Time.deltaTime;
//
//			if (DotProduct < 0) {
//				ShakeCount = 0;
//				if (ShakeCount > 0 & ShakeCount < 2) {
//					print ("move up");
//					moveUp ();
//				} else if (ShakeCount > 2 && diveCamera.transform.position.y > yOffset);{
//					print ("moveDown");
//					moveDown ();
//				}
//		    }
	    }
  }
//			print (ShakeCount);
//		} else if (moveAngleXXXX > angle && angle > 270.0f) {
//			yOffset += 5.0f;
//			if (angle > 45.0f && angle < 90.0f) {
//				yOffset -= 5.0f;
//			}
//		}
	

	public void moveForward() {
		Vector3 direction = new Vector3 (diveCamera.transform.forward.x, 0, diveCamera.transform.forward.z).normalized * moveSpeed * Time.deltaTime;
		Quaternion rotation = Quaternion.Euler (new Vector3 (0, -diveCamera.transform.rotation.eulerAngles.y, 0));
		diveCamera.transform.Translate (rotation * direction);
		diveCamera.transform.position = new Vector3 (diveCamera.transform.position.x, yOffset, diveCamera.transform.position.z);
	}
	public void runForward() {
		Vector3 direction = new Vector3 (diveCamera.transform.forward.x, 0, diveCamera.transform.forward.z).normalized * moveSpeed2 * Time.deltaTime;
		Quaternion rotation = Quaternion.Euler (new Vector3 (0, -diveCamera.transform.rotation.eulerAngles.y, 0));
		diveCamera.transform.Translate (rotation * direction);
		diveCamera.transform.position = new Vector3 (diveCamera.transform.position.x, yOffset, diveCamera.transform.position.z);
	}
	public void moveBackward() {
		Vector3 direction = new Vector3 (diveCamera.transform.forward.x, 0, diveCamera.transform.forward.z).normalized * moveSpeed3 * Time.deltaTime;
		Quaternion rotation = Quaternion.Euler (new Vector3 (0, -diveCamera.transform.rotation.eulerAngles.y, 0));
		diveCamera.transform.Translate (rotation * direction);
		diveCamera.transform.position = new Vector3 (diveCamera.transform.position.x, yOffset, diveCamera.transform.position.z);
	}

//	public void moveUp(){
//		Vector3 direction = Vector3.up * moveSpeed2 * Time.deltaTime;
//		Quaternion rotation = Quaternion.Euler (new Vector3 (0, -diveCamera.transform.rotation.eulerAngles.y, 0));
//		rotation = Quaternion.identity;
//		diveCamera.transform.Translate (rotation * direction);
//		diveCamera.transform.position = new Vector3 (diveCamera.transform.position.x, diveCamera.transform.position.y, diveCamera.transform.position.z);
//		diveCamera.transform.position += direction;
//	}
//
//	public void moveDown(){
//		Vector3 direction = Vector3.up * -moveSpeed * Time.deltaTime;
//		Quaternion rotation = Quaternion.Euler (new Vector3 (0, -diveCamera.transform.rotation.eulerAngles.y, 0));
//		rotation = Quaternion.identity;
//		diveCamera.transform.Translate (rotation * direction);
//		diveCamera.transform.position = new Vector3 (diveCamera.transform.position.x, diveCamera.transform.position.y, diveCamera.transform.position.z);
//		diveCamera.transform.position += direction;
//	}
}