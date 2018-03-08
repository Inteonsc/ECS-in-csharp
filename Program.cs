using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

                //Tests the entity ID system.
                Entity[] entarr = new Entity[50];

                for(int i = 0; i<entarr.Length;i++){
                    entarr[i] = new Entity();

                    Console.WriteLine(entarr[i].id);
                }
                entarr[20].componentsList.Add(new ECS.Health(10));

               Health test = entarr[20].componentsList.OfType<Health>().FirstOrDefault();

               Console.WriteLine("hp is:" + test.hp);




                // Start the game loop
                while (app.IsOpen) {
                    // Process events
                    app.DispatchEvents();
                    
                    // Clear screen
                    app.Clear(AppSettings.windowColor);

                    // Update the window
                    app.Display();
                } //End game loop
            } //End Main()
        } //End Program


        static class AppSettings{
            public static Color windowColor;

        }

    }
