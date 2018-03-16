using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using ECS;

namespace RectangleEaterClone {
        static class Program {
            static void OnClose(object sender, EventArgs e) {
                // Close the window when OnClose event is received
                RenderWindow window = (RenderWindow)sender;
                window.Close();
                
            }

            static void OnLostFocus(object sender, EventArgs e){
                //DEATH RED
                
                RenderWindow window = (RenderWindow)sender;
                window.SetMouseCursorVisible(true);
                Game.setPauseState(true);
                Game.uiScene = 1;
                Game.uiUpdate = 1;
                //Should probably add pause code.
            }






            static void Main() {
                // Create the main window
                RenderWindow app = new RenderWindow(new VideoMode(800, 600), "SFML Works!", Styles.None);
                
                
                app.Closed += new EventHandler(OnClose);
                app.LostFocus += new EventHandler(OnLostFocus);
                
                AppSettings.windowColor = new Color(0, 192, 255);
                app.SetKeyRepeatEnabled(false);
                app.SetMouseCursorVisible(false);
                app.Position = new Vector2i(200,200);
                Game.Start(app);
                
                

                //program loop. maybe move to game.
                Clock tickrateClock = new Clock();
                Time tickrate = Time.FromSeconds(1f / 120f);
                Time renderRate = Time.FromSeconds(1f / 70f);
                Time accumulatorLogic = Time.Zero;
                Time accumulatorRender = Time.Zero;
                // Start the game loop
                while (app.IsOpen) {
                    
                    
                    Thread.Sleep(4);
                    


                    if(accumulatorLogic > tickrate){
                        // Process events
                        app.DispatchEvents();
                        Game.update(app);
                        accumulatorLogic -= tickrate;
                    }

                    if(accumulatorRender > renderRate){
                        app.Clear(AppSettings.windowColor);
                        Game.render(app);
                        accumulatorRender -= renderRate;
                        // Update the window
                        app.Display();
                    }


                    
                    Time deltaTime = tickrateClock.Restart();
                    accumulatorLogic += deltaTime;
                    accumulatorRender += deltaTime;

                } //End game loop
            } //End Main()
        } //End Program


        static class AppSettings{
            public static Color windowColor;

        }

    }
