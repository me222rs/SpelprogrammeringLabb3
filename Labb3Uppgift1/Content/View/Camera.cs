using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3Uppgift1.Content.View
{
    class Camera
    {
        private int width;
        private int height;
        private float scale;
        private int levelWidth;
        private int levelHeight;
        private int frame;
        private static int borderIndent = 10;

        public Camera(int width, int heigth)
        {
            int scaleX = (width - borderIndent * 2);
            int scaleY = (heigth - borderIndent * 2);

            scale = scaleX;
            if (scaleY < scaleX)
            {
                scale = scaleY;
            }
        }
        public Camera(int frame)
        {
            this.frame = frame;
            //this.levelWidth = levelWidth;
            //this.levelHeight = levelHeight;
        }

        public float Scale
        {
            get { return scale; }
        }

        public Vector2 scaleVector(float xPos, float yPos)
        {
            float X = (xPos * scale);
            float Y = (yPos * scale);

            return new Vector2(X, Y);
        }

        //Metod som sköter skalningen
        public void setDimensions(int width, int height)
        {
            this.width = width;
            this.height = height;

            int scaleX = (width - frame * 2);
            int scaleY = (height - frame * 2);

            scale = scaleX;
            if (scaleY < scaleX)
            {
                scale = scaleY;
            }
        }

        //public void SetFrame(int size)
        //{
        //    frame = size;
        //}

        public int GetFrame() {
            return frame;
        }

        public float getScale()
        {
            return scale;
        }

        public Rectangle Splitter(float x, float y, float radius)
        {
            int vSize = (int)(radius * scale);

            int vx = (int)(x * scale);
            int vy = (int)(y * scale);

            return new Rectangle(vx, vy, vSize, vSize);
        }





        //Uppgift 1-3 av laboration 1
        /*
        int sizeOfTile = 64;
        int borderSize = 64;
        int levelWidth = 8;
        int levelHeight = 8;
        int frame = 64;
        float scale;
        Vector2 vec;



        //Skalar om skärmstorleken. width = 320 & height = 240
        public void Scale(int width, int height) {

            int scaleX = (width - frame * 2) / levelWidth;
            int scaleY = (height - frame * 2) / levelHeight;

            scale = scaleX;
            if (scaleY < scaleX)
            {
                scale = scaleY;
            }

        }
        //Hämtar skalan
        public float getScale()
        {
            return scale;
        }

        // Omvandlar logiska koordinater till visuella koordinater
        public Vector2 GetVisualCoordinates(Vector2 logical){

            float visualX = borderSize + logical.X * sizeOfTile;
            float visualY = borderSize + logical.Y * sizeOfTile;
            return new Vector2(visualX, visualY);

        }
        // Omvandlar omvända logiska koordinater och returnerar visuella koordinater
        public Vector2 GetVisualRotatedCoordinates(Vector2 logical) {
            const int maxXCoordinate = 7;
            const int maxYCoordinate = 7;
            float reversedCoordinateX;
            float reversedCoordinateY;

            reversedCoordinateX = maxXCoordinate - logical.X;
            reversedCoordinateY = maxYCoordinate - logical.Y;

            
            float visualX = borderSize + reversedCoordinateX * sizeOfTile;
            float visualY = borderSize + reversedCoordinateY * sizeOfTile;
            return new Vector2(visualX, visualY);
        }

        */
        //0,0	=   7,7     =   512,512
        //6,0	=   1,7     =   128,512
        //2,7	=   5,0     =   384,64
        //7,7   =   0,0     =   64,64

    }
}
