using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HexaTest.GameStateManagement
{
    public interface IGameState : IDisposable
    {
        void Initialize();
        EGameState Update(GameTime gameTime);
        void Draw(GameTime gameTime);
        void Unload();
    } 
}
