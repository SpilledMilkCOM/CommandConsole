﻿// See https://aka.ms/new-console-template for more information

using CommandConsole;

var message = "Hello, World!";
var messageHeight = 1;
var column = 0;

var dimensions = new ConsoleDimensions();
var text = new ConsoleText();

dimensions.Write();

// The message starts at 0, 0

text.Write(message, 0, 0);

// Some animation

for (int row = 0; row < 10; row++) {
    Console.MoveBufferArea(column, row,  message.Length, messageHeight, column, row + 1);

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