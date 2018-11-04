using UnityEngine;
using System.Collections;

public class csRuntimeGenerator 
	: MonoBehaviour 
{

	private coDungeonGenerator        dungeonGenerator;
	private coDungeonImplementorDinky dungeonImplementor;
	private coDungeonDecoratorDinky   dungeonDecorator;

	void Start () 
	{	
		dungeonGenerator   = (coDungeonGenerator       )this.transform.GetComponent(typeof(coDungeonGenerator     ));
		dungeonImplementor = (coDungeonImplementorDinky)this.transform.GetComponent(typeof(coDungeonImplementor   ));
		dungeonDecorator   = (coDungeonDecoratorDinky  )this.transform.GetComponent(typeof(coDungeonDecoratorDinky));
	}	
	
	void Update () 
	{	
	}

	void OnGUI()
	{
		if (GUI.Button(new Rect(10,10,100,30), "Generate!"))
		{
			GenerateRuntimeDungeon();
		}
	}	

	public void GenerateRuntimeDungeon()
	{
		if (!dungeonGenerator  ) return;
		if (!dungeonImplementor) return;

		// These three lines show how, once you have a reference to the dungeon scripts, you can change parameters on the fly.
		dungeonGenerator.m_dungeonSize = coDungeonGenerator.enDungeonSize.Medium;
		dungeonGenerator.m_corridors   = coDungeonGenerator.enCorridors.  Dungeon;
		dungeonGenerator.m_roomSizeMAX = coDungeonGenerator.enRoomSize.   Large;
		
		dungeonGenerator.DestroyDungeon();					
	
		bool bDungonOK = false;
		int  retries = 0;
	
		int oldRoomCount = dungeonGenerator.RoomCount;
	
		while (!bDungonOK && retries < 25)
		{					
			dungeonGenerator.CreateDungeon();	
			
			bDungonOK = dungeonImplementor.ImplementDungeon();

			if (bDungonOK)
			{
				dungeonGenerator.RoomCount = oldRoomCount;
				if (dungeonDecorator) dungeonDecorator.DecorateDungeon();
			}
			else
			{
				dungeonGenerator.RoomCount--;
				retries++;				
			}					
		}
		
	
		if (!bDungonOK)
		{
			Debug.LogError("Tried 25 times to generate valid dungeon; gave up!");
		}
	}
}
