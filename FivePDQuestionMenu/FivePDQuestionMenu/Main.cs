using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using NativeUI;

namespace Client
{
    public class Main : BaseScript
    {
        public bool onduty = false;

        public static Ped ped1;
        public static Vehicle vehicle1;
        public static int ped1blip;

        private MenuPool _menuPool;
        private UIMenu mainMenu;

        public string menuname;

        public void TrafficStopQuestions(UIMenu menu)
        {
            var trafficstopquestionssub = _menuPool.AddSubMenu(menu, "Traffic Stop Questions", "Ask driver's questions during your traffic stop");
            for (int i = 0; i < 1; i++) ;

            trafficstopquestionssub.MouseEdgeEnabled = false;
            trafficstopquestionssub.ControlDisablingEnabled = false;

            var intro = _menuPool.AddSubMenu(trafficstopquestionssub, "~y~Intro");
            for (int i = 0; i < 1; i++) ;

            intro.MouseEdgeEnabled = false;
            intro.ControlDisablingEnabled = false;

            var goodmorning = new UIMenuItem("Hello", "");
            intro.AddItem(goodmorning);
            intro.OnItemSelect += async (sender, item, index) =>
            {
                if (item == goodmorning)
                {
                    //Play Greet Sound
                    Game.Player.Character.PlayAmbientSpeech("KIFFLOM_GREET");

                    //Generate lines
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "I should still be sleeping",
                        "I'm all out of doughnuts and coffee, sorry",
                        "Hello officer", "Indeed it is a very good morning",
                        "Hello to you too", "I have a feeling its goinig to get worse",
                        "Yes, the Lord is good",
                        "I was just minding my own business, you should try it"
                    };

                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Driver: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var howareyou = new UIMenuItem("How are you today?", "");
            intro.AddItem(howareyou);
            intro.OnItemSelect += async (sender, item, index) =>
            {
                if (item == howareyou)
                {
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "Well I've been better",
                        "I am starving and headed to get some lunch",
                        "I have been fighting the flu all week officer",
                        "Just buried my brother today, not that you care",
                        "Eh... yourself?",
                        "This hottie hit on me at the gym, it made my day",
                        "I really don't care for small talk",
                        "Same ole, same ole, I guess"
                    };
                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Driver: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var reasonforstop = new UIMenuItem("Any idea why I stopped you?", "");
            intro.AddItem(reasonforstop);
            intro.OnItemSelect += async (sender, item, index) =>
            {
                if (item == reasonforstop)
                {
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "I don't have the slightest clue",
                        "I am sure you will make something up",
                        "Did I forget to signal my turn or something?",
                        "Did someone call me in for cutting them off?",
                        "To pay your respects to my dead grandmother?",
                        "Nope but have at it officer",
                        "You watched me leave the Krispy Kreme?",
                        "To tell me I broke one of the million laws in this city?"
                    };
                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Driver: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var anythingincar = new UIMenuItem("Any weapons or anything illegal in the car?", "");
            intro.AddItem(anythingincar);
            intro.OnItemSelect += async (sender, item, index) =>
            {
                if (item == anythingincar)
                {
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "No officer",
                        "Yes, I have my side arm on me",
                        "Why is it your business?"
                    };
                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Driver: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var getid = new UIMenuItem("Can I have your identification please?", "");
            intro.AddItem(getid);
            intro.OnItemSelect += async (sender, item, index) =>
            {
                if (item == getid)
                {
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "Here you go, officer *hands ID*",
                        "I guess *rolls eyes*",
                        "Sure, why not"
                    };
                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Driver: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var movingviolations = _menuPool.AddSubMenu(trafficstopquestionssub, "~y~Moving Violations");
            for (int i = 0; i < 1; i++) ;

            movingviolations.MouseEdgeEnabled = false;
            movingviolations.ControlDisablingEnabled = false;

            var speeding = new UIMenuItem("You were speeding", "");
            movingviolations.AddItem(speeding);
            movingviolations.OnItemSelect += async (sender, item, index) =>
            {
                if (item == speeding)
                {
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "Are you sure?",
                        "You guys doit all the time, I just wanted to try it once",
                        "I am not sure what to say, I didn't realize it",
                        "My apologies it is a new car",
                        "I had full control, in no way was I reckless!",
                        "Only reason you stopped me is because I let you",
                        "I had a gas station burrito with an immodium AD haha",
                        "I heard the limit is just a suggestion though?"
                    };
                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Driver: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var impeding = new UIMenuItem("You were impeding traffic", "");
            movingviolations.AddItem(impeding);
            movingviolations.OnItemSelect += async (sender, item, index) =>
            {
                if (item == impeding)
                {
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "And that is a problem why?",
                        "The damn check engine light is on",
                        "Funny story I forgot to get gas, so I'm almost out",
                        "I like making the other drivers go around me",
                        "I was on tinder swiping a very important match",
                        "I didn't know I could get stopped for not speeding",
                        "So you want me to speed?",
                        "I dropped something and was trying to dig under the seat"
                    };
                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Driver: ~w~" + possiblefirstnames[firstname]);
                };
            };

            var redlight = new UIMenuItem("You ran a red light", "");
            movingviolations.AddItem(redlight);
            movingviolations.OnItemSelect += async (sender, item, index) =>
            {
                if (item == redlight)
                {
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "It's only split seconds.. it should be fine..",
                        "The light was yellow, you should check your eyesight!",
                        "I thought I had just beat it. I guess not",
                        "I wasn't paying attention if Im going to be honest",
                        "Why don't I get praised for the lights I DO stop at?",
                        "Sorry, I'm in a hurry.. I need to pee",
                        "I did not have time to stop for that thing",
                        "I goofed, I know I should have stopped",
                        "Yep and I am still going to be late"
                    };
                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Driver: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var stopsign = new UIMenuItem("You ran a stop sign", "");
            movingviolations.AddItem(stopsign);
            movingviolations.OnItemSelect += async (sender, item, index) =>
            {
                if (item == stopsign)
                {
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "They are like every twenty feet!",
                        "My apologies",
                        "Oh no did I?",
                        "Look at that.. I did and nobody died",
                        "*sighs*",
                        "Honest mistake sorry officer",
                        "I took the cutest selfie *shows you phone*",
                        "Cause they are a waste of time",
                        "I did roll right through that son of a gun didnt I?"
                    };
                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Driver: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var documentation = _menuPool.AddSubMenu(trafficstopquestionssub, "~y~Documentation");
            for (int i = 0; i < 1; i++) ;

            documentation.MouseEdgeEnabled = false;
            documentation.ControlDisablingEnabled = false;

            var expiredlicense = new UIMenuItem("Did you know your license is expired?", "");
            documentation.AddItem(expiredlicense);
            documentation.OnItemSelect += async (sender, item, index) =>
            {
                if (item == expiredlicense)
                {
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "I must have forgotten to renew it. Sorry",
                        "How does it expire its a piece of plastic, do I recycle it?",
                        "I'll get to the DMV when I can",
                        "I know it. But I like this license because I look young in the photo",
                        "Please just give me warning. I'll renew it right away",
                        "My record is three years without renewing it",
                        "Just expired so I can still drive on it right?",
                        "I rarely drive so I don't renew it often"
                    };
                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Driver: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var suspendedlicense = new UIMenuItem("Why are you driving with a suspended license?", "");
            documentation.AddItem(suspendedlicense);
            documentation.OnItemSelect += async (sender, item, index) =>
            {
                if (item == suspendedlicense)
                {
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "Sorry, I really need to drive to go to work",
                        "Are you sure? They say my license is no longer suspended",
                        "I swear, I didn't know that my license is suspended",
                        "Okay, that seems very unfortunate huh?",
                        "I have no one to give me rides, I have to use my vehicle",
                        "I was told they would change it in the system to valid",
                        "I did not think I would get caught",
                        "I did not know it was still suspended"
                    };
                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Driver: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var expiredregistration = new UIMenuItem("Do you know your registration has expired?", "");
            documentation.AddItem(expiredregistration);
            documentation.OnItemSelect += async (sender, item, index) =>
            {
                if (item == expiredregistration)
                {
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "I didn't get any mail from DMV about the renewal",
                        "My secretary must have forgotten to tell me to do that",
                        "So it was broke down and it just got fixed",
                        "Registration is just a cash grab by the state",
                        "Oh, I am so sorry",
                        "I did not realize that",
                        "Hmmm I thought it renewed",
                        "Yeah I will get that taken care of ASAP"
                    };
                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Driver: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var noregistration = new UIMenuItem("Why do you have no registration on this vehicle?", "");
            documentation.AddItem(noregistration);
            documentation.OnItemSelect += async (sender, item, index) =>
            {
                if (item == noregistration)
                {
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "Really? Had no clue, they never told me",
                        "I just bought this vehicle last week",
                        "Dammnit, I will get right on that tonight!",
                        "I assumed the dealership handled all of that",
                        "The fees are insane",
                        "I share this with my brother and it was his turn to register it",
                        "I sold this vehicle but I still drive it from time to time",
                        "I never do until I get stopped"
                    };
                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Driver: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var expiredinsurance = new UIMenuItem("Do you know your insurance has expired?", "");
            documentation.AddItem(expiredinsurance);
            documentation.OnItemSelect += async (sender, item, index) =>
            {
                if (item == expiredinsurance)
                {
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "Are you sure? it should be auto-renewed",
                        "I don't have money to renew it",
                        "Please just give me warning. This is not a ticket I can afford",
                        "I lost my job and the funds weren't in the bank",
                        "My dad is supposed to take care of all that",
                        "Are you sure that information is correct?",
                        "I sure do",
                        "No, that is not right"
                    };
                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Driver: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var noinsurance = new UIMenuItem("I show you have no insurance on this vehicle?", "");
            documentation.AddItem(noinsurance);
            documentation.OnItemSelect += async (sender, item, index) =>
            {
                if (item == noinsurance)
                {
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "I didn't know, i guess it got cancelled",
                        "Don't need it, I am an excellent driver!",
                        "Please just give me warning. I'll renew it right away",
                        "I auto pay for that and I thought everything was good",
                        "I only pay for 6 months out of the year to save money",
                        "I can barely afford my rent",
                        "I just bought it so I can't insure it until I have the title",
                        "Yeah I shouldn't be driving it right now"
                    };
                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Driver: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var ending = _menuPool.AddSubMenu(trafficstopquestionssub, "~y~Traffic Stop Endings");
            for (int i = 0; i < 1; i++) ;

            ending.MouseEdgeEnabled = false;
            ending.ControlDisablingEnabled = false;

            var returninfo = new UIMenuItem("Sorry for the wait, here is your info back", "");
            ending.AddItem(returninfo);
            ending.OnItemSelect += async (sender, item, index) =>
            {
                if (item == returninfo)
                {
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "Thank You",
                        "Thanks, I appreciate it",
                        "So what is the verdict your honor?",
                        "I can't wait to hear your ruling",
                        "I was beginning to think you died back there",
                        "Did you stop and take lunch while you were back there?",
                        "No trouble at all",
                        "Not going to lie I was getting kind of worried",
                        "What the hell took you so long?"
                    };
                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Driver: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var issuewarning = new UIMenuItem("I am just going to give you a warning okay?", "");
            ending.AddItem(issuewarning);
            ending.OnItemSelect += async (sender, item, index) =>
            {
                if (item == issuewarning)
                {
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "Appreciate that I really do",
                        "You are a saint you have no idea",
                        "That is what I was hoping for",
                        "Fabulous! I love that we are seeing eye to eye",
                        "You are the best",
                        "That really means the world to me",
                        "You didn't have to do that but I thank you",
                        "That is A-OKAY with me",
                        "Great news... the justice system works huh?"
                    };
                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Driver: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var citation = new UIMenuItem("I am going to cite you for ____", "");
            ending.AddItem(citation);
            ending.OnItemSelect += async (sender, item, index) =>
            {
                if (item == citation)
                {
                    //Play Animation
                    Prop notepad = await World.CreateProp("prop_notepad_02", Game.Player.Character.Position, true, false);
                    notepad.AttachTo(Game.Player.Character, Game.Player.Character.Position, Game.Player.Character.Rotation);
                    Game.Player.Character.Task.PlayAnimation("veh@busted_std", "issue_ticket_cop");
                    await BaseScript.Delay(6000);
                    Game.Player.Character.Task.ClearAll();
                    notepad.Delete();

                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "Let's get this show on the road okay?",
                        "I couldn't agree more",
                        "Amazing how you just spent so much of my money for me",
                        "I will most certainly see you in court",
                        "Whatever",
                        "Well their goes my insurance rates",
                        "That sucks but I understand",
                        "Just as hungry for my money as you are for doughnuts I see",
                        "*Sighs*"
                    };
                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Driver: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var questions = new UIMenuItem("Any other questions for me at this time?", "");
            ending.AddItem(questions);
            ending.OnItemSelect += async (sender, item, index) =>
            {
                if (item == questions)
                {
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "Nope",
                        "Not that I can think of",
                        "That will be all",
                        "Can I go now?",
                        "No officer",
                        "Nah",
                        "Not really",
                        "Not at this time",
                        "If you dont make the court date the ticket is dismissed right?"
                    };
                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Driver: ~w~" + possiblefirstnames[firstname]);
                }
            };
        }

        public void StoppedPedQuestions(UIMenu menu)
        {
            var stoppedpedsub = _menuPool.AddSubMenu(menu, "Ped Questions");
            for (int i = 0; i < 1; i++) ;

            stoppedpedsub.MouseEdgeEnabled = false;
            stoppedpedsub.ControlDisablingEnabled = false;

            var peddoing = new UIMenuItem("What are you doing?", "");
            stoppedpedsub.AddItem(peddoing);
            stoppedpedsub.OnItemSelect += async (sender, item, index) =>
            {
                if (item == peddoing)
                {
                    //Generate lines
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "Just hanging around",
                        "I need some fresh air",
                        "I'm relaxing my soul",
                        "I'm just waiting for a friend..",
                        "It's none of your business!",
                        "Please mind your own business!",
                        "Why do you care?",
                        "I don't need to answer that..",
                        "I choose not to answer..",
                        "I have the right to shut the fuck up.."
                    };

                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Subject: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var pedfrom = new UIMenuItem("Where are you coming from?", "");
            stoppedpedsub.AddItem(pedfrom);
            stoppedpedsub.OnItemSelect += async (sender, item, index) =>
            {
                if (item == pedfrom)
                {
                    //Generate lines
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "From home",
                        "From my friend's home",
                        "From work",
                        "From the grocery store",
                        "From hell!",
                        "I just came from the hospital",
                        "I have the right not to answer..",
                        "I have the right to remain silent.."
                    };

                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Subject: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var pedto = new UIMenuItem("Where are you going?", "");
            stoppedpedsub.AddItem(pedto);
            stoppedpedsub.OnItemSelect += async (sender, item, index) =>
            {
                if (item == pedto)
                {
                    //Generate lines
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "I wanna go home",
                        "I'm on my way home",
                        "I'm going to work",
                        "Just going to the grocery store",
                        "I'm going to see a friend",
                        "Going to my friend's home",
                        "Anywhere I like..",
                        "You don't want to know..",
                        "I have the right not to answer.."
                    };

                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Subject: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var drinking = _menuPool.AddSubMenu(stoppedpedsub, "~y~Drinking / Drugs");
            for (int i = 0; i < 1; i++) ;

            drinking.MouseEdgeEnabled = false;
            drinking.ControlDisablingEnabled = false;

            var alcohol = new UIMenuItem("Have you had anything to drink?", "");
            drinking.AddItem(alcohol);
            drinking.OnItemSelect += async (sender, item, index) =>
            {
                if (item == alcohol)
                {
                    //Generate lines
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "I have one shot of vodka an hour ago",
                        "I don't drink alcohol",
                        "I drank a six-pack of beer",
                        "Alcohol is not good for my health..",
                        "Yes, I had a couple beers",
                        "I've never had a drink in my life. I swear.."
                    };

                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Subject: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var drugs = new UIMenuItem("Have you used any drugs recently?", "");
            drinking.AddItem(drugs);
            drinking.OnItemSelect += async (sender, item, index) =>
            {
                if (item == drugs)
                {
                    //Generate lines
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "I do drugs for my medical condition..",
                        "No drugs.. Drugs make you sick..",
                        "I take prescription pills..",
                        "Why would I use drugs? I don't wanna die...",
                        "I use some drugs for pleasure",
                        "I never used drugs in my life",
                        "I use from time to time",
                        "Do I look like a drug addict?"
                    };

                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Subject: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var Possession = _menuPool.AddSubMenu(stoppedpedsub, "~y~Possession");
            for (int i = 0; i < 1; i++) ;

            Possession.MouseEdgeEnabled = false;
            Possession.ControlDisablingEnabled = false;

            var illegalitems = new UIMenuItem("Anything illegal on you?", "");
            Possession.AddItem(illegalitems);
            Possession.OnItemSelect += async (sender, item, index) =>
            {
                if (item == illegalitems)
                {
                    //Generate lines
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "No sir. I'm harmless..",
                        "I'm a good citizen",
                        "I don't wanna go to jail",
                        "Perhaps I have some..",
                        "I don't know. Check for yourself..",
                        "Nope!",
                        "You don't have the right to touch me",
                        "Maybe yes, maybe no.."
                    };

                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Subject: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var investigationquestions = _menuPool.AddSubMenu(stoppedpedsub, "~y~Investigation Questions");
            for (int i = 0; i < 1; i++) ;

            investigationquestions.MouseEdgeEnabled = false;
            investigationquestions.ControlDisablingEnabled = false;

            var whatsgoingon = new UIMenuItem("What is going on here?", "");
            investigationquestions.AddItem(whatsgoingon);
            investigationquestions.OnItemSelect += async (sender, item, index) =>
            {
                if (item == whatsgoingon)
                {
                    //Generate lines
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "Umm.. I am just as surprised as you are officer",
                        "What are you talking about?",
                        "Shit, I dunno",
                        "All I know is I'm minding my own business",
                        "Shoot beats me",
                        "It is a long story",
                        "Sorry I don't talk to cops",
                        "I am not sure what you mean",
                        "What are you even doing here?"
                    };

                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Subject: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var identificationpresent = new UIMenuItem("Do you have identification on you?", "");
            investigationquestions.AddItem(identificationpresent);
            investigationquestions.OnItemSelect += async (sender, item, index) =>
            {
                if (item == identificationpresent)
                {
                    //Generate lines
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "Yeah I do",
                        "Damn, my brother got it",
                        "If I don't, am I free to go?",
                        "~o~*refuses*",
                        "Ughh here we go again",
                        "I can give you my name if you want",
                        "I do but I'm not giving it to you",
                        "Why do yall always gotta hassle me?",
                        "Of course I always keep it with me"
                    };

                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Subject: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var freetogo = new UIMenuItem("You are free to go now", "");
            investigationquestions.AddItem(freetogo);
            investigationquestions.OnItemSelect += async (sender, item, index) =>
            {
                if (item == freetogo)
                {
                    //Generate lines
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "Thank you I appreciate it",
                        "Yep, thanks for wasting my time",
                        "Stay safe out there officer",
                        "I told you I didn't do anything",
                        "It's about time",
                        "Ahhh sweet freedom",
                        "Do I get paid for the time you wasted",
                        "Always a pleasure",
                        "I appreciate you and your sacrifice"
                    };

                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Subject: ~w~" + possiblefirstnames[firstname]);

                    //Release Ped
                    foreach (Ped peds in World.GetAllPeds())
                    {
                        if (peds != Game.Player.Character & peds.Position.DistanceToSquared(Game.Player.Character.Position) < 10f)
                        {
                            //Freeze Position
                            peds.IsPositionFrozen = false;

                            //Show Notification
                            Screen.ShowNotification("Nearby ped(s) have been released.");

                            //Cancel Tasks
                            API.ClearPedTasks(peds.GetHashCode());
                        }
                    }
                }
            };

            var searchquestions = _menuPool.AddSubMenu(stoppedpedsub, "~y~Search Questions");
            for (int i = 0; i < 1; i++) ;

            searchquestions.MouseEdgeEnabled = false;
            searchquestions.ControlDisablingEnabled = false;

            var vehiclesearch = new UIMenuItem("Do you consent to a search?", "");
            searchquestions.AddItem(vehiclesearch);
            searchquestions.OnItemSelect += async (sender, item, index) =>
            {
                if (item == vehiclesearch)
                {
                    //Big Message
                    //NativeUI.BigMessageThread.MessageInstance.ShowOldMessage("Do you consent to a search?");

                    //Generate lines
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "Why in the HELL would I do something like that?",
                        "No, just no",
                        "You can't be for real right now",
                        "You want me to just let you in all my pockets?",
                        "Ahhh this is the harassment I have seen so much on the news",
                        "Appreciate your offer but I lawfully object",
                        "What if I have a weapon on me?",
                        "Go for it",
                        "Sure, Its not like you are going to find anything"
                    };

                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Subject: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var solicitationquestions = _menuPool.AddSubMenu(stoppedpedsub, "~y~Solicitation Questions");
            for (int i = 0; i < 1; i++) ;

            solicitationquestions.MouseEdgeEnabled = false;
            solicitationquestions.ControlDisablingEnabled = false;

            var howseverythinggoing = new UIMenuItem("How's everything going?", "");
            solicitationquestions.AddItem(howseverythinggoing);
            solicitationquestions.OnItemSelect += async (sender, item, index) =>
            {
                if (item == howseverythinggoing)
                {
                    //Generate lines
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "Just high on life officer",
                        "It could be better, just waiting for my pimp..I mean boyfriend",
                        "I was just on way to the 24/7",
                        "I don't know I'm just out for a walk",
                        "Would be alot better if you left me alone",
                        "My sister died this week so I am not doing well",
                        "It's been cold as hell tonight, and no it's not because of my clothes",
                        "It's been a long week and I just been relaxing?",
                        "Pretty good, how about you?",
                        "I am so ready to get drunk"
                    };

                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Subject: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var recievedsolicitationcalls = new UIMenuItem("We recieved calls you are solicitng", "");
            solicitationquestions.AddItem(recievedsolicitationcalls);
            solicitationquestions.OnItemSelect += async (sender, item, index) =>
            {
                if (item == recievedsolicitationcalls)
                {
                    //Generate lines
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "Hell no do I look like a girl who needs to sell her pussy?",
                        "No,I am just waiting for my Uber officer",
                        "Are you just going to state the obvious all night and waste my time?",
                        "Yes, I am trying to show a few lucky guys a good time",
                        "I would never do that, it's so gross",
                        "People are always slut shaming me because of how I dress",
                        "I swear to you, I am not soliciting",
                        "It's no different than Tinder and that's legal",
                        "I can't help guys just want to pull over and talk to me",
                        "Did you see me solicit sex in anyway?"
                    };

                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Subject: ~w~" + possiblefirstnames[firstname]);
                }
            };

            var loiteringwarning = new UIMenuItem("Just so you know loitering is a crime", "");
            solicitationquestions.AddItem(loiteringwarning);
            solicitationquestions.OnItemSelect += async (sender, item, index) =>
            {
                if (item == loiteringwarning)
                {
                    //Generate lines
                    var firstnamerandom = new Random();
                    var possiblefirstnames = new List<string>
                    {
                        "Am I? Sorry, I didn't realize",
                        "Oh yeah, well I don't really give a shit",
                        "You want me to loiter my pussy on your face huh?",
                        "I pay my taxes too, I should be able to stand on any road I want",
                        "Can you define it for me?",
                        "Nope, I did't throw anything on the ground. Wait that's littering",
                        "Really? I didn't see a sign?",
                        "I've been moving around so that's NOT loitering",
                        "Shit, I think I got a ticket for that before",
                        "I don't think this is the kinda thing you cops should be concerned with"
                    };

                    int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                    //Choose Response
                    Screen.ShowSubtitle("~y~Subject: ~w~" + possiblefirstnames[firstname]);
                }
            };
        }

        public void PedInteraction(UIMenu menu)
        {
            var pedinteractionsub = _menuPool.AddSubMenu(menu, "Ped Interaction");
            for (int i = 0; i < 1; i++) ;

            pedinteractionsub.MouseEdgeEnabled = false;
            pedinteractionsub.ControlDisablingEnabled = false;

            var stopped = new UIMenuItem("Stop the Ped", "");
            pedinteractionsub.AddItem(stopped);
            pedinteractionsub.OnItemSelect += async (sender, item, index) =>
            {
                if (item == stopped)
                {
                    if (stopped.Text == "Stop the Ped")
                    {
                        stoptheped();
                        stopped.Text = "Release Ped";
                    }
                    else if (stopped.Text == "Release Ped")
                    {
                        ped1.Task.ClearAll();
                        API.ClearPedTasks(ped1.GetHashCode());
                        ped1.IsPersistent = false;
                        API.RemoveBlip(ref ped1blip);
                        stopped.Text = "Stop the Ped";
                    }
                }
            };

            var CPR = new UIMenuItem("Perform CPR", "");
            pedinteractionsub.AddItem(CPR);
            pedinteractionsub.OnItemSelect += async (sender, item, index) =>
            {
                if (item == CPR)
                {
                    if (CPR.Text == "Perform CPR")
                    {
                        CPR.Text = "Cancel CPR";
                        //Play animation
                        Game.Player.Character.Task.PlayAnimation("mini@cpr@char_a@cpr_def", "cpr_intro");

                        //Wait
                        await BaseScript.Delay(5000);

                        //Play CPR
                        Game.Player.Character.Task.PlayAnimation("mini@cpr@char_a@cpr_str", "cpr_pumpchest");

                        //Generate possibilities
                        var firstnamerandom = new Random();
                        var possiblefirstnames = new List<string>
                    {
                        "~g~alive",
                        "~r~dead",
                        "~r~dead",
                        "~r~dead",
                        "~r~dead",
                        "~r~dead",
                        "~r~dead",
                        "~r~dead",
                        "~r~dead",
                        "~r~dead",
                        "~r~dead",
                        "~g~alive",
                        "~g~alive",
                        "~g~alive",
                        "~g~alive"
                    };

                        int firstname = firstnamerandom.Next(possiblefirstnames.Count);

                        if (possiblefirstnames[firstname] == "~g~alive")
                        {
                            foreach (Ped peds in World.GetAllPeds())
                            {
                                if (peds != Game.Player.Character & peds.Position.DistanceToSquared(Game.Player.Character.Position) < 5f)
                                {
                                    peds.AttachBlip();

                                    //911 Notification
                                    API.SetNotificationTextEntry("STRING");
                                    API.SetNotificationColorNext(4);
                                    API.AddTextComponentString("The ped is " + possiblefirstnames[firstname]);
                                    API.SetTextScale(0.5f, 0.5f);
                                    API.SetNotificationMessage("CHAR_CALL911", "CHAR_CALL911", false, 0, "Dispatch", "~y~Status Update");
                                    API.DrawNotification(true, false);

                                    //Screen.ShowNotification("The ped is " + possiblefirstnames[firstname]);
                                    API.ResurrectPed(peds.GetHashCode());
                                    peds.Resurrect();
                                    Game.Player.Character.Task.ClearAll();
                                }
                            }
                        }
                        else if (possiblefirstnames[firstname] == "~r~dead")
                        {
                            foreach (Ped peds in World.GetAllPeds())
                            {
                                if (peds != Game.Player.Character & peds.Position.DistanceToSquared(Game.Player.Character.Position) < 10f)
                                {
                                    //911 Notification
                                    API.SetNotificationTextEntry("STRING");
                                    API.SetNotificationColorNext(4);
                                    API.AddTextComponentString("The ped is " + possiblefirstnames[firstname]);
                                    API.SetTextScale(0.5f, 0.5f);
                                    API.SetNotificationMessage("CHAR_CALL911", "CHAR_CALL911", false, 0, "Dispatch", "~y~Status Update");
                                    API.DrawNotification(true, false);

                                    //Screen.ShowNotification("The ped is " + possiblefirstnames[firstname]);
                                    Game.Player.Character.Task.ClearAll();
                                    //Do nothing else
                                }
                            }
                        }
                    }
                    
                    if (CPR.Text == "Cancel CPR")
                    {
                        CPR.Text = "Perform CPR";
                        LocalPlayer.Character.Task.ClearAll();
                    }
                }
            };
        }

        public void VehicleInteraction(UIMenu menu)
        {
            var vehicleinteractionsub = _menuPool.AddSubMenu(menu, "Vehicle Interaction");
            for (int i = 0; i < 1; i++) ;

            vehicleinteractionsub.MouseEdgeEnabled = false;
            vehicleinteractionsub.ControlDisablingEnabled = false;

            var stopvehicle = new UIMenuItem("Stop Vehicle", "");
            vehicleinteractionsub.AddItem(stopvehicle);
            vehicleinteractionsub.OnItemSelect += async (sender, item, index) =>
            {
                if (item == stopvehicle)
                {
                    if (stopvehicle.Text == "Stop Vehicle")
                    {
                        stopthevehicle();
                        stopvehicle.Text = "Release Vehicle";
                    }
                    else if (stopvehicle.Text == "Release Vehicle")
                    {
                        vehicle1.IsEngineRunning = true;
                        vehicle1.IsPositionFrozen = false;
                        vehicle1.IsPersistent = false;
                        Screen.ShowNotification("Vehicle has been released");
                        stopvehicle.Text = "Stop Vehicle";
                    }
                }
            };
        }

        public Main()
        {
            //INI
            string resourcename = API.GetCurrentResourceName();
            string data = Function.Call<string>(Hash.LOAD_RESOURCE_FILE, resourcename, "config.ini");
            int menukey = Int32.Parse(data);

            //Menu Information
            _menuPool = new MenuPool();
            var mainMenu = new UIMenu("FivePD Questions", "Mod by Abel Gaming");
            _menuPool.Add(mainMenu);
            TrafficStopQuestions(mainMenu);
            StoppedPedQuestions(mainMenu);
            PedInteraction(mainMenu);
            VehicleInteraction(mainMenu);
            _menuPool.RefreshIndex();
            _menuPool.MouseEdgeEnabled = false;
            _menuPool.ControlDisablingEnabled = false;

            //Events
            EventHandlers["playerSpawned"] += new Action(playerSpawned);

            //Tick Event
            Tick += OnTick;

            Tick += async () =>
            {
                _menuPool.ProcessMenus();
                foreach (Ped peds in World.GetAllPeds())
                {
                    if (peds != LocalPlayer.Character & peds.Position.DistanceToSquared(LocalPlayer.Character.Position) < 10f & API.IsControlJustPressed(0, menukey) && !_menuPool.IsAnyMenuOpen())
                    {
                        mainMenu.Visible = !mainMenu.Visible;
                    }
                }
            };
        }

        private void playerSpawned()
        {
            Screen.ShowNotification("Running FivePD Interaction Questions by Abel Gaming");
        }

        private void OnClientResourceStart(string resourceName)
        {
            
        }

        private async Task OnTick()
        {
            
        }

        private Ped stoptheped()
        {
            Ped[] allPeds = World.GetAllPeds();
            if (allPeds.Length == 0)
                return (Ped)null;
            float num = float.MaxValue;
            ped1 = (Ped)null;
            foreach (Ped ped2 in allPeds)
            {
                if (!Entity.Equals((Entity)Game.PlayerPed, (Entity)ped2))
                {
                    float distance = World.GetDistance(((Entity)ped2).Position, ((Entity)Game.PlayerPed).Position);
                    if ((double)distance < (double)num)
                    {
                        ped1 = ped2;
                        num = distance;
                    }
                }
            }

            //Block Events
            ped1.BlockPermanentEvents = true;

            //Do Tasks
            ped1.Task.StandStill(-1);
            API.TaskStandStill(ped1.GetHashCode(), -1);

            //Show notification
            Screen.ShowNotification("Ped has been stopped");

            //Make ped persistent
            ped1.IsPersistent = true;

            //Create blip
            ped1blip = API.AddBlipForEntity(ped1.GetHashCode());

            return ped1;
        }

        private Vehicle stopthevehicle()
        {
            Vehicle[] allVehicles = World.GetAllVehicles();
            if (allVehicles.Length == 0)
                return (Vehicle)null;
            float num = float.MaxValue;
            vehicle1 = (Vehicle)null;
            foreach (Vehicle vehicle2 in allVehicles)
            {
                if (!Entity.Equals((Entity)Game.PlayerPed.CurrentVehicle, (Entity)vehicle2))
                {
                    float distance = World.GetDistance(((Entity)vehicle2).Position, ((Entity)Game.PlayerPed).Position);
                    if ((double)distance < (double)num)
                    {
                        vehicle1 = vehicle2;
                        num = distance;
                    }
                }
            }

            //Turn Engine Off
            vehicle1.IsEngineRunning = false;

            //Freeze position
            vehicle1.IsPositionFrozen = true;

            //Show notification
            Screen.ShowNotification(vehicle1.DisplayName + " has been stopped");

            //Make persistent
            vehicle1.IsPersistent = true;

            //Return
            return vehicle1;
        }
    }
}

//1.0.8 Changes

    //Changed the animation of the CPR function
    //Switched revive function to use the CitizenFX so the disappearing ped issue would be resolved