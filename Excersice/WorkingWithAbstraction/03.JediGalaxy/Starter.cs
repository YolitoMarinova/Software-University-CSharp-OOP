using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.JediGalaxy
{
    public class Starter
    {
        private int[,] galaxy;
        private long sum;
    
        public void Start()
        {
             int[] dimensions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            galaxy = FillMatrix(dimensions);
        
            string command = Console.ReadLine();
            
            while (command != "Let the Force be with you")
            {
                int[] playerCoordinates = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilCoordinates = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int evilRow = evilCoordinates[0];
                int evilCol = evilCoordinates[1];

                MoveEvil(evilRow, evilCol);               

                int playerRow = playerCoordinates[0];
                int playerCol = playerCoordinates[1];

                MovePlayer(playerRow, playerCol);                

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        private void MovePlayer(int playerRow, int playerCol)
        {
            while (playerRow >= 0 && playerCol < galaxy.GetLength(1))
            {
                if (IsInMatrix(playerRow, playerCol))
                {
                    sum += galaxy[playerRow, playerCol];
                }

                playerCol++;
                playerRow--;
            }
        }

        private void MoveEvil(int evilRow, int evilCol)
        {
            while (evilRow >= 0 && evilCol >= 0)
            {
                if (IsInMatrix(evilRow, evilCol))
                {
                    galaxy[evilRow, evilCol] = 0;
                }

                evilRow--;
                evilCol--;
            }
        }

        private int[,] FillMatrix(int[] dimestions)
        {
            int row = dimestions[0];
            int col = dimestions[1];

            galaxy = new int[row, col];

            int value = 0;

            for (int currentRow = 0; currentRow < row; currentRow++)
            {
                for (int curretnCol = 0; curretnCol < col; curretnCol++)
                {
                    galaxy[currentRow, curretnCol] = value++;
                }
            }

            return galaxy;
        }

        private bool IsInMatrix(int row, int col)
        {
            return row >= 0 && row < galaxy.GetLength(0) && col >= 0 && col < galaxy.GetLength(1);
        }
    }
}
