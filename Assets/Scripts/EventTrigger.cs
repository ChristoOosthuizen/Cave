<<<<<<< HEAD
﻿
using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> 33b156abcf5d0296cc1fba698ef0c62835f52d6d
using ShinobiTools;
using System.Collections;
using System.Collections.Generic;

<<<<<<< HEAD
public class EventTrigger : ShinobiMono
{
=======
public class EventTrigger : ShinobiMono{
>>>>>>> 33b156abcf5d0296cc1fba698ef0c62835f52d6d

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

<<<<<<< HEAD
    void Start()
    {

    }
=======
    void Start () {
	
	}
>>>>>>> 33b156abcf5d0296cc1fba698ef0c62835f52d6d

    void OnTriggerEnter(Collider other)
    {
        if (readyToTrigger)
        {
            //Starts timer to reset event
            if (!singleEvent)
<<<<<<< HEAD
                SetTimer(timeToReset, false, () => { ResetTrigger(eventNumber); });
=======
                SetTimer(timeToReset, false, () => { ResetTrigger(eventNumber); }); 
>>>>>>> 33b156abcf5d0296cc1fba698ef0c62835f52d6d

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
