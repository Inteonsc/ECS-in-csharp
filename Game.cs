
using ECS;
using System.Collections.Generic;
using System.Linq;
using SFML.Graphics;
using SFML.System;

namespace RectangleEaterClone {

    public static class Game{

           static systems.SystemsContainer sysContainer = new systems.SystemsContainer();
           static Entity playerEnt;
           static Clock deltaTime;

           static RenderWindow app;

            
            //runs at the start of the game. Makes starting object.
            public static void Start(RenderWindow appwindow){
                app = appwindow;
                Entity playerEnt = new Entity();
                World.AddEntity(playerEnt);
                playerEnt.componentsList.Add(new Position((int)app.Size.X /2,(int) app.Size.Y / 2));
                playerEnt.componentsList.Add(new PlayerControlled());
                playerEnt.componentsList.Add(new ColorComponent(Color.Green));


                deltaTime.Restart();

            }
            //render function. Happens every frame. Handles everything to do with drawing to the screen.
            public static void render(RenderWindow app){

                //temporary list of entities to draw.
                List<ECS.Entity> entToDraw = new List<Entity>();
                //filter all entities to only ones which can be drawn. can expand later to only
                //ones on the screen. for optimiziation
                foreach(Entity entities in ECS.World.entityList){
                        if(entities.componentsList.OfType<ColorComponent>().Any() && entities.componentsList.OfType<Position>().Any() ){
                            entToDraw.Add(entities);
                        }
                }
                sysContainer.Render(entToDraw, app);

            }
                //this contains all the logic that happens. 
                //maybe multithread and make it run independently of render.
            public static void update(RenderWindow app){
                
                sysContainer.PlayerControl(playerEnt, deltaTime.Restart());
            }

    }




}
