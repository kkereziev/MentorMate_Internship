This is a basic readme to guide the evaluator through my thought process during my work on this task.

So the we're going to use OOP we have to define the objects first-the main objects are the grid and each cell in the grid.
I've created class Grid and added properties for number of rows(weight), number of columns(height), indexing our custom cell 2d array,costructor, 
validation function for the indexing property and clone function.
I've also created struct Cell with a single property-Value.

The grid is filled in the FillGrid method in class GridOperations, it is very important to note that through the whole processing the 2d arrray manipulate
not as grid but as normal array. We take the wanted cell by reversing the place of the indexing ex. in the first test we want cell with coordinates 1,0 
where 1 stands for column number and 0 for row number- grid[row,col] where col is 1 and row is 0.

In each iteration we mustn't change the current grid because our calculations will fail, we have to itterate and keep info for each cell if we have to change it or no for the
next iteration. This was accomplished by making shadow copy of original object, changes are made in the second object and when iteration is finally over the 
newly created object is assigned to the original. I chose Cell to be struct because struct it value type and when we make the shadow copy, if we leave Cell as class we have to iterate
our inner array in order to make each Cell object new instance.

When we iterate we take each cell of the array. We have to consider all of the surrounding cells, which in the perfect case are 8. This becomes a problem because there will be
cell with only 3 neighbours, or 4 neighbours for example. The solution I found most fitting  here is to simply ignore the if-else statements and get each cell with GetCellValue method
which is called in SumSurroundings method(they are both in CellOperations class). In the SumSurroundings method we take the grid, number of column and row of the current cell and
get 8 times each surrounding cell with the GetCellValue method. There we use try-catch block if we hit IndexOutOfRangeError we simply return -1. Finally, back in method SumSurroundings 
we gather all 8 cells in array and use LINQ to take only the values greater than 0 and sum them. After that, depending if the cell is currently green or red we have 2 methods-RedChangeColor
and GreenChangeColor which check the sum of the surroundings and change the color of the cell if needed.

