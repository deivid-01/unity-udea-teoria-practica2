using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
/// <summary>
/// UnitTest for GrammarTools 
/// </summary>
public class GrammarToolsTest : MonoBehaviour
{
    [Test]
    public void NAnullableTest () {

        //ARRANGE: All preconditions and inputs
        GenericGrammar genericGrammar=new GenericGrammar();

        #region Define grammar

        Production production1 = new Production();
        Production production2 = new Production();
        Production production3 = new Production();
        Production production4 = new Production();
        Production production5 = new Production();
        Production production6 = new Production();
        Production production7 = new Production();
        Production production8 = new Production();
        Production production9 = new Production();
        Production production10 = new Production();

        production1.leftSide = new Element ( Element.Kind.noTerminal , 'A' );
        production2.leftSide = new Element ( Element.Kind.noTerminal , 'A' );
        production3.leftSide = new Element ( Element.Kind.noTerminal , 'B' );
        production4.leftSide = new Element ( Element.Kind.noTerminal , 'B' );
        production5.leftSide = new Element ( Element.Kind.noTerminal , 'C' );
        production6.leftSide = new Element ( Element.Kind.noTerminal , 'C' );
        production7.leftSide = new Element ( Element.Kind.noTerminal , 'D' );
        production8.leftSide = new Element ( Element.Kind.noTerminal , 'D' );
        production9.leftSide = new Element ( Element.Kind.noTerminal , 'E' );
        production10.leftSide = new Element ( Element.Kind.noTerminal , 'E' );


        production1.rightSide.Add ( new Element ( Element.Kind.terminal , 'a' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'C' ) );

        production2.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );
        production2.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production2.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'A' ) );


        production3.rightSide.Add ( new Element ( Element.Kind.nulo , '¬' ) );
 

        production4.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production4.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'A' ) );
        production4.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );

        production5.rightSide.Add ( new Element ( Element.Kind.terminal , 'c' ) );
        production5.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'C' ) );

        production6.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );
        production6.rightSide.Add ( new Element ( Element.Kind.terminal , 'd' ) );
        production6.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );

        production7.rightSide.Add ( new Element ( Element.Kind.nulo , '¬' ) );

        production8.rightSide.Add ( new Element ( Element.Kind.terminal , 'e' ) );
        production8.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'E' ) );

        production9.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );
        production9.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );

        production10.rightSide.Add ( new Element ( Element.Kind.terminal , 'f' ) );


        genericGrammar.productions.Add ( production1 );
        genericGrammar.productions.Add ( production2 );
        genericGrammar.productions.Add ( production3 );
        genericGrammar.productions.Add ( production4 );
        genericGrammar.productions.Add ( production5 );
        genericGrammar.productions.Add ( production6 );
        genericGrammar.productions.Add ( production7 );
        genericGrammar.productions.Add ( production8 );
        genericGrammar.productions.Add ( production9 );
        genericGrammar.productions.Add ( production10 );
        #endregion
        #region ACT
        //ACT on the method under test

        var result=GrammarTools.GetAnullableNoTerminals(genericGrammar);
        #endregion

        #region Expected

        //ASSERT occurence of expected results


        List<Element> expectedElements = new List<Element>
        {
            new Element ( Element.Kind.noTerminal , 'B' ) ,
            new Element ( Element.Kind.noTerminal , 'D' ) ,
            new Element ( Element.Kind.noTerminal , 'E' )
        };

        var r=false;

        for ( int i = 0 ;i < result.Count ;i++ )
        {
            if ( result [i].value.Equals ( expectedElements[i].value ) && result [i].kind.Equals ( expectedElements [i].kind ) )
            {
                r = true;
            }
        }

       // CollectionAssert.AreEqual ( expectedElements.ToArray() ,result.ToArray() );
        Assert.That ( r , Is.EqualTo ( true ) );
        #endregion

    }
    [Test]
    public void AnullableProductionsTest () {
        #region Define grammar
        GenericGrammar genericGrammar=new GenericGrammar();


        Production production1 = new Production();
        Production production2 = new Production();
        Production production3 = new Production();
        Production production4 = new Production();
        Production production5 = new Production();
        Production production6 = new Production();
        Production production7 = new Production();
        Production production8 = new Production();
        Production production9 = new Production();
        Production production10 = new Production();

        production1.leftSide = new Element ( Element.Kind.noTerminal , 'A' );
        production2.leftSide = new Element ( Element.Kind.noTerminal , 'A' );
        production3.leftSide = new Element ( Element.Kind.noTerminal , 'B' );
        production4.leftSide = new Element ( Element.Kind.noTerminal , 'B' );
        production5.leftSide = new Element ( Element.Kind.noTerminal , 'C' );
        production6.leftSide = new Element ( Element.Kind.noTerminal , 'C' );
        production7.leftSide = new Element ( Element.Kind.noTerminal , 'D' );
        production8.leftSide = new Element ( Element.Kind.noTerminal , 'D' );
        production9.leftSide = new Element ( Element.Kind.noTerminal , 'E' );
        production10.leftSide = new Element ( Element.Kind.noTerminal , 'E' );


        production1.rightSide.Add ( new Element ( Element.Kind.terminal , 'a' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'C' ) );

        production2.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );
        production2.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production2.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'A' ) );


        production3.rightSide.Add ( new Element ( Element.Kind.nulo , '¬' ) );


        production4.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production4.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'A' ) );
        production4.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );

        production5.rightSide.Add ( new Element ( Element.Kind.terminal , 'c' ) );
        production5.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'C' ) );

        production6.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );
        production6.rightSide.Add ( new Element ( Element.Kind.terminal , 'd' ) );
        production6.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );

        production7.rightSide.Add ( new Element ( Element.Kind.nulo , '¬' ) );

        production8.rightSide.Add ( new Element ( Element.Kind.terminal , 'e' ) );
        production8.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'E' ) );

        production9.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );
        production9.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );

        production10.rightSide.Add ( new Element ( Element.Kind.terminal , 'f' ) );


        genericGrammar.productions.Add ( production1 );
        genericGrammar.productions.Add ( production2 );
        genericGrammar.productions.Add ( production3 );
        genericGrammar.productions.Add ( production4 );
        genericGrammar.productions.Add ( production5 );
        genericGrammar.productions.Add ( production6 );
        genericGrammar.productions.Add ( production7 );
        genericGrammar.productions.Add ( production8 );
        genericGrammar.productions.Add ( production9 );
        genericGrammar.productions.Add ( production10 );
        #endregion

        var result = GrammarTools.GetAnnullableProductions ( genericGrammar );

        foreach ( var item in result )
        {
           // Debug.Log ( item );
        }


        List<int>expectedElements= new List<int>(){
            3,7,9
        };
        var r=false;
        for ( int i = 0 ;i < result.Count ;i++ )
        {
            if ( result [i].Equals ( expectedElements [i] )  )
            {
                r = true;
            }
        }

        Assert.That ( r , Is.EqualTo ( true ) );

    }
    [Test]
    public void GetFirstNoTerminalsTest () {
        #region Define grammar
        GenericGrammar genericGrammar=new GenericGrammar();


        Production production1 = new Production();
        Production production2 = new Production();
        Production production3 = new Production();
        Production production4 = new Production();
        Production production5 = new Production();
        Production production6 = new Production();
        Production production7 = new Production();
        Production production8 = new Production();
        Production production9 = new Production();
        Production production10 = new Production();

        production1.leftSide = new Element ( Element.Kind.noTerminal , 'A' );
        production2.leftSide = new Element ( Element.Kind.noTerminal , 'A' );
        production3.leftSide = new Element ( Element.Kind.noTerminal , 'B' );
        production4.leftSide = new Element ( Element.Kind.noTerminal , 'B' );
        production5.leftSide = new Element ( Element.Kind.noTerminal , 'C' );
        production6.leftSide = new Element ( Element.Kind.noTerminal , 'C' );
        production7.leftSide = new Element ( Element.Kind.noTerminal , 'D' );
        production8.leftSide = new Element ( Element.Kind.noTerminal , 'D' );
        production9.leftSide = new Element ( Element.Kind.noTerminal , 'E' );
        production10.leftSide = new Element ( Element.Kind.noTerminal , 'E' );


        production1.rightSide.Add ( new Element ( Element.Kind.terminal , 'a' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'C' ) );

        production2.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );
        production2.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production2.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'A' ) );


        production3.rightSide.Add ( new Element ( Element.Kind.nulo , '¬' ) );


        production4.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production4.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'A' ) );
        production4.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );

        production5.rightSide.Add ( new Element ( Element.Kind.terminal , 'c' ) );
        production5.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'C' ) );

        production6.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );
        production6.rightSide.Add ( new Element ( Element.Kind.terminal , 'd' ) );
        production6.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );

        production7.rightSide.Add ( new Element ( Element.Kind.nulo , '¬' ) );

        production8.rightSide.Add ( new Element ( Element.Kind.terminal , 'e' ) );
        production8.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'E' ) );

        production9.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );
        production9.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );

        production10.rightSide.Add ( new Element ( Element.Kind.terminal , 'f' ) );


        genericGrammar.productions.Add ( production1 );
        genericGrammar.productions.Add ( production2 );
        genericGrammar.productions.Add ( production3 );
        genericGrammar.productions.Add ( production4 );
        genericGrammar.productions.Add ( production5 );
        genericGrammar.productions.Add ( production6 );
        genericGrammar.productions.Add ( production7 );
        genericGrammar.productions.Add ( production8 );
        genericGrammar.productions.Add ( production9 );
        genericGrammar.productions.Add ( production10 );
        #endregion

        var result=GrammarTools.GetFirstNoTerminals ( genericGrammar );

        #region print result
        foreach ( Set set in result )
        {
            Debug.Log ( set.name );
            foreach ( char value in set.values )
            {
                Debug.Log ("Values :"+ value );

            }
            Debug.Log ( "--------" );

        }
        #endregion

        #region Define expectedSet
        List<Set>expectedSet=new List<Set>(){
              new Set('A',new List<char>(){ 'a','b','e' } ,Set.Kind.first),
              new Set('B',new List<char>(){ 'b' } ,Set.Kind.first),
              new Set('C',new List<char>(){ 'c','d','e' } ,Set.Kind.first),
              new Set('D',new List<char>(){ 'e', } ,Set.Kind.first),
              new Set('E',new List<char>(){ 'b','e','f' } ,Set.Kind.first)
        };
        var r = true;
        for ( int i = 0 ;i < result.Count ;i++ )
        {
            if ( !( result [i].name.Equals ( expectedSet [i].name ) ) )
            {
                r = false;
                break;
            }
            else
            {
                for ( int j = 0 ;j < result [i].values.Count ;j++ )
                {
                    if ( !(result [i].values.Contains ( expectedSet [i].values [j] ) ))
                    {
                        r = false;
                        break;
                    }
                   
                }
            }            
        }
        #endregion

        Assert.That ( r , Is.EqualTo ( true ) );
    }

    [Test]
    public void GetFirstProductionsTest () {
        #region Define grammar
        GenericGrammar genericGrammar=new GenericGrammar();


        Production production1 = new Production();
        Production production2 = new Production();
        Production production3 = new Production();
        Production production4 = new Production();
        Production production5 = new Production();
        Production production6 = new Production();
        Production production7 = new Production();
        Production production8 = new Production();
        Production production9 = new Production();
        Production production10 = new Production();

        production1.leftSide = new Element ( Element.Kind.noTerminal , 'A' ,1);
        production2.leftSide = new Element ( Element.Kind.noTerminal , 'A', 2);
        production3.leftSide = new Element ( Element.Kind.noTerminal , 'B' ,3);
        production4.leftSide = new Element ( Element.Kind.noTerminal , 'B' ,4);
        production5.leftSide = new Element ( Element.Kind.noTerminal , 'C', 5);
        production6.leftSide = new Element ( Element.Kind.noTerminal , 'C', 6);
        production7.leftSide = new Element ( Element.Kind.noTerminal , 'D', 7);
        production8.leftSide = new Element ( Element.Kind.noTerminal , 'D', 8);
        production9.leftSide = new Element ( Element.Kind.noTerminal , 'E', 9);
        production10.leftSide = new Element ( Element.Kind.noTerminal , 'E' ,10);


        production1.rightSide.Add ( new Element ( Element.Kind.terminal , 'a' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'C' ) );

        production2.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );
        production2.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production2.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'A' ) );


        production3.rightSide.Add ( new Element ( Element.Kind.nulo , '¬' ) );


        production4.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production4.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'A' ) );
        production4.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );

        production5.rightSide.Add ( new Element ( Element.Kind.terminal , 'c' ) );
        production5.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'C' ) );

        production6.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );
        production6.rightSide.Add ( new Element ( Element.Kind.terminal , 'd' ) );
        production6.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );

        production7.rightSide.Add ( new Element ( Element.Kind.nulo , '¬' ) );

        production8.rightSide.Add ( new Element ( Element.Kind.terminal , 'e' ) );
        production8.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'E' ) );

        production9.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );
        production9.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );

        production10.rightSide.Add ( new Element ( Element.Kind.terminal , 'f' ) );


        genericGrammar.productions.Add ( production1 );
        genericGrammar.productions.Add ( production2 );
        genericGrammar.productions.Add ( production3 );
        genericGrammar.productions.Add ( production4 );
        genericGrammar.productions.Add ( production5 );
        genericGrammar.productions.Add ( production6 );
        genericGrammar.productions.Add ( production7 );
        genericGrammar.productions.Add ( production8 );
        genericGrammar.productions.Add ( production9 );
        genericGrammar.productions.Add ( production10 );
        #endregion

        var result=GrammarTools.GetFirstProducctions ( genericGrammar );
  
        #region print result
       /* foreach ( Set set in result )
        {
            Debug.Log ( set.index );
            foreach ( char value in set.values )
            {
                Debug.Log ( "Values :" + value );

            }
            Debug.Log ( "--------" );

        }*/
        #endregion

        #region Define expectedSet
        List<Set>expectedSet=new List<Set>(){
              new Set(1,new List<char>(){ 'a' } ,Set.Kind.first),
              new Set(2,new List<char>(){ 'b','e' } ,Set.Kind.first),
              new Set(3,new List<char>(){ } ,Set.Kind.first),
              new Set(4,new List<char>(){ 'b', } ,Set.Kind.first),
              new Set(5,new List<char>(){ 'c' } ,Set.Kind.first),
              new Set(6,new List<char>(){ 'd','e' } ,Set.Kind.first),
              new Set(7,new List<char>(){ } ,Set.Kind.first),
              new Set(8,new List<char>(){ 'e'} ,Set.Kind.first),
              new Set(9,new List<char>(){ 'b','e'} ,Set.Kind.first),
              new Set(10,new List<char>(){'f' } ,Set.Kind.first)
        };
        var r = true;
        for ( int i = 0 ;i < result.Count ;i++ )
        {
            if ( !( result [i].index.Equals ( expectedSet [i].index ) ) )
            {
                r = false;
                break;
            }
            else
            {
                for ( int j = 0 ;j < result [i].values.Count ;j++ )
                {
                    if ( !( result [i].values.Contains ( expectedSet [i].values [j] ) ) )
                    {
                        r = false;
                        break;
                    }

                }
            }
        }
        #endregion

        Assert.That ( r , Is.EqualTo ( true ) );
    }
    [Test]
    public void GetNextOfNoTerminalsTest () {
        #region Define grammar
        GenericGrammar genericGrammar=new GenericGrammar();


        Production production1 = new Production();
        Production production2 = new Production();
        Production production3 = new Production();
        Production production4 = new Production();
        Production production5 = new Production();
        Production production6 = new Production();
        Production production7 = new Production();
        Production production8 = new Production();
        Production production9 = new Production();
        Production production10 = new Production();

        production1.leftSide = new Element ( Element.Kind.noTerminal , 'A' , 1 );
        production2.leftSide = new Element ( Element.Kind.noTerminal , 'A' , 2 );
        production3.leftSide = new Element ( Element.Kind.noTerminal , 'B' , 3 );
        production4.leftSide = new Element ( Element.Kind.noTerminal , 'B' , 4 );
        production5.leftSide = new Element ( Element.Kind.noTerminal , 'C' , 5 );
        production6.leftSide = new Element ( Element.Kind.noTerminal , 'C' , 6 );
        production7.leftSide = new Element ( Element.Kind.noTerminal , 'D' , 7 );
        production8.leftSide = new Element ( Element.Kind.noTerminal , 'D' , 8 );
        production9.leftSide = new Element ( Element.Kind.noTerminal , 'E' , 9 );
        production10.leftSide = new Element ( Element.Kind.noTerminal , 'E' , 10 );


        production1.rightSide.Add ( new Element ( Element.Kind.terminal , 'a' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'C' ) );

        production2.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );
        production2.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production2.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'A' ) );


        production3.rightSide.Add ( new Element ( Element.Kind.nulo , '¬' ) );


        production4.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production4.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'A' ) );
        production4.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );

        production5.rightSide.Add ( new Element ( Element.Kind.terminal , 'c' ) );
        production5.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'C' ) );

        production6.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );
        production6.rightSide.Add ( new Element ( Element.Kind.terminal , 'd' ) );
        production6.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );

        production7.rightSide.Add ( new Element ( Element.Kind.nulo , '¬' ) );

        production8.rightSide.Add ( new Element ( Element.Kind.terminal , 'e' ) );
        production8.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'E' ) );

        production9.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );
        production9.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );

        production10.rightSide.Add ( new Element ( Element.Kind.terminal , 'f' ) );


        genericGrammar.productions.Add ( production1 );
        genericGrammar.productions.Add ( production2 );
        genericGrammar.productions.Add ( production3 );
        genericGrammar.productions.Add ( production4 );
        genericGrammar.productions.Add ( production5 );
        genericGrammar.productions.Add ( production6 );
        genericGrammar.productions.Add ( production7 );
        genericGrammar.productions.Add ( production8 );
        genericGrammar.productions.Add ( production9 );
        genericGrammar.productions.Add ( production10 );
        #endregion
        
        var result=GrammarTools.GetNextOfNoTerminals ( genericGrammar );

        
        #region print result
        /*
         foreach ( Set set in result )
         {
             Debug.Log ( set.name );
             foreach ( char value in set.values )
             {
                 Debug.Log ( "Values :" + value );

             }
             Debug.Log ( "--------" );

         }*/
        #endregion
        
        #region Define expectedSet
        List<Set>expectedSet=new List<Set>(){
              new Set('A',new List<char>(){ 'b','c','d','e','¬' } ,Set.Kind.first),
              new Set('B',new List<char>(){ 'b' , 'c' , 'd' , 'e' , '¬' } ,Set.Kind.first),
              new Set('C',new List<char>(){ 'b' , 'c' , 'd' , 'e' , '¬' } ,Set.Kind.first),
              new Set('D',new List<char>(){ 'b','d'} ,Set.Kind.first),
              new Set('E',new List<char>(){ 'b' , 'd' } ,Set.Kind.first)
        };
        var r = true;
        for ( int i = 0 ;i < result.Count ;i++ )
        {
            if ( !( result [i].name.Equals ( expectedSet [i].name ) ) )
            {
                r = false;
                break;
            }
            else
            {
                for ( int j = 0 ;j < result [i].values.Count ;j++ )
                {
                    if ( !( result [i].values.Contains ( expectedSet [i].values [j] ) ) )
                    {
                        r = false;
                        break;
                    }

                }
            }
        }
        #endregion
        
        Assert.That ( r , Is.EqualTo ( true ) );
       // Assert.That ( x , Is.EqualTo ( true ) );
    }

    [Test]
    public void GetSeleccionSetOfProductionsTest () {
        #region Define grammar
        GenericGrammar genericGrammar=new GenericGrammar();


        Production production1 = new Production();
        Production production2 = new Production();
        Production production3 = new Production();
        Production production4 = new Production();
        Production production5 = new Production();
        Production production6 = new Production();
        Production production7 = new Production();
        Production production8 = new Production();
        Production production9 = new Production();
        Production production10 = new Production();

        production1.leftSide = new Element ( Element.Kind.noTerminal , 'A' , 1 );
        production2.leftSide = new Element ( Element.Kind.noTerminal , 'A' , 2 );
        production3.leftSide = new Element ( Element.Kind.noTerminal , 'B' , 3 );
        production4.leftSide = new Element ( Element.Kind.noTerminal , 'B' , 4 );
        production5.leftSide = new Element ( Element.Kind.noTerminal , 'C' , 5 );
        production6.leftSide = new Element ( Element.Kind.noTerminal , 'C' , 6 );
        production7.leftSide = new Element ( Element.Kind.noTerminal , 'D' , 7 );
        production8.leftSide = new Element ( Element.Kind.noTerminal , 'D' , 8 );
        production9.leftSide = new Element ( Element.Kind.noTerminal , 'E' , 9 );
        production10.leftSide = new Element ( Element.Kind.noTerminal , 'E' , 10 );


        production1.rightSide.Add ( new Element ( Element.Kind.terminal , 'a' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'C' ) );

        production2.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );
        production2.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production2.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'A' ) );


        production3.rightSide.Add ( new Element ( Element.Kind.nulo , '¬' ) );


        production4.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production4.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'A' ) );
        production4.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );

        production5.rightSide.Add ( new Element ( Element.Kind.terminal , 'c' ) );
        production5.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'C' ) );

        production6.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );
        production6.rightSide.Add ( new Element ( Element.Kind.terminal , 'd' ) );
        production6.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );

        production7.rightSide.Add ( new Element ( Element.Kind.nulo , '¬' ) );

        production8.rightSide.Add ( new Element ( Element.Kind.terminal , 'e' ) );
        production8.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'E' ) );

        production9.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );
        production9.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );

        production10.rightSide.Add ( new Element ( Element.Kind.terminal , 'f' ) );


        genericGrammar.productions.Add ( production1 );
        genericGrammar.productions.Add ( production2 );
        genericGrammar.productions.Add ( production3 );
        genericGrammar.productions.Add ( production4 );
        genericGrammar.productions.Add ( production5 );
        genericGrammar.productions.Add ( production6 );
        genericGrammar.productions.Add ( production7 );
        genericGrammar.productions.Add ( production8 );
        genericGrammar.productions.Add ( production9 );
        genericGrammar.productions.Add ( production10 );
        #endregion

        var result=GrammarTools.GetSeleccionSetOfProductions ( genericGrammar );


        #region print result
        
         foreach ( Set set in result )
         {
             Debug.Log ( set.index );
             foreach ( char value in set.values )
             {
                 Debug.Log ( "Values :" + value );

             }
             Debug.Log ( "--------" );

         }
        #endregion

        #region Define expectedSet
        List<Set>expectedSet=new List<Set>(){
              new Set(1,new List<char>(){ 'a' } ,Set.Kind.first),
              new Set(2,new List<char>(){ 'b','e' } ,Set.Kind.first),
              new Set(3,new List<char>(){'b','c','d','e','¬' } ,Set.Kind.first),
              new Set(4,new List<char>(){ 'b', } ,Set.Kind.first),
              new Set(5,new List<char>(){ 'c' } ,Set.Kind.first),
              new Set(6,new List<char>(){ 'd','e' } ,Set.Kind.first),
              new Set(7,new List<char>(){'b','d' } ,Set.Kind.first),
              new Set(8,new List<char>(){ 'e'} ,Set.Kind.first),
              new Set(9,new List<char>(){ 'b','d','e'} ,Set.Kind.first),
              new Set(10,new List<char>(){'f' } ,Set.Kind.first)
        };
        var r = true;
        for ( int i = 0 ;i < result.Count ;i++ )
        {
            if ( !( result [i].index.Equals ( expectedSet [i].index ) ) )
            {
                r = false;
                break;
            }
            else
            {
                for ( int j = 0 ;j < result [i].values.Count ;j++ )
                {
                    if ( !( result [i].values.Contains ( expectedSet [i].values [j] ) ) )
                    {
                        r = false;
                        break;
                    }

                }
            }
        }
        #endregion

        Assert.That ( r , Is.EqualTo ( true ) );
  
    }
}