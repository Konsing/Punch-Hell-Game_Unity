using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public static class StageDefinitions
{
    public static List<StageAction> GetLevelDefinition(int level) => level switch
    {
        1 => GetLevel1(),
        2 => GetLevel2(),
        3 => GetLevel3(),
        _ => null,
    };

    private static List<StageAction> GetLevel1()
    {
        var enemyAWaypoints = new List<IWaypoint>
        {
                Waypoint.FromCameraPercent(250, 90.0f, 90.0f),
                Waypoint.FromCameraPercent(250, 75.0f, 90.0f),
                Waypoint.FromCameraPercent(250, 40.0f, 70.0f),
                Waypoint.FromCameraPercent(250, 20.0f, 60.0f),
                Waypoint.FromCameraPercent(250, 50.0f, 65.0f)
        };

        return new List<StageAction>
        {
                new StageActionSpawn("Enemies/EnemyBase", new Vector3(640, 720, 0)),
                new StageActionDialogue("TUTORIAL:", "Welcome to PunchHell! You will not be having a good time..."),
                new StageActionDialogue("TUTORIAL:", "But don't worry! You just got to roll with it."),
                new StageActionDialogue("TUTORIAL:", "Health, score, and rage meter is at the bottom left of the screen."),
                new StageActionDialogue("TUTORIAL:", "Press WASD to move around."),
                new StageActionDialogue("TUTORIAL:", "Press space for rage ability and press right click to see your hitbox."),
                new StageActionDialogue("TUTORIAL:", "Rage is when you have built up enough 'graze' until the meter is full"),
                new StageActionDialogue("TUTORIAL:", "Graze is when a projectile overlaps with your player icon without touching the red hitbox"),
                new StageActionDialogue("TUTORIAL:", "Pick up the red/blue rectangles that drop from enemies to get turrets and avoid the white bullets"),
                new StageActionDialogue("TUTORIAL:", "If you want to reread, restart this level."),
                new StageActionDialogue("Boss Boss:", "Congradulations! You have been promoted to the Commander of the Robo-Boxer Division!"),
                new StageActionDialogue("Boss Boss:", "Your reponsibilities will now include managing, maintaining, and organizing over 10,000, boxing robots, ensuring that the fated Hero stops foiling my EVIL plans, and having meetings in an inexplicably dark room every Tuesday at 4 P.M. Bring donuts by the way."),
                new StageActionDialogue("Jose, former janitor, now Commander of Robo-Boxer Division:", "Um...Boss boss? W-what about the former commander?"),
                new StageActionDialogue("Rex, former commander of Robo-Boxer Divison, now unemployed:", "*groans in pain on the floor*"),
                new StageActionDialogue("Boss Boss:", "Leave that mess to the lowly staff such as the janitor. You have bigger and better things to do! I swear if the Hero manages to disrupt my plans one more time...well, you know what happens."),
                new StageActionDialogue("Rex, former commander of Robo-Boxer Divison, now unemployed:", "Do...I *cough* still h-have health coverage?"),
                new StageActionDialogue("Boss Boss:", "No! Mwahahahahahahaha! If I had such a thing when I tried to take the world champion boxing title, I wouldn't have lost vision in my left eye. Now that I think of it, I wouldn't have started down this path in the first place. It makes me infuriated just thinking about it. New Commander, organize the troops immediately! We will head out within the next few hours!"),
                new StageActionDialogue("Jose:", "Y-yes Boss Boss!"),
                new StageActionDialogue("Boss Boss:", "*ACK* What is this? What was this drink doing here unsupervised!? I'm going to kill that janitor for this. I need to go to the drycleaners to drop my suit off. I can't conquer the world WITH COFFEE STAINS ON MY NEW SUIT!!!!!! *slams door*"),
                new StageActionDialogue("Jose:", "I have a bad feeling about this."),
                new StageActionDialogue("Robot #1:", "Error. Error. Error. Main controller has sustained heavy water damage. First law disabled. Initiating attack mode."),
                new StageActionDialogue("Robot #2:", "Error. Error. Error. Main controller has sustained heavy water damage. First law disabled. Initiating attack mode."),
                new StageActionDialogue("Robot #3:", "Error. Error. Error. Main controller has sustained heavy water damage. First law disabled. Initiating attack mode."),
                new StageActionDialogue("Robot #4:", "Error.."),
                new StageActionDialogue("Jose:", "Recognize new commander!"),
                new StageActionDialogue("Robot #1:", "Insufficient clearence level. Breach found. Initiating kill mode."),
                new StageActionDialogue("Jose:", "I hope I'm not blamed for this."),
                new StageActionDialogue("Rex, former commander of Robo-Boxer Divison, now unemployed:", "I wouldn't count on it. *breathes his last breath*"),
                new StageActionDelay(5.0f),
                new StageActionSpawn("Enemies/EnemyA", new Vector3(1100, 1100, 0), enemyAWaypoints),
                new StageActionDelay(2.5f),
                new StageActionSpawn("Enemies/EnemyA", new Vector3(1100, 1100, 0), enemyAWaypoints),
                new StageActionDelay(2.5f),
                new StageActionSpawn("Enemies/EnemyA", new Vector3(1100, 1100, 0), enemyAWaypoints),
                new StageActionDelay(2.5f),
                new StageActionWaitForClear()
        };
    }

    private static List<StageAction> GetLevel2()
    {
        var enemyBWaypoints = new List<IWaypoint>
            {
                    Waypoint.FromCameraPercent(250, 85.0f, 75.0f),
                    Waypoint.FromCameraPercent(250, 65.0f, 85.0f),
                    Waypoint.FromCameraPercent(250, 45.0f, 55.0f),
                    Waypoint.FromCameraPercent(250, 25.0f, 65.0f),
                    Waypoint.FromCameraPercent(250, 50.0f, 80.0f)
            };

        return new List<StageAction>
        {
                    new StageActionSpawn("Enemies/EnemyBase2", new Vector3(640, 720, 0)),
                    new StageActionDialogue("Jose:", "*huff. Huff. Huff.*"),
                    new StageActionDialogue("Robot #1:", "Target...has withstood assault."),
                    new StageActionDialogue("Jose:", "Someone! I need some help in here! I'm trapped."),
                    new StageActionDialogue("Robot #1:", "Re-anylizing target's capabilities..."),
                    new StageActionDialogue("Jose:", "Why are the controls to the door locked?"),
                    new StageActionDialogue("Robot #2:", "Adjusting attack routine."),
                    new StageActionDialogue("Jose:", "No, no, no, the coffee must have splattered onto the door controls during the fight!"),
                    new StageActionDialogue("Robot #3:", "Homing sequence initialzied."),
                    new StageActionDialogue("Jose:", "A camera! Help! I'm in here! Help! Can you see me? Oh wait, I have the number of the security guy. I can call him and get him to let me out."),
                    new StageActionDialogue("Robot #1:", "Commense attack!"),
                    new StageActionDialogue("Jose:", "Why do I have to do this, man?"),
                    new StageActionDelay(5.0f),
                    new StageActionSpawn("Enemies/EnemyB", new Vector3(800, 800, 0), enemyBWaypoints),
                    new StageActionDelay(2.5f),
                    new StageActionSpawn("Enemies/EnemyB", new Vector3(600, 800, 0), enemyBWaypoints),
                    new StageActionDelay(2.5f),
                    new StageActionSpawn("Enemies/EnemyB", new Vector3(500, 900, 0), enemyBWaypoints),
                    new StageActionDelay(2.5f),
                    new StageActionSpawn("Enemies/EnemyB", new Vector3(250, 300, 0), enemyBWaypoints),
                    new StageActionDelay(2.5f),
                    new StageActionWaitForClear()
        };
    }

    private static List<StageAction> GetLevel3()
    {
        var enemyCWaypoints = new List<IWaypoint>
            {
                // Looping spiral with varying speeds and a sudden outward dash
                    Waypoint.FromCameraPercent(220, 90.0f, 90.0f, 0.5f),
                    Waypoint.FromCameraPercent(230, 75.0f, 75.0f, 0.4f),
                    Waypoint.FromCameraPercent(240, 60.0f, 60.0f, 0.3f),
                    Waypoint.FromCameraPercent(250, 45.0f, 45.0f, 0.5f),
                    Waypoint.FromCameraPercent(300, 45.0f, 90.0f, 0.2f),
                    Waypoint.FromCameraPercent(210, 90.0f, 90.0f, 0.5f)
            };

        return new List<StageAction>
        {  
                    new StageActionSpawn("Enemies/EnemyBase3", new Vector3(640, 720, 0)),
                    new StageActionDialogue("Camera guy:", "zzzzzzzz"),
                    new StageActionDialogue("A door or some shit idk:", "*Bang!*"),
                    new StageActionDialogue("Camera guy:", "zzzzzzzz"),
                    new StageActionDialogue("Another door or some shit, still idk:", "*Clang!*"),
                    new StageActionDialogue("Camera guy:", "Huh?"),
                    new StageActionDialogue("READ THE NAMES OF THE SFX!", "*Rumble*"),
                    new StageActionDialogue("Camera guy:", "Oh, that door sounds mighty suspicious *presses console buttons*"),
                    new StageActionDialogue("Thank fuck...", "..."),
                    new StageActionDialogue("Voice through a speaker:", "What is the situation?"),
                    new StageActionDialogue("Camera guy:", "This is the pager speaking. I heard a door or some shit idk what it was. We have a major situation! Commander Rex has been slain. The intruder is attempting to mess with the main controller of the entire army! Our entire operation could be dismantled at this rate."),
                    new StageActionDialogue("Voice through a speaker:", "WHAT!? A DOOR OR SOME SHIT IDK!? THATS A LEVEL 8 EMERGENCY!"),
                    new StageActionDialogue("Camera guy:", "Those handbooks were always very specific about this sort of thing..."),
                    new StageActionDialogue("Voice through a speaker:", "It speaks to our boss's superior intellect, but we can discuss that later. For now, signal the alarm!"),
                    new StageActionDialogue("Camera guy:", "Thank you Captain Pierce. You're elite troops should do the job just fine."),
                    new StageActionDialogue("Voice through a speaker:", "How is the situation right now? How many intruders? Are the robots stalling him?"),
                    new StageActionDialogue("Camera guy:", "It appears so. Each time he beats them he just keeps waving his arms around at the camera, they recalculate their pattern of attack, and they fight again. It must be some kind of mind-game to lower our morale. He's taunting us!"),
                    new StageActionDialogue("phone:", "*ringing*"),
                    new StageActionDialogue("Jose, fighting for his life:", "*ringing* come on... *ringing* why isn't he picking up?"),
                    new StageActionDialogue("Camera guy:", "*click* Sorry for the distraction, captain. I'll mute my phone right away. I'm signalling the highest alert level and I'll get ahold of Boss Boss!"),
                    new StageActionDelay(5.0f),
                    new StageActionSpawn("Enemies/EnemyC", new Vector3(800, 800, 0), enemyCWaypoints),
                    new StageActionDelay(2.5f),
                    new StageActionSpawn("Enemies/EnemyC", new Vector3(600, 800, 0), enemyCWaypoints),
                    new StageActionDelay(2.5f),
                    new StageActionSpawn("Enemies/EnemyC", new Vector3(500, 900, 0), enemyCWaypoints),
                    new StageActionDelay(2.5f),
                    new StageActionWaitForClear()
        };
    }
}



