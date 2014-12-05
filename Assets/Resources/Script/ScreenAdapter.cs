using UnityEngine;
using System.Collections;

public class ScreenAdapter {
	public static readonly float SCREEN_WIDTH = 640;
	public static readonly float SCREEN_HEIGHT = 960;
	
	public static float RATIO_W = SCREEN_WIDTH/Screen.width;
	public static float RATIO_H = SCREEN_HEIGHT/Screen.height;

	public static float FONT_RATIO = Screen.width/SCREEN_WIDTH;
	public static int STD_FONT_SIZE = 45;

	public static Rect Translate(Rect inputRect){
		Rect res = new Rect ();
		res.x = inputRect.x / RATIO_W;
		res.y = inputRect.y / RATIO_H;
		res.width = inputRect.width / RATIO_W;
		res.height = inputRect.height / RATIO_H;

		return res;
	}

    public static Vector3 transformVector(Vector3 vector) {
        vector.x /= RATIO_W;
        vector.y /= RATIO_H;
        return vector;
    }

	public static int AdaptFontSize(){
		return (int)(STD_FONT_SIZE * FONT_RATIO);
	}

	public static int AdaptFontSize(int fontSize){
		return (int)(fontSize * FONT_RATIO);
	}
}
