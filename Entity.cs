using System.Collections.Generic;
using SFML.Graphics;
namespace ECS {

    //add support for parent objects.
    public class Entity{
        public uint id;
        public List<Component> componentsList = new List<Component>();
        public Sprite sprite;
        public Entity(){
            id = World.AddEntity(this);
            
        }

    }









}