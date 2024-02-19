
using WebApplication1.Database;
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














app.MapGet("/notes", () =>
{
    List<Note> blogs = new List<Note>();
    using (var db = new NotesContext())
    {
        blogs = db.Notes.Select(x=>x).ToList();

        
    }

    return blogs;
});

app.MapPost("/createNote", (Note note) =>
{
    using (var db = new NotesContext())
    {
        db.Notes.Add(note);
        db.SaveChanges();
    }

    return "successfull";
});

app.MapPatch("/updateNote/{title}/", (string title, Note newnote) =>
{
    using (var db = new NotesContext())
    {
        db.Notes.Update(newnote);
        db.SaveChanges();
    }

    return "updated sucessfully";
});

app.MapDelete("/deleteNote/{title}/", (string title) =>
{
    using (var db = new NotesContext())
    {
        var value = db.Notes.SingleOrDefault(note => note.Title == title);
        db.Notes.Remove(value);
        db.SaveChanges();
    }

    return "deleted sucessfully";
});


app.Run();

