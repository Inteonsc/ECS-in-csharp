using ECS;
using System.Collections.Generic;
using System.Linq;
using SFML.Graphics;

namespace systems {

    public partial class SystemsContainer{

        public void Render(List<Entity> entsToDraw, RenderWindow app){


            
            foreach(Entity ent in entsToDraw){
                Position posComponent = ent.componentsList.OfType<Position>().First();
                
                ColorComponent colourComponent = ent.componentsList.OfType<ColorComponent>().First();

                RectangleShape shape = new RectangleShape();

                shape.FillColor = colourComponent.objectColor;
                shape.Position = new SFML.System.Vector2f(posComponent.x, posComponent.y);
                shape.Size = new SFML.System.Vector2f(20, 20);
                
                app.Draw(shape);
                
            }

        }
    }
}