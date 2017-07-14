using System;
using System.Linq;


namespace psLib.Extensions
{
    public static class ParamsMap
    {
        
        public static string InputFileName(this string[] args)
        {
            return args.getValue(3, "InputFileName");

        }
        public static string Keyword(this string[] args)
        {

            return args.getValue(0, "Keyword");

        }
        public static string SecondKeyword(this string[] args)
        {

            return args.getValue(1, "SecondKeyword");

        }
        public static int Proximity(this string[] args) {
            
                return Convert.ToInt32(args.getValue(2, "Proximity"));
            
        }
        public static string getValue(this string[] args, int index, string paramname)
        {
            if (index > args.Count()) {
                throw new ArgumentException(string.Format("index {0} out of range while accessing input parameter {1}",index,paramname));
            }
            return args[index];
        }
    }
}
