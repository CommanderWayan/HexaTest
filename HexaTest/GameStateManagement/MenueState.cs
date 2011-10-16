using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexaTest.GameStateManagement
{
    class MenueState : IGameState
    {
        public void Initialize()
        {
 
        }

        public EGameState Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            return EGameState.Menue;        
        }

        public void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
         
        }

        public void Unload()
        {
          
        }

        public void Dispose()
        {
           
        }
    }
}
