﻿using Microsoft.Extensions.DependencyInjection;
using SondaCapta.Domain.Abstractions;
using System;
using System.Linq;
using System.IO;

namespace SondaCapta.UI.Console
{
    class Program
    {
        private static InputInterpreter _interpreter;

        static void Main(string[] args)
        {
            ServiceConfiguration.ConfigureServices();

            ComposeServices();

            System.Console.Write("Input file name: ");
            string filename = System.Console.ReadLine();

            try
            {
                using (StreamReader fs = new StreamReader(filename, true))
                {
                    string configuration = fs.ReadLine();

                    try
                    {
                        _interpreter.Configure(configuration);
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine($"Could not configure system. Error: {e.Message}");
                        EndProgram();
                        return;
                    }

                    while (!fs.EndOfStream)
                    {
                        string probeCreation = fs.ReadLine();
                        string probeCommand = fs.ReadLine();

                        try
                        {
                            IProbe probe = _interpreter.CreateProbe(probeCreation);
                            _interpreter.CommandProbe(probe, probeCommand);
                            PrintProbePosition(probe);
                        }
                        catch (Exception e)
                        {
                            System.Console.WriteLine($"Could not interpret probe data. Error: {e.Message}");
                            EndProgram();
                            return;
                        }

                    }
                }
            }
            catch
            {
                System.Console.WriteLine($"Couldn't open file {filename}");
                EndProgram();
                return;
            }

            EndProgram();
        }

        private static void PrintProbePosition(IProbe probe)
        {
            char orientation;

            orientation = probe.Position.Orientation.ToString().ToUpper().First();

            System.Console.WriteLine($"{probe.Position.X} {probe.Position.Y} {orientation}");
        }

        private static void EndProgram()
        {
            while (System.Console.KeyAvailable)
                System.Console.ReadKey();

            System.Console.WriteLine();
            System.Console.WriteLine("Press enter to exit");
            System.Console.ReadLine();
        }

        private static void ComposeServices()
        {
            _interpreter = ServiceConfiguration.ServiceProvider.GetService<InputInterpreter>();
        }
    }
}
