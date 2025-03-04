using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


List<Cafe> repo = new List<Cafe>() {
    new Cafe("SimpleCoffee","Ленина 99", 242, 54800)
    new Cafe("Жизнь Март", "Театральная 11А", 94, 32300)
    new Cafe("Счастливые люди", "ЛЕнина 64", 52, 33040)
    };

app.MapGet("/", () => repo);
app.MapPost("/add",(Cafe newCafe) => repo.Add(newCafe));
app.MapPut("/{id}", (string id, UpdateCafeDTO dto)=>
{
    Cafe buffer = repo.Find(x => x.Name == id);
    buffer.Address = dto.address;
});
app.MapDelete("/delete/{id}",(string id) =>
{
    Cafe buffer = repo.Find(x => x.Name == id);
    repo.Remove(buffer);
});
app.Run();

class Cafe
{
    public Cafe(string name, string address, int user, int revenue)
    {
        Name = name;
        Address = address;
        User = user;
        Revenue = revenue;
    }

    public string Name { get; set; }
    public string Address { get; set; }
    public int User { get; set; }
    public int Revenue { get; set; }

}

record class UpdateCafeDTO (string address);