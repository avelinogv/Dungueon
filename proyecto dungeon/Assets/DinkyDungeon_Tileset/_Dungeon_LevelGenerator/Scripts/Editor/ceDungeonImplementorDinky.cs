// Copyright (C) 2012 Vertex Stream Games
// Only for use, modification and/or re-distribution in a compiled project.
// No re-sale of modified code permitted.

#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
	
/// <summary>
/// Custom GUI for the Dungeon Generator 
/// </summary>
[CustomEditor(typeof(coDungeonImplementorDinky))]
public class ceDungeonImplementorDinky
	: Editor 
{
	#region Functions
	
		public override void OnInspectorGUI()
		{	
			coDungeonImplementorDinky dI
				= target as coDungeonImplementorDinky;	
		
			coDungeonGenerator dG
					= (coDungeonGenerator)
						dI.transform.GetComponent
							(typeof(coDungeonGenerator));	
			
			if (dG)
			{			
				dI.Player
					= (GameObject)EditorGUILayout.ObjectField 
						("Player", dI.Player, typeof(GameObject), true);	
			
				EditorGUILayout.Separator();			
				EditorGUILayout.PrefixLabel("Corridors");			
				EditorGUILayout.Separator();	
			
				dI.TileI
					= (GameObject)EditorGUILayout.ObjectField 
						("I-Tile", dI.TileI, typeof(GameObject), true);	
			
				dI.TileL
					= (GameObject)EditorGUILayout.ObjectField 
						("L-Tile", dI.TileL, typeof(GameObject), true);
			
				dI.TileT
					= (GameObject)EditorGUILayout.ObjectField 
						("T-Tile", dI.TileT, typeof(GameObject), true);
			
				dI.TileX
					= (GameObject)EditorGUILayout.ObjectField 
						("X-Tile", dI.TileX, typeof(GameObject), true);
			
				dI.TileE
					= (GameObject)EditorGUILayout.ObjectField 
						("E-Tile", dI.TileE, typeof(GameObject), true);
			
				EditorGUILayout.Separator();			
				EditorGUILayout.PrefixLabel("Small Rooms");			
				EditorGUILayout.Separator();	
			
				dI.RoomOne
					= (GameObject)EditorGUILayout.ObjectField 
						("1 Door", dI.RoomOne, typeof(GameObject), true);
			
				dI.RoomTwo
					= (GameObject)EditorGUILayout.ObjectField 
						("2 Door", dI.RoomTwo, typeof(GameObject), true);
			
				dI.RoomTwoB
					= (GameObject)EditorGUILayout.ObjectField 
						("2 Door (B)", dI.RoomTwoB, typeof(GameObject), true);
			
				dI.RoomThree
					= (GameObject)EditorGUILayout.ObjectField 
						("3 Door", dI.RoomThree, typeof(GameObject), true);
			
				dI.RoomFour
					= (GameObject)EditorGUILayout.ObjectField 
						("4 Door", dI.RoomFour, typeof(GameObject), true);
			
				EditorGUILayout.Separator();			
				EditorGUILayout.PrefixLabel("Large Rooms");			
				EditorGUILayout.Separator();
			
				dI.LargeRoom
					= (GameObject)EditorGUILayout.ObjectField 
						("Large", dI.LargeRoom, typeof(GameObject), true);
			
				dI.LongRoom
					= (GameObject)EditorGUILayout.ObjectField 
						("Long", dI.LongRoom, typeof(GameObject), true);
			
				EditorGUILayout.Separator();			
				EditorGUILayout.PrefixLabel("Doors");			
				EditorGUILayout.Separator();
			
				dI.DoorFrame
					= (GameObject)EditorGUILayout.ObjectField 
						("Frame", dI.DoorFrame, typeof(GameObject), true);
			
				dI.DoorWood
					= (GameObject)EditorGUILayout.ObjectField 
						("Wood", dI.DoorWood, typeof(GameObject), true);
			
				dI.DoorGate
					= (GameObject)EditorGUILayout.ObjectField 
						("Gate", dI.DoorGate, typeof(GameObject), true);
			
				dI.DoorStone
					= (GameObject)EditorGUILayout.ObjectField 
						("Stone (Block Doorway)", dI.DoorStone, typeof(GameObject), true);				
			
				EditorGUILayout.Separator();			
				EditorGUILayout.PrefixLabel("Entrance / Exit");			
				EditorGUILayout.Separator();

			
				dI.Entrance
					= (GameObject)EditorGUILayout.ObjectField 
						("Entrance", dI.Entrance, typeof(GameObject), true);
			
				dI.Exit
					= (GameObject)EditorGUILayout.ObjectField 
						("Exit", dI.Exit, typeof(GameObject), true);
				
			}		
			
			if (GUI.changed)
				EditorUtility.SetDirty (target);
		}	
	
	#endregion 
}

#endif