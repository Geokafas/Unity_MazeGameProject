using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;

public class playerData
{
    public int health;
    public int hammers;
    public int gridSize;
    public int score;
    public float playerPosy;
}

public class GameControl : MonoBehaviour
{

    public static GameControl control;
    private Vector3 sizeOfGrid;
    public Text hammersText;
    public Text scoreText;
	public GameObject indicator;

    bool toggleR = true;
    public bool exitMode = false;

    public Material redTrans;
    public Material greenTrans;
    public Material blueTrans;
    public Material m1Trans;
    public Material m2Trans;
    public Material m3Trans;

    public Material red;
    public Material green;
    public Material blue;
    public Material m1;
    public Material m2;
    public Material m3;

    public GameObject fpsCamera;
    public GameObject secondCamera;
    public GameObject hammer;
    public GameObject RedCube;
    public GameObject BlueCube;
    public GameObject GreenCube;
    public GameObject T1Cube;
    public GameObject T2Cube;
    public GameObject T3Cube;
    public GameObject Plane;
    public GameObject Bound1;
    public GameObject Bound2;
    public GameObject Bound3;
    public GameObject Bound4;
    public GameObject youLose;
    public GameObject youWon;
    public int levels;
    playerData player = new playerData();

    public char[,,] cubeLayout; //map array

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }



	void Start()
	{
		//GameObject lightGameObject = new GameObject("The Light");
		//Light lightComp = lightGameObject.AddComponent<Light>();
		//lightComp.color = Color.blue;
		//lightGameObject.transform.position = new Vector3(0, 5, 0);
		string line;
		int i, j, k;

		RedCube.GetComponent<Renderer>().sharedMaterial = red;
		GreenCube.GetComponent<Renderer>().sharedMaterial = green;
		BlueCube.GetComponent<Renderer>().sharedMaterial = blue;
		T1Cube.GetComponent<Renderer>().sharedMaterial = m1;
		T2Cube.GetComponent<Renderer>().sharedMaterial = m2;
		T3Cube.GetComponent<Renderer>().sharedMaterial = m3;


		try
		{

			// Create a new StreamReader, tell it which file to read and what encoding the file
			// was saved as
			StreamReader theReader = new StreamReader("maze.txt", Encoding.Default);
			// Immediately clean up the reader after this block of code is done.
			// You generally use the "using" statement for potentially memory-intensive objects
			// instead of relying on garbage collection.
			// (Do not confuse this with the using directive for namespace at the 
			// beginning of a class!)
			using (theReader)
			{
				//reads player data
				string[] temp;
				line = theReader.ReadLine();
				temp = line.Split('=');
				levels = int.Parse(temp[1]);
				line = theReader.ReadLine();
				temp = line.Split('=');
				player.gridSize = int.Parse(temp[1]);

				line = theReader.ReadLine();
				temp = line.Split('=');
				player.hammers = int.Parse(temp[1]);
				hammersText.text = "Hammers: " + player.hammers;


				line = theReader.ReadLine(); // reads 1st level
				cubeLayout = new char[levels, player.gridSize, player.gridSize];

				// reads grid layout                
				for (i = 0; i < levels; i++)
				{
					Debug.Log(player.gridSize);
					for (j = 0; j < player.gridSize; j++)
					{
						line = theReader.ReadLine();
						temp = line.Split(null as char[], StringSplitOptions.RemoveEmptyEntries);
						for (k = 0; k < player.gridSize; k++)
						{
							if ("T1".Equals(temp[k], StringComparison.Ordinal))
							{
								cubeLayout[i, j, k] = 'T'; //Touvla
							}
							else if ("T2".Equals(temp[k], StringComparison.Ordinal))
							{
								cubeLayout[i, j, k] = 'M'; //Marmaro
							}
							else if ("T3".Equals(temp[k], StringComparison.Ordinal))
							{
								cubeLayout[i, j, k] = 'P'; //Petres
							}
							else
							{
								cubeLayout[i, j, k] = Convert.ToChar(temp[k]);
							}
						}
					}
					line = theReader.ReadLine(); // reads i st level
					temp = line.Split(null as char[], StringSplitOptions.RemoveEmptyEntries);
					if ("END".Equals(temp[0], StringComparison.Ordinal))
					{
						Debug.Log(line);
					}
				}
				theReader.Close();
			}
		}
		// If anything broke in the try block, we throw an exception with information
		// on what didn't work
		catch (Exception e)
		{
			Console.WriteLine("{0}\n", e.Message);
		}


		for (i = 0; i < levels; i++)
		{
			for (j = 0; j < player.gridSize; j++)
			{
				for (k = 0; k < player.gridSize; k++)
				{
					Debug.Log(cubeLayout[i, j, k]);
					if (cubeLayout[i, j, k] == 'R')
					{
						RedCube.transform.position = new Vector3((float)j, (float)i + 0.5f, (float)k);
						Instantiate(RedCube, RedCube.transform.position, Quaternion.identity);
					}
					else if (cubeLayout[i, j, k] == 'G')
					{
						GreenCube.transform.position = new Vector3((float)j, (float)i + 0.5f, (float)k);
						Instantiate(GreenCube, GreenCube.transform.position, Quaternion.identity);
					}
					else if (cubeLayout[i, j, k] == 'B')
					{
						BlueCube.transform.position = new Vector3((float)j, (float)i + 0.5f, (float)k);
						Instantiate(BlueCube, BlueCube.transform.position, Quaternion.identity);
					}
					else if (cubeLayout[i, j, k] == 'P')
					{
						T3Cube.transform.position = new Vector3((float)j, (float)i + 0.5f, (float)k);
						Instantiate(T3Cube, T3Cube.transform.position, Quaternion.identity);
					}
					else if (cubeLayout[i, j, k] == 'M')
					{
						T2Cube.transform.position = new Vector3((float)j, (float)i + 0.5f, (float)k);
						Instantiate(T2Cube, T2Cube.transform.position, Quaternion.identity);
					}
					else if (cubeLayout[i, j, k] == 'T')
					{
						T1Cube.transform.position = new Vector3((float)j, (float)i + 0.5f, (float)k);
						Instantiate(T1Cube, T1Cube.transform.position, Quaternion.identity);
					}
				}
			}
		}



		sizeOfGrid = transform.localScale;
		sizeOfGrid.x = (float)player.gridSize;
		sizeOfGrid.y = 1.0F;
		sizeOfGrid.z = (float)player.gridSize;
		Plane.transform.localScale = sizeOfGrid / 10;
		Plane.transform.position = new Vector3(player.gridSize / 2 - 0.5f, 0f, player.gridSize / 2);
		Instantiate(Plane);
		Bound1.transform.localScale = new Vector3(1.6f, 0.1f, 1f);
		Bound2.transform.localScale = new Vector3(1.6f, 0.1f, 1f);
		Bound3.transform.localScale = new Vector3(1.6f, 0.1f, 1f);
		Bound4.transform.localScale = new Vector3(1.6f, 0.1f, 1f);
		Bound3.transform.rotation = Quaternion.Euler(90, 90, 0);
		Bound4.transform.rotation = Quaternion.Euler(90, 90, 180);
		Bound1.transform.position = new Vector3(7.52f, 5f, -0.46f);
		Bound2.transform.position = new Vector3(7.52f, 5f, 16f);
		Bound3.transform.position = new Vector3(0f, 5f, 8f);

		Bound4.transform.position = new Vector3(15.48f, 5f, 7.46f);

		Instantiate(Bound1);
		Instantiate(Bound2);
		Instantiate(Bound3);
		Instantiate(Bound4);
		positionPlayer();
	}

    private void Update()
    {
		updateScore();

		if (Input.GetButtonDown("Rotate"))
        {
            if (toggleR)
            {
                toggleR = false;
                GameControl.control.rotateCam();
				indicator.transform.position = new Vector3(fpsCamera.transform.position.x, fpsCamera.transform.position.y + levels + 1.5f, fpsCamera.transform.position.z);
			}
            else
            {
                toggleR = true;
                GameControl.control.resetCam();
            }
        }

        if (Input.GetButtonDown("Cancel"))
        {
            GameControl.control.gameOver();
            exitMode = true;
        }
    }

    void updateScore() //final score
    {
        player.playerPosy = fpsCamera.transform.position.y;
        player.score = (player.gridSize * player.gridSize) + ((player.hammers * 50)-5) - ((int)Time.realtimeSinceStartup);
        scoreText.text = "Score: " + player.score;
    }

    public void rotateCam()
    {
        secondCamera.SetActive(true);
        fpsCamera.SetActive(false);
		indicator.SetActive(true);
    }

    public void resetCam() // reset to the main camera
    {
        secondCamera.SetActive(false);
        fpsCamera.SetActive(true);
		indicator.SetActive(false);

	}

    public void gameOver()
    {
        youLose.SetActive(true);
        secondCamera.SetActive(true);
        fpsCamera.SetActive(false);
        updateScore();
    }
    public void loseHammers()
    {
        player.hammers--;
        hammersText.text = "Hammers: " + player.hammers;
    }
	

    void positionPlayer()
    {
        int j, k;
        for (j = 0; j < player.gridSize; j++)
        {
            for (k = 0; k < player.gridSize; k++)
            {
                if (cubeLayout[0, j, k] == 'E')
                {
                    fpsCamera.transform.position = new Vector3((float)j, 0.5f, (float)k);
                    fpsCamera.transform.rotation = Quaternion.identity;

                    break;
                }
            }
        }
    }
}
