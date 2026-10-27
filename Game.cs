// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;
using System.Security.Principal;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class! Like Floats and shit
    /// </summary>
    //float x;
    //float y;
    //float radius;
    //float angleform;
    //these don't go here ^^
    public class Game
    {
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        Bubble[] bubbles = new Bubble[1000];
        int bubblecount = 0;
        public void Setup()
        {
            Window.SetTitle("Interactive BUBBLES"); //PLEASE SET THIS BE THE LAST TIME I DELETE AND REMAKE A GITHUB REPOSITORY
            Window.SetSize(800, 600); // it was originally at 800 x 800 until I carefully read to rubric...
           //Window.TargetFPS = 60; // There's no need for this
        }


        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        /// MY PLAN FOR THIS TOY ASSIGNMENT IS AN INFINITE BUBBLE POPPING GAME. MAKE THE BUBBLES MOVES AROUND THE WINDOW, CLICK TO POP THEM
        /// AND HOLD SOMETHING LIKE SPACE TO BLOW MORE BUBBLES 
        public bool showText = true;
        public void Update()
        {
            Window.ClearBackground(166, 221, 255);
            if (showText == true) // by removing the semicolon it allows the text to fully disappear the moment the space bar is pressed down once
            {
                Text.Draw("Press/hold Space!", 260f, 150f);
            }

            if (Input.IsKeyboardKeyPressed(KeyboardKey.Space))
            {
                showText = false;
            }
            if (Input.IsKeyboardKeyDown(KeyboardKey.Space))
            {
                bubbles[bubblecount] = new Bubble();
                bubbles[bubblecount].setup();
                bubblecount += 1;
            }
            
            for (int i = 0; i < bubblecount; i++)
            {
                    
                    bubbles[i].update();
            }
            if (Input.IsMouseButtonPressed(MouseButton.Left))
            {
                Vector2 mouse = Input.GetMousePosition();

                for (int i = 0; i < bubblecount; i++)
                {
                    if (bubbles[i].trypop(mouse.X, mouse.Y))
                    {
                        bubbles[i] = new Bubble();
                    }
                }

            }
           /* if (Input.IsKeyboardKeyPressed(KeyboardKey.R)) I tried to make a button that resets the game (pop all bubbles in an instant)
            {

                for (int i = 0; i < bubblecount; i++)
                {


                }

            }
           */
            //Bubble Wand
            Draw.SetFillColor(25, 24, 28);
            Draw.Capsule(400, 600, 400, 400, 10);
            Draw.SetFillColor(25, 24, 28);
            Draw.Circle(400, 400, 100);
            Draw.SetFillColor(0, 200, 255);//, 50); Opacity can't work unless I make the circle below a ring.
            Draw.Circle(400, 400, 90);
        }

    }

}
