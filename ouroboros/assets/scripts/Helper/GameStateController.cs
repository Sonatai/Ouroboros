using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour {

     
	event_script_A roomA;
	event_script_R1 room1;
	event_script_R2 room2;
	event_script_R3 room3;
	event_script_R4 room4;
	event_script_R5 room5;
	player_script player;
	private GameObject playerCameraObject;
	public Camera playerCamera;


    Eventscript[] Room;

	void Start () {

        Debug.developerConsoleVisible = true;
        

        roomA = GameObject.FindObjectOfType (typeof(event_script_A)) as event_script_A;
		room1 = GameObject.FindObjectOfType (typeof(event_script_R1)) as event_script_R1;
		room2 = GameObject.FindObjectOfType (typeof(event_script_R2)) as event_script_R2;
		room3 = GameObject.FindObjectOfType (typeof(event_script_R3)) as event_script_R3;
		room4 = GameObject.FindObjectOfType (typeof(event_script_R4)) as event_script_R4;
		room5 = GameObject.FindObjectOfType (typeof(event_script_R5)) as event_script_R5;

		player = GameObject.FindObjectOfType (typeof(player_script)) as player_script;
		playerCameraObject = GameObject.FindWithTag ("MainCamera");
		playerCamera = playerCameraObject.GetComponent<Camera> ();


        Room = new Eventscript[6];
        Room[0] = roomA;
        Room[1] = room1;
        Room[2] = room2;
        Room[3] = room3;
        Room[4] = room4;
        Room[5] = room5;


    


	}
	
	void Update () {

		//size calculation utility variables:
		












	}


}
