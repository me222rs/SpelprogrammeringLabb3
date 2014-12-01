using Labb3Uppgift1.Content.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3Uppgift1.Content.View
{
    //Instans av kamera och ritar ut bollen
    class BallView : Game
    {
       
        private SpriteBatch spriteBatch;
        private Texture2D ballTexture;
        private int windowHeight;
        private int windowWidth;
        private Camera camera;
        private float rotation = 3.14f / 2.0f;
        
        //Metod som läser in texturer som tillhör bollen
        public BallView(GraphicsDevice graphicsDevice, ContentManager content, int frame)
        {
            //Hämtar ut bredd och höjd på fönstret
            windowWidth = graphicsDevice.Viewport.Width;
            windowHeight = graphicsDevice.Viewport.Height;

            
            camera = new Camera(frame);
            camera.setDimensions(windowWidth, windowHeight);
            spriteBatch = new SpriteBatch(graphicsDevice);
 
            ballTexture = content.Load<Texture2D>("Ball");
 
        }
        //Metod som ritar ut banan
        internal void DrawLevel(Texture2D backgroundTexture, Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor, Texture2D pixel) {


            spriteBatch.Begin();
            // Ritar ut bakgrundsbilden           
            spriteBatch.Draw(backgroundTexture,
                new Rectangle(0, 0,
                windowWidth, windowHeight), null,
                Color.White, 0, Vector2.Zero,
                SpriteEffects.None, 0);

            int frameY = 0;
            int frameX = 0;

            if(rectangleToDraw.Height > rectangleToDraw.Width){
                frameX = rectangleToDraw.Height - rectangleToDraw.Width;
            }
            if (rectangleToDraw.Width > rectangleToDraw.Height) {
                frameY = rectangleToDraw.Width - rectangleToDraw.Height;
            }


            //camera.setDimensions(rectangleToDraw.Width, rectangleToDraw.Height);

            //Hittade en tutorial för att rita ut en ram här: http://bluelinegamestudios.com/posts/drawing-a-hollow-rectangle-border-in-xna-4-0/
            //Använde mig utav koden i länken ovan och lade till lite så att den fungerade som jag ville.
            
            // Rita översta linjen
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);

            // Rita vänstra linjen
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);

            // Rita högra linjen
            spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder - frameY),
                                            rectangleToDraw.Y,
                                            thicknessOfBorder + frameY,
                                            rectangleToDraw.Height), borderColor);
            // Rita botten linjen
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X,
                                            rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder - frameX,
                                            rectangleToDraw.Width,
                                            thicknessOfBorder + frameX), borderColor);




            spriteBatch.End();
        }


        //Metod som ritar ut bollen
        internal void DrawBall(BallSimulation ballSimulation) {
            //int size = windowWidth / 10;

            Ball ball = new Ball();
            int vx = (int)(ballSimulation.getXPosition() * camera.getScale() + camera.GetFrame());
            int vy = (int)(ballSimulation.getYPosition() * camera.getScale() + camera.GetFrame());

            int size = (int)(ball.diameter * camera.getScale());

            rotation += 0.01f;
            Rectangle destrect = new Rectangle(vx - size/2, vy - size/2, size, size);
            Rectangle srcRect = new Rectangle(0,0, ballTexture.Width, ballTexture.Height);

            Vector2 origin = new Vector2(187 / 2, 226/2);
            spriteBatch.Begin();
            spriteBatch.Draw(ballTexture, destrect, Color.White);
            //spriteBatch.Draw(ballTexture, destrect, srcRect, Color.White, rotation, origin, SpriteEffects.None, 0);
            //spriteBatch.Draw(ballTexture, new Vector2(vx, vy), srcRect, Color.White, rotation, origin, new Vector2(size / (float)ballTexture.Width, size / (float)ballTexture.Height), SpriteEffects.None, 0);
            spriteBatch.End();
        }
    }
}
