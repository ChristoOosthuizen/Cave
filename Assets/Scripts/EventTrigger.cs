using UnityEngine;
using ShinobiTools;
using System.Collections;
using System.Collections.Generic;

public class EventTrigger : ShinobiMono{

    //List of all possible events that the trigger can call
    public List<Animator> animations;

    //Audio source
    public SECTR_AudioCue audioCue;

    //Can the events be triggered more than once
    public bool oneShot;

    //Only has a single event
    public bool singleEvent;

    //Can the event be triggered?
    public bool readyToTrigger;

    public float timeToReset = 2.5f;

    public bool playRandom;

    //Audio component of event.
    public bool playAudio;

    //Animation component of event.
    public bool playAnimation;
    //What event to play
    public int eventNumber = 0;

    public Vector3 audioLocation;

    void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (readyToTrigger)
        {
            //Starts timer to reset event
            if (!singleEvent)
                SetTimer(timeToReset, false, () => { ResetTrigger(eventNumber); }); 

            //Plays animation if event supports animation
            if (playAnimation)
            {
                //selects a random animation
                if (playRandom)
                {
                    eventNumber = Random.Range(0, animations.Count - 1);
                }
                //Plays the animation
                if (animations[eventNumber] != null)
                    animations[eventNumber].SetBool("trigger", true);

                //If it is one shot, remove animation from queue
                if (oneShot)
                {
                    if (animations[eventNumber] != null)
                        animations.Remove(animations[eventNumber]);

                }
                if (eventNumber + 1 < animations.Count)
                {
                    eventNumber++;
                }
            }

            //Plays audio if event supports audio
            if (playAudio)
            {
                //Plays audio
                SECTR_AudioSystem.Play(audioCue, audioLocation, false);
            }

            //Sets cooldown on trigger
            readyToTrigger = false;

        }
    }

    private void ResetTrigger(int prevEventNumber)
    {
        readyToTrigger = true;
        if (!oneShot && playAnimation)
        {
            if (playAnimation)
            {
                animations[prevEventNumber].SetBool("trigger", false);
            }
        }
    }
}
