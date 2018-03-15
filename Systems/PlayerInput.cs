using ECS;
using SFML.Window;
using SFML.System;
using SFML.Graphics;
using System.Linq;

namespace systems {

    public partial class SystemsContainer{
        
        //delta time is time since last frame. worked out in Game.cs.
        public void PlayerControl(Entity ent, Time deltaTime, RenderWindow app){
            
            
            float tmpX = ent.componentsList.OfType<PhysicalProps>().First().x;
            float tmpY = ent.componentsList.OfType<PhysicalProps>().First().y;

            /* Old Keyboard controls. This is here incase i want to add keyboard controls.
            if(Keyboard.IsKeyPressed(Keyboard.Key.W)){
                tmpY -= 20 * deltaTime.AsSeconds();
            }
            if(Keyboard.IsKeyPressed(Keyboard.Key.A)){
                tmpX -= 20 * deltaTime.AsSeconds();
            }
            if(Keyboard.IsKeyPressed(Keyboard.Key.S)){
                tmpY += 20 * deltaTime.AsSeconds();
            }
            if(Keyboard.IsKeyPressed(Keyboard.Key.D)){
                tmpX += 20 * deltaTime.AsSeconds();
                
            }

            */
            //mouse control
            Vector2i mousePos = Mouse.GetPosition(app);
            //center mouse. 20 is the current width/height of all objects.
            tmpX = mousePos.X - 10;
            tmpY = mousePos.Y - 10;

            ent.componentsList.OfType<PhysicalProps>().First().SetPos(tmpX,tmpY);

        }


    }


}