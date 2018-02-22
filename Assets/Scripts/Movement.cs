using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    static Vector3 UpDelta;
    static Vector3 LeftDelta;
    static Vector3 DownDelta;
    static Vector3 RightDelta;
    public float TurnDelta = 0.3f;
    public float MovementDelta = 0.3f;
    static float Delta = 0.3f;
    public float Step = 1.0f;
    public float StepDelta = 0.001f;

    static Movement()
    {
        Movement.SetDeltas(null);
    }

    static void SetDeltas(GameObject go)
    {
        UpDelta = Vector3.forward * Delta;
        LeftDelta = Vector3.left * Delta;
        DownDelta = Vector3.back * Delta;
        RightDelta = Vector3.right * Delta;
    }

    // Update is called once per frame
    void Update () {
        bool step = false;
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Movement.UpDelta * Step);
            step = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Movement.LeftDelta * Step);
            step = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Movement.DownDelta * Step);
            step = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Movement.RightDelta * Step);
            step = true;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            gameObject.transform.Rotate(0, -TurnDelta, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            gameObject.transform.Rotate(0, TurnDelta, 0);
        }

        Movement.Delta = MovementDelta;
        SetDeltas(gameObject);

        if (step)
        {
            Step -= StepDelta;
            if(Step < 0
                || Step > 1)
            {
                StepDelta *= -1;
            }
        }
        else
        {
            Step = 0.5f;
        }
	}
}
