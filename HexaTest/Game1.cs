using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using HexaTest.Help;
using HexaTest.config;


namespace HexaTest
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D cursorTexture;
        Vector2 cursorPosition;      

        Playfield.Playfield playfield;
		Effect AlphaBlend;
		KeyboardState keyState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Config.checkAndCreate();
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "Hexa";			
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);            
            cursorTexture = this.Content.Load<Texture2D>(@"cursor\cursor_normal");
			AlphaBlend = Content.Load<Effect>(@"pixelshaders\AlphaBlend");
            playfield = new HexaTest.Playfield.Playfield(21, 31, this.Content);
            
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
			keyState = Keyboard.GetState();
			if(keyState.IsKeyDown(Keys.F5))
			{
				playfield = new HexaTest.Playfield.Playfield(21, 31, this.Content);
			}
            // TODO: Add your update logic here
            cursorPosition.X = Mouse.GetState().X;
            cursorPosition.Y = Mouse.GetState().Y;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
			
            GraphicsDevice.Clear(Color.Black);
			//spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);			
            //effectTest.CurrentTechnique.Passes["P0"].Apply();
			playfield.Draw(spriteBatch, AlphaBlend, GraphicsDevice);
			spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);					        
            spriteBatch.Draw(cursorTexture, cursorPosition, Color.White);
			spriteBatch.End();
            //spriteBatch.End();
            // TODO: Add your drawing code here
			;
            base.Draw(gameTime);
			
        }
    }
}
