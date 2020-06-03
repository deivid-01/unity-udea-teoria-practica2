using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Instruction controller to show each instruction
/// </summary>
public class InstructionsController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[]  instructions;

    int actualInstruction;
    
    void Start()
    {
        actualInstruction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        

        if ( Input.GetKeyDown ( KeyCode.RightArrow ) )
        {
            instructions [actualInstruction].SetActive ( false );
            actualInstruction++;
            if ( actualInstruction >= instructions.Length )
            {
                SceneManager.LoadScene ( 0 );
                return;
            }
            else
            { 
                instructions [actualInstruction].SetActive ( true );

            }

        }

        else if ( Input.GetKeyDown ( KeyCode.LeftArrow ) )
        {
            
            if ( actualInstruction == 0 )
            {
                return;
            }

            instructions [actualInstruction].SetActive ( false );
            actualInstruction--;
            instructions [actualInstruction].SetActive ( true );

        }

    }
}
