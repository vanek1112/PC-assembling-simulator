using System.Numerics;

namespace Tickets;

internal class TicketsTask
{
    private const int MaxLength = 100;
    private const int MaxSum = 2000;
 
    private static BigInteger CountHappyTickets(BigInteger[,] happyTickets, int length, int sum)
    {
        if (happyTickets[length, sum] >= 0) 
            return happyTickets[length, sum];
        if (sum == 0) 
            return 1;
        if (length == 0) 
            return 0;
 
        happyTickets[length, sum] = 0;
        
        for (var i = 0; i < 10; i++)
            if (sum - i >= 0)
                happyTickets[length, sum] += CountHappyTickets(happyTickets, length - 1, sum - i);

        return happyTickets[length, sum];
    }
        
    private static BigInteger[,] InitializeHappyTicketsContainer()
    {
        var happyTickets = new BigInteger[MaxLength + 1, MaxSum + 1];
 
        for (var i = 0; i < MaxLength; i++)
            for (var j = 0; j < MaxSum; j++)
                happyTickets[i, j] = -1;

        return happyTickets;
    }

    public static BigInteger Solve(int halfLength, int totalSum)
    {
        if (totalSum % 2 != 0)
            return 0;
 
        var happyTickets = InitializeHappyTicketsContainer();
           
        var halfResult = CountHappyTickets(happyTickets, halfLength, totalSum / 2);
        
        return halfResult * halfResult;
    }
}