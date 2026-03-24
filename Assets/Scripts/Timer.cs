using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEditor.Overlays;
using UnityEngine;

public class Timer
{
	private static readonly Stopwatch stopwatch = new();
	private static  List<long> steps = new();

	private List<long> previousSteps = new();

	public static bool IsRunning
	{
		get => stopwatch.IsRunning;
	}

	public static double ElapsedSeconds
	{
		get => stopwatch.ElapsedMilliseconds * 0.001f;
	}

	public static int StepsCount
	{
		get => steps.Count;
	}

	public static double GetStepElapsedSeconds(int index)
	{
		return steps[index] * 0.001f;
	}

	/// <summary>
	/// Reset the timer and remove any steps.
	/// </summary>
	public static void Reset()
	{
		stopwatch.Reset();
		steps.Clear();
	}

	public static void Start()
	{
		stopwatch.Start();
	}

	public static void Stop()
	{
		stopwatch.Stop();
	}

	public static void Step()
	{
		steps.Add(stopwatch.ElapsedMilliseconds);
	}

	public static void Save()
	{
		// TODO : save our time steps (line 7 of this script) inside a file.
		Timer data = new Timer();
		//data.steps = steps;

		string json = JsonUtility.ToJson(data, true);
		string path = Application.persistentDataPath + "/Score.json";
		System.IO.File.WriteAllText( path, json );
	}

	public static void Load()
	{
		// TODO : load our time steps from a file (if we have any)
		// and store them inside our steps variable (line 7 of this script)
		// to show them to the player before starting a race.
		string path = Application.persistentDataPath + "/Score.json";
		if (File.Exists(path))
		{
			string json = System.IO.File.ReadAllText(path);
			Timer loadedData = JsonUtility.FromJson<Timer>(json);
			//List<long> loadedListe = new List<long>(data.steps);

			//Timer.List.previousSteps = loadedListe;
		}

		
	}
}
