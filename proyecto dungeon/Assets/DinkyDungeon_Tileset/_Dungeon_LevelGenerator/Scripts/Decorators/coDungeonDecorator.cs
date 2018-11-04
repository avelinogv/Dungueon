// Copyright (C) 2012 Vertex Stream Games
// Only for use, modification and/or re-distribution in a compiled project.
// No re-sale of modified code permitted.

#if UNITY_EDITOR

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class coDungeonDecorator
	: MonoBehaviour 
{	
	public enum enCellType
	{
		None,
		TileI,
		TileL,
		TileT,
		TileX,
		TileE,
		RoomOne,
		RoomTwo,
		RoomTwoB,
		RoomThree,
		RoomFour,
		RoomLong,
		RoomLarge,
	}
	
	public struct stDecoratorCell
	{
		public enCellType CellType;
		public Vector3	  CellPosition;
		public Quaternion CellRotation;
		
		public stDecoratorCell
			(enCellType cellType,
			 Vector3 	cellPosition,
			 Quaternion	cellRotation)
		{
			this.CellType     = cellType;
			this.CellPosition = cellPosition;
			this.CellRotation = cellRotation;
		}
	}
	
	public List<stDecoratorCell> Cells;
	
	public abstract bool DecorateDungeon();	
}

#endif