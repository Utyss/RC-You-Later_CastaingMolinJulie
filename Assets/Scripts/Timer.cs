using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.IO;
using UnityEditor.Overlays;
using UnityEngine;


public static class Timer
{
	private static readonly Stopwatch stopwatch = new();
	public static  List<long> steps = new();
    private static string saveLocation => Application.dataPath + "/../Score.txt";


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
        

        //Timer dataScore = new Timer();
        FileStream stream = new FileStream(saveLocation, FileMode.Create);
		StreamWriter writer = new StreamWriter(stream);
		foreach(long step in steps)
		{
			writer.WriteLine(step);
		}
		writer.Close();
		stream.Close();

		UnityEngine.Debug.Log("Score saved at" + saveLocation);
	}

	public static void Load()
	{
		// TODO : load our time steps from a file (if we have any)
		// and store them inside our steps variable (line 7 of this script)
		// to show them to the player before starting a race.

		if (File.Exists(saveLocation))
		{

			string content = System.IO.File.ReadAllText(saveLocation);
			string[] lines = content.Split('\n');

			steps.Clear();

			foreach (string line in lines)
			{
				if (long.TryParse(line, out long value))
				{
					steps.Add(value);
				}
			}

        }
		else
		{
            UnityEngine.Debug.Log("Aucune données");
        }

	}

	//Ce code a été fait grâce à l'aide des tutos youtube, de l'aide de Fiona, Lily et Méline.
}
