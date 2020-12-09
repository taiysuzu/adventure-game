/// created by : Taiyo Suzuki
/// date       : 8/12/2020
/// description: A basic text adventure game engine

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace adventure_game
{
    public partial class AdventureGame : Form
    {
        // variables
        int scene = 0;
        int redScene = 0;
        int blueScene = 0;
        int yellowScene = 0;
        int greenScene = 0;
        int doorSlam = 0;
        int goldCoin = 0;
        int number = 0;
        //random number generator
        Random randGen = new Random();

        public AdventureGame()
        {
            InitializeComponent();
            //startup view
            coinBox.Parent = backgroundLabel;
            coinBox.Visible = false;
            outputLabel.Text = "\n Welcome to Adventure Time. \nGood luck!";
            blueScene = 100;
            yellowScene = 99;
            greenScene = 99;
            redLabel.Text = "Start";
            blueLabel.Text = "Exit";
            yellowLabel.Text = "";
            greenLabel.Text = "";

        }

        private void AdventureGame_KeyDown(object sender, KeyEventArgs e)
        {
            /// check to see what button has been pressed and advance
            /// to the next appropriate scene
            if (e.KeyCode == Keys.M)       //red button press
            {
                scene = redScene;
                if (redScene == 100)
                {
                    Application.Exit();
                }
            }
            else if (e.KeyCode == Keys.B)  //blue button press
            {
                scene = blueScene;
                if (blueScene == 100)
                {
                    Application.Exit();
                }
            }
            else if (e.KeyCode == Keys.N) //yellow button press
            {
                scene = yellowScene;
                if (yellowScene == 100)
                {
                    Application.Exit();
                }
            }
            else if (e.KeyCode == Keys.Space) //green button press
            {
                scene = greenScene;
                if (greenScene == 100)
                {
                    Application.Exit();
                }
            }

            /// Display text and game options to screen based on the current scene
            switch (scene)
            {
                case 0:  //start scene  
                    outputLabel.Text = "You wake up in an unfamiliar bedroom.\nWhat do you want to do?"; //output text story
                    redLabel.Text = "Go back to sleep"; //options on buttons
                    blueLabel.Text = "Go into the Hall";
                    yellowLabel.Text = "Take a look around";
                    redScene = 0;//changes which scene each buttons takes you to
                    blueScene = 1;
                    yellowScene = 2;
                    greenScene = 99;
                    imageBox.BackgroundImage = Properties.Resources.bedroom; //change image
                    break;
                case 1:
                    outputLabel.Text = "You walk into the hallway and find yourself bathed in an eerie blue light.\nWhat do you want to do?";
                    redLabel.Text = "Look for the source of the light";
                    blueLabel.Text = "Run back to the bedroom";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    redScene = 3;
                    blueScene = 4;
                    yellowScene = 99;
                    greenScene = 99;
                    imageBox.BackgroundImage = Properties.Resources.hallway;
                    break;
                case 2:
                    outputLabel.Text = "As you begin to look around the room, you notice some strange things.\nWhat do you investigate first?";
                    redLabel.Text = "Hovering Lamp";
                    blueLabel.Text = "Fireplace Aquarium";
                    yellowLabel.Text = "Loose Floorboard";
                    greenLabel.Text = "";
                    redScene = 7;
                    blueScene = 8;
                    yellowScene = 9;
                    greenScene = 99;
                    imageBox.BackgroundImage = Properties.Resources.bedroom;
                    break;
                case 3:
                    outputLabel.Text = "You look around, but you can't seem to find the source of the light. You notice some shadowy figures approaching from one end of the hallway.\nDo you stand your ground or run?";
                    redLabel.Text = "Stand your ground";
                    blueLabel.Text = "Run";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    redScene = 5;
                    blueScene = 19;
                    yellowScene = 99;
                    greenScene = 99;
                    imageBox.BackgroundImage = Properties.Resources.hallway_figures;
                    break;
                case 4:
                    outputLabel.Text = "You run back to the room you came out of and slam the door behind you.\n(Continue)";
                    doorSlam = 1;
                    redLabel.Text = "Continue";
                    blueLabel.Text = "";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    redScene = 2;
                    blueScene = 99;
                    yellowScene = 99;
                    greenScene = 99;
                    imageBox.BackgroundImage = Properties.Resources.bedroom;
                    break;
                case 5:
                    outputLabel.Text = "You decide to stand your ground. The figures look less and less solid as they approach. In a few seconds, you are enveloped by the shadows and lose consciousness.\n(Continue)";
                    redLabel.Text = "Continue";
                    blueLabel.Text = "";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    redScene = 0;
                    blueScene = 99;
                    yellowScene = 99;
                    greenScene = 99;
                    imageBox.BackgroundImage = Properties.Resources.hallway_figures;
                    break;
                case 6:
                    outputLabel.Text = "You run as fast as you can down the hall, but in your haste you tigger a tripwire and fall into a spike pit.";
                    redLabel.Text = "Continue";
                    blueLabel.Text = "";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    redScene = 18;
                    blueScene = 99;
                    yellowScene = 99;
                    greenScene = 99;
                    imageBox.BackgroundImage = Properties.Resources.rip1;
                    break;
                case 7:
                    outputLabel.Text = "You examine the lamp, which seems to be floating of its own accord.\nPlug the lamp in?";
                    redLabel.Text = "Yes";
                    blueLabel.Text = "No";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    redScene = 10;
                    blueScene = 11;
                    yellowScene = 99;
                    greenScene = 99;
                    imageBox.BackgroundImage = Properties.Resources.floatlamp;
                    break;
                case 8:
                    outputLabel.Text = "You go over to the fireplace, which has been crudely renovated into an aquarium. You spend some time looking at the fish, and you notice a tub of fish food beside the aquarium.\nDo you feed the fish?";
                    redLabel.Text = "Yes";
                    blueLabel.Text = "No";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    if (doorSlam == 1)
                    {
                        if (goldCoin == 1)
                        {
                            redScene = 12;
                            blueScene = 20;
                            yellowScene = 99;
                            greenScene = 99;
                        }
                        if (goldCoin == 0)
                        {
                            redScene = 12;
                            blueScene = 21;
                            yellowScene = 99;
                            greenScene = 99;
                        }
                    }
                    else if (doorSlam == 0)
                    {
                        if (goldCoin == 1)
                        {
                            redScene = 22;
                            blueScene = 23;
                            yellowScene = 99;
                            greenScene = 99;
                        }
                        if (goldCoin == 0)
                        {
                            redScene = 24;
                            blueScene = 21;
                            yellowScene = 99;
                            greenScene = 99;
                        }
                    }
                    break;
                case 9:
                    outputLabel.Text = "You spot a loose floorboard.\nDo you check what's underneath?";
                    redLabel.Text = "Yes";
                    blueLabel.Text = "No";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    imageBox.BackgroundImage = Properties.Resources.floorboard;
                    number = randGen.Next(1, 6);
                    if (doorSlam == 1)
                    {
                        if (number == 5)
                        {
                            redScene = 16;
                            blueScene = 25;
                            yellowScene = 99;
                            greenScene = 99;
                        }
                        else
                        {
                            redScene = 17;
                            blueScene = 25;
                            yellowScene = 99;
                            greenScene = 99;
                        }

                    }
                    else if (doorSlam == 0)
                    {
                        redScene = 16;
                        blueScene = 25;
                        yellowScene = 99;
                        greenScene = 99;
                    }
                    break;
                case 10:
                    outputLabel.Text = "The lamp blows up, leaving you handless. You go into shock and die of blood loss.";
                    redLabel.Text = "Continue";
                    blueLabel.Text = "";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    redScene = 18;
                    blueScene = 99;
                    yellowScene = 99;
                    greenScene = 99;
                    imageBox.BackgroundImage = Properties.Resources.rip1;
                    break;
                case 11:
                    outputLabel.Text = "You decide to leave the lamp as it is.\nWhat do you investigate next?";
                    redLabel.Text = "Loose Floorboard";
                    blueLabel.Text = "Fireplace Aquarium";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    redScene = 9;
                    blueScene = 8;
                    yellowScene = 99;
                    greenScene = 99;
                    imageBox.BackgroundImage = Properties.Resources.bedroom;
                    break;
                case 12:
                    outputLabel.Text = "The fish start to thrash about as you sprinkle the food in. You put your hand too close and get bitten, at which you realize they're piranhas. They smell blood and all start to attack you. You get dragged under and devoured.";
                    redLabel.Text = "Continue";
                    blueLabel.Text = "";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    redScene = 18;
                    blueScene = 99;
                    yellowScene = 99;
                    greenScene = 99;
                    imageBox.BackgroundImage = Properties.Resources.rip1;
                    break;
                case 13:
                    outputLabel.Text = "The room begins to close like the trash compactor from Star Wars.\nWhat do you do?";
                    redLabel.Text = "Accept your fate";
                    blueLabel.Text = "Try to prop something up to stop the walls";
                    yellowLabel.Text = "Toss the coin in water and wish to be saved";
                    greenLabel.Text = "";
                    redScene = 14;
                    blueScene = 14;
                    yellowScene = 15;
                    greenScene = 99;
                    imageBox.BackgroundImage = Properties.Resources.bedroom;
                    break;
                case 14:
                    outputLabel.Text = "You are squished.";
                    redLabel.Text = "Continue";
                    blueLabel.Text = "";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    redScene = 18;
                    blueScene = 99;
                    yellowScene = 99;
                    greenScene = 99;
                    imageBox.BackgroundImage = Properties.Resources.rip1;
                    break;
                case 15:
                    outputLabel.Text = "There is a blinding flash of white light. When you are able to see again, you are in your own bedroom.\n\nCongratulations on completing Adventure Time!\nThanks for playing!";
                    coinBox.Visible = false;
                    redLabel.Text = "Continue";
                    blueLabel.Text = "";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    redScene = 18;
                    blueScene = 99;
                    yellowScene = 99;
                    greenScene = 99;
                    imageBox.BackgroundImage = Properties.Resources.yourroom;
                    break;
                case 16:
                    if (goldCoin == 0)
                    {
                        outputLabel.Text = "You find a gold coin under the loose floorboard. You take the coin.\nWhat do you investigate next?";
                        goldCoin = 1;
                        coinBox.Visible = true;
                        redLabel.Text = "Fireplace Aquarium";
                        blueLabel.Text = "Hovering Lamp";
                        yellowLabel.Text = "";
                        greenLabel.Text = "";
                        redScene = 8;
                        blueScene = 7;
                        yellowScene = 99;
                        greenScene = 99;
                        imageBox.BackgroundImage = Properties.Resources.floorboard;
                    }
                    else
                    {
                        outputLabel.Text = "The space underneath the floorboard where you found the coin is now empty.\nWhat do you investigate next?";
                        redLabel.Text = "Fireplace Aquarium";
                        blueLabel.Text = "Hovering Lamp";
                        yellowLabel.Text = "";
                        greenLabel.Text = "";
                        redScene = 8;
                        blueScene = 7;
                        yellowScene = 99;
                        greenScene = 99;
                        imageBox.BackgroundImage = Properties.Resources.floorboard;
                    }
                    break;
                case 17:
                    outputLabel.Text = "You lift up the floorboard and come face to face with the biggest spider you've ever seen. It bites your head off and sucks out your insides.";
                    redLabel.Text = "Continue";
                    blueLabel.Text = "";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    redScene = 18;
                    blueScene = 99;
                    yellowScene = 99;
                    greenScene = 99;
                    imageBox.BackgroundImage = Properties.Resources.rip1;
                    break;
                case 18:
                    outputLabel.Text = "Game over.\nPlay again?";
                    redLabel.Text = "Yes";
                    blueLabel.Text = "No";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    redScene = 0;
                    blueScene = 100;
                    yellowScene = 99;
                    greenScene = 99;
                    break;
                case 19:
                    outputLabel.Text = "You decide to run.\nRun where?";
                    redLabel.Text = "Back to the bedroom.";
                    blueLabel.Text = "Down the hall the opposite way.";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    redScene = 4;
                    blueScene = 6;
                    yellowScene = 99;
                    greenScene = 99;
                    imageBox.BackgroundImage = Properties.Resources.hallway_figures;
                    break;
                case 20:
                    outputLabel.Text = "You don't feed the fish. You remember your mom telling you about throwing a coin into a well and making a wish. The aquarium's not quite a well, but oh well... \nDo you make a wish and toss the coin into the water?";
                    redLabel.Text = "Yes";
                    blueLabel.Text = "No";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    redScene = 15;
                    blueScene = 13;
                    yellowScene = 99;
                    greenScene = 99;
                    break;
                case 21:
                    outputLabel.Text = "You don't feed the fish.\nWhat do you investigate next?";
                    redLabel.Text = "Hovering Lamp";
                    blueLabel.Text = "Loose Floorboard";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    redScene = 7;
                    blueScene = 9;
                    yellowScene = 99;
                    greenScene = 99;
                    break;
                case 22:
                    outputLabel.Text = "You feed the fish. You remember your mom telling you about throwing a coin into a well and making a wish. The aquarium's not quite a well, but oh well... \nDo you make a wish and toss the coin into the water?";
                    redLabel.Text = "Yes";
                    blueLabel.Text = "No";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    redScene = 15;
                    blueScene = 13;
                    yellowScene = 99;
                    greenScene = 99;
                    break;
                case 23:
                    outputLabel.Text = "You don't feed the fish. You remember your mom telling you about throwing a coin into a well and making a wish. The aquarium's not quite a well, but oh well... \nDo you make a wish and toss the coin into the water?";
                    redLabel.Text = "Yes";
                    blueLabel.Text = "No";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    redScene = 15;
                    blueScene = 13;
                    yellowScene = 99;
                    greenScene = 99;
                    break;
                case 24:
                    outputLabel.Text = "You feed the fish.\nWhat do you investigate next?";
                    redLabel.Text = "Hovering Lamp";
                    blueLabel.Text = "Loose Floorboard";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    redScene = 7;
                    blueScene = 9;
                    yellowScene = 99;
                    greenScene = 99;
                    break;
                case 25:
                    outputLabel.Text = "You don't lift up the floorboard.\nWhat do you investigate next?";
                    redLabel.Text = "Hovering Lamp";
                    blueLabel.Text = "Fireplace Aquarium";
                    yellowLabel.Text = "";
                    greenLabel.Text = "";
                    redScene = 7;
                    blueScene = 8;
                    yellowScene = 99;
                    greenScene = 99;
                    imageBox.BackgroundImage = Properties.Resources.bedroom;
                    break;
                default:
                    break;
            }
        }

    }

}