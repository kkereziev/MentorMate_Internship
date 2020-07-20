namespace GreenRedGame
{
    interface ICellOperations
    {
        int SumSurroundings(int[,] grid, int row, int col);
        void RedChangeColor(int[,] grid, int row, int col, int sum);
        void GreenChangeColor(int[,] grid, int row, int col, int sum);
    }
}
