using ECS;
using SFML.Window;
using SFML.System;
using System.Linq;

namespace systems {

    public partial class SystemsContainer{
        
        //delta time is time since last frame. worked out in Game.cs.
        public void PlayerControl(Entity ent, Time deltaTime){
            int tmpX = 0;
            int tmpY = 0;
            if(Keyboard.IsKeyPressed(Keyboard.Key.W)){
                tmpY += 5 * deltaTime.AsMilliseconds();
            }
            if(Keyboard.IsKeyPressed(Keyboard.Key.A)){
                tmpX -= 5 * deltaTime.AsMilliseconds();
            }
            if(Keyboard.IsKeyPressed(Keyboard.Key.S)){
                tmpY -= 5 * deltaTime.AsMilliseconds();
            }
            if(Keyboard.IsKeyPressed(Keyboard.Key.D)){
                tmpX += 5 * deltaTime.AsMilliseconds();
            }
            ent.componentsList.OfType<Position>().First().Set(tmpX,tmpY);

        }


    }


}