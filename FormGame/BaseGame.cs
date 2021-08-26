using System;
using System.Collections.Generic;
using System.Text;

namespace TestingGame
{
    class BaseGame
    {
        int[,,] array3D = new int[8, 6, 4] {
                // Goes clockwise [north, east, south, west} north can be 1(deadend) - 4, 4 being straight hallway                               
                //5-8  5 = first block all open plus() junction  (6 = wall open left and right) ( 7 open left) (8 open right)                               
                //9-12 9 = second block up  plus junc) (10 =  T junction) (11 left turn) (12 right turn)                                
                //13-16  = Third up (13 = all open (14 t junc) (15 left turn) (16 right turn)                                
                //17 1st person corner on left) (18 corner on right);                                
                //19 dead end one block up w door , open on left                    
                //20 dead end w door

                //      0              1               2                3              4              5               
                { { 0, 0, 0, 0 }, { 0, 0, 0, 0 },{ 0, 0, 0, 0 }, {  0, 0, 0, 0 },{ 0, 0, 0, 0 }, { 0, 0, 0, 0 } }, //0
                { {  0, 0, 0, 0}, { 1,8,4,7  },  {  0, 0, 0, 0 }, { 0, 0, 0, 0 },{  0, 0, 0, 0}, {  0, 0, 0, 0 } }, //1
                { {  0, 0, 0, 0}, { 2, 6,15, 6},  { 0, 0, 0, 0 }, { 0, 0, 0, 0 },{ 0, 0, 0, 0 }, { 0, 0, 0, 0 } }, //2
                { {  0, 0, 0, 0}, { 3,18,7,6  },{ 0, 0, 0, 0 }, { 0, 0, 0, 0 }, {20,8,12,17 }, { 0, 0, 0, 0 } }, //3
                { {  0, 0, 0, 0}, { 4, 5, 3, 6}, { 17,15,8,10  }, { 18,11,6,14 },{ 19,7, 8, 4 }, { 0, 0, 0, 0 } }, //4 
                { {  0, 0, 0, 0}, { 4, 5, 6 ,8 },{  0, 0, 0, 0 }, { 0, 0, 0, 0 },{  0, 0, 0, 0}, {  0, 0, 0, 0 } }, //5
                { {  0, 0, 0, 0}, { 4, 5, 6 ,8 },{  0, 0, 0, 0 }, { 0, 0, 0, 0 },{  0, 0, 0, 0}, {  0, 0, 0, 0 } },//6
                { {  0, 0, 0, 0 }, { 4, 5, 6 ,8 },{  0, 0, 0, 0 }, { 0, 0, 0, 0 },{  0, 0, 0, 0}, {  0, 0, 0, 0 } }  //7
                                                };

        public int[,,] Array3D { get => array3D;} // Getter only for location and direction facing
    }
}
