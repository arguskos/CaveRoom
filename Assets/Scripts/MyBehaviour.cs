using UnityEngine;
using System.Collections;
using SynchronizerData;


public class MyBehaviour : MonoBehaviour
{

    public Vector3[] beatPositions;

    private BeatObserver beatObserver;
    private int beatCounter;


    void Start()
    {
        beatObserver = GetComponent<BeatObserver>();
        beatCounter = 0;
    }

    void Update()
    {
        if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat)
        {
           
        }
        if ((beatObserver.beatMask & BeatType.DownBeat) == BeatType.DownBeat)
        {
            transform.position = beatPositions[beatCounter];
            beatCounter = (++beatCounter == beatPositions.Length ? 0 : beatCounter);
        }
    }
}
