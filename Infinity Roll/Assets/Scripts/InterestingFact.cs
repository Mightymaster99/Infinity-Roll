using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterestingFact : MonoBehaviour {

    int lengthOfFacts;

    string[] facts = new string[] {
        "This game was made in 3 days for the UDC Game Jam! The theme was \"Only one button!\"",
        "The only control for this game is the Space Bar Button. As long as that works, you don't need any other button!",
        "This game was inspired by the dinosaur game from Google Chrome when there is no wifi!",
        "This game is the result of my first Game Jam!",
        "While this is my first Game Jam, this isn't my first game! My first is on the Google Play Store, titled \"Crosses\" and it's produced by \"Basil Leaf Games\"!",
        "If you roll off the edge of a platform without jumping, you can actually jump while you fall!",
        "You can do a sort of \"Climb\" up the side of platform, provided you collide with the upper half of it!",
        "The music is the result of not being able to sleep at 2 am and took a half hour to make. Thankfully, the weekend had just started.",
        "Due to a glitch in the current version of the game, you can actually die from the coin. It would take 158 coins.",
        "The coin actually pushes you back very slightly, instead of speeding you up. This is a glitch, and it's not from a negative sign.", //This is the 10th one!
        "There is no mute button! That would break the UDC Theme. If you don't like the music, mute the tab or device.", 
        "The glitchiest item in the game is currently the coin. That's because it is completely solid I'm still learning to twist its mechanics."
    };

    public void ChangeName() {
        this.gameObject.GetComponent<Text>().text = "Fun Fact: " + facts[Random.Range(0, facts.Length)];
    }

}
