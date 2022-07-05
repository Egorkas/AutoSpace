// See https://aka.ms/new-console-template for more information
using Algorithms.Services;

//First Service
var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 11, 12 };
var firstService = new FirstService();
var result = firstService.AddEvenNumbers(array);//32
Console.WriteLine(result);

//Second service
var text = "hello wolrld !!!";
var secondService = new SecondService();
Console.WriteLine(secondService.RemoveRepeatedChars(text));//helo_wrd!