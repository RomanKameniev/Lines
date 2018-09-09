# Lines
Path_find_A*_algoritm

The Lie Algorithm (Wave Algorithm)

The algorithm is designed to search for the shortest path from the starting cell to the final cell, if possible,
or, in the absence of a path, issue a message of obstruction.
Consists of 2 functions:
-FindWave () // function includes 2 steps. Initialization and order of wave propagation.
-FindBestWay (int [,] Map) // Returns the minimum path between two points


* Initialization
Create an array consisting of {-2 and -1} // Characters for balls and empty space
Mark starting cell 0
step: = 0;

* Wave propagation
CYCLE
For each cell cMap [SDot.X, SDot.Y], the marked step
mark all adjacent free unmarked cells in the city step + 1
KC
step ++;
SUCCESS (the final cell is not marked) And (there is the possibility of wave propagation)
IF the end point is marked
The PATH is found, its length is equal to the step
IF the motion amount is greater than the dimensions of the map or all the cells around are labeled
THE WAY is absent


* Restoring the way
IF the finish cell is marked
THAT
go to the finish cell
CYCLE
The 1st number in the current cell
Go to the selected cell and add it to the path
For the current cell - not the starting



I chose this algorithm, since the algorithm does not overestimate the distance between points.
Its time complexity varies from O (| E |) (if the points are on the same line)
up to O (| V ^ 2 |) (if there are a large number of obstacles between the points),
which is suitable for not large fields, as in our case.

The advantage of this algorithm is its simplicity in understanding, a relatively small amount of consumed resources,
in comparison with the Dijkstra algorithm, the time complexity of which varies from O (| nlogn + mlogm |) to O (| V ^ 2 |),
which is less acceptable for this task.

The disadvantage is the time complexity of the search, if there are many obstacles between the points.

Have a good time!
