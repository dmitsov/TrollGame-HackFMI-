using UnityEngine;
using System.Collections;
using NPCNamespace;
using PositionControl;

namespace NPCNamespace{


	class NPCFactory{
		public NPCFactory(){

		}
		public static GameObject npc;
		public static void MakeNumberOfNPCS(int num, ArrayList list){
			for(int i = 0; i < num; i++){
				list.Add(MakeNPC());
			}
		}

		public static NPC MakeNPC(){
			NPC np = new NPC(0,0.0f,0.0f,Direction.DONT_MOVE);
			if(npc != null){
				GameObject obj = (GameObject)MonoBehaviour.Instantiate(npc);
				np = new NPC(obj.GetInstanceID(),0.0f,0.0f,Direction.DONT_MOVE);
			}

			return np;
		}

	}
}

