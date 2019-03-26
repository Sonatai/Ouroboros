using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    
	private player_script player;
	private GameObject playerCameraObject;
	private Camera playerCamera;
    private Eventscript[] Room;

    private List<GameObject> listeners = new List<GameObject>();
    
	void Start ()
    {
        Debug.developerConsoleVisible = true;

		player = GameObject.FindObjectOfType (typeof(player_script)) as player_script;
		playerCameraObject = GameObject.FindWithTag ("MainCamera");
		playerCamera = playerCameraObject.GetComponent<Camera> ();

        Room = new Eventscript[6];
        Room[0] = GameObject.FindObjectOfType(typeof(event_script_A)) as event_script_A;
        Room[1] = GameObject.FindObjectOfType(typeof(event_script_R1)) as event_script_R1;
        Room[2] = GameObject.FindObjectOfType(typeof(event_script_R2)) as event_script_R2;
        Room[3] = GameObject.FindObjectOfType(typeof(event_script_R3)) as event_script_R3;
        Room[4] = GameObject.FindObjectOfType(typeof(event_script_R4)) as event_script_R4;
        Room[5] = GameObject.FindObjectOfType(typeof(event_script_R5)) as event_script_R5;

        AddListener(gameObject);
        AddListener(GameObject.Find("player"));
        AddListener(GameObject.Find("EventManager_Anfang"));
        AddListener(GameObject.Find("EventManager_R1"));
        AddListener(GameObject.Find("EventManager_R2"));
        AddListener(GameObject.Find("EventManager_R3"));
        AddListener(GameObject.Find("EventManager_R4"));
        AddListener(GameObject.Find("EventManager_R5"));
        AddListener(GameObject.Find("EventManager_Plateau"));

    }
    public void AddListener(GameObject listener) {
        if (!listeners.Contains(listener)) {
            listeners.Add(listener);
        }
    }
    
    public bool executeStateCommand(string input)
    {
        if (input.Equals("help")) {
            
        }

        string[] parts = input.Split(new char[] {'.', '(', ')' }, 4);
        if (parts == null) { return false; }
        if (listeners.Where(obj => obj.name == parts[0]) == null) { return false; }
        GameObject go = listeners.Where(obj => obj.name == parts[0]).SingleOrDefault();
        if (go != null)
        {
            Debug.Log("Receiver object found: " + go.name);
            go.SendMessage(parts[1], parts[2]);
            return true;
        }
        else
        {
            return false;
        }

    }

    public void CreateSphere(string input)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Debug.Log(""+input);
    }




	void Update () {

		//size calculation utility variables:
		
        

	}


}
