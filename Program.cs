using System.IO;
using System;
using System.Collections.Generic;
using System.Text.Json;

List<Note> notes = new List<Note>();
bool notesFileAvailable;
loadAllNotes();

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

void handleUserInput(int op)
{
    switch (op)
    {
        case 1:
            getAllNotes();
            break;
        case 2:
            System.Console.Write("Enter an ID: ");
            string input = Console.ReadLine();
            int inputAsInt = int.Parse(input);
            searchNote(inputAsInt);
            break;
        case 3:
            System.Console.Write("Title: ");
            string title = Console.ReadLine();
            System.Console.Write("Description: ");
            string description = Console.ReadLine();
            Random rnd = new Random();
            int id = rnd.Next(1, 100);
            createNote(id, title, description);
            checkJsonFile();
            break;
        case 4:
            System.Console.WriteLine("Input was 4");
            break;
        default:
            System.Console.WriteLine("Wrong operator.");
            break;
    }
}

void loadAllNotes()
{
    if (File.Exists("Notes.json"))
    {
        string json = File.ReadAllText("Notes.json");
        if (string.IsNullOrEmpty(json))
        {
            System.Console.WriteLine("File is empty.");
        }
        else
        {
            notes = JsonSerializer.Deserialize<List<Note>>(json)!;
            System.Console.WriteLine("notes loaded..");
        }
    }
    else
    {
        System.Console.WriteLine("Notes not available.");
    }
}

void createNote(int id, string title, string description)
{
    Note newNote = new Note(id, title, description);
    notes.Add(newNote);
};

void deleteNote(int note_id)
{

};

void getAllNotes()
{
     if (notes.Count == 0)
            {
                System.Console.WriteLine("-------------------");
                System.Console.WriteLine("");
                System.Console.WriteLine("No notes available.");
                System.Console.WriteLine("");
                System.Console.WriteLine("-------------------");
            }
            else
            {
                foreach (Note note in notes)
                {
                    System.Console.WriteLine("-------------------");
                    System.Console.WriteLine("");
                    System.Console.WriteLine($"ID: {note.id}");
                    System.Console.WriteLine($"Title: {note.title}");
                    System.Console.WriteLine("");
                    System.Console.WriteLine("-------------------");
                }
            }
};

void searchNote(int note_id)
{
    Note note = notes.FirstOrDefault(note => note.id == note_id);
    if (note != null)
    {
        System.Console.WriteLine($"Note title: {note.title}");
        System.Console.WriteLine($"Note description: {note.description}");
    }
    else
    {
        System.Console.WriteLine("Note was not found.");
    }
};

void checkJsonFile()
{
    if (File.Exists("Notes.json"))
    {
        saveNotesToJson();
    }
    else
    {
        File.Create("Notes.json");
        saveNotesToJson();
    }
};

void saveNotesToJson()
{
    string jsonString = JsonSerializer.Serialize(notes);
    System.Console.WriteLine($"Json-String {jsonString}");
    File.WriteAllText("Notes.json", jsonString);
}