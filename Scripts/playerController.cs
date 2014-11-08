using UnityEngine;
using System.Collections;
using PositionControl;

namespace PositionControl{
	public class playerController : MonoBehaviour
	{
		private event moveScript.StartMovDel startMov;			
		private event moveScript.StopMovDel stopMov;

		// Use this for initialization
		void Start ()
		{
			startMov += GetComponent<moveScript>().startMove;
			stopMov  += GetComponent<moveScript>().stopMove;
		}
	
		// Update is called once per frame
		void Update ()
		{
			if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)){
				Direction dir = Input.GetKeyDown(KeyCode.A) ? Direction.LEFT : Direction.RIGHT;
				startMov.Invoke (dir);
			} else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W)){
				Direction dir = Input.GetKeyDown(KeyCode.W) ? Direction.UP : Direction.DOWN;
				startMov.Invoke(dir);
			} else if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || 
			          	Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.S)) {
				stopMov.Invoke ();
			}
		}
	}
}
