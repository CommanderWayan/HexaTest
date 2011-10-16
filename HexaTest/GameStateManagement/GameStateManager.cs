using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace HexaTest.GameStateManagement
{
    public enum EGameState
    {
        Nothing = 0x00,
        Intro = 0x01,
        Menue = 0x02,
        Game = 0x03,
    }

    class GameStateManager
    {
        private EGameState gameState = EGameState.Nothing;
        private IntroState intro = null;
        private MenueState menue = null;
        private GameState game = null;
        private Game1 parent = null;

        public GameStateManager(Game1 parent)
        {
            this.intro = new IntroState();
            this.menue = new MenueState();
            this.game = new GameState(parent);
            this.parent = parent;
            gameState = EGameState.Nothing;
        }

        public IntroState Intro
        {
            get { return intro; }
        }

        public MenueState Menue
        {
            get { return menue; }
        }

        public GameState Game
        {
            get { return game; }
        }
        
        public EGameState GameState
        {
            get { return this.gameState; }
            set
            {
                //unload old content
                switch (gameState)
                {
                    case EGameState.Nothing:
                        break;
                    case EGameState.Intro:
                        this.intro.Unload();
                        break;
                    case EGameState.Menue:
                        this.menue.Unload();
                        break;
                    case EGameState.Game:
                        this.game.Unload();
                        break;
                }

                //load new content
                this.gameState = value;
                switch (this.gameState)
                {
                    case EGameState.Nothing:
                        //Quit Game!
                        break;
                    case EGameState.Intro:
                        this.intro.Initialize();
                        break;
                    case EGameState.Menue:
                        this.menue.Initialize();
                        break;
                    case EGameState.Game:
                        this.game.Initialize();
                        break;
                }
            }
        } 
    }
}
