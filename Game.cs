// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Interrogation interrogation = new Interrogation();
        Vector2 playerPosition = new Vector2(400, 200);
        float playerRadius = 25;
        float countdown = 30;
        float transitionTimer;
        int countdownDisplay;

        bool showScene1 = true;
        bool showScene2 = false;
        bool showInterrogation = false;
        bool showInterrogationYes = false;
        bool showInterrogationNo = false;

        

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(800, 800);
            Window.SetTitle("Test");
            Window.TargetFPS = 60;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.Black);
            if (showScene1 ==  true)
            {
                Scene1();
            }
            else if (showScene2 == true)
            {
                Scene2();
            }
            else if (showInterrogation == true)
            {
                interrogation.Question1();
            }
            else if (showInterrogationYes == true)
            {
                interrogation.InterrogationYes();
            }
            else if (showInterrogationNo == true)
            {
                interrogation.InterrogationNo();
            }
        }

        public void Player()
        {
            // Setup
            Draw.FillColor = Color.LightGray;
            Draw.Circle(playerPosition, playerRadius);

            // Movement
            if (Input.IsKeyboardKeyDown(KeyboardInput.A))
            {
                playerPosition.X -= 5;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                playerPosition.X += 5;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.W))
            {
                playerPosition.Y -= 5;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.S))
            {
                playerPosition.Y += 5;
            }

            // Collision
            if (playerPosition.Y - playerRadius < 0)
            {
                playerPosition.Y = 25;
            }
            if (playerPosition.Y + playerRadius > 800)
            {
                playerPosition.Y = 775;
            }
            if (playerPosition.X - playerRadius < 0)
            {
                playerPosition.X = 25;
            }
            if (playerPosition.X + playerRadius > 800)
            {
                playerPosition.X = 775;
            }
        }

        public void Scene1()
        {
            Player();
            countdown -= Time.DeltaTime;
            if (countdown > 0)
            {
                Text.Color = Color.White;
                Text.Draw($"Timer: {countdown}", 10, 10);
            }
            else if (countdown <= 0)
            {
                transitionTimer = countdown + 3;
                transitionTimer -= Time.DeltaTime;
                //Text.Draw($"Timer: {transitionTimer}", 100, 100);
                if (transitionTimer <= 0)
                {
                    transitionTimer = 0;
                    showScene1 = false;
                    showScene2 = true;
                }
            }
        }

        public void Scene2()
        {
            Window.ClearBackground(Color.Black);
            Text.Color = Color.White;
            Text.Draw("Two weeks later...", 250, 300);

            float continueTimer;
            continueTimer = Time.SecondsElapsed;
            //Text.Draw($"Timer: {continueTimer}", 100, 100);
            if (continueTimer >= 10)
            {
                Text.Draw("Click to continue.", 250, 400);
            }
            if (Input.IsMouseButtonPressed(0))
            {
                showScene2 = false;
                showInterrogation = true;
            }
        }

        
    }

}
