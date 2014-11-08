using UnityEngine;
using System.Collections;


namespace NPCNamespace{


	class NPC{
		public static int RageLimit = 3;

		public NPC(int gID, float x, float y, PositionControl.Direction d){
			this.gameObjID = gID;
			this.x = x;
			this.y = y;
			this.dir = d;
			rageMeter = 0;
		}

		public int gameObjID;
		public float x;
		public float y;
		public PositionControl.Direction dir;
		public int rageMeter;
	}

	public interface INPCController{

		void SpawnNPC();
		void CheckCollisions();
		void CheckTriggeredTraps();
		void LowerRageMeter();
		void UpdatePositions();

	}


}