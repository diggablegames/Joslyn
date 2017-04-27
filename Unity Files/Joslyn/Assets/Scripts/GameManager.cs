using UnityEngine;

static class GameManager
{
	// so, these items are available project-wide: Enjoy!
//	public static GUIController guiController;
	public static GoogleSheets googleSheets;
	public static PanelController panelController;

	// when the program launches, GameManager will check that all the needed elements are in place
	// that's exactly what you do in the static constructor here:
	static GameManager()
	{
		GameObject g;
//		g = safeFind("__GUIController");
//		guiController = (GUIController)SafeComponent( g, "GUIController" );
		g = safeFind("GameController");
		googleSheets = (GoogleSheets)SafeComponent( g, "GoogleSheets" );
		panelController = (PanelController)SafeComponent( g, "PanelController" );

#if UNITY_IPHONE
		//iPhone specific controllers here
#elif UNITY_ANDROID
		//android specific controllers here
#endif
	}


	// when GameManager wakes up, it checks everything is in place - it uses these routines to do so
	private static GameObject safeFind(string s)
	{
		GameObject g = GameObject.Find(s);
		if ( g == null ) BigProblem("The " +s+ " game object is not in this scene. You're stuffed.");
		return g;
	}
	private static Component SafeComponent(GameObject g, string s)
	{
		Component c = g.GetComponent(s);
		if ( c == null ) BigProblem("The " +s+ " component is not there. You're stuffed.");
		return c;
	}
	private static void BigProblem(string error)
	{
		for (int i=10;i>0;--i) Debug.LogError(" >>>>>>>>>>>> Cannot proceed... " +error);
		for (int i=10;i>0;--i) Debug.LogError(" !!! Is it possible you just forgot to launch from scene zero, the __preEverythingScene scene.");
		Debug.Break();
	}
}

