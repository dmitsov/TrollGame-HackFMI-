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
		
		public float moveSpeed = 0.0f;
		public float height = 0.0f;
		public float width = 0.0f;

		private Direction dir;
		private bool isMoving;
		public delegate void StartMovDel(Direction d);
		public delegate void StopMovDel();
		public StartMovDel startMove;
		public StopMovDel stopMove;
		private GameObject floor;



		void Awake(){
			startMove = StartMoving;
			stopMove = StopMoving;
		}
		
		void Start () {
			this.floor = GameObject.Find("floor");

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
			CheckIfInBounds();
		}
		
		public void StopMoving(){
			this.isMoving = false;
			this.dir = Direction.DONT_MOVE;
		}
		
		public void StartMoving(Direction dir){
			if(!isMoving){
				this.dir = dir;
				this.isMoving = true;
			}
		}
		
		private void CheckIfInBounds(){
			float tx = floor.transform.position.x + 10.24f;
			float ty = floor.transform.position.y + 10.24f;

			float dx = floor.transform.position.x - 10.24f;
			float dy = floor.transform.position.y - 10.24f;
			float rSpeed = 0.0f;
			if(tx < this.transform.position.x + width * 0.5f|| dx > this.transform.position.x - width * 0.5f){
				rSpeed = dir == Direction.RIGHT ? tx - 8.19f * 0.5f: dx + 8.19f * 0.5f;
				this.transform.position = new Vector3(rSpeed,this.transform.position.y,0);
			} else if(ty < this.transform.position.y + height * 0.5f ||dy > this.transform.position.y - height * 0.5f){
				rSpeed = dir == Direction.UP ? ty - 4.6f * 0.5f  : dy + 4.6f * 0.5f; 
				this.transform.position = new Vector3(this.transform.position.x,rSpeed,0);
			}


		}
		
	}
}
