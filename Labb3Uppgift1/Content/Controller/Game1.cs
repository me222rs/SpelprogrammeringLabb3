#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Labb3Uppgift1.Content.View;
using Labb3Uppgift1.Content.Model;
using Labb3Uppgift1.Content;
#endregion

namespace Labb3Uppgift1.Content.Controller
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        BallView ballView;
        Texture2D pixel;
        //Ramens bredd är enkel att ändra ifall man vill
        private int frame = 10;
        SplitterSystem splitterSystem;
        Texture2D particleTexture;
        Texture2D explosionTexture;
        AnimateExplosion explosion;
        ShockWave shockwave;
        Viewport viewPort;
        Vector2 position;
        
        BallSimulation ballSimulation = new BallSimulation();
        Texture2D backgroundTexture;
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //Hårdkodad storlek på skärmen, ändra här för att ändra storlek

            // Storlekar på boll och ram skalar om utan problem, men går man över 720*720 så kommer det inte bli lika snyggt pga. att bilden inte är så stor
            graphics.PreferredBackBufferWidth = 512;
            graphics.PreferredBackBufferHeight = 512;

            
        }
        

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            position.X = 0.5f;
            position.Y = 0.5f;
            splitterSystem = new SplitterSystem(GraphicsDevice.Viewport, position);
            shockwave = new ShockWave(GraphicsDevice.Viewport, position, Content);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //Källa för de två kodraderna under: http://bluelinegamestudios.com/posts/drawing-a-hollow-rectangle-border-in-xna-4-0/
            // Create a new SpriteBatch, which can be used to draw textures.
            pixel = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });

            //Här kan man sätta en valfri bakgrundsbild
            backgroundTexture = Content.Load<Texture2D>("Shore");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ballView = new BallView(GraphicsDevice, Content, frame);
            particleTexture = Content.Load<Texture2D>("splitter");
            explosionTexture = Content.Load<Texture2D>("explosion");

            explosion = new AnimateExplosion(explosionTexture, GraphicsDevice.Viewport);
           
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            ballSimulation.Update(gameTime);
            splitterSystem.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Rectangle titleSafeRectangle = GraphicsDevice.Viewport.TitleSafeArea;       
            //Ritar ut bakgrundsbild och en ram omkring den innan jag ritar ut bollen
            ballView.DrawLevel(backgroundTexture, titleSafeRectangle, frame, Color.Black, pixel);
            // Här ritas bollen ut ovanpå bakgrunden
            ballView.DrawBall(ballSimulation);
            shockwave.Draw(spriteBatch, (float)gameTime.ElapsedGameTime.TotalSeconds);
            splitterSystem.Draw(spriteBatch, particleTexture);
            explosion.Draw(spriteBatch, (float)gameTime.ElapsedGameTime.TotalSeconds);
    
            
            base.Draw(gameTime);
        }
    }
}
