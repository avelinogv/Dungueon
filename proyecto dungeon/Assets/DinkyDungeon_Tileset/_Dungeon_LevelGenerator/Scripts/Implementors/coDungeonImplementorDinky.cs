// Copyright (C) 2012 Vertex Stream Games
// Only for use, modification and/or re-distribution in a compiled project.
// No re-sale of modified code permitted.

#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class coDungeonImplementorDinky
	: coDungeonImplementor
{
	#region Enums
	
	[System.Flags]
	enum enCellState
	{
		None       = 0,
		NorthEmpty = 1,
		NorthWall  = 2,
		NorthDoor  = 4,
		SouthEmpty = 8,
		SouthWall  = 16,
		SouthDoor  = 32,
		EastEmpty  = 64,
		EastWall   = 128,
		EastDoor   = 256,
		WestEmpty  = 512,
		WestWall   = 1024,
		WestDoor   = 2048,		
	};

	enum enCellDirection
	{
		North,
		South,
		East,
		West,
	};
	
	#endregion
	
	#region Members
	
		public GameObject m_prefab_Player;
	
		public GameObject m_prefab_TileI;
		public GameObject m_prefab_TileL;
		public GameObject m_prefab_TileT;
		public GameObject m_prefab_TileX;
		public GameObject m_prefab_TileE;
	
		public GameObject m_prefab_RoomOne;
		public GameObject m_prefab_RoomTwo;
		public GameObject m_prefab_RoomTwoB;
		public GameObject m_prefab_RoomThree;
		public GameObject m_prefab_RoomFour;
	
		public GameObject m_prefab_LargeRoom;
		public GameObject m_prefab_LongRoom;
	
		public GameObject m_prefab_DoorFrame;
		public GameObject m_prefab_DoorWood;
		public GameObject m_prefab_DoorGate;
		public GameObject m_prefab_DoorStone;
	
		public GameObject m_prefab_Entrance;
		public GameObject m_prefab_Exit;	
	
	#endregion
	
	#region Properties	
		
		public GameObject Player
		{
			get { return m_prefab_Player;  }
			set { m_prefab_Player = value; }
		}
		public GameObject TileI
		{
			get { return m_prefab_TileI;  }
			set { m_prefab_TileI = value; }
		}
	
		public GameObject TileL
		{
			get { return m_prefab_TileL;  }
			set { m_prefab_TileL = value; }
		}
	
		public GameObject TileT
		{
			get { return m_prefab_TileT;  }
			set { m_prefab_TileT = value; }
		}
	
		public GameObject TileX
		{
			get { return m_prefab_TileX;  }
			set { m_prefab_TileX = value; }
		}
	
		public GameObject TileE
		{
			get { return m_prefab_TileE;  }
			set { m_prefab_TileE = value; }
		}
	
		public GameObject RoomOne
		{
			get { return m_prefab_RoomOne;  }
			set { m_prefab_RoomOne = value; }
		}
	
		public GameObject RoomTwo
		{
			get { return m_prefab_RoomTwo;  }
			set { m_prefab_RoomTwo = value; }
		}	
		
		public GameObject RoomTwoB
		{
			get { return m_prefab_RoomTwoB;  }
			set { m_prefab_RoomTwoB = value; }
		}
	
		public GameObject RoomThree
		{
			get { return m_prefab_RoomThree;  }
			set { m_prefab_RoomThree = value; }
		}
	
		public GameObject RoomFour
		{
			get { return m_prefab_RoomFour;  }
			set { m_prefab_RoomFour = value; }
		}
	
		public GameObject LargeRoom
		{
			get { return m_prefab_LargeRoom;  }
			set { m_prefab_LargeRoom = value; }
		}
	
		public GameObject LongRoom
		{
			get { return m_prefab_LongRoom;  }
			set { m_prefab_LongRoom = value; }
		}
	
		public GameObject DoorFrame
		{
			get { return m_prefab_DoorFrame;  }
			set { m_prefab_DoorFrame = value; }
		}
	
		public GameObject DoorWood
		{
			get { return m_prefab_DoorWood;  }
			set { m_prefab_DoorWood = value; }
		}
	
		public GameObject DoorGate
		{
			get { return m_prefab_DoorGate;  }
			set { m_prefab_DoorGate = value; }
		}
	
		public GameObject DoorStone
		{
			get { return m_prefab_DoorStone;  }
			set { m_prefab_DoorStone = value; }
		}
	
		public GameObject Entrance
		{
			get { return m_prefab_Entrance;  }
			set { m_prefab_Entrance = value; }
		}
	
		public GameObject Exit
		{
			get { return m_prefab_Exit;  }
			set { m_prefab_Exit = value; }
		}
	
	#endregion
	
	#region Functions		
		
		public override bool ImplementDungeon()
		{	
			coDungeonGenerator dG
				= (coDungeonGenerator)
					transform.GetComponent
					(typeof(coDungeonGenerator));	
		
			coDungeonDecoratorDinky dD
				= (coDungeonDecoratorDinky)
					transform.GetComponent
						(typeof(coDungeonDecoratorDinky));	
		
			if (dD != null)
			{
				if (dD.Cells == null) dD.Cells = new List<coDungeonDecorator.stDecoratorCell>();
				dD.Cells.Clear();			
			}
		
			if (dG)
			{			
				bool b_entrancePlaced = false;	
				bool b_exitPlaced     = false;
				bool b_atLeastOneRoom = false;
			
				foreach (Vector2 cell in dG.Dungeon.CellLocations)
				{				
					Vector3	   pos = new Vector3(cell.x*10, 0, cell.y*10);				
					Quaternion rot = Quaternion.identity;	
				
					GameObject  cellTile  = null;			
					enCellState cellState = enCellState.None;
				
					if (dG.Dungeon[cell].NorthSide == csDungeonCell.SideType.Empty) cellState |= enCellState.NorthEmpty;
					if (dG.Dungeon[cell].NorthSide == csDungeonCell.SideType.Wall)  cellState |= enCellState.NorthWall;
					if (dG.Dungeon[cell].NorthSide == csDungeonCell.SideType.Door)  cellState |= enCellState.NorthDoor;
				
					if (dG.Dungeon[cell].SouthSide == csDungeonCell.SideType.Empty) cellState |= enCellState.SouthEmpty;
					if (dG.Dungeon[cell].SouthSide == csDungeonCell.SideType.Wall)  cellState |= enCellState.SouthWall;
					if (dG.Dungeon[cell].SouthSide == csDungeonCell.SideType.Door)  cellState |= enCellState.SouthDoor;
				
					if (dG.Dungeon[cell].EastSide == csDungeonCell.SideType.Empty) cellState |= enCellState.EastEmpty;
					if (dG.Dungeon[cell].EastSide == csDungeonCell.SideType.Wall)  cellState |= enCellState.EastWall;
					if (dG.Dungeon[cell].EastSide == csDungeonCell.SideType.Door)  cellState |= enCellState.EastDoor;
				
					if (dG.Dungeon[cell].WestSide == csDungeonCell.SideType.Empty) cellState |= enCellState.WestEmpty;
					if (dG.Dungeon[cell].WestSide == csDungeonCell.SideType.Wall)  cellState |= enCellState.WestWall;
					if (dG.Dungeon[cell].WestSide == csDungeonCell.SideType.Door)  cellState |= enCellState.WestDoor;
				
					// Compass is flipped as follows (North is DOWN (-Z Axis)):
				
					//   S
					// W ┼ E
					//   N
				
					// ○ = OPEN
					// ■ = WALL
					// □ = DOOR				
				
					// Rooms only comprise WALLS and DOORS (never OPEN)
				
					if (!IsBigRoom(dG, cell))
					{
				
						//   ○ 
						// ■ │ ■ 
						//   ○ 
						if ((int)cellState==1161)
						{
							cellTile = this.m_prefab_TileI;
							rot = Quaternion.Euler(0,0,0);
						}
					
						//   ○ 
						// ■ │ ■ 
						//   □ 
						if ((int)cellState==1164)
						{
							cellTile = this.m_prefab_TileI;
							rot = Quaternion.Euler(0,0,0);					
						}
					
						//   □ 
						// ■ │ ■ 
						//   ○ 
						if ((int)cellState==1185)
						{
							cellTile = this.m_prefab_TileI;
							rot = Quaternion.Euler(0,0,0);					
						}
					
						//   □ 
						// ■ │ ■ 
						//   □ 
						if ((int)cellState==1188)
						{
							if (!IsSmallRoom(dG, pos))
							{
								cellTile = this.m_prefab_TileI;
								rot = Quaternion.Euler(0,0,0);
							}
							else
							{
								cellTile = this.m_prefab_RoomTwo;
								rot = Quaternion.Euler(0,0,0);					
								CreateDoor(dG, pos, enCellDirection.North);
								CreateDoor(dG, pos, enCellDirection.South);
								b_atLeastOneRoom = true;
							}
						}
					
						//   ○ 
						// ■ │ ■ 
						//   ■ 
						if ((int)cellState==1162)
						{
							if (b_entrancePlaced)
							{
								if (b_exitPlaced)
								{
									cellTile = this.m_prefab_TileE;
									rot = Quaternion.Euler(0,0,0);
								}
								else
								{								
									cellTile = this.m_prefab_Exit;
									rot = Quaternion.Euler(0,180,0);
									b_exitPlaced = true;
									pos.y = -2.8f;
								}							
							}
							else
							{
								cellTile = this.m_prefab_Entrance;
								rot = Quaternion.Euler(0,0,0);
								b_entrancePlaced = true;
								Player.transform.position = pos + Vector3.up * 4;
								Player.transform.rotation = rot;
							}
						}
					
						//   □ 
						// ■ │ ■ 
						//   ■ 
						if ((int)cellState==1186)
						{
							if (!IsSmallRoom(dG, pos))
							{
								if (b_entrancePlaced)
								{
									if (b_exitPlaced)
									{
										cellTile = this.m_prefab_TileE;
										rot = Quaternion.Euler(0,0,0);
									}
									else
									{								
										cellTile = this.m_prefab_Exit;
										rot = Quaternion.Euler(0,180,0);
										b_exitPlaced = true;
										pos.y = -2.8f;
									}							
								}
								else
								{
									cellTile = this.m_prefab_Entrance;
									rot = Quaternion.Euler(0,0,0);
									b_entrancePlaced = true;
									Player.transform.position = pos + Vector3.up * 4;
									Player.transform.rotation = rot;
								}
							}
							else
							{
								cellTile = this.m_prefab_RoomOne;
								rot = Quaternion.Euler(0,0,0);						
								CreateDoor(dG, pos, enCellDirection.South);
								b_atLeastOneRoom = true;
							}					
						}
					
						//   ■ 
						// ■ │ ■ 
						//   ○ 
						if ((int)cellState==1169)
						{
							if (b_entrancePlaced)
							{
								if (b_exitPlaced)
								{
									cellTile = this.m_prefab_TileE;
									rot = Quaternion.Euler(0,180,0);
								}
								else
								{								
									cellTile = this.m_prefab_Exit;
									rot = Quaternion.Euler(0,0,0);
									b_exitPlaced = true;
									pos.y = -2.8f;
								}							
							}
							else
							{
								cellTile = this.m_prefab_Entrance;
								rot = Quaternion.Euler(0,180,0);
								b_entrancePlaced = true;
								Player.transform.position = pos + Vector3.up * 4;
								Player.transform.rotation = rot;
							}
						}
					
						//   ■ 
						// ■ │ ■ 
						//   □ 
						if ((int)cellState==1172)
						{
							if (!IsSmallRoom(dG, pos))
							{
								if (b_entrancePlaced)
								{
									if (b_exitPlaced)
									{
										cellTile = this.m_prefab_TileE;
										rot = Quaternion.Euler(0,180,0);
									}
									else
									{								
										cellTile = this.m_prefab_Exit;
										rot = Quaternion.Euler(0,0,0);
										b_exitPlaced = true;
										pos.y = -2.8f;
									}							
								}
								else
								{
									cellTile = this.m_prefab_Entrance;
									rot = Quaternion.Euler(0,180,0);
									b_entrancePlaced = true;
									Player.transform.position = pos + Vector3.up * 4;
									Player.transform.rotation = rot;
								}
							}
							else
							{
								cellTile = this.m_prefab_RoomOne;
								rot = Quaternion.Euler(0,180,0);						
								CreateDoor(dG, pos, enCellDirection.North);
								b_atLeastOneRoom = true;
							}			
						}
					
						//   ■ 
						// ○ ─ ○ 
						//   ■ 
						if ((int)cellState==594)
						{
							cellTile = this.m_prefab_TileI;
							rot = Quaternion.Euler(0,90,0);
						}
					
						
						//   ■ 
						// □ ─ □ 
						//   ■ 
						if ((int)cellState==2322)
						{
							if (!IsSmallRoom(dG, pos))
							{
								cellTile = this.m_prefab_TileI;
								rot = Quaternion.Euler(0,90,0);
							}
							else
							{
								cellTile = this.m_prefab_RoomTwo;
								rot = Quaternion.Euler(0,90,0);					
								CreateDoor(dG, pos, enCellDirection.East);
								CreateDoor(dG, pos, enCellDirection.West);
								b_atLeastOneRoom = true;
							}					
						}
					
						//   ■ 
						// □ ─ ○ 
						//   ■ 
						if ((int)cellState==2130)
						{
							cellTile = this.m_prefab_TileI;
							rot = Quaternion.Euler(0,90,0);					
						}
					
						//   ■ 
						// ○ ─ □ 
						//   ■ 
						if ((int)cellState==786)
						{
							cellTile = this.m_prefab_TileI;
							rot = Quaternion.Euler(0,90,0);					
						}
					
						//   ■ 
						// ■ ─ ○ 
						//   ■ 
						if ((int)cellState==1106)
						{
							if (b_entrancePlaced)
							{
								if (b_exitPlaced)
								{
									cellTile = this.m_prefab_TileE;
									rot = Quaternion.Euler(0,90,0);
								}
								else
								{								
									cellTile = this.m_prefab_Exit;
									rot = Quaternion.Euler(0,270,0);
									b_exitPlaced = true;
									pos.y = -2.8f;
								}					
							}
							else
							{
								cellTile = this.m_prefab_Entrance;
								rot = Quaternion.Euler(0,90,0);
								b_entrancePlaced = true;
								Player.transform.position = pos + Vector3.up * 4;
								Player.transform.rotation = rot;
							}
						}
					
						//   ■ 
						// ■ ─ □ 
						//   ■ 
						if ((int)cellState==1298)
						{
							if (!IsSmallRoom(dG, pos))
							{
								if (b_entrancePlaced)
								{
									if (b_exitPlaced)
									{
										cellTile = this.m_prefab_TileE;
										rot = Quaternion.Euler(0,90,0);
									}
									else
									{								
										cellTile = this.m_prefab_Exit;
										rot = Quaternion.Euler(0,270,0);
										b_exitPlaced = true;
										pos.y = -2.8f;
									}					
								}
								else
								{
									cellTile = this.m_prefab_Entrance;
									rot = Quaternion.Euler(0,90,0);
									b_entrancePlaced = true;
									Player.transform.position = pos + Vector3.up * 4;
									Player.transform.rotation = rot;
								}
							}
							else
							{
								cellTile = this.m_prefab_RoomOne;
								rot = Quaternion.Euler(0,90,0);						
								CreateDoor(dG, pos, enCellDirection.East);
								b_atLeastOneRoom = true;
							}			
						}
					
						//   ■ 
						// ○ ─ ■ 
						//   ■ 
						if ((int)cellState==658)
						{
							if (b_entrancePlaced)
							{
								if (b_exitPlaced)
								{
									cellTile = this.m_prefab_TileE;
									rot = Quaternion.Euler(0,270,0);
								}
								else
								{								
									cellTile = this.m_prefab_Exit;
									rot = Quaternion.Euler(0,90,0);
									b_exitPlaced = true;
									pos.y = -2.8f;
								}					
							}
							else
							{
								cellTile = this.m_prefab_Entrance;
								rot = Quaternion.Euler(0,270,0);
								b_entrancePlaced = true;
								Player.transform.position = pos + Vector3.up * 4;
								Player.transform.rotation = rot;						
							}
						}
					
						//   ■ 
						// □ ─ ■ 
						//   ■ 
						if ((int)cellState==2194)
						{
							if (!IsSmallRoom(dG, pos))
							{
								if (b_entrancePlaced)
								{
									if (b_exitPlaced)
									{
										cellTile = this.m_prefab_TileE;
										rot = Quaternion.Euler(0,270,0);
									}
									else
									{								
										cellTile = this.m_prefab_Exit;
										rot = Quaternion.Euler(0,90,0);
										b_exitPlaced = true;
										pos.y = -2.8f;
									}				
								}
								else
								{
									cellTile = this.m_prefab_Entrance;
									rot = Quaternion.Euler(0,270,0);
									b_entrancePlaced = true;
									Player.transform.position = pos + Vector3.up * 4;
									Player.transform.rotation = rot;
								}
							}
							else
							{
								cellTile = this.m_prefab_RoomOne;
								rot = Quaternion.Euler(0,270,0);						
								CreateDoor(dG, pos, enCellDirection.West);
								b_atLeastOneRoom = true;
							}		
						}
					
						//   ■ 
						// ○ ┐ ■ 
						//   ○ 
						if ((int)cellState==657)
						{
							cellTile = this.m_prefab_TileL;
							rot = Quaternion.Euler(0,0,0);
						}
					
						//   ■ 
						// □ ┐ ■ 
						//   ○ 
						if ((int)cellState==2193)
						{
							cellTile = this.m_prefab_TileL;
							rot = Quaternion.Euler(0,0,0);					
						}
					
						//   ■ 
						// □ ┐ ■ 
						//   □ 
						if ((int)cellState==2196)
						{
							if (!IsSmallRoom(dG, pos))
							{						
								cellTile = this.m_prefab_TileL;
								rot = Quaternion.Euler(0,0,0);					
							}
							else
							{
								cellTile = this.m_prefab_RoomTwoB;
								rot = Quaternion.Euler(0,270,0);	
							
								CreateDoor(dG, pos, enCellDirection.North);
								CreateDoor(dG, pos, enCellDirection.West);							
							
								b_atLeastOneRoom = true;
							}						
						}
					
						//   ■ 
						// ○ ┐ ■ 
						//   □ 
						if ((int)cellState==660)
						{
							cellTile = this.m_prefab_TileL;
							rot = Quaternion.Euler(0,0,0);									
						}
					
						//   ○ 
						// ○ ┘ ■ 
						//   ■ 
						if ((int)cellState==650)
						{
							cellTile = this.m_prefab_TileL;
							rot = Quaternion.Euler(0,90,0);
						}
					
						//   ○ 
						// □ ┘ ■ 
						//   ■ 
						if ((int)cellState==2186)
						{
							cellTile = this.m_prefab_TileL;
							rot = Quaternion.Euler(0,90,0);					
						}
					
						//   □ 
						// □ ┘ ■ 
						//   ■ 
						if ((int)cellState==2210)
						{
							if (!IsSmallRoom(dG, pos))
							{						
								cellTile = this.m_prefab_TileL;
								rot = Quaternion.Euler(0,90,0);					
							}
							else
							{
								cellTile = this.m_prefab_RoomTwoB;
								rot = Quaternion.Euler(0,0,0);	
							
								CreateDoor(dG, pos, enCellDirection.West);
								CreateDoor(dG, pos, enCellDirection.South);							
							
								b_atLeastOneRoom = true;
							}							
						}
					
						//   □ 
						// ○ ┘ ■ 
						//   ■ 
						if ((int)cellState==674)
						{
							cellTile = this.m_prefab_TileL;
							rot = Quaternion.Euler(0,90,0);										
						}
					
						//   ○ 
						// ■ └ ○ 
						//   ■ 
						if ((int)cellState==1098)
						{
							cellTile = this.m_prefab_TileL;
							rot = Quaternion.Euler(0,180,0);
						}
					
						//   ○ 
						// ■ └ □ 
						//   ■ 
						if ((int)cellState==1290)
						{
							cellTile = this.m_prefab_TileL;
							rot = Quaternion.Euler(0,180,0);					
						}
					
						//   □ 
						// ■ └ ○ 
						//   ■ 
						if ((int)cellState==1122)
						{
							cellTile = this.m_prefab_TileL;
							rot = Quaternion.Euler(0,180,0);					
						}
					
						//   □ 
						// ■ └ □ 
						//   ■ 
						if ((int)cellState==1314)
						{
							if (!IsSmallRoom(dG, pos))
							{						
								cellTile = this.m_prefab_TileL;
								rot = Quaternion.Euler(0,180,0);					
							}
							else
							{
								cellTile = this.m_prefab_RoomTwoB;
								rot = Quaternion.Euler(0,90,0);	
							
								CreateDoor(dG, pos, enCellDirection.South);
								CreateDoor(dG, pos, enCellDirection.East);							
							
								b_atLeastOneRoom = true;
							}					
						}
					
						//   ■ 
						// ■ ┌ ○ 
						//   ○ 
						if ((int)cellState==1105)
						{
							cellTile = this.m_prefab_TileL;
							rot = Quaternion.Euler(0,270,0);
						}
					
						//   ■ 
						// ■ ┌ ○ 
						//   □ 
						if ((int)cellState==1108)
						{
							cellTile = this.m_prefab_TileL;
							rot = Quaternion.Euler(0,270,0);					
						}
					
						//   ■ 
						// ■ ┌ □ 
						//   ○ 
						if ((int)cellState==1297)
						{
							cellTile = this.m_prefab_TileL;
							rot = Quaternion.Euler(0,270,0);					
						}				
					
						//   ■ 
						// ■ ┌ □ 
						//   □ 
						if ((int)cellState==1300)
						{
							if (!IsSmallRoom(dG, pos))
							{						
								cellTile = this.m_prefab_TileL;
								rot = Quaternion.Euler(0,270,0);					
							}
							else
							{
								cellTile = this.m_prefab_RoomTwoB;
								rot = Quaternion.Euler(0,180,0);	
							
								CreateDoor(dG, pos, enCellDirection.North);
								CreateDoor(dG, pos, enCellDirection.East);							
							
								b_atLeastOneRoom = true;
							}
						}
					
						//   ○ 
						// ○ ┤ ■ 
						//   ○ 
						if ((int)cellState==649)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,0,0);
						}
					
						//   □ 
						// □ ┤ ■ 
						//   □ 
						if ((int)cellState==2212)
						{
							if (!IsSmallRoom(dG, pos))
							{
								cellTile = this.m_prefab_TileT;
								rot = Quaternion.Euler(0,0,0);					
							}
							else
							{
								cellTile = this.m_prefab_RoomThree;
								rot = Quaternion.Euler(0,270,0);							
								
								CreateDoor(dG, pos, enCellDirection.North);
								CreateDoor(dG, pos, enCellDirection.South);
								CreateDoor(dG, pos, enCellDirection.West);
							}
						}				
						
						//   ○ 
						// ○ ┤ ■ 
						//   □ 
						if ((int)cellState==652)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,0,0);										
						}	
					
						//   □ 
						// □ ┤ ■ 
						//   ○ 
						if ((int)cellState==2209)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,0,0);										
						}	
					
						//   ○ 
						// □ ┤ ■ 
						//   ○ 
						if ((int)cellState==2185)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,0,0);								
						}	
					
						//   □ 
						// ○ ┤ ■ 
						//   ○ 
						if ((int)cellState==673)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,0,0);								
						}	
					
						//   □ 
						// ○ ┤ ■ 
						//   □ 
						if ((int)cellState==676)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,0,0);								
						}	
					
						//   ○ 
						// □ ┤ ■ 
						//   □ 
						if ((int)cellState==2188)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,0,0);								
						}	
					
						//   ○ 
						// ○ ┴ ○ 
						//   ■ 
						if ((int)cellState==586)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,90,0);
						}
					
						//   □ 
						// □ ┴ ○ 
						//   ■ 
						if ((int)cellState==2146)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,90,0);					
						}	
					
						//   □ 
						// ○ ┴ □ 
						//   ■ 
						if ((int)cellState==802)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,90,0);					
						}	
						
						//   □ 
						// □ ┴ □ 
						//   ■ 
						if ((int)cellState==2338)
						{
							if (!IsSmallRoom(dG, pos))
							{
								cellTile = this.m_prefab_TileT;
								rot = Quaternion.Euler(0,90,0);					
							}
							else
							{
								cellTile = this.m_prefab_RoomThree;
								rot = Quaternion.Euler(0,0,0);							
								
								CreateDoor(dG, pos, enCellDirection.South);
								CreateDoor(dG, pos, enCellDirection.East);
								CreateDoor(dG, pos, enCellDirection.West);
							}				
						}
					
						//   □ 
						// ○ ┴ ○ 
						//   ■ 
						if ((int)cellState==610)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,90,0);							
						}
					
						//   ○ 
						// □ ┴ □ 
						//   ■ 
						if ((int)cellState==2314)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,90,0);							
						}
					
						//   ○ 
						// □ ┴ ○ 
						//   ■ 
						if ((int)cellState==2122)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,90,0);								
						}
					
						//   ○ 
						// ○ ┴ □ 
						//   ■ 
						if ((int)cellState==778)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,90,0);									
						}
					
						//   ○ 
						// ■ ├ ○ 
						//   ○ 
						if ((int)cellState==1097)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,180,0);
						}				
						
						//   □ 
						// ■ ├ ○ 
						//   ○ 
						if ((int)cellState==1121)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,180,0);					
						}
					
						//   □ 
						// ■ ├ □ 
						//   ○ 
						if ((int)cellState==1313)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,180,0);					
						}
					
						//   □ 
						// ■ ├ ○ 
						//   □ 
						if ((int)cellState==1124)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,180,0);					
						}
					
						//   ○ 
						// ■ ├ □ 
						//   ○ 
						if ((int)cellState==1289)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,180,0);					
						}
					
						//   ○ 
						// ■ ├ ○ 
						//   □ 
						if ((int)cellState==1100)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,180,0);					
						}
					
						//   □ 
						// ■ ├ □ 
						//   □ 
						if ((int)cellState==1316)
						{
							if (!IsSmallRoom(dG, pos))
							{
								cellTile = this.m_prefab_TileT;
								rot = Quaternion.Euler(0,180,0);					
							}
							else
							{
								cellTile = this.m_prefab_RoomThree;
								rot = Quaternion.Euler(0,90,0);							
								
								CreateDoor(dG, pos, enCellDirection.North);
								CreateDoor(dG, pos, enCellDirection.South);
								CreateDoor(dG, pos, enCellDirection.East);
							}				
						}
					
						//   ○ 
						// ■ ├ □ 
						//   □ 
						if ((int)cellState==1292)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,180,0);				
						}				
					
						//   ■ 
						// ○ ┬ ○ 
						//   ○ 
						if ((int)cellState==593)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,270,0);
						}	
					
						//   ■ 
						// □ ┬ ○ 
						//   □ 
						if ((int)cellState==2132)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,270,0);					
						}	
					
						//   ■ 
						// □ ┬ □ 
						//   ○ 
						if ((int)cellState==2321)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,270,0);					
						}	
					
						//   ■ 
						// □ ┬ □ 
						//   □ 
						if ((int)cellState==2324)
						{
							if (!IsSmallRoom(dG, pos))
							{
								cellTile = this.m_prefab_TileT;
								rot = Quaternion.Euler(0,270,0);					
							}
							else
							{
								cellTile = this.m_prefab_RoomThree;
								rot = Quaternion.Euler(0,180,0);							
								
								CreateDoor(dG, pos, enCellDirection.North);
								CreateDoor(dG, pos, enCellDirection.East);
								CreateDoor(dG, pos, enCellDirection.West);
							}								
						}	
					
						//   ■ 
						// □ ┬ ○ 
						//   ○ 
						if ((int)cellState==2129)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,270,0);					
						}	
					
						//   ■ 
						// ○ ┬ □ 
						//   □ 
						if ((int)cellState==788)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,270,0);					
						}	
					
						//   ■ 
						// ○ ┬ □ 
						//   ○ 
						if ((int)cellState==785)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,270,0);					
						}	
					
						//   ■ 
						// ○ ┬ ○ 
						//   □ 
						if ((int)cellState==596)
						{
							cellTile = this.m_prefab_TileT;
							rot = Quaternion.Euler(0,270,0);					
						}	
					
					
						//   ○ 
						// ○ ┼ ○ 
						//   ○ 
						if ((int)cellState==585)
						{
							cellTile = this.m_prefab_TileX;
							rot = Quaternion.Euler(0,0,0);
						}
					
						//   □ 
						// ○ ┼ ○ 
						//   ○ 
						if ((int)cellState==609)
						{
							cellTile = this.m_prefab_TileX;
							rot = Quaternion.Euler(0,0,0);
						}
					
						//   ○ 
						// □ ┼ ○ 
						//   □ 
						if ((int)cellState==2124)
						{
							cellTile = this.m_prefab_TileX;
							rot = Quaternion.Euler(0,0,0);					
						}	
					
						//   ○ 
						// □ ┼ ○ 
						//   ○ 
						if ((int)cellState==2121)
						{
							cellTile = this.m_prefab_TileX;
							rot = Quaternion.Euler(0,0,0);					
						}	
					
						//   □ 
						// □ ┼ ○ 
						//   ○ 
						if ((int)cellState==2145)
						{
							cellTile = this.m_prefab_TileX;
							rot = Quaternion.Euler(0,0,0);					
						}	
					
						//   ○ 
						// ○ ┼ □ 
						//   □ 
						if ((int)cellState==780)
						{
							cellTile = this.m_prefab_TileX;
							rot = Quaternion.Euler(0,0,0);					
						}	
					
						//   ○ 
						// ○ ┼ □ 
						//   ○ 
						if ((int)cellState==777)
						{
							cellTile = this.m_prefab_TileX;
							rot = Quaternion.Euler(0,0,0);					
						}						
					
						//   □ 
						// ○ ┼ □ 
						//   ○
						if ((int)cellState==801)
						{
							cellTile = this.m_prefab_TileX;
							rot = Quaternion.Euler(0,0,0);					
						}	
					
						//   ○ 
						// □ ┼ □ 
						//   ○ 
						if ((int)cellState==2313)
						{
							cellTile = this.m_prefab_TileX;
							rot = Quaternion.Euler(0,0,0);					
						}	
					
						//   ○ 
						// ○ ┼ ○ 
						//   □ 
						if ((int)cellState==588)
						{
							cellTile = this.m_prefab_TileX;
							rot = Quaternion.Euler(0,0,0);					
						}	
					
						//   □ 
						// □ ┼ □ 
						//   ○ 
						if ((int)cellState==2337)
						{
							cellTile = this.m_prefab_TileX;
							rot = Quaternion.Euler(0,0,0);					
						}	
					
						//   □ 
						// □ ┼ ○ 
						//   □ 
						if ((int)cellState==2148)
						{
							cellTile = this.m_prefab_TileX;
							rot = Quaternion.Euler(0,0,0);					
						}	
					
						//   ○ 
						// □ ┼ □ 
						//   □ 
						if ((int)cellState==2316)
						{
							cellTile = this.m_prefab_TileX;
							rot = Quaternion.Euler(0,0,0);					
						}	
					
						//   □ 
						// ○ ┼ □ 
						//   □ 
						if ((int)cellState==804)
						{
							cellTile = this.m_prefab_TileX;
							rot = Quaternion.Euler(0,0,0);					
						}	
					
						//   □ 
						// ○ ┼ ○ 
						//   □ 
						if ((int)cellState==612)
						{
							cellTile = this.m_prefab_TileX;
							rot = Quaternion.Euler(0,0,0);					
						}	
					
						//   □ 
						// □ ┼ □ 
						//   □ 
						if ((int)cellState==2340)
						{
							if (!IsSmallRoom(dG, pos))
							{
								cellTile = this.m_prefab_TileX;
								rot = Quaternion.Euler(0,0,0);
							}
							else
							{	
								cellTile = this.m_prefab_RoomFour;
								rot = Quaternion.Euler(0,0,0);					
							
								CreateDoor(dG, pos, enCellDirection.North);
								CreateDoor(dG, pos, enCellDirection.South);
								CreateDoor(dG, pos, enCellDirection.East);
								CreateDoor(dG, pos, enCellDirection.West);
							
								b_atLeastOneRoom = true;
							}
						}	
					}
					
					if (cellTile != null)
					{
						GameObject newTile = (GameObject)Instantiate(cellTile, pos, rot); 
						newTile.transform.parent = this.transform;		
					
						// Add Decorator Cell Data
						if (dD != null)
						{					
							coDungeonDecorator.enCellType dCellType = coDungeonDecorator.enCellType.None;
						
							if (cellTile == this.m_prefab_TileE) dCellType = coDungeonDecorator.enCellType.TileE;
							if (cellTile == this.m_prefab_TileX) dCellType = coDungeonDecorator.enCellType.TileX;
							if (cellTile == this.m_prefab_TileI) dCellType = coDungeonDecorator.enCellType.TileI;
							if (cellTile == this.m_prefab_TileT) dCellType = coDungeonDecorator.enCellType.TileT;
							if (cellTile == this.m_prefab_TileL) dCellType = coDungeonDecorator.enCellType.TileL;
						
							if (cellTile == this.m_prefab_RoomOne)   dCellType = coDungeonDecorator.enCellType.RoomOne;
							if (cellTile == this.m_prefab_RoomTwo)   dCellType = coDungeonDecorator.enCellType.RoomTwo;
							if (cellTile == this.m_prefab_RoomTwoB)  dCellType = coDungeonDecorator.enCellType.RoomTwoB;
							if (cellTile == this.m_prefab_RoomThree) dCellType = coDungeonDecorator.enCellType.RoomThree;
							if (cellTile == this.m_prefab_RoomFour)  dCellType = coDungeonDecorator.enCellType.RoomFour;							
						
							coDungeonDecorator.stDecoratorCell dCell 
								= new coDungeonDecorator.stDecoratorCell
									(dCellType, pos, rot);
						
							dD.Cells.Add(dCell);						
						}
					}
					else
					{
						if ((int)cellState != 1170 && !IsBigRoom(dG, cell))
						{
							Debug.LogWarning("Tile not handled: " + ((int)cellState).ToString() + " - " + cellState.ToString());						
							Debug.Log(BuildTileTextIcon(cellState));
							
						}
					}
				}
			
				//Big rooms!
				foreach (csDungeonRoom room in dG.Dungeon.Rooms)
				{
					//Large Room
					if (room.Bounds.width > 1 || room.Bounds.height > 1)
					{
						Vector3 roomPos = new Vector3(room.Bounds.center.x * 10 - 5, 0, room.Bounds.center.y * 10 - 5);				
					
						bool bOkToPlace = true;
//						foreach (Transform t in transform)
//						{
//							if (Vector3.Distance(roomPos, t.position) < 10.0f)
//								bOkToPlace = false;
//								//return false;
//						}
					
						if (bOkToPlace)
						{
				
							GameObject roomPrefab = null;
							Quaternion roomRot = Quaternion.identity;					
						
							if (room.Bounds.width == 2 && room.Bounds.height == 2)						
								roomPrefab = this.m_prefab_LargeRoom;
													
							if (room.Bounds.width == 1 && room.Bounds.height == 2)					
								roomPrefab = this.m_prefab_LongRoom;						
						
							if (room.Bounds.width == 2 && room.Bounds.height == 1)					
							{
								roomPrefab = this.m_prefab_LongRoom;
								roomRot = Quaternion.Euler(0,90,0);
							}
						
							if (roomPrefab != null)
							{						
								GameObject
								newTile = (GameObject)Instantiate(roomPrefab, roomPos, roomRot); 
								newTile.transform.parent = this.transform;
								b_atLeastOneRoom = true;
							
								foreach (Vector2 roomCell in room.CellLocations)
								{
									Vector2 roomCellLocation = new Vector2(room.Bounds.x + roomCell.x, room.Bounds.y + roomCell.y);
									Vector3 roomCellRealPos =  new Vector3(roomCellLocation.x * 10, 0, roomCellLocation.y * 10);
									
									if (dG.Dungeon[roomCellLocation].NorthSide == csDungeonCell.SideType.Door)
										CreateDoor(dG, roomCellRealPos, enCellDirection.North);
								
									if (dG.Dungeon[roomCellLocation].SouthSide == csDungeonCell.SideType.Door)
										CreateDoor(dG, roomCellRealPos, enCellDirection.South);
								
									if (dG.Dungeon[roomCellLocation].EastSide == csDungeonCell.SideType.Door)
										CreateDoor(dG, roomCellRealPos, enCellDirection.East);
								
									if (dG.Dungeon[roomCellLocation].WestSide == csDungeonCell.SideType.Door)
										CreateDoor(dG, roomCellRealPos, enCellDirection.West);
								
									if (dG.Dungeon[roomCellLocation].NorthSide == csDungeonCell.SideType.Wall)
										BlockExit(roomCellRealPos, enCellDirection.North);
								
									if (dG.Dungeon[roomCellLocation].SouthSide == csDungeonCell.SideType.Wall)
										BlockExit(roomCellRealPos, enCellDirection.South);
								
									if (dG.Dungeon[roomCellLocation].EastSide == csDungeonCell.SideType.Wall)
										BlockExit(roomCellRealPos, enCellDirection.East);
								
									if (dG.Dungeon[roomCellLocation].WestSide == csDungeonCell.SideType.Wall)
										BlockExit(roomCellRealPos, enCellDirection.West);								
															
								}
							
								// Add Decorator Cell Data
								if (dD != null)
								{					
									coDungeonDecorator.enCellType dCellType = coDungeonDecorator.enCellType.None;
								
									if (roomPrefab == this.m_prefab_LargeRoom) dCellType = coDungeonDecorator.enCellType.RoomLarge;
									if (roomPrefab == this.m_prefab_LongRoom)  dCellType = coDungeonDecorator.enCellType.RoomLong;
								
									coDungeonDecorator.stDecoratorCell dCell 
										= new coDungeonDecorator.stDecoratorCell
											(dCellType, roomPos, roomRot);
								
									dD.Cells.Add(dCell);	
								}		
							}
						}
					}
				}
			
				if (!b_entrancePlaced) return false;
				if (!b_exitPlaced) 	   return false;
				if (!b_atLeastOneRoom) return false;
			
				return true;
			}
		
			return false;		
		}	
	
		private bool IsSmallRoom(coDungeonGenerator dG, Vector3 pos)
		{
			foreach (csDungeonRoom room in dG.Dungeon.Rooms)
			{			
				Vector3 roomPos = new Vector3(room.Bounds.x * 10, 0, room.Bounds.y * 10);
			
				if (roomPos == pos) 
				{	
					if (room.Bounds.width == 1 && room.Bounds.height == 1) return true;
				}
			}
		
			return false;
		}		
	
		private bool IsBigRoom(coDungeonGenerator dG, Vector2 pos)
		{	
			foreach (csDungeonRoom room in dG.Dungeon.Rooms)
			{	
				if (room.Bounds.width != 1 || room.Bounds.height != 1)					
				{			
					if (room.Bounds.Contains(pos))
						return true;					
				}
			}					
		
			return false;
		}	
		
		private void CreateDoor(coDungeonGenerator dG, Vector3 pos, enCellDirection dir)
		{
			Vector3    offSet   = Vector3.zero;
			Quaternion rotation = Quaternion.identity;
		
			foreach (Transform t in transform)
			{
				if (t.position == pos && t.tag == "DOOR")
					return;			
			}
		
			Vector2 realPos = new Vector2(pos.x / 10, pos.z / 10);
		
			switch (dir)
			{
				case enCellDirection.South:
					offSet = Vector3.forward * 4.35f;
					rotation = Quaternion.Euler(0,0,0);
					break;
				case enCellDirection.East:
					offSet = Vector3.right * 4.35f;
					rotation = Quaternion.Euler(0,90,0);	
					if (IsSmallRoom(dG, pos 	+ Vector3.right * 10)) return;
					if (IsBigRoom  (dG, realPos + Vector2.right     )) return;				
					break;
				case enCellDirection.North:
					offSet = Vector3.forward * -4.35f;
					rotation = Quaternion.Euler(0,180,0);
				if (IsSmallRoom(dG, pos     + Vector3.forward * -10)) return;
				if (IsBigRoom  (dG, realPos + Vector2.up      *-1  )) return;				
					break;			
				case enCellDirection.West:
					offSet = Vector3.right * -4.35f;
					rotation = Quaternion.Euler(0,270,0);
					break;			
			}		
		
			GameObject
			dW = (GameObject)Instantiate((Random.Range(0.0f, 1.0f)>0.5f) ? this.m_prefab_DoorWood : this.m_prefab_DoorGate, pos + offSet, rotation);			
			dW.transform.parent = this.transform;	
			try
			{
				dW.tag = "DOOR";
			}
			catch
			{
				Debug.LogWarning("DOOR Tag not defined.  This may cause doors to be placed incorrectly.  Please add a tag to your project called DOOR.");
			}
		}		
		
		private void BlockExit(Vector3 pos, enCellDirection dir)
		{
			Vector3    offSet   = Vector3.zero;
			Quaternion rotation = Quaternion.identity;
		
			foreach (Transform t in transform)
			{
				if (t.position == pos && t.tag == "DOOR")
					return;			
			}
		
			switch (dir)
			{
				case enCellDirection.South:
					offSet = Vector3.forward * 4.5f;
					rotation = Quaternion.Euler(0,0,0);
					break;
				case enCellDirection.East:
					offSet = Vector3.right * 4.5f;
					rotation = Quaternion.Euler(0,90,0);
					break;
				case enCellDirection.North:
					offSet = Vector3.forward * -4.5f;
					rotation = Quaternion.Euler(0,180,0);
					break;			
				case enCellDirection.West:
					offSet = Vector3.right * -4.5f;
					rotation = Quaternion.Euler(0,270,0);
					break;			
			}		
		
			GameObject
			dW = (GameObject)Instantiate(this.m_prefab_DoorStone, pos + offSet + new Vector3(0.0f, 1.95f, 0.05f), rotation);			
			dW.transform.parent = this.transform;	
			try
			{
				dW.tag = "DOOR";
			}
			catch
			{
				Debug.LogWarning("DOOR Tag not defined.  This may cause doors to be placed incorrectly.  Please add a tag to your project called DOOR.");
			}
		}	
	
		private string BuildTileTextIcon(enCellState cellState)
		{	
			string returnVal = "";
		
			if ( (cellState & enCellState.SouthWall) == enCellState.SouthWall)
				returnVal = returnVal + "-W-";
			if ( (cellState & enCellState.SouthDoor) == enCellState.SouthDoor)
				returnVal = returnVal + "-D-";
			if ( (cellState & enCellState.SouthEmpty) == enCellState.SouthEmpty)
				returnVal = returnVal + "-O-";
		
			returnVal = returnVal + "\r\n";
		
			if ( (cellState & enCellState.WestWall) == enCellState.WestWall)
				returnVal = returnVal + "W-";
			if ( (cellState & enCellState.WestDoor) == enCellState.WestDoor)
				returnVal = returnVal + "D-";
			if ( (cellState & enCellState.WestEmpty) == enCellState.WestEmpty)
				returnVal = returnVal + "O-";
		
			if ( (cellState & enCellState.EastWall) == enCellState.EastWall)
				returnVal = returnVal + "W";
			if ( (cellState & enCellState.EastDoor) == enCellState.EastDoor)
				returnVal = returnVal + "D";
			if ( (cellState & enCellState.EastEmpty) == enCellState.EastEmpty)
				returnVal = returnVal + "O";
		
			returnVal = returnVal + "\r\n";
		
			if ( (cellState & enCellState.NorthWall) == enCellState.NorthWall)
				returnVal = returnVal + "-W-";
			if ( (cellState & enCellState.NorthDoor) == enCellState.NorthDoor)
				returnVal = returnVal + "-D-";
			if ( (cellState & enCellState.NorthEmpty) == enCellState.NorthEmpty)
				returnVal = returnVal + "-O-";		
		
		
			return returnVal;	
		}
	
	#endregion
}

#endif