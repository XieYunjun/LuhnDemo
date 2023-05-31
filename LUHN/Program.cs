namespace LUHN
{
    internal class Program
    {
        static void Main(string[] args)
        {
        r: Console.WriteLine("Enter 19 Number or type Q or q to exit :");

            string res = string.Empty;

            var str = Console.ReadLine();

            if (string.IsNullOrEmpty(str) || str.ToUpper().Equals("Q"))
            {
                Console.WriteLine("exit.....");
                Environment.Exit(0);
            }

            Console.WriteLine("you entered: " + str + "...Length=" + str.Length);

            if (str.Length == 20)
            {
                var number = str[..^1];

                res = Convert19To20(number);

                var success = res == str;

                if (success)
                {
                    Console.WriteLine(number);
                }
                else
                {
                    Console.WriteLine("输入20位Number验证LUHN算法未通过");
                }
            }

            if (str.Length == 19)
            {
                res = Convert19To20(str!);

                Console.WriteLine("res= " + res + "...Length=" + res?.Length);
            }

            goto r;
        }

        static string Convert19To20(string str)
        {
            var res = luhnNext(str);

            return str + res;
        }

        public static int luhnSum(string InVal)
        {
            int evenSum;
            int oddSum;
            bool isEven;
            bool IsOdd = true;
            evenSum = 0;
            oddSum = 0;
            int strLen;
            strLen = InVal.Length;
            int i;
            for (i = strLen; i >= 1; i--)
            {
                int digit;
                digit = int.Parse(InVal.Substring(i - 1, 1));
                if (IsOdd)
                {
                    oddSum = oddSum + digit;
                    IsOdd = false;
                }
                else
                {
                    digit = digit * 2;
                    if (digit > 9)
                    {
                        digit = digit - 9;
                    }
                    evenSum = evenSum + digit;
                    IsOdd = true;
                }

            }
            int luhnSum = (oddSum + evenSum);

            return luhnSum;
        }

        public static int luhnNext(string InVal)
        {
            int luhnNext;
            int rst;
            rst = luhnSum(InVal + 0) % 10;
            if (rst == 0)
                luhnNext = 0;
            else
                luhnNext = 10 - rst;

            return luhnNext;

        }
    }
}