using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace HexaTest.GameStateManagement
{
    class GameState : IGameState
    {
        private Game1 parent = null;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D cursorTexture;
        private Vector2 cursorPosition;
        private Effect effectTest;

        private Playfield.Playfield playfield;

        private KeyboardState keyState;

        public GameState(Game1 parent)
        {
            this.parent = parent;
            graphics = new GraphicsDeviceManager(parent);
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            parent.Window.Title = "Hexa";
        }

        public void Initialize()
        {
            spriteBatch = new SpriteBatch(parent.GraphicsDevice);
            effectTest = parent.Content.Load<Effect>(@"pixelshaders\AlphaMap");
            cursorTexture = parent.Content.Load<Texture2D>(@"cursor\cursor_normal");
            // TODO: use this.Content to load your game content here

            playfield = new HexaTest.Playfield.Playfield(5, 11, parent.Content);
            //hexafield.setUniTextureTest(cursorFrame);
        }

        public EGameState Update(GameTime gameTime)
        {
            keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.F5))
            {
                playfield = new HexaTest.Playfield.Playfield(5, 11, parent.Content);
            }
            cursorPosition.X = Mouse.GetState().X;
            cursorPosition.Y = Mouse.GetState().Y;

            return EGameState.Game;
        }

        public void Draw(GameTime gameTime)
        {
            if (effectTest.IsDisposed)
            {
                Console.Write("ok?");
            }

            effectTest.CurrentTechnique = effectTest.Techniques["Vicky"];


            spriteBatch.Begin(SpriteSortMode.Immediate,BlendState.NonPremultiplied);
			
            //effectTest.CurrentTechnique.Passes["P0"].Apply();
			playfield.Draw(spriteBatch);            
            
            spriteBatch.Draw(cursorTexture, cursorPosition, Color.White);
            spriteBatch.End();
        }

        public void Unload()
        {

        }

        public void Dispose()
        {

        }
    }
}
