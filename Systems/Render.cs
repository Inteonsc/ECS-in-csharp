using ECS;
using RectangleEaterClone;

using System.Collections.Generic;
using System.Linq;

using SFML.Graphics;

namespace systems {

    public partial class SystemsContainer{
        //renders all objects and menus. Should seperate into different methods depending on what is being drawn.
        public void Render(List<Entity> entsToDraw, RenderWindow app){


            //draw game objects.
            foreach(Entity ent in entsToDraw){
                Position posComponent = ent.componentsList.OfType<Position>().First();
                
                ColorComponent colourComponent = ent.componentsList.OfType<ColorComponent>().First();

                RectangleShape shape = new RectangleShape();

                shape.FillColor = colourComponent.objectColor;
                shape.Position = new SFML.System.Vector2f(posComponent.x, posComponent.y);
                shape.Size = new SFML.System.Vector2f(20, 20);
                
                app.Draw(shape);
                
            }
            //Pause Code.
            if(Game.getPauseState()){
                RectangleShape pauseShade = new RectangleShape();

                pauseShade.FillColor = new Color(0,0,0,128);
                pauseShade.Position = new SFML.System.Vector2f(0,0);
                pauseShade.Size = new SFML.System.Vector2f(app.Size.X,app.Size.Y);
                
                app.Draw(pauseShade);
            }

        }
    }
}