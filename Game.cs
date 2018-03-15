
using ECS;
using System.Collections.Generic;
using System.Linq;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace RectangleEaterClone {

    public static class Game{

           static systems.SystemsContainer sysContainer = new systems.SystemsContainer();
           static Entity playerEnt;
           static Clock deltaTime = new Clock();

           static RenderWindow app;

           static  bool paused = false;

            
            //runs at the start of the game. Makes starting object.
            public static void Start(RenderWindow appwindow){
                app = appwindow;
                playerEnt = new Entity();
                World.AddEntity(playerEnt);
                playerEnt.componentsList.Add(new PhysicalProps((int)app.Size.X /2,(int) app.Size.Y / 2, 20, 20));
                playerEnt.componentsList.Add(new PlayerControlled());
                playerEnt.componentsList.Add(new ColorComponent(Color.Green));

                //create some test objects;
                //create the entity and components
                Entity temp1 = new Entity();
                Entity temp2 = new Entity();


                //add the components
                temp1.componentsList.Add(new PhysicalProps(50,50,20,20));
                temp1.componentsList.Add(new ColorComponent(Color.Red));
                //Spawn the entity
                World.AddEntity(temp1);

                //add the components
                temp2.componentsList.Add(new ColorComponent(Color.Green));
                temp2.componentsList.Add(new PhysicalProps(200,20,200,20));
                //Spawn the entity
                
                World.AddEntity(temp2);


                //pause menu entities

                Entity resumeButton = new Entity();
                resumeButton.componentsList.Add(new UIObject(false));

                resumeButton.componentsList.Add(new PhysicalProps((app.Size.X / 2), (app.Size.Y / 2) , 200,80));
                World.AddEntity(resumeButton);

                deltaTime.Restart();

            }
            //render function. Happens every frame. Handles everything to do with drawing to the screen.
            public static void render(RenderWindow app){

                //temporary list of entities to draw.
                List<ECS.Entity> entToDraw = new List<Entity>();
                //filter all entities to only ones which can be drawn. can expand later to only
                //ones on the screen. for optimiziation
                foreach(Entity entities in ECS.World.entityList){
                        if(entities.componentsList.OfType<ColorComponent>().Any() && entities.componentsList.OfType<PhysicalProps>().Any() ){
                            entToDraw.Add(entities);
                        }
                }
                sysContainer.Render(entToDraw, app);

            }
                //this contains all the logic that happens. 
                //maybe multithread and make it run independently of render.
            public static void update(RenderWindow app){
                Time dTimeLog = deltaTime.Restart();

                sysContainer.PauseManager(app);
                if(!Game.paused){
                    sysContainer.PlayerControl(playerEnt, dTimeLog, app);
                    sysContainer.Update(null, dTimeLog, app);
                }
            }

            // WARNING==========================================================================================================================================
            // Very big line of code incoming. Prepare yourself.
            public static void setPauseState(bool pause){
                paused = pause;
                if(pause == false){
                    //only pauses main screen.
                    Mouse.SetPosition(new Vector2i((int)playerEnt.componentsList.OfType<PhysicalProps>().First().x,(int) playerEnt.componentsList.OfType<PhysicalProps>().First().y), app);
                    
                }
            }

            public static bool getPauseState(){
                return paused;
            }

    }




}
