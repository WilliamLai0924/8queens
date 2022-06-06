using System;
using System.Collections.Generic;
using System.Linq;

namespace _8queens
{
    class Program
    {
        static void Main(string[] args)
        {
            Chess chess = new Chess();
            List<List<int>> result = chess.AllResult();
            chess.Print(result);
        }
    }

    class Chess
    {
        List<int> row
        {
            get
            {
                return new List<int> { 0, 1, 2, 3 };
            }
        }

        public void Print(List<List<int>> result)
        {
            foreach (var data in result)
            {
                for (int i = 0; i < row.Count(); i++)
                {
                    string q = string.Empty;
                    foreach (var item in data)
                    {
                        if (i == item)
                        {
                            q += "Q";
                        }
                        else
                        {
                            q += ".";
                        }
                    }

                    Console.WriteLine(q);
                }

                Console.WriteLine("***************");
            }
        }

        public List<List<int>> AllResult()
        {
            List<List<int>> allResult = new List<List<int>>();
            foreach (var r in row)
            {
                List<int> set = new List<int> { r };
                bool isGood = Play(set, 1);
                if (isGood == true)
                {
                    allResult.Add(set);
                }
            }

            return allResult;
        }

        bool Play(List<int> queens, int index)
        {
            bool isGood = false;
            List<int> valids = GetValids(queens, index);
            foreach (var r in row)
            {
                foreach (var valid in valids)
                {
                    if (r == valid)
                    {
                        queens.Add(r);
                        isGood = true;
                        if (row.Count() > queens.Count())
                        {
                            isGood = Play(queens, index + 1);
                        }

                        if (isGood == true)
                        {
                            break;
                        }
                        else
                        {
                            isGood = false;
                            queens.RemoveAt(queens.Count() - 1);
                        }
                    }
                }

                if (isGood == true)
                {
                    break;
                }
            }

            return isGood;
        }

        List<int> GetValids(List<int> queens, int index)
        {
            var response = row;
            for (int i = 0; i < queens.Count(); i++)
            {
                int gap = index - i;
                if (queens[i] - gap >= 0)
                {
                    response.RemoveAll(j => j == queens[i] - gap);
                }

                if (queens[i] + gap <= 4)
                {
                    response.RemoveAll(j => j == queens[i] + gap);
                }

                response.RemoveAll(j => j == queens[i]);
            }

            return response;
        }
    }
}