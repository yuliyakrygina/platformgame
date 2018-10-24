using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	//follow player

	public GameObject target; //gameobject type of variable, any object that exists withing the world of the game.
	public float followahead; //have camera follow ahead of player
	public float smoothing; 

	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame, occurs at every instant of the game
	void FixedUpdate () {
		//attached to every object in the game, what ever object this script is attached to, the transform position will follow that, for this is camera
		//transform.position = target.transform.position;  //transform of player, and go to position of player, target is player!

		targetPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z); // x is dependent on player, y and z moves only with camera. 
		//was transform.positon, where we want the camera to move to. 

		//this moves target of camera ahead of player
		if(target.transform.localScale.x > 0f) //facing right
		{
			targetPosition = new Vector3(targetPosition.x + followahead, targetPosition.y, targetPosition.z); 
		} else
		{
			targetPosition = new Vector3(targetPosition.x - followahead, targetPosition.y, targetPosition.z);  

		}

		//transform.position = targetPosition; //camera position = camera position

		transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime); //where it is, where we want it to be, how much time to get there
	}
}
