
using HappyNumbers;

var class1 = new HappyNumberGenerator();

var happyNumbers = class1.GetHappyNumbers();

happyNumbers.ForEach(number =>
{
    Console.WriteLine(number);
});

