using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormGame

//Neil Little SDEV 260
//  16 November 2019
//  16 November 2019
//    Week 12 Homework.
{//****************************************************************************** Abstract class that contains an array for giving a value to
    // *************************************************************************** Identify what image to display.  
    abstract class locationBaseAbst  
    {
        public int x { get; set; }
        public int y { get; set; }
        public int heading { get; set; }
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
                { {  0, 0, 0, 0}, { 2, 6,26, 6},  { 0, 0, 0, 0 }, { 0, 0, 0, 0 },{ 0, 0, 0, 0 }, { 0, 0, 0, 0 } }, //2
                { {  0, 0, 0, 0}, { 3, 18, 22,6  },{ 0, 0, 0, 0 }, { 0, 0, 0, 0 }, {20,8,12,13 }, { 0, 0, 0, 0 } }, //3
                { {  0, 0, 0, 0}, { 24, 5, 25, 6}, { 17,15,18,10  }, { 9,11,6,14 },{ 19,7, 8, 28 }, { 0, 0, 0, 0 } }, //4 
                { {  0, 0, 0, 0}, { 23, 17, 2 ,8 },{  0, 0, 0, 0 }, { 0, 0, 0, 0 },{  0, 0, 0, 0}, {  0, 0, 0, 0 } }, //5
                { {  0, 0, 0, 0}, { 27, 7, 1 ,8 },{  0, 0, 0, 0 }, { 0, 0, 0, 0 },{  0, 0, 0, 0}, {  0, 0, 0, 0 } },//6
                { {  0, 0, 0, 0 }, { 0, 0, 0 , 0},{  0, 0, 0, 0 }, { 0, 0, 0, 0 },{  0, 0, 0, 0}, {  0, 0, 0, 0 } }  //7
                                                };

        public int[,,] Array3D { get => array3D;}
    }
    class locationMethods: locationBaseAbst
    {
        public int _ImageMain { get; set; }
        
        public void GetImageNumber(int x,int y,int heading )
        {
            _ImageMain = Array3D[x, y, heading];
        }
    }
}
