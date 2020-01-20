using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Selectable : MonoBehaviour
{
    public Image image;
    public Selectable up;

    public Selectable down; 

    public Selectable left; 

    public Selectable right; 

    //Conventions - Up is 0, Right is 1, Down is 2, and Left is 3. This will be the 
    //the convention used for all functions. 

    public Selectable(Image img, Selectable Up, Selectable Right, Selectable Down, Selectable Left){
        image = img; 
        up = Up; 
        right = Right; 
        down = Down;
        left = Left; 
    }

    public List<Selectable> GetSelectables(){
        List<Selectable> directions = new List<Selectable>(4); 
        directions[0] = up; 
        directions[1] = right; 
        directions[2] = down; 
        directions[3] = left; 
        return directions; 
    }

    public Selectable GetRight(){
        if (right == null){
            return this; 
        }
        else{
            return right; 
        }
    }

    public Selectable GetLeft(){
        if (left == null){
            return this; 
        }
        else{
            return left; 
        }
    }

    public Selectable GetUp(){
        if (up == null){
            return this; 
        }
        else{
            return up; 
        }
    }

    public Selectable GetDown(){
        if (down == null){
            return this; 
        }
        else{
            return down; 
        }
    }

    /*public void SetSelectable(){

    }*/
}
