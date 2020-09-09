using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TaM
{
    class Level
    {
        public string name;
        public int width;
        public int height;
        private string data;

        public Level(string name, int width, int height, string data)
        {
            this.name = name;
            this.width = width;
            this.height = height;
            this.data = data;
        }

        public void DataReader(string data)
        {
            string[] dataArray = data.Split(' ');
            string Minotour = dataArray[0];
            string Theseus = dataArray[1];
            string Exit = dataArray[2];
           // iterate through the rest of the array using the strings to create new squares
            for(int i = 0; i < dataArray.Length - 3; i++)
            {
                Square sqaure = new Square(data);

            }
        }
    }
}
