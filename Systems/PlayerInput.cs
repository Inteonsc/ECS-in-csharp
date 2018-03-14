using ECS;
using SFML.Window;
using SFML.System;
using SFML.Graphics;
using System.Linq;

namespace systems {

    public partial class SystemsContainer{
        
        //delta time is time since last frame. worked out in Game.cs.
        public void PlayerControl(Entity ent, Time deltaTime, RenderWindow app){
            
            
            float tmpX = ent.componentsList.OfType<Position>().First().x;
            float tmpY = ent.componentsList.OfType<Position>().First().y;
            
            if(Keyboard.IsKeyPressed(Keyboard.Key.W)){
                tmpY += 20 * deltaTime.AsSeconds();
            }
            if(Keyboard.IsKeyPressed(Keyboard.Key.A)){
                tmpX -= 20 * deltaTime.AsSeconds();
            }
            if(Keyboard.IsKeyPressed(Keyboard.Key.S)){
                tmpY -= 20 * deltaTime.AsSeconds();
            }
            if(Keyboard.IsKeyPressed(Keyboard.Key.D)){
                tmpX += 20 * deltaTime.AsSeconds();
            }
            ent.componentsList.OfType<Position>().First().Set(tmpX,tmpY);

        }


    }


}