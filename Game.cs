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
        Vector2 playerPosition = new Vector2(400, 200);
        float playerRadius = 25;
        float countdown = 5;
        float transitionTimer;
        int countdownDisplay;

        bool showScene1 = true;
        bool showScene2 = false;
        bool showInterrogation = false;
        bool showInterrogationYes = false;
        bool showInterrogationNo = false;

        Vector2 yesCircle = new Vector2(100, 200);
        float radius = 50;
        Vector2 noCircle = new Vector2(700, 200);

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
                Interrogation();
            }
            else if (showInterrogationYes == true)
            {
                InterrogationYes();
            }
            else if (showInterrogationNo == true)
            {
                InterrogationNo();
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

        public void Interrogation()
        {
            Draw.FillColor = Color.DarkGray;
            Draw.Rectangle(0, 600, 800, 200);
            Text.Color = Color.White;
            Text.Draw("Did you do the crime?", 20, 620);
            Draw.Circle(yesCircle, radius);
            Text.Draw("Yes", 75, 185);
            Draw.Circle(noCircle, radius);
            Text.Draw("No", 685, 185);

            if (Input.GetMouseX() >= yesCircle.X - radius && Input.GetMouseX() <= yesCircle.X + radius
                && Input.GetMouseY() >= yesCircle.Y - radius && Input.GetMouseY() <= yesCircle.Y + radius)
            {
                bool isInsideOption1 = true;
                if (isInsideOption1 && Input.IsMouseButtonPressed(0))
                {
                    showInterrogation = false;
                    showInterrogationYes = true;
                }
            }

            if (Input.GetMouseX() >= noCircle.X - radius && Input.GetMouseX() <= noCircle.X + radius
                && Input.GetMouseY() >= noCircle.Y - radius && Input.GetMouseY() <= noCircle.Y + radius)
            {
                bool isInsideOption2 = true;
                if (isInsideOption2 && Input.IsMouseButtonPressed(0))
                {
                    showInterrogation = false;
                    showInterrogationNo = true;
                }
            }
        }

        public void InterrogationYes()
        {
            Window.ClearBackground(Color.Black);
            Draw.FillColor = Color.DarkGray;
            Draw.Rectangle(0, 600, 800, 200);
            Text.Color = Color.White;
            Text.Draw("I can't believe this. GAME OVER.", 20, 620);
            Draw.Circle(yesCircle, radius);
            Text.Draw("Yes", 75, 185);
            Draw.Circle(noCircle, radius);
            Text.Draw("No", 685, 185);
        }

        public void InterrogationNo()
        {
            Window.ClearBackground(Color.Black);
            Draw.FillColor = Color.DarkGray;
            Draw.Rectangle(0, 600, 800, 200);
            Text.Color = Color.White;
            Text.Draw("I knew it wasn't you. YOU WIN.", 20, 620);
            Draw.Circle(yesCircle, radius);
            Text.Draw("Yes", 75, 185);
            Draw.Circle(noCircle, radius);
            Text.Draw("No", 685, 185);
        }
    }

}
