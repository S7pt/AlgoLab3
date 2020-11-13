# Wedd algorithm
Worst case difficulty: O(n^2) </br>
	Average difficulty: O(n) </br>
* Incoming parameters: </br>
	* **N** - the number of pairs </br>
	* **people** - the array of pairs </br>

This algorithm creates an array of hashsets, which in this case, happens to be very useful, because our elements can duplicate, and hashset prevents this scenario. </br>
Then we, using iteration, divide the incoming array(**people**) into previously mentioned hashset array by tribes. </br>
After that we go through every tribe, count all boys and girls in the existing tribes. During that iteration we also count pairs of people from the same tribe to subtract it from all the possible combinations later. Then, by simple multiplication(boys*girls), we get all existing pairs of different tribes. Finally, using the counter of wrong pairs I mentioned earlied, we exclude it from the all existing pairs by subtraction, and thus, we get the final result.
