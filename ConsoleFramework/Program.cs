// See https://aka.ms/new-console-template for more information

using ConsoleFramework.Library;

Console.WriteLine("Hello, World!");

App.Ask("Is it good?", "No?!");
App.AskQuestion(new Question("Why?",
    new Question.Option[]
    {
        new Question.Option("Dunno", "1", () => App.Say("Oh, okay")),
        new Question.Option("It's hot", "2", () => App.Say("Unfortunate")),
    }));