using UnityEngine;
using System.Collections;
using SynchronizerData;


public class CubeBehavior : MonoBehaviour
{

    private Animator anim;
    private BeatObserver beatObserver;


    void Start()
    {
        anim = GetComponent<Animator>();
        beatObserver = GetComponent<BeatObserver>();
    }

    void Update()
    {
        if ((beatObserver.beatMask & BeatType.DownBeat) == BeatType.DownBeat)
        {
            //  transform.Rotate(Vector3.up, 45f);
            transform.Rotate(Vector3.forward, 45f);

        }
        if ((beatObserver.beatMask & BeatType.UpBeat) == BeatType.UpBeat)
        {
            print("Up");
            //transform.Rotate(Vector3.forward, 45f);
        }
    }
}
