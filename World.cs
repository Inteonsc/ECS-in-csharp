using System.Collections.Generic;


namespace ECS {


    //This stores a list of entities and also how many entities there are.
    static class World{
       //this is used for new IDs
        static uint numofEntities = 0;

        static List<Entity> entityList = new List<Entity>();
        //This retrieves the number of entities
        public static uint GetNumofEntities(){
        
            return numofEntities;
        }

        //This is called by Entity when a new entity is created. This adds the entity to the list and also increments the number of entities.
        public static uint AddEntity(Entity ent){
            numofEntities++;
            entityList.Add(ent);
            return numofEntities;
        }

    }
}