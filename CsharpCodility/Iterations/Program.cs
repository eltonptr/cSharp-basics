namespace Iterations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 1162;

            Console.WriteLine(gapFinder(n));
        }

        static int gapFinder(int n)
        {
            int count = 0;
            var binaryArray = Convert.ToString(n, 2).ToCharArray().Select((x, y) => new { Index = y, 
                Value = x }).ToList();
            bool hitFlag = false;
            List<int> counts = new List<int>();
            foreach (var obj in binaryArray)
            {
                if (obj.Value == 49)
                {
                    if (obj.Index != binaryArray.Count - 1)
                    {
                        if (!hitFlag)
                        {
                            if (binaryArray[obj.Index + 1].Value == 48)
                            {
                                hitFlag = true;
                                count = 0;
                            }
                        }
                        else
                        {
                            counts.Add(count);
                            if (binaryArray[obj.Index + 1].Value == 48)
                            {
                                hitFlag = true;
                                count = 0;
                            }
                            else
                            {
                                hitFlag= false;
                            }
                        }
                    }
                    else if (obj.Index == binaryArray.Count - 1)
                    {
                        if (hitFlag)
                        {
                            counts.Add(count);
                            hitFlag = false;
                        }
                    }
                }
                else
                {
                    if (hitFlag)
                    {
                        count++;
                    }
                    else
                    {
                        if (obj.Index != 0)
                        {
                            if (binaryArray[obj.Index - 1].Value == 48)
                            {
                                hitFlag = true;
                                count++;
                            }
                        }
                    }
                }
            }

            return counts.Count != 0 ? counts.Max() : 0;
        }

    }
}