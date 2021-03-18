namespace ModelClassReflector.ViewModels
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Caliburn.Micro;
    using Model;

    internal sealed class ShellViewModel : Screen, IShell
    {
        private string _reflectedJson;
        private string _sourceCode;

        public ShellViewModel()
        {
            DisplayName = Assembly.GetExecutingAssembly().GetName().Name;

            SourceCode = "some inout";
            ReflectedJson = "some output";
        }

        public string SourceCode
        {
            get => _sourceCode;
            set
            {
                if (value != _sourceCode)
                {
                    _sourceCode = value;
                    NotifyOfPropertyChange();
                }
            }
        }

        public string ReflectedJson
        {
            get => _reflectedJson;
            set
            {
                if (value != _reflectedJson)
                {
                    _reflectedJson = value;
                    NotifyOfPropertyChange(() => ReflectedJson);
                }
            }
        }

        public void CreateJson()
        {
            using (var compiler = new CodeDomCompiler())
            {
                var instruction = new CompilerInstructions();
                instruction.AssemblyLocations.Add(typeof(IScript).Assembly.Location);
                //needed for Roslyn:
                instruction.AssemblyLocations.Add(typeof(object).Assembly.Location);

                //code does not to reside in a namespace
////                instruction.ClassName = $"Class_{Guid.NewGuid():N}";
////                instruction.Code = @"using System;
////public class " + instruction.ClassName + ": " + typeof(IScript).FullName + @"
////{
////    public void Run() 
////    {
////        Console.WriteLine(""Hello world!"");
////    }
////}";

                var words = SourceCode.Split(new string[] {" ", Environment.NewLine},
                    StringSplitOptions.RemoveEmptyEntries);

                var classIndex = Array.IndexOf(words, "class");
                if (classIndex < 0)
                {
                    throw new Exception("No 'class' definition in code snippet");
                }

                var className = words[classIndex + 1];

                instruction.ClassName = className;
                instruction.Code = SourceCode;

                ReflectedJson += $"Result from: {compiler.GetType().Name}";

                try
                {
                    var output = compiler.CompileAndCreateObject(instruction);
                }
                catch (Exception ex)
                {
                    var t = ex;
                }
            }
        }
    }
}
