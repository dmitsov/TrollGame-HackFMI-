using UnityEngine;
using System.Collections;


namespace PositionControl{
	
	public enum Direction{
		DONT_MOVE = 0,
		UP = 1,
		RIGHT = 2,
		LEFT = 3,
		DOWN = 4
	};
	
	
	
	public class moveScript : MonoBehaviour {
		private static ArrayList walls = new ArrayList();

		public float moveSpeed = 0.0f;
		public float height = 0.0f;
		public float width = 0.0f;

		public float floorHeight = 0.0f;
		public float floorWidth = 0.0f;

		public Direction dir;
		private bool isMoving;
		public delegate void StartMovDel(Direction d);
		public delegate void StopMovDel();
		public StartMovDel startMove;
		public StopMovDel stopMove;

		private bool isTriggered = false;
		public bool IsTrig{get{return isTriggered;}}
		public Direction oldDir = Direction.DONT_MOVE;

		void Awake(){
			for(int i = 0; i < 4; i++){

			}

			startMove = StartMoving;
			stopMove = StopMoving;
		}
		
		void Start () {

		}
		
		
		void Update () {
			if(isMoving){
				MoveToDir(dir);
			}
		}
		
		
		private void MoveToDir(Direction dir){
			switch(dir){
			case Direction.UP:
				this.transform.Translate(0,moveSpeed,0);
				break;	
			case Direction.DOWN:
				this.transform.Translate(0,-moveSpeed,0);
				break;
			case Direction.RIGHT:
				this.transform.Translate(moveSpeed,0,0);
				break;	
			case Direction.LEFT:
				this.transform.Translate(-moveSpeed,0,0);
				break;
			default: break;
			}
		
		}
		
		public void StopMoving(){
			this.isMoving = false;
			this.dir = Direction.DONT_MOVE;
			this.isTriggered = false;
		}
		
		public void StartMoving(Direction dir){
			if(!isMoving){
				this.dir = dir;
				this.isMoving = true;
				this.isTriggered = false;
			}
		}

		public void OnTriggerEnter2D(Collider2D col){
			switch(dir){
			case Direction.UP:
				transform.Translate(0,-moveSpeed*2.0f,0);
				break;
			case Direction.RIGHT:
				transform.Translate(-moveSpeed*2.0f,0,0);
				break;
			case Direction.DOWN:
				transform.Translate(0,moveSpeed*2.0f,0);
				break;
			case Direction.LEFT:
				this.transform.Translate(moveSpeed*2.0f,0,0);
				break;
			}
			oldDir = dir;
			dir = Direction.DONT_MOVE;
			isMoving = false;
			isTriggered = true;
		}

	

	}
}
