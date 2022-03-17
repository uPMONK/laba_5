using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using System.Text.RegularExpressions;
using Avalonia.Controls;
using RegEX.Models;

namespace RegEX.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string input = "";
        string output = "";
        string regex = "";
        RegExFinder finder = new RegExFinder();
        public MainWindowViewModel()
        {
       
        }
        public string Input
        {
            set
            {
                this.RaiseAndSetIfChanged(ref input, value);
                this.ChangeOutput();
            }
            get
            {
                return this.input;
            }
        }
        public string Output
        {
            set
            {
                this.RaiseAndSetIfChanged(ref output, value);
            }
            get
            {
                return this.output;
            }
        }
        public string Regex
        {
            set
            {
                this.RaiseAndSetIfChanged(ref regex, value);
                this.ChangeOutput();
            }
            get
            {
                return this.regex;
            }
        }   
        public void ChangeOutput()
        {
            var matches = finder.GetMatches(Regex, Input);
            String outString = "";
            foreach (string match in matches)
            {
                if (match.Length > 0)
                    outString += match + "\n";
            }

            this.Output = outString;

        }

        public void SaveOutputInFile(string path)
        {
            var fileIO = new FileConroller();
            fileIO.Write(this.Output, path);
        }

        public void ReadFileToInput(string path)
        {
            var fileIO = new FileConroller();
            this.Input = fileIO.Read(path);
        }

    
    }
 
}
