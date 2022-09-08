using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Comman_Class
{
    public class General_Class
    {
        public int minDist1(int[] arr, int n, int x, int y)
        {
            int i, j;
            int min_dist = int.MaxValue;
            for (i = 0; i < n; i++)
            {
                for (j = i + 1; j < n; j++)
                {
                    if ((x == arr[i] &&
                         y == arr[j] ||
                         y == arr[i] &&
                           x == arr[j])
                        && min_dist >
                       Math.Abs(i - j))

                        min_dist =
                        Math.Abs(i - j);
                }
            }
            return min_dist;
        }
        //previous index and min distance
        int i = 0, p = -1, min_dist = int.MaxValue;
        public int minDist(int[] arr, int n, int x, int y)
        {
            for (i = 0; i < n; i++)
            {
                if (arr[i] == x || arr[i] == y)
                {
                    //we will check if p is not equal to -1 and
                    //If the element at current index matches with
                    //the element at index p , If yes then update
                    //the minimum distance if needed
                    if (p != -1 && arr[i] != arr[p])
                        min_dist = Math.Min(min_dist, i - p);

                    //update the previous index
                    p = i;
                }
            }
            //If distance is equal to int max
            if (min_dist == int.MaxValue)
                return -1;

            return min_dist;
        }


    }
}
