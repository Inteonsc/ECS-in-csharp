
using ECS;
using System.Collections.Generic;
using System.Linq;
using SFML.Graphics;

namespace RectangleEaterClone {

    public static class Game{

           static systems.SystemsContainer SysContainer = new systems.SystemsContainer();

            public static void render(RenderWindow app){
                List<ECS.Entity> entToDraw = new List<Entity>();
                foreach(Entity entities in ECS.World.entityList){
                        if(entities.componentsList.OfType<ColorComponent>().Any() && entities.componentsList.OfType<Position>().Any() ){
                            entToDraw.Add(entities);
                        }
                }
                SysContainer.Render(entToDraw, app);

            }

    }




}
