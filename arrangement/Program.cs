using System;
using System.Collections;
namespace arrangement
{
    class Program
    {
        protected string arrangements(string inputs)
        {
            string val = inputs;
            int count = 0, j = 0;
            string[] arr;
            string col = "", res = "", dep = "", rollno = "", temproll = "", prevyear = "", prevcol = "", prevdep = "", prevrol = "", year = "", temp = "", start = "", end = "";
            ArrayList indexes = new ArrayList();
            indexes.Add(1);
            foreach (var ch in val)
            {
                j++;
                if (ch == ',')
                {
                    indexes.Add(j);
                    count++;
                }
            }
            indexes.Add(j);
            int len = j;
            ArrayList years = new ArrayList();
            int flag1 = 0, flag2 = 0;
            ArrayList Colleges = new ArrayList();
            ArrayList depts = new ArrayList();
            int count1 = 0, count2 = 0;
            for (int i = 0; i <= count; i++)
            {
                prevyear = year;
                prevdep = dep;
                prevcol = col;
                prevrol = rollno;
                dep = "";
                col = "";
                year = "";
                rollno = "";
                flag2 = 0;
                flag1 = 0;
                for (j = (int)indexes[i] - 1; j < (int)indexes[i + 1]; j++)
                {
                    if ((Char.IsLetter(val[j])) && (flag1 == 0))
                        col = col + val[j];
                    else if ((Char.IsDigit(val[j])) && (flag2 == 0))
                    {
                        year = year + val[j];
                        flag1 = 1;
                    }
                    else if ((Char.IsLetter(val[j])) && (flag1 == 1))
                    {
                        flag2 = 1;
                        dep = dep + val[j];
                    }
                    else if ((Char.IsDigit(val[j])) && (flag2 == 1))
                    {
                        rollno = rollno + val[j];
                    }

                }
                if ((prevyear == year) && (prevdep == dep) && (prevcol == col) && (Int16.Parse(prevrol) == Int16.Parse(rollno) - 1))
                {
                    if (count1 == 0)
                        start = prevrol;
                    end = rollno;
                    count1++;

                }
                else if ((prevyear == year) && (prevdep == dep) && (prevcol == col))
                {
                    if (end != "")
                        res = res + ", " + col + year + dep + start + "-" + end;
                    else
                        res = res + ", " + col + year + dep + prevrol;
                    start = "";
                    end = "";
                    count1 = 0;
                }
                else
                {
                    if (end != "")
                        res = res + ", " + prevcol + prevyear + prevdep + start + "-" + end;
                    else
                        res = res + ", " + prevcol + prevyear + prevdep + prevrol;
                    count1 = 0;
                    start = "";
                    end = "";
                }
            }
            if (end != "")
                res = res + ", " + col + year + dep + start + "-" + end;
            else
                res = res + ", " + col + year + dep + rollno;
            char[] trimChars = { ',' ,' ' };
            res = res.Trim(trimChars);
            return res;
        }

        static void Main(string[] args)
        {
            Program P = new Program();
            string res = P.arrangements("PTA22EE005, CET22EE007, PTA22EE008");
            Console.WriteLine(res);
        }
    }
}
    

