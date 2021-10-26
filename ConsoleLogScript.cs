using UnityEngine;

public class ConsoleLogScript : MonoBehaviour
{
	public DebugEnablerScript debug;

	private string myLog = "Debug Console Output:";

	private bool doShow;

	private int kChars = 700;

	private int enters;

	private int id;

	public string[] code;

	private void OnEnable()
	{
		Application.logMessageReceived += Log;
	}

	private void OnDisable()
	{
		Application.logMessageReceived -= Log;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			enters++;
			if (enters > 9)
			{
				doShow = !doShow;
			}
		}
		if (doShow && id < code.Length && Input.GetKeyDown(code[id]))
		{
			id++;
			if (id == code.Length)
			{
				debug.EnableDebug();
			}
		}
	}

	public void Log(string logString, string stackTrace, LogType type)
	{
		myLog = myLog + "\n" + logString;
		if (myLog.Length > kChars)
		{
			myLog = myLog.Substring(myLog.Length - kChars);
		}
	}

	private void OnGUI()
	{
		if (doShow)
		{
			GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.width / 1280f, Screen.height / 720, 1f));
			GUI.TextArea(new Rect(0f, 479.9952f, 426.6624f, 239.9976f), myLog);
		}
	}
}
