using System.IO;
using System;

List<Note> notes = new List<Note>();
bool notesFileAvailable;

if (File.Exists("Notes.json"))
{
    System.Console.WriteLine("Notes loaded.");
    notesFileAvailable = true;
}
else
{
    System.Console.WriteLine("No notes found.");
    notesFileAvailable = false;
}

displayMenue();
string userInput = Console.ReadLine();
while (userInput != "0")
{
    try
    {
        int operation = int.Parse(userInput);
        handleUserInput(operation);        
    }
    catch (System.FormatException e)
    {
        System.Console.WriteLine("invalid input");
    }
    displayMenue();
    userInput = Console.ReadLine();
}

void displayMenue()
{
    System.Console.WriteLine("--- Welcome to your note App! ---");
    System.Console.WriteLine("");
    System.Console.WriteLine("What do you wanna do?");
    System.Console.WriteLine("");
    System.Console.WriteLine("[1] : Show all notes");
    System.Console.WriteLine("[2] : Get one note");
    System.Console.WriteLine("[3] : Create a new note");
    System.Console.WriteLine("[4] : Delete one note");
    System.Console.WriteLine("[0] : Cancel");
}

void createNote(int id, string title, string description)
{
    Note newNote = new Note(id, title, description);
    notes.Add(newNote);
    System.Console.WriteLine($"Notes: {notes.Count}");
}
;

void deleteNote()
{
    
};

void getAllNotes()
{
    
};

void searchNote()
{

};

void handleUserInput(int op)
{
    switch (op)
    {
        case 1:
            foreach (Note note in notes)
            {
                System.Console.WriteLine(note.title);
            }
            break;
        case 2:
            System.Console.WriteLine("Input was 2");
            break;
        case 3:
            System.Console.Write("Title: ");
            string title = Console.ReadLine();
            System.Console.Write("Description: ");
            string description = Console.ReadLine();
            Random rnd = new Random();
            int id = rnd.Next(1, 100);
            createNote(id, title, description);
            break;
        case 4:
            System.Console.WriteLine("Input was 4");
            break;
        default:
            System.Console.WriteLine("Wrong operator.");
            break;
    }
}