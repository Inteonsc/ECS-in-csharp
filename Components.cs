
using SFML.Graphics;
//Components to use in ECS. These are usually inside the entities and hold all of the data.
namespace ECS {

    public class Component{
        
    }

    public class Health : Component{
        public int hp;
        
        public Health(int HP){
            hp = HP;
            
        }
        
    }

    public class PhysicalProps : Component{
        
        public float x;
        public float y;

        public float sizeX;
        public float sizeY;

        public PhysicalProps(float inputx, float inputy, float inputSX, float inputSY){
            x = inputx;
            y = inputy;
            sizeX = inputSX;
            sizeY = inputSY;
        }

        public void SetPos(float X, float Y){
            x = X;
            y = Y;
        }
        
        
    }


    public class ColorComponent : Component{
        public Color objectColor;

        public ColorComponent(Color col){
            objectColor = col;
        }

    }
    
    public class Food : Component{

    }

    // doesn't need any values yet. just by having a player controlled component shows
    // that its player controlled. no need for bool.
    public class PlayerControlled : Component{
        

        public PlayerControlled(){

        }

    }

    public class UIObject : Component{
        public bool active;
        
        //When to Draw. 0 = while playing game, 1 = pause menu. Should make this an enum
        public int scene;
        //decides which hoverover, click animations to play.
        public int animType;

        

    }



    public class UIImage : UIObject{


        public Texture texture;
        public Color col;
        public UIImage(bool Active, Texture tex, int Scene, Color color, int AnimType){
            active = Active;
            texture = tex;
            scene = Scene;
            col = color;
            animType = AnimType;
        }
    }

    public class UIText : UIObject{


        public Text text;
        public UIText(bool Active, Text tex, int AnimType, int Scene){
            active = Active;
            text = tex;
            scene = Scene;
            animType = AnimType;
        }
    }


    
}