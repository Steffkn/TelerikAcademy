// Declare two string variables and assign them with following value:
// The "use" of quotations causes difficulties.
// Do the above in two different ways: with and without using quoted strings.

using System;

class WithAndWithoutUsingQuotedStrings
{
    static void Main()
    {
        int quote = (int)'\"'; // намира кода на кавичките

        string firstWayTODO = "The \"use\" of quotations causes difficulties.";
        string secondWayTODO = "The " + (char)quote + "use" + (char)quote + " of quotations causes difficulties."; // използвайки кода намерен по рано на местото на quote ще се вмъкнат кавички, чрез кастване към char променлива :)

        Console.WriteLine(firstWayTODO);
        Console.WriteLine(secondWayTODO);
    }
}

