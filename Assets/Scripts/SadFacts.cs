using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SadFacts : MonoBehaviour
{
    public TMP_Text fact;
    public GameObject panel;
    public float delay;
    public AudioClip factSound;
    float tempT;
    int tempInd;

    List<string> facts = new List<string>() { "One way to deal with the space junk is to send it back to Earth, burning it up in the atmosphere during reentry.",
        "The space debris all travel by fast enough for a relatively small piece of orbiting debris to damage a satellite or a space craft.",
        "According to the National Oceanic and Atmospheric Administration, an average total between 200 – 400 tracked space debris enter Earth’s atmosphere every year.",
        "On February 10, 2009, a privately owned American communication satellite, Iridium-33, accidentally crashed into a Russian military satellite, Kosmos 2251, marking the first ever accidental in-orbit collision.",
        "Donald Kessler, a NASA scientist, imagined what is now known as “Kessler Syndrome” in which he theorized that continuous collisions of man-made objects in space will potentially destroy telecommunications and keep humanity trapped on Earth.",
        "There are about 4,700 satellites still in space, but only an approximate 1,800 are still working.", "In 2007, China deliberately destroyed one of their weather satellites to test a new weapon which contributed to over 3,000 pieces of space debris — the largest ever tracked.", "Space debris is also known as orbital debris, space junk, space waste, space trash, space litter, or space garbage.",
        "Chain reaction of collisions of debris increases the cost of protection for spacecraft missions and has a great potential of destroying live satellites.",
        "Space junk is not only a threat to active satellites and spaceships but also to Earth and its habitants.",
        "According to NASA, an average of one cataloged piece of debris has fallen back to Earth each day for the past 50 years.",
        "Despite their size, there has been no significant property damage from the debris to Earth yet",
        "Major contributors to space debris include the explosion of upper stages and satellite collisions.",
        "According to the ESA, debris up to 1 cm could cause critical damage while anything larger than 10 cm could shatter a satellite or spacecraft into pieces." };

    // Start is called before the first frame update
    private void Start()
    {
        panel.SetActive(true);

        tempT = 0;
        fact.text = facts[Random.Range(0, facts.Count - 1)];
    }



    // Update is called once per frame
    void Update()
    {
        tempT += Time.deltaTime;

        if(tempT >= delay)
        {
            GetComponent<AudioSource>().PlayOneShot(factSound);
            panel.SetActive(true);

            tempT = 0;
            fact.text = facts[Random.Range(0, facts.Count - 1)];
        }
    }
}
