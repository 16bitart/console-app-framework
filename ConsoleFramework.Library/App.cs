namespace ConsoleFramework.Library
{
    public static class App
    {
        public static void Say(string message)
        {
            Console.WriteLine(message);
        }

        public static string Ask(string message, string noInputResponse = "")
        {
            Say(message);
            var response = Console.ReadLine();
            return string.IsNullOrWhiteSpace(response) ? noInputResponse : response;
        }

        public static void AskQuestion(Question question)
        {
            var response = Ask(question.ToString());
            foreach (var questionOption in question.Options)
            {
                if (questionOption.Evaluate(response))
                {
                    questionOption.OnOption?.Invoke();
                }
            }
        }
    }

    public class Question
    {
        public Question(string message, params Option[] options)
        {
            if (options.Length == 0) throw new ArgumentException("Question must have at least one option.");
            Options = options;
            Message = message;
        }

        public string Message { get; private set; }
        public Option[] Options { get; private set; }

        public override string ToString()
        {
            var options = string.Join($"{Environment.NewLine}", Options.Select(x=> x.ToString()));
            return $"{Message}{options}";
        }

        public class Option
        {
            public Option(string displayText, string requiredInputValue, Action onOption)
            {
                DisplayText = displayText;
                OnOption = onOption;
                RequiredInputValue = requiredInputValue;
            }

            public string DisplayText { get; private set; }
            public string RequiredInputValue { get; private set; }
            public Action OnOption { get; private set; }

            public bool Evaluate(string input)
            {
                return string.Compare(input, RequiredInputValue, StringComparison.OrdinalIgnoreCase) == 0;
            }

            public override string ToString()
            {
                return $"{RequiredInputValue}: {DisplayText}";
            }
        }
    }

    public class Function
    {

    }
}