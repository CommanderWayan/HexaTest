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
        Texture2D cursorFrame;

        Texture2D cursorTexture;
        Vector2 cursorPosition;

        Playfield.Playfield hexafield;

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
			textureManager.TextureNet x = new textureManager.TextureNet(this.Content);
            base.Initialize();

            //textureManager.TextureManager texMan = new textureManager.TextureManager();
            //texMan.addTexture("wald");
            //texMan.addTexture("wiese");
            //texMan.addTexture("berg");
            //texMan.addTexture("steppe");
            //texMan.addTexture("strand");

            //texMan.addConnection("wald", "wiese");
            //texMan.addConnection("wiese", "wlad");
            //texMan.addConnection("wald", "wald");
            //texMan.addConnection("wiese", "wiese");
            //texMan.addConnection("berg", "berg");
            //texMan.addConnection("steppe", "steppe");
            //texMan.addConnection("strand", "strand");
            //texMan.addConnection("berg", "wiese");
            //texMan.addConnection("strand", "wiese");
            //texMan.addConnection("strand", "wald");

            //texMan.save("config/example.xml");

            //textureManager.TextureXMLWrapper xml = new textureManager.TextureXMLWrapper();
            //Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            //List<string> tmpList = new List<string>();
            //tmpList.Add("baum");
            //tmpList.Add("wiese");
            ////xml.texDef.Add(new textureManager.Texturedefintion("baum", tmpList));
            //dic.Add("baum", tmpList);
            //tmpList = new List<string>();
            //tmpList.Add("wasser");
            //tmpList.Add("strand"); 
            //tmpList.Add("kliff");
            ////xml.texDef.Add(new textureManager.Texturedefintion("strand", tmpList));
            //dic.Add("strand", tmpList);
            //tmpList = new List<string>();
            //tmpList.Add("wasser");
            //tmpList.Add("kliff");
            //tmpList.Add("wald");
            //tmpList.Add("berg");
            //dic.Add("berg", tmpList);
            ////xml.texDef.Add(new textureManager.TextureDefintion("baum", 0, 0, new int[] { 0, 0, 0, 0, 0, 0 }));
            ////xml.texDef.Add(new textureManager.TextureDefintion("wiese", 1, 1, new int[] { 1, 1, 1, 1, 1, 1 }));
            ////xml.texDef.Add(new textureManager.TextureDefintion("strand", 2, 2, new int[] { 2, 2, 2, 2, 2, 2 }));

            //xml.createFromDictionary(dic);

            //xml.exportXML("config/example.xml");
            //xml.importXML("config/example.xml");
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            cursorFrame = this.Content.Load<Texture2D>(@"ground\forest_green_plain");
            cursorTexture = this.Content.Load<Texture2D>(@"cursor\cursor_normal");
            // TODO: use this.Content to load your game content here

            hexafield = new HexaTest.Playfield.Playfield(11, 21);
            hexafield.setUniTextureTest(cursorFrame);
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            for (int y = 0; y <= hexafield._playfield.GetUpperBound(0); y++)
            {
                for (int x = 0; x <= hexafield._playfield.GetUpperBound(1); x++)
                {
                    spriteBatch.Draw(hexafield._playfield[y,x].getTexture, new Rectangle(hexafield._playfield[y,x].Origin.X, hexafield._playfield[y,x].Origin.Y,Helpers.HexFieldWidth, Helpers.HexFieldHeight),Color.White);
                }
            }            
            spriteBatch.Draw(cursorTexture, cursorPosition, Color.White);            
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
