using MongoDB.Driver;
using MongoTest;

MongoClient client = new MongoClient("mongodb+srv://root:myroot@cluster0.gq94xxf.mongodb.net/?retryWrites=true&w=majority");

var studentCollection = client.GetDatabase("test").GetCollection<Student>("students");

var studentData = studentCollection.Find(_ => true).ToList();

Console.WriteLine(studentData.Count);

foreach (var item in studentData)
{
    Console.WriteLine($"{item.Name} {item.Score}");
}