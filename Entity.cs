using System.Collections.Generic;

namespace ECS {


    class Entity{
        public uint id;
        public List<Component> componentsList = new List<Component>();
        
        public Entity(){
            id = World.AddEntity(this);
            
        }

    }









}