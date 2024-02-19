var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


Note[] notes = new Note[]
    {
       new Note( "akshay", "build this app", "nodate"),new Note( "aakash", "learn c#", "today" ),new Note( "charan", "testnote", "today" ) };










app.MapGet("/notes", () =>
{
    return notes;
});

app.MapPost("/createNote", (Note note) =>
{ 
    notes = notes.Append(note).ToArray();
    return notes;
});

app.MapPatch("/updateNote/{title}/", (string title, Note newnote) =>
{
    notes = notes.Select((note) => note.Title != title ? note :newnote).ToArray();
});

app.MapDelete("/deleteNote/{title}/", (string title) =>
{
    notes = notes.Where((note) => note.Title != title).ToArray();
});


app.Run();

record Note(string Title, string note, string dateandtime){}