using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ControlFlowConditionalStatements
{
    class RefactoredCode
    {
        private void RefactorIfStatement()
        {
            Potato potato = new Potato();
            //... 
            if (potato != null)
            {
                if (potato.isPeeled && !potato.IsRotten)
                {
                    Cook(potato);
                }
            }


            int row = 0;
            int col = 0;
            int minCellRow = 0;
            int maxCellRow = 0;
            int minCellCol = 0;
            int maxCellCol = 0;
            bool isVisitableCell = false;

            if (isVisitableCell)
            {
                if (row >= minCellRow && row <= maxCellRow)
                {
                    if (maxCellCol >= col && minCellCol <= col)
                    {
                        VisitCell();
                    }
                }
            }

        }

        private void VisitCell()
        {
            throw new NotImplementedException();
        }


        private void RefactorLoop()
        {
            int[] array = {1,2,3,4};
            int expectedValue = 0;
            bool isValueFound = false;

            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(array[i]);
                    if (array[i] == expectedValue)
                    {
                        isValueFound = true;
                    }
                }
                else
                {
                    Console.WriteLine(array[i]);
                }
            }
            
            // More code here
            if (isValueFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
