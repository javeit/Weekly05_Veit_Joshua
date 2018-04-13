using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour {

	/// <summary>
	/// The offset in the z axis from the mouse click position
	/// for the NavMeshAgent's destination
	/// </summary>
	public float zOffset;

	void Update () {

		if(Input.GetMouseButtonDown(0)) {

			// rather than attach a reference to the main camera, 
			// I'm taking advantage of that fact that the main camera is the camera 
			// that I want in this case and accessing it through Camera.main
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit)) {

				// offset the z position of the destination by an ammount set in the inspector
				GetComponent<NavMeshAgent>().SetDestination(hit.point + new Vector3(0f, 0f, zOffset));
			}
		}
	}
}
