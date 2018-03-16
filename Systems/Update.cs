using ECS;
using System.Collections.Generic;
using RectangleEaterClone;
using System.Linq;

using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace systems {

    public partial class SystemsContainer{

        public void Update(List<Entity> entToUpdate,List<Entity> uiEntToUpdate, Time deltaTime, RenderWindow app){
            
            
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
                        }
                        else{
                            UIComponent.col = Color.White;
                            
                            if(ent.sprite.Position.X < physComponent.x  )
                                ent.sprite.Position += new Vector2f(450 * deltaTime.AsSeconds(),0);
                        }

                    }
                }
            }
            
        }



    }

}