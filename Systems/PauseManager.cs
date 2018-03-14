using ECS;
using System.Collections.Generic;
using RectangleEaterClone;

using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace systems {

    public partial class SystemsContainer{

        Clock pauseTimer = new Clock();

        public void PauseManager( RenderWindow app){
            
                
                if(Keyboard.IsKeyPressed(Keyboard.Key.Escape) && pauseTimer.ElapsedTime > Time.FromSeconds(0.3f)){
                    Game.setPauseState(!Game.getPauseState());
                    if(Game.getPauseState()){
                        app.SetMouseCursorVisible(true);
                    }else{
                        app.SetMouseCursorVisible(false);
                    }
                    pauseTimer.Restart();
                }
        }



    }

}