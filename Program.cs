using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solu=new Solution();
            string resu=solu.AddBinary("101010","110100");
            Console.WriteLine("Result:{0}", resu);
        }
    }
    
    public class Solution {
        public string AddBinary(string a, string b) {
            char[] aArray=a.ToCharArray();
            char[] bArray=b.ToCharArray();
            
            int aLength=a.Length;
            int bLength=b.Length;
            
            Stack<int> newList=new Stack<int>();
            
            int carry=0;
            for(var i=0; i<Math.Max(aLength,bLength);i++)
            {
                int aInt=0;
                int bInt=0;
                if(aLength-1-i>=0 && bLength-1-i>=0)
                {
                    aInt=int.Parse(aArray[aLength-1-i].ToString());
                    bInt=int.Parse(bArray[bLength-1-i].ToString());
                }else if(aLength-1-i<0)
                {
                    aInt=0;
                    bInt=int.Parse(bArray[bLength-1-i].ToString());
                }else if(bLength-1-i<0)
                {
                    aInt=int.Parse(aArray[aLength-1-i].ToString());
                    bInt=0;
                }
                
                if(aInt+bInt+carry==0)
                {
                    newList.Push(0);
                    carry=0;
                }else if(aInt+bInt+carry==1)
                {
                    newList.Push(1);
                    carry=0;
                }else if(aInt+bInt+carry==2)
                {
                    newList.Push(0);
                    carry=1;
                }else if(aInt+bInt+carry==3)
                {
                    newList.Push(1);
                    carry=1;
                }
            }
            
            //for the last digit if has a carry
            if(carry==1)
            {
                newList.Push(1);
            }
                
            string result=String.Join("", newList.ToArray());
            
            return result;
        }
    }
}
