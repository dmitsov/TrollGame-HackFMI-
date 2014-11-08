using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using NPCNamespace;
using PositionControl;

public class TheBrain : MonoBehaviour, INPCController{

	private ArrayList npcs;
	public GameObject prefab = null;
	// Use this for initialization
	void Start () {
		npcs = new ArrayList();
		NPCFactory.npc = prefab;
		NPCFactory.MakeNumberOfNPCS(2,npcs);

		int direction = 1;
		foreach(NPC n in npcs){
			GameObject obj = (GameObject)EditorUtility.InstanceIDToObject (n.gameObjID);
		
			int spwnPoint = new System.Random().Next(4);

			spwnPoint = spwnPoint == 0 ? spwnPoint + 1: spwnPoint;
			switch(spwnPoint){
				case 1: 
					obj.transform.position = GameObject.Find ("SpawnPoint1").transform.position; 
					break;
				case 2: 
					obj.transform.position = GameObject.Find ("SpawnPoint2").transform.position; 
					break;
				case 3: 
					obj.transform.position = GameObject.Find ("SpawnPoint3").transform.position; 
					break;
				default:
					break;
			}

		
			var script = obj.GetComponent<moveScript>();
			script.StartMoving((Direction)direction++);

		}

	}
	
	// Update is called once per frame
	void Update () {
		CheckTriggeredTraps ();
		CheckCollisions();
	}

	public void CheckCollisions(){
		foreach(NPC n in npcs){
			moveScript script = ((GameObject)EditorUtility.InstanceIDToObject(n.gameObjID)).GetComponent<moveScript>();
			if(script.IsTrig){
				Direction d = script.oldDir;
				d = (int)d < 4 ? (Direction)(d+1) : (Direction)1;

			
				script.startMove.Invoke (d);
			}
		}
	}

	public void CheckTriggeredTraps(){

	}

	public void SpawnNPC(){
		NPCFactory.MakeNumberOfNPCS (1,npcs);

	}

	public void UpdatePositions(){

	}

	public void LowerRageMeter(){
		foreach(NPC n in npcs){
			if(n.rageMeter > 0){
				n.rageMeter--;
			}
		}
	}
}