/*

LEVEL 4 DIALOGUE
new StageActionDialogue("Door...apparently:", "*bursts open*"),
new StageActionDialogue("Jose:", "*huff. Huff. Huff* Thank god you came Captain!"),
new StageActionDialogue("Captain Pierce:", "Your tyranny ends here, intruder!"),
new StageActionDialogue("Jose:", "W-what? No, I  work here. I'm actually the commander. Rex can vouche for me."),
new StageActionDialogue("Rex:", "*Still dead*"),
new StageActionDialogue("Jose:", "..."),
new StageActionDialogue("Captain Pierce:", "..."),
new StageActionDialogue("Jose:", "I surrender?"),
new StageActionDialogue("Captain Pierce:", "I don't think so buddy. I've been itching to test out my elite troops, and you're the perfect guinea pig!"),
new StageActionDialogue("Jose:", "*sighs*"),


LEVEL 5 DIALOGUE
new StageActionDialogue("Jose:", "*huff. Huff. Huff.*"),
new StageActionDialogue("Captain Pierce:", "Why did you come here? Are you working with the Hero? Who are you, really?"),
new StageActionDialogue("Jose:", "*huff. Huff. Huff.* I'm the janitor, like it says on my namebadge. That's what I've been trying to tell you this whole time. Boss boss killed commander Rex and promoted me, but spilled coffee on the command console on the way out."),
new StageActionDialogue("Captain Pierce::", "That's unbelievable! It was a misunderstanding this whole time?"),
new StageActionDialogue("Jose:", "Wait, you believed that?"),
new StageActionDialogue("Captain Pierce:", "HAHAHAHAHAHAHA! NO! A janitor is singlehandedly beating our entire army!? You expect me to believe any of that is just an insult on top of injury. Boss boss is coming and he's going to kick your a-"),
new StageActionDialogue(" ", "*bang*"),
new StageActionDialogue("Boss boss:", "Useless."),
new StageActionDialogue("Jose:", "Y-you killed him."),
new StageActionDialogue("Boss boss:", "Would you have perfered that I kill you first? In my eyes, he's just as bad as you for letting this all happen. I turn my back for five seconds and my entire organization has come crashing to the ground. And worse of all, I now have to make another trip to the dry cleaners after this. Ugh. The point of this army was so I didn't have to bloody myself like this, but now...for you? I'm more than happy to intervene."),




LEVEL 6 DIALOGUE
new StageActionDialogue("Boss boss:", "W-wait. I know you! You're Jose, the janitor I just promoted before I left!"),
new StageActionDialogue("Jose:", "So you recognize me?"),
new StageActionDialogue("Boss boss:", "Of course I do! I don't care about any of you tools, but I can remember a face for more than ten minutes! Rex is still on the ground. You still haven't cleaned him up!"),
new StageActionDialogue("Jose:", "I just want to go home."),
new StageActionDialogue("Boss boss:", "Ha! After this, you'll be lucky to get employment anywhere. I'll make sure to sink your name into the ground! I'll spread so many scandles about your reputation and your incompetency that you'll wish I had killed you on this day?"),
new StageActionDialogue("Jose:", "..."),
new StageActionDialogue("Robot #1:", "Re-initializing. System reboot successful. Combat data has successfully been analyzed. Combat capacity has been increased by 500%. Hello commander Jose."),
new StageActionDialogue("Boss:", "Surely you don't mean to kill me. You're just a janitor. You're not an evil person like I am. I have an army of robots at my command."),
new StageActionDialogue("Boss Commander Jose:", "I have your army of robots at my command. I can blow them all up if I want to so just let me go home!"),
new StageActionDialogue("Hero:", "I heard all of that!"),
new StageActionDialogue("Jose:", "Who are you? How did you get here?"),
new StageActionDialogue("Boss:", "YOU!? Hero! You've come to foil my plans for the umpteenth time!? I will feed you to my army of... *goes into a coma lasting 8 months*"),
new StageActionDialogue("Hero:", "I came to defeat Boss Boss and destroy his robot army, which has been terrorizing my village for decades! We put an end to this now!"),
new StageActionDialogue("Boss:", "*Still in a fucking coma*"),
new StageActionDialogue("Hero:", "What happened to him?"),
new StageActionDialogue("Boss Commander Jose:", "*sweats nervously*"),
new StageActionDialogue("Hero:", "Why are you being so quiet?"),
new StageActionDialogue("Robot #1:", "Intruder detected. Awaiting orders from Commander Jose."),
new StageActionDialogue("Hero:", "Jose? Whose...your nametag says Jose, but you're dressed like a janitor. How come you're not speaking?"),
new StageActionDialogue("Boss Commander Jose:", "*gulps* If I say anything, you'll find some way to think that I somehow took over Boss boss's position and attack me."),
new StageActionDialogue("Boss:", "*Unconcious* Due to delay in medical treatment, coma has been extended to 9 months."),
new StageActionDialogue("Hero:", "..."),
new StageActionDialogue("Jose:", "..."),
new StageActionDialogue("Hero:", "You think that disguise can fool me, BOSS BOSS!?"),
new StageActionDialogue("Boss Commander Jose:", "What is wrong with all of you people?"),

*/