using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TaM
{
	public class Game : ILevelHolder
	{
		public int LevelHeight { get; set; } 
		public int LevelWidth { get; set; }
		public string CurrentLevelName { get; set; }
		public int LevelCount { get; set; }
		private List<string> LevNames;
		private Level CurrentLevel;
		public int MoveCount;

        public Game()
		{
			this.LevelHeight = 0;
			this.LevelWidth = 0;
			this.CurrentLevelName = "No levels loaded";
			this.LevelCount = 0; 
			this.LevNames = new List<string>();
			this.MoveCount = 0;
		}
		public List<string> LevelNames()
		{
			return this.LevNames;
		}


        public void AddLevel(string name, int width, int height, string data)
        {
			this.CurrentLevelName = name;
			this.LevelWidth = width;
			this.LevelHeight = height;
			this.LevelCount += 1;
			this.LevNames.Add(name);
			Level Level = new Level(name, width, height, data);
			CurrentLevel = Level;
        }
		
		public Square WhatIsAt(int x, int y)
        {
			Square square = this.CurrentLevel.allMySquares[x, y];
			return square;

        }

		public void SetLevel(string name)
        {
			
			// check if name = LevNames
			// loop through each name in list
			foreach (string levelName in this.LevNames) {
				if (levelName == name)
                {
					this.CurrentLevelName = name;
				}
            }
        }

        public void MoveTheseus(Moves move)
        {
			//where is theseus  
			int[] theseus = CurrentLevel.GetTheseus();
			//what is the new square theseus is moving to
			//get current x y of theseus 
			//depending on direction plus or minus from the x y values
			int x = theseus[1];
			int y = theseus[0];
			bool canMove = false;
			Square origin = WhatIsAt(x, y);
			//can theseus move to that square
			//if wall is blocking theseus cannot move
			//else move theseus
			switch (move) 
			{
				case Moves.UP:
					if (!origin.Top)
					{
						y -= 1;
						canMove = true;
					}
					break;
				case Moves.DOWN:
					if (!origin.Bottom)
					{
						y += 1;
						canMove = true;
					}
					break;
				case Moves.LEFT:
					if (!origin.Left)
					{
						x -= 1;
						canMove = true;
					}
					break;
				case Moves.RIGHT:
					if (!origin.Right)
					{
						x += 1;
						canMove = true;
					}
					break;
			
            }
			//use what is at method to select new square for theseus 
			//add one to move count 
			if (canMove)
            {
				Square destination = WhatIsAt(y, x);
				CurrentLevel.theseus = new int[] { y, x };
				origin.Theseus = false;
				destination.Theseus = true;
				this.MoveCount++;
			}

		}



	}

}
