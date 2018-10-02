using ECS;
using RectangleEaterClone;

using System.Collections.Generic;
using System.Linq;

using SFML.Graphics;
using SFML.Window;
//Update so that it gets all the enties from the world, 1 foreach and then seperate them. Remove entsToDraw and UIEnts
namespace systems{

    public partial class SystemsContainer{

        //renders all objects and menus. Should seperate into different methods depending on what is being drawn.
        public void Render(List<Entity> entsToDraw, List<Entity> UIEntsToDraw, RenderWindow app){


            //draw game objects.
            foreach (Entity ent in entsToDraw){

                PhysicalProps physComponent = ent.componentsList.OfType<PhysicalProps>().First();

                ColorComponent colourComponent = ent.componentsList.OfType<ColorComponent>().First();

                RectangleShape shape = new RectangleShape();

                shape.FillColor = colourComponent.objectColor;
                shape.Position = new SFML.System.Vector2f(physComponent.x - (physComponent.sizeX / 2), physComponent.y - (physComponent.sizeY / 2));
                shape.Size = new SFML.System.Vector2f(physComponent.sizeX, physComponent.sizeY);

                app.Draw(shape);

            }
            //Pause Code.
            if (Game.getPauseState()){

                RectangleShape pauseShade = new RectangleShape();

                pauseShade.FillColor = new Color(0, 0, 0, 128);
                pauseShade.Position = new SFML.System.Vector2f(0, 0);
                pauseShade.Size = new SFML.System.Vector2f(app.Size.X, app.Size.Y);

                app.Draw(pauseShade);
            }
            if (UIEntsToDraw.Any()){

                //draw UI elements last.
                foreach (Entity ent in UIEntsToDraw){

                    if(ent.componentsList.OfType<UIImage>().Any()){
                    PhysicalProps physComponent = ent.componentsList.OfType<PhysicalProps>().First();
                    UIImage UIComponent = ent.componentsList.OfType<UIImage>().First();

                    

                    
                    ent.sprite.Texture = UIComponent.texture;

                    ent.sprite.Color = UIComponent.col;
                    

                    app.Draw(ent.sprite);
                    }
                    else if (ent.componentsList.OfType<UIText>().Any()){

                    }
                }
            }
        }
    }
}