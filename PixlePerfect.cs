using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixlePerfect : MonoBehaviour {

    public static float pixlesToUnits = 1f;
    public static float scale = 1f;

    public Vector2 nativeRes = new Vector2(1920, 1080);
    void Awake() {
        var camera = GetComponent<Camera>();

        if (camera.orthographic) {
            scale = Screen.height / nativeRes.y;
            pixlesToUnits *= scale;

            camera.orthographicSize = (Screen.height / 2) / pixlesToUnits;
        }

    }


}