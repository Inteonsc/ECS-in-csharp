using ECS;
using System.Collections.Generic;
using RectangleEaterClone;
using System.Linq;
using System;

using SFML.Graphics;
using SFML.System;
using SFML.Window;

//Update so that it gets all the enties from the world, 1 foreach and then seperate them. Remove entsToDraw and UIEnts
namespace systems {

    public partial class SystemsContainer{
        
        public void Update(List<Entity> entToUpdate,List<Entity> uiEntToUpdate, Time deltaTime, RenderWindow app){
            Entity PC = null;
            //get player character
            foreach (Entity ent in World.entityList){
                
                    if(ent.componentsList.OfType<PlayerControlled>().Any()){
                        PC = ent;
                    }
            }

            
            foreach (Entity ent in uiEntToUpdate){
                if(ent.componentsList.OfType<UIImage>().Any()){
                    UIImage UIComponent = ent.componentsList.OfType<UIImage>().First();
                    PhysicalProps physComponent = ent.componentsList.OfType<PhysicalProps>().First();
                    if (UIComponent.animType == 1 && UIComponent.active){
                        //ent.sprite.Scale = new SFML.System.Vector2f(physComponent.sizeX / ent.sprite.Texture.Size.X, physComponent.sizeY / ent.sprite.Texture.Size.Y);
                        //hover over
                        if(ent.sprite.GetGlobalBounds().Contains(Mouse.GetPosition(app).X, Mouse.GetPosition(app).Y)){
                            UIComponent.col = new Color(255,255,255,140);

                            //code to move object out
                            
                            if(ent.sprite.Position.X > physComponent.x - 60)
                                ent.sprite.Position += new Vector2f(-450 * deltaTime.AsSeconds(),0);
                                if(Mouse.IsButtonPressed(Mouse.Button.Left)){
                                    Game.setPauseState(false);
                                    app.SetMouseCursorVisible(false);
                                    Game.uiScene = 0;
                                    Game.uiUpdate = 0;
                                }
                        }
                        else{
                            UIComponent.col = Color.White;
                            
                            if(ent.sprite.Position.X < physComponent.x  )
                                ent.sprite.Position += new Vector2f(450 * deltaTime.AsSeconds(),0);
                        }

                    }
                }
            }
            //first check that there is a PC to compare to.
            if(PC != null){
                //check if it has HP component and then compare it to player to see whether bigger or not.
                foreach (Entity ent in entToUpdate){
                    if(ent.componentsList.OfType<Health>().Any() && ent.componentsList.OfType<ColorComponent>().Any()){
                        Health PCHealth = PC.componentsList.OfType<Health>().First();
                        Health EntHealth = ent.componentsList.OfType<Health>().First();
                        if(PCHealth.hp > EntHealth.hp){
                            ent.componentsList.OfType<ColorComponent>().First().objectColor = Color.Blue;
                        }else{
                            ent.componentsList.OfType<ColorComponent>().First().objectColor = Color.Red;
                        }

                    }
                }


            }else{
                Console.WriteLine("Update 61, NO PC FOUND");
            }
            
        }



    }

}