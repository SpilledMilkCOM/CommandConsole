﻿// See https://aka.ms/new-console-template for more information

using CommandConsole;
using CommandConsole.Interfaces;
using Commands.Interfaces;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddCommandConsole();

var provider = services.BuildServiceProvider();

var mcp = provider.GetRequiredService<IMasterControlProgram>();

InitializeCommands(mcp);

var result = await mcp.ExecuteAsync();

var messageHeight = 1;
var column = 0;

var dimensions = new ConsoleDimensions();
var text = new ConsoleText();

dimensions.Write();

// The message starts at 0, 0

text.Text = "Hello, World!";
text.Write();

// Some animation

for (int row = 0; row < 10; row++) {
    Console.MoveBufferArea(column, row, text.Text.Length, messageHeight, text.Column, row + 1);

    dimensions.Write();

    Thread.Sleep(250);
}

Console.Clear();
dimensions.Write();

// Track the window size and write the dimensions in the bottom corner.
// If you scroll UP....  (you can still scroll up - which I don't really want)

var lastWidth = Console.WindowWidth;
var lastHeight = Console.WindowHeight;

while (true) {

    var width = Console.WindowWidth;
    var height = Console.WindowHeight;

    if (lastWidth != width || lastHeight != height) {
        // TODO: Check to see if the window height got smaller.

        Console.Clear();

        dimensions.Write();

        lastWidth = width;
        lastHeight = height;
    }

    Thread.Sleep(100);
}

void InitializeCommands(IMasterControlProgram mcp) {
    var loop = provider.GetRequiredService<ILoopCounterCommand>();

    loop.Row = 10;
    loop.Column = 20;

    mcp.AddCommand(loop);

    loop = provider.GetRequiredService<ILoopCounterCommand>();

    loop.Row = 10;
    loop.Column = 40;

    mcp.AddCommand(loop);

    loop = provider.GetRequiredService<ILoopCounterCommand>();

    loop.Row = 20;
    loop.Column = 30;

    mcp.AddCommand(loop);

    var spinner = provider.GetRequiredService<IAnimatedTextCommand>();

    spinner.Row = 15;
    spinner.Column = 25;
    spinner.Frames.AddRange( new List<string> { "|", "/", "-", "\\" });
    spinner.FramesPerSecond = 4;

    mcp.AddCommand(spinner);

    var delay = provider.GetRequiredService<IDelayCommand>();

    delay.DelayInMilliseconds = 100;

    mcp.AddCommand(delay);
}