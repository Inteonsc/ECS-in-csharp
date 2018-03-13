using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

using SFML;
using SFML.Graphics;
using SFML.Window;

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
                AppSettings.windowColor = Color.Red;
                //Should probably add pause code.
            }

            static void OnGainFocus(object sender, EventArgs e){
                //good blue
                AppSettings.windowColor = new Color(0, 192, 255);
                //Should probably add resume code.
            }

            static void Main() {
                // Create the main window
                RenderWindow app = new RenderWindow(new VideoMode(800, 600), "SFML Works!", Styles.None);
                
                
                app.Closed += new EventHandler(OnClose);
                app.LostFocus += new EventHandler(OnLostFocus);
                app.GainedFocus += new EventHandler(OnGainFocus);
                AppSettings.windowColor = new Color(0, 192, 255);

                
                //create some test objects;
                //create the entity and components
                Entity temp1 = new Entity();
                Entity temp2 = new Entity();
                ColorComponent EntColor1 = new ColorComponent(Color.Red);
                Position EntPos1 = new Position(50,50);
                ColorComponent EntColor2 = new ColorComponent(Color.Green);
                Position EntPos2 = new Position(200,200);


                //add the components
                temp1.componentsList.Add(EntPos1);
                temp1.componentsList.Add(EntColor1);
                //Spawn the entity
                World.AddEntity(temp1);

                //add the components
                temp2.componentsList.Add(EntPos2);
                temp2.componentsList.Add(EntColor2);
                //Spawn the entity
                
                World.AddEntity(temp2);



                // Start the game loop
                while (app.IsOpen) {
                    // Process events
                    app.DispatchEvents();
                    
                    // Clear screen
                    app.Clear(AppSettings.windowColor);
                    Game.render(app);
                    // Update the window
                    app.Display();
                } //End game loop
            } //End Main()
        } //End Program


        static class AppSettings{
            public static Color windowColor;

        }

    }
