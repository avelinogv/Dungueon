// Copyright (C) 2012 Vertex Stream Games
// Only for use, modification and/or re-distribution in a compiled project.
// No re-sale of modified code permitted.

#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class coDungeonDecoratorDinky
	: coDungeonDecorator
{
	#region Members
	
		public List<GameObject> ITilePrefabs;
		public List<GameObject> LTilePrefabs;
		public List<GameObject> TTilePrefabs;
		public List<GameObject> XTilePrefabs;
		public List<GameObject> ETilePrefabs;
	
		public List<GameObject> RoomOnePrefabs;
		public List<GameObject> RoomTwoPrefabs;
		public List<GameObject> RoomTwoBPrefabs;
		public List<GameObject> RoomThreePrefabs;
		public List<GameObject> RoomFourPrefabs;
		public List<GameObject> LongRoomPrefabs;
		public List<GameObject> LargeRoomPrefabs;
	
	#endregion
	
	#region Functions
	
		public override bool DecorateDungeon ()
		{	
			foreach (stDecoratorCell cell in this.Cells)
			{
				try
				{
					switch (cell.CellType)
					{
						case enCellType.RoomOne:
					
							int indexOne = Random.Range(0, this.RoomOnePrefabs.Count);
					
							GameObject
							furnitureOne = (GameObject)Instantiate(RoomOnePrefabs[indexOne], cell.CellPosition, cell.CellRotation);							
							furnitureOne.transform.parent = this.transform;	

							try
							{
								furnitureOne.tag = "FURNITURE";
							}
							catch
							{
								Debug.LogWarning("FURNITURE Tag not defined.  This may cause decorators to fail.  Please add a tag to your project called FURNITURE.");
							}		
					
							break;
					
						case enCellType.RoomTwo:
					
							int indexTwo = Random.Range(0, this.RoomTwoPrefabs.Count);
					
							GameObject
							furnitureTwo = (GameObject)Instantiate(RoomTwoPrefabs[indexTwo], cell.CellPosition, cell.CellRotation);							
							furnitureTwo.transform.parent = this.transform;	
							
							try
							{
								furnitureTwo.tag = "FURNITURE";
							}
							catch
							{
								Debug.LogWarning("FURNITURE Tag not defined.  This may cause decorators to fail.  Please add a tag to your project called FURNITURE.");
							}		
					
							break;
					
						case enCellType.RoomTwoB:
					
							int indexTwoB = Random.Range(0, this.RoomTwoBPrefabs.Count);
					
							GameObject
							furnitureTwoB = (GameObject)Instantiate(RoomTwoBPrefabs[indexTwoB], cell.CellPosition, cell.CellRotation);							
							furnitureTwoB.transform.parent = this.transform;	

							try
							{
								furnitureTwoB.tag = "FURNITURE";
							}
							catch
							{
								Debug.LogWarning("FURNITURE Tag not defined.  This may cause decorators to fail.  Please add a tag to your project called FURNITURE.");
							}				
					
							break;
					
						case enCellType.RoomThree:
					
							int indexThree = Random.Range(0, this.RoomThreePrefabs.Count);
					
							GameObject
							furnitureThree = (GameObject)Instantiate(RoomThreePrefabs[indexThree], cell.CellPosition, cell.CellRotation);							
							furnitureThree.transform.parent = this.transform;	

							try
							{
								furnitureThree.tag = "FURNITURE";
							}
							catch
							{
								Debug.LogWarning("FURNITURE Tag not defined.  This may cause decorators to fail.  Please add a tag to your project called FURNITURE.");
							}						
					
							break;
					
						case enCellType.RoomFour:
					
							int indexFour = Random.Range(0, this.RoomFourPrefabs.Count);
					
							GameObject
							furnitureFour = (GameObject)Instantiate(RoomFourPrefabs[indexFour], cell.CellPosition, cell.CellRotation);							
							furnitureFour.transform.parent = this.transform;

							try
							{
								furnitureFour.tag = "FURNITURE";
							}
							catch
							{
								Debug.LogWarning("FURNITURE Tag not defined.  This may cause decorators to fail.  Please add a tag to your project called FURNITURE.");
							}			
					
							break;
					
						case enCellType.RoomLarge:
					
							int indexLarge = Random.Range(0, this.LargeRoomPrefabs.Count);
					
							GameObject
							furnitureLarge = (GameObject)Instantiate(LargeRoomPrefabs[indexLarge], cell.CellPosition, cell.CellRotation);							
							furnitureLarge.transform.parent = this.transform;	

							try
							{
								furnitureLarge.tag = "FURNITURE";
							}
							catch
							{
								Debug.LogWarning("FURNITURE Tag not defined.  This may cause decorators to fail.  Please add a tag to your project called FURNITURE.");
							}		
					
							break;
					
						case enCellType.RoomLong:
					
							int indexLong = Random.Range(0, this.LongRoomPrefabs.Count);
					
							GameObject
							furnitureLong = (GameObject)Instantiate(LongRoomPrefabs[indexLong], cell.CellPosition, cell.CellRotation);
							furnitureLong.transform.parent = this.transform;	

							try
							{
								furnitureLong.tag = "FURNITURE";
							}
							catch
							{
								Debug.LogWarning("FURNITURE Tag not defined.  This may cause decorators to fail.  Please add a tag to your project called FURNITURE.");
							}		
					
							break;
					
						case enCellType.TileE:
						
								int indexE = Random.Range(0, this.ETilePrefabs.Count);
						
								GameObject
								fE = (GameObject)Instantiate(ETilePrefabs[indexE], cell.CellPosition, cell.CellRotation);								
								fE.transform.parent = this.transform;

								try
								{
									fE.tag = "FURNITURE";
								}
								catch
								{
									Debug.LogWarning("FURNITURE Tag not defined.  This may cause decorators to fail.  Please add a tag to your project called FURNITURE.");
								}		
						
							break;
						
						case enCellType.TileX:
						
								int indexX = Random.Range(0, this.XTilePrefabs.Count);
						
								GameObject
								fX = (GameObject)Instantiate(XTilePrefabs[indexX], cell.CellPosition, cell.CellRotation);								
								fX.transform.parent = this.transform;

								try
								{
									fX.tag = "FURNITURE";
								}
								catch
								{
									Debug.LogWarning("FURNITURE Tag not defined.  This may cause decorators to fail.  Please add a tag to your project called FURNITURE.");
								}			
						
							break;
					
						case enCellType.TileI:
						
								int indexI = Random.Range(0, this.ITilePrefabs.Count);
						
								GameObject
								fI = (GameObject)Instantiate(ITilePrefabs[indexI], cell.CellPosition, cell.CellRotation);								
								fI.transform.parent = this.transform;	

								try
								{
									fI.tag = "FURNITURE";
								}
								catch
								{
									Debug.LogWarning("FURNITURE Tag not defined.  This may cause decorators to fail.  Please add a tag to your project called FURNITURE.");
								}		
						
							break;
					
						case enCellType.TileT:
						
								int indexT = Random.Range(0, this.TTilePrefabs.Count);
						
								GameObject
								fT = (GameObject)Instantiate(TTilePrefabs[indexT], cell.CellPosition, cell.CellRotation);								
								fT.transform.parent = this.transform;

								try
								{
									fT.tag = "FURNITURE";
								}
								catch
								{
									Debug.LogWarning("FURNITURE Tag not defined.  This may cause decorators to fail.  Please add a tag to your project called FURNITURE.");
								}			
						
							break;
					
						case enCellType.TileL:
						
								int indexL = Random.Range(0, this.LTilePrefabs.Count);
						
								GameObject
								fL = (GameObject)Instantiate(LTilePrefabs[indexL], cell.CellPosition, cell.CellRotation);								
								fL.transform.parent = this.transform;	

								try
								{
									fL.tag = "FURNITURE";
								}
								catch
								{
									Debug.LogWarning("FURNITURE Tag not defined.  This may cause decorators to fail.  Please add a tag to your project called FURNITURE.");
								}		
						
							break;
					}
				}
				catch
				{
					Debug.LogWarning("Unable to decorate room - missing prefabs!");
				}
			}
		
			return true;
		}
	
	#endregion
}

#endif