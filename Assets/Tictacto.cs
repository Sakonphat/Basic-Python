using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tictacto : MonoBehaviour {

    [SerializeField]
    Text[] Texts;

    //Declare integers to keep any number of magic square 
    int[] magicSquareNumber = new int[9] { 8, 1, 6, 3, 5, 7, 4, 9, 2 };
    //Declare board to set value "O" turn and "X" turn
    int[] playersBoard = new int[9];


    //Set "O" turn
    bool isO = true;

    //Check end game?
    bool isEndGame = false;

    public void OnClick(int buttonID)
    {
        Debug.Log("End game : " + isEndGame);

        //Reset game
        if (buttonID == 9 )
        {
            int i = 0;
            while (true)
            {
                if(i < 9)
                {
                    playersBoard[i] = 0;
                    Texts[i].text = "";
                    i++;
                }
                else
                {
                    break;
                }
            }

            if (isO)
            {
                Texts[9].text = "This turn is O";// Texts[9] is set turn message
                isO = false;
            }
            else
            {
                Texts[9].text = "This turn is O";
                isO = true;
            }
            isEndGame = false;
            Debug.Log("End game : "+isEndGame);
            return;
        }
 

        //If text is "O" or "X" then text is not changed
        if (Texts[buttonID].text != "")
        {
            return;
        }
        //If end game all text is not changed
        if( (Texts[buttonID].text == "" || Texts[buttonID].text != "" )&& isEndGame == true  )
        {
            return;
        }

        //Set value in playersBoard
        //If isO is ture then playersBoard is set positive number else negative number 
        playersBoard[buttonID] = isO ? magicSquareNumber[buttonID] : -magicSquareNumber[buttonID];

        //Set text on UI 
        //If buttonID on playerBoard is positive number is "O" else if negative number is "X"
        Texts[buttonID].text = playersBoard[buttonID] > 0 ? "O" : "X";

        //Set "X" turn
        isO = !isO;
        //Set message
        if (isO)
        {
            Texts[9].text = "This turn is O";
        }
        else if (!isO)
        {
            Texts[9].text = "This turn is X";
        }
 
        int sumMagicSuareNumber = 15;


        if (
            playersBoard[0] + playersBoard[1] + playersBoard[2] == sumMagicSuareNumber ||
            playersBoard[3] + playersBoard[4] + playersBoard[5] == sumMagicSuareNumber ||
            playersBoard[6] + playersBoard[7] + playersBoard[8] == sumMagicSuareNumber ||

            playersBoard[0] + playersBoard[3] + playersBoard[6] == sumMagicSuareNumber ||
            playersBoard[1] + playersBoard[4] + playersBoard[7] == sumMagicSuareNumber ||
            playersBoard[2] + playersBoard[5] + playersBoard[8] == sumMagicSuareNumber ||

            playersBoard[0] + playersBoard[4] + playersBoard[8] == sumMagicSuareNumber ||
            playersBoard[2] + playersBoard[4] + playersBoard[6] == sumMagicSuareNumber
        )
        {
            Debug.Log("O is winner");
            Texts[9].text = "O is winner !";
            isEndGame = true;
            Debug.Log("End game : " + isEndGame);
        }
        else if (
            playersBoard[0] + playersBoard[1] + playersBoard[2] == -sumMagicSuareNumber ||
            playersBoard[3] + playersBoard[4] + playersBoard[5] == -sumMagicSuareNumber ||
            playersBoard[6] + playersBoard[7] + playersBoard[8] == -sumMagicSuareNumber ||

            playersBoard[0] + playersBoard[3] + playersBoard[6] == -sumMagicSuareNumber ||
            playersBoard[1] + playersBoard[4] + playersBoard[7] == -sumMagicSuareNumber ||
            playersBoard[2] + playersBoard[5] + playersBoard[8] == -sumMagicSuareNumber ||

            playersBoard[0] + playersBoard[4] + playersBoard[8] == -sumMagicSuareNumber ||
            playersBoard[2] + playersBoard[4] + playersBoard[6] == -sumMagicSuareNumber

        )
        {
            Debug.Log("X is winner");
            Texts[9].text = "X is winner !";
            isEndGame = true;
            Debug.Log("End game : " + isEndGame);
        }
        else if ( 
            playersBoard[0] != 0 && playersBoard[1] != 0 && playersBoard[2] != 0 && 
            playersBoard[3] != 0 && playersBoard[4] != 0 && playersBoard[5] != 0 &&
            playersBoard[6] != 0 && playersBoard[7] != 0 && playersBoard[8] != 0 
            )
        {
            Debug.Log("Draw");
            Texts[9].text = "Draw";
            isEndGame = true;
            Debug.Log("End game : " + isEndGame);
        }
    }
  

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
