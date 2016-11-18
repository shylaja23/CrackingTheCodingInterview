/*
Given two rectangles, find if the given two rectangles overlap or not. A rectangle is denoted by providing the x and y co-ordinates of two points: the left top corner and the right bottom corner of the rectangle.

Note that two rectangles sharing a side are considered overlapping.

rectanglesOverlap

Input:

The first integer T denotes the number of test cases. For every test case, there are 2 lines of input. The first line consists of 4 integers: denoting the co-ordinates of the 2 points of the first rectangle. The first integer denotes the x co-ordinate and the second integer denotes the y co-ordinate of the left topmost corner of the first rectangle. The next two integers are the x and y co-ordinates of right bottom corner. Similarly, the second line denotes the cordinates of the two points of the second rectangle.


Output:

For each test case, output (either 1 or 0) denoting whether the 2 rectangles are overlapping. 1 denotes the rectangles overlap whereas 0 denotes the rectangles do not overlap.

Input
2
0 10 10 0
5 5 15 0
0 2 1 1
-2 2 0 -3

Output
1
0
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Point
    {
        public int x;
        public int y;
    }
    public class Rectangle
    {
        public Point topLeft;
        public Point bottomRight;
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            Program p = new Program();
            p.CompareValues();
             
        }
        
        public void CompareValues(){
            int noOfTestCases = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < noOfTestCases;i++){
                Rectangle A = getPointsArray();
                Rectangle B = getPointsArray();
                if(A.bottomRight.x <= B.topLeft.x || B.bottomRight.x <= A.topLeft.x)
                    Console.WriteLine("0");
                else if(A.bottomRight.y >= B.topLeft.y || B.bottomRight.y >= A.topLeft.y)
                    Console.WriteLine("0");
                else
                    Console.WriteLine("1");
                
            }
        }
        public Rectangle getPointsArray()
        {
            string strArray = Console.ReadLine();
            string[] arr = strArray.Trim().Split(new Char[]{' '});
            Point topLeft =  new Point();
            topLeft.x = Convert.ToInt32(arr[0]);
            topLeft.y = Convert.ToInt32(arr[1]);
            Point bottomRight = new Point();
            bottomRight.x = Convert.ToInt32(arr[2]);
            bottomRight.y = Convert.ToInt32(arr[3]);
            Rectangle tmp = new Rectangle();
            tmp.topLeft = topLeft;
            tmp.bottomRight = bottomRight;
            return tmp;
        }
    }
    
}
