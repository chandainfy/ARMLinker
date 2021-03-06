﻿using System.Collections.Generic;
using Microsoft.VisualStudio.Shell.Interop;

namespace ARMCustomTool.Tests.Fakes
{
    public class FakeProgress : IVsGeneratorProgress, IReporter
    {
        public List<(int warning, uint level, string error, uint line, uint columnd)> Errors = new List<(int warning, uint level, string error, uint line, uint columnd)>();
        public List<(uint complete, uint total)> Progresses = new List<(uint complete, uint total)>();

        public int GeneratorError(int fWarning, uint dwLevel, string bstrError, uint dwLine, uint dwColumn)
        {
            Errors.Add((fWarning, dwLevel, bstrError, dwLevel, dwColumn));
            return 0;
        }

        public int Progress(uint nComplete, uint nTotal)
        {
            Progresses.Add((nComplete, nTotal));
            return 0;
        }

        public void ReportError(string message)
        {
            GeneratorError(0, 0, message, 0, 0);
        }
    }
}