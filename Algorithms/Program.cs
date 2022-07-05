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

//Third Service
var list = new List<string>
{
    "1", "dsd", "2","sam","3",
    "month", "4", "all", "5"
};
var resultList = ThirdService<string>.RemoveOddElements(list);//dsd sam month all
foreach (var item in resultList)
{
    Console.WriteLine(item);
}