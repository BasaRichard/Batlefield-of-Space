using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ScreenElement;
using static Batlefield_of_Space.ENUMS;

namespace Batlefield_of_Space
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GAME : Microsoft.Xna.Framework.Game
    {
        private float timeElapsed;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background;   //háttér
        Texture2D dummyTexture; //alap text
        MouseState ms;          //egér állapot
        MouseState prevms;         //elözö egér állapot
        KeyboardState ks;
        KeyboardState prevks;
        List<Button> buttons;
        GameState gameState;
        MenuState menuState;
        CHARACTER character;
            


        public GAME()
        {
            this.IsMouseVisible = true;
            graphics = new GraphicsDeviceManager(this);
            buttons = new List<Button>();
            Content.RootDirectory = "Content";
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            gameState = GameState.Stop;
            menuState = MenuState.Start;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
          
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("bg_menu");
            dummyTexture = new Texture2D(GraphicsDevice, 1, 1);
            Color[] colorData = {
                Color.White,
            };
            dummyTexture.SetData<Color>(colorData);
            character = new CHARACTER(new Rectangle(100, 200, 50, 100), Content.Load<Texture2D>("charAnimation"), 
                this.Window.ClientBounds.Width, this.Window.ClientBounds.Height);
           
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.Milliseconds;

            
            if (this.IsActive)
            {if (prevms != ms)
            {
                prevms = ms;
            }
            if (prevks != ks)
            {
                prevks = ks;
            }
            ks = Keyboard.GetState();
                ms = Mouse.GetState();


                switch (gameState)
                {
                    case GameState.Start:
                        {
                            
                            
                            if (ks.IsKeyDown(Keys.D) && !ks.IsKeyDown(Keys.A))
                            {
                                character.Move(10, 0);
                                if (timeElapsed >= character.Interval)
                                {
                                    character.Animation(ENUMS.Orientation.Right);
                                    timeElapsed = 0;
                                }
                            }
                            if (ks.IsKeyDown(Keys.A) && !ks.IsKeyDown(Keys.D))
                            {
                                character.Move(-10, 0);
                                if (timeElapsed >= character.Interval)
                                {
                                    character.Animation(ENUMS.Orientation.Left);
                                    timeElapsed = 0;
                                }
                            }
                            else if (ks.IsKeyDown(Keys.W))
                            {
                                character.Move(0, -10);
                                if (timeElapsed >= character.Interval)
                                {
                                    character.Animation(ENUMS.Orientation.Up);
                                    timeElapsed = 0;
                                }
                            }
                            else if (ks.IsKeyDown(Keys.S))
                            {
                                character.Move(0, 10);
                                if (timeElapsed >= character.Interval)
                                {
                                    character.Animation(ENUMS.Orientation.Down);
                                    timeElapsed = 0;
                                }
                            }

                            break;
                        }
                    case GameState.Play:
                        {
                            break;
                        }
                    case GameState.Stop:
                        {
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
               
                #region  
                

               

                switch (menuState)
                {
                    case MenuState.Start:
                        {
                            buttons.Clear();
                            background = Content.Load<Texture2D>("bg_menu");
                            buttons.Add(new Button(100, 100, Content.Load<Texture2D>("bt_newgame"), null));
                            buttons.Add(new Button(100, 150, Content.Load<Texture2D>("bt_newgame"), null));
                            buttons.Add(new Button(100, 200, Content.Load<Texture2D>("bt_exit"), null));
                            if (buttons[0].LeftClick(ms, prevms)) { 
                                menuState = MenuState.Newgame;
                                gameState = GameState.Start;}
                            else if (buttons[1].LeftClick(ms, prevms))
                                menuState = MenuState.Load;
                            else if (buttons[2].LeftClick(ms, prevms))
                                Exit();
                            break;
                        }
                    case MenuState.Newgame:
                        {
                            buttons.Clear();
                            buttons.Add(new Button(450, 200, Content.Load<Texture2D>("bt_newcharacter"), null));
                            buttons.Add(new Button(100, 200, Content.Load<Texture2D>("bt_Back"), null));
                            buttons.Add(new Button(150, 300, Content.Load<Texture2D>("alian1"), null));
                            buttons.Add(new Button(300, 300, Content.Load<Texture2D>("alian2"), null));
                            buttons.Add(new Button(450, 300, Content.Load<Texture2D>("alian3"), null));
                            if (buttons[0].LeftClick(ms, prevms))
                                gameState= GameState.Start;
                            menuState = MenuState.Game;
                            if (buttons[1].LeftClick(ms, prevms))
                                menuState = MenuState.Start;
                #region
                            /*
                            buttons.Clear();
                            background = Content.Load<Texture2D>("bg_newgame");
                            buttons.Add(new Button(120, 100, Content.Load<Texture2D>("bt_newgame"), null));
                            buttons.Add(new Button(120, 150, Content.Load<Texture2D>("bt_Back"), null));
                            buttons.Add(new Button(120, 200, Content.Load<Texture2D>("bt_Back"), null));
                            if (buttons[0].LeftClick(ms, prevms))
                            {
                                buttons.Clear();
                                background = Content.Load<Texture2D>("bg_newgame");
                                buttons.Add(new Button(130, 300, Content.Load<Texture2D>("bt_newcharacter"), null));
                                buttons.Add(new Button(100, 150, Content.Load<Texture2D>("bt_Back"), null));
                                if (buttons[0].LeftClick(ms, prevms))
                                {
                                        background = Content.Load<Texture2D>("bg_newgame");
                                        buttons.Add(new Button(140, 150, Content.Load<Texture2D>("bt_Back"), null));
                                    if (buttons[5].LeftClick(ms, prevms))
                                    {
                                        background = Content.Load<Texture2D>("bg_newgame");
                                        buttons.Add(new Button(150, 150, Content.Load<Texture2D>("bt_Back"), null));
                                    }

                                }
                                else
                                {
                                    menuState = MenuState.Start;
                                }
                            }
                            else if(buttons[1].LeftClick(ms, prevms))
                            {
                                menuState = MenuState.Start;
                            }
                            else if (buttons[2].LeftClick(ms, prevms))
                            {
                                menuState = MenuState.Start;
                            }*/
                            #endregion
                            break;
                        }
                    case MenuState.Load:
                        {
                            buttons.Clear();
                            buttons.Add(new Button(100, 100, Content.Load<Texture2D>("bt_play"), null));
                            buttons.Add(new Button(110, 200, Content.Load<Texture2D>("bt_play"), null));
                            buttons.Add(new Button(120, 300, Content.Load<Texture2D>("bt_play"), null));
                            buttons.Add(new Button(100, 400, Content.Load<Texture2D>("bt_Back"), null));
                            if (buttons[0].LeftClick(ms, prevms) || buttons[1].LeftClick(ms, prevms) || buttons[2].LeftClick(ms, prevms))
                            {
                                gameState = GameState.Start;
                                menuState = MenuState.Game;
                            }
                            if (buttons[3].LeftClick(ms, prevms))
                                menuState = MenuState.Start;
                            break;
                        }
                    case MenuState.Game:
                        {
                            buttons.Clear();
                            break;
                        }
                    default:
                        {
                            buttons.Clear();
                            break;
                        }

                }

                #endregion
            }
                base.Update(gameTime);
           


        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        { 
           
           

            spriteBatch.Begin();
            spriteBatch.Draw(character.Texture, character.Position, 
                new Rectangle(
                character.CurrentFrameX * character.FrameWidth,
                character.CurrentFrameY * character.FrameHegiht,
                character.FrameWidth,
                character.FrameHegiht
                ),Color.White);
            #region
            if (menuState != MenuState.Game)
            {
                int w = Window.ClientBounds.Width;
                int h = Window.ClientBounds.Height;
                spriteBatch.Draw(background,new Rectangle(0,0,w,h), Color.White);
                buttons.ForEach(x =>
                {
                    x.Draw(spriteBatch);
                });

            }
               


                //spriteBatch.Draw(dummyTexture, button1, Color.Red);
                switch (gameState)
                {
                    case GameState.Start:
                        {
                        spriteBatch.Draw(character.Texture, character.Position,
               new Rectangle(
               character.CurrentFrameX * character.FrameWidth,
               character.CurrentFrameY * character.FrameHegiht,
               character.FrameWidth,
               character.FrameHegiht
               ), Color.White);
                        break;
                        }
                    case GameState.Play:
                        {
                            break;
                        }
                    case GameState.Stop:
                        {
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                
            #endregion
            spriteBatch.End();

            base.Draw(gameTime);
        }
        
    }
}
