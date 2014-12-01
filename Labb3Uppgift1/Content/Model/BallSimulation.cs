using Labb3Uppgift1.Content.View;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3Uppgift1.Content.Model
{
    //Ska innehålla förflyttning och kollision
    class BallSimulation
    {

        Ball ball = new Ball();
        //Camera camera;
        
        internal void Update(GameTime gameTime)
        {
            
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            ball.x += elapsedTime * ball.speedX;
            ball.y += elapsedTime * ball.speedY;
           
            


            //Följande metoder gör så att bollen studsar mot väggarna
            if (ball.x > 1.0f - ball.diameter / 2)
            {
                ball.speedX = ball.speedX * -1.0f;
                
            }

            if (ball.y > 1.0f - ball.diameter / 2)
            {
                ball.speedY = ball.speedY * -1.0f;
                
            }


            if (ball.x < 0.0f + ball.diameter / 2)
            {
                ball.speedX = ball.speedX * -1.0f;
               
            }

            if (ball.y < 0.0f + ball.diameter / 2)
            {
                ball.speedY = ball.speedY * -1.0f;
                
            }



        }

        //Returnerar bollens X position
        public float getXPosition() {
            return ball.x;
        }
        
        //Returnerar bollens Y position
        public float getYPosition()
        {
            return ball.y;
        }

    }
}
